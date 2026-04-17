using System.Linq.Dynamic.Core;
using ExactOnline.Client.Models.Sync;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;

namespace ExactOnline.Client.Sdk.Sync;

// ---------------------------------------------------------------------------
// Support types
// ---------------------------------------------------------------------------

/// <summary>Progress snapshot reported during a <see cref="SyncOperation{TModel}"/> run.</summary>
/// <remarks>Initializes a new snapshot with the cumulative counters at a given page.</remarks>
public readonly struct SyncProgress(int recordsRead, int recordsInsertedOrUpdated, int recordsDeletedRead, int recordsDeleted, int pageIndex)
{
	/// <summary>Total rows read from the upsert feed so far.</summary>
	public int RecordsRead { get; } = recordsRead;

	/// <summary>Total rows the upsert callback reported as persisted so far.</summary>
	public int RecordsInsertedOrUpdated { get; } = recordsInsertedOrUpdated;

	/// <summary>Total keys read from the deletion feed so far.</summary>
	public int RecordsDeletedRead { get; } = recordsDeletedRead;

	/// <summary>Total rows the deletion callback reported as removed so far.</summary>
	public int RecordsDeleted { get; } = recordsDeleted;
	/// <summary>0-based counter of the page that produced this snapshot.</summary>
	public int PageIndex { get; } = pageIndex;

	/// <inheritdoc />
	public override string ToString() =>
		$"page={PageIndex} read={RecordsRead} upserted={RecordsInsertedOrUpdated} deletedRead={RecordsDeletedRead} deleted={RecordsDeleted}";
}

/// <summary>Context passed to the per-page upsert handler.</summary>
public sealed class SyncPageContext<TModel>
{
	/// <summary>Deduplicated entities ready to persist (after <c>FilterDoubles</c> for sync-feed endpoints).</summary>
	public required IReadOnlyList<TModel> Entities { get; init; }
	/// <summary>Original page as returned by the API — useful if you need the raw sync-feed history.</summary>
	public required IReadOnlyList<TModel> RawEntities { get; init; }
	/// <summary>0-based page counter within the run.</summary>
	public required int PageIndex { get; init; }
	/// <summary>Skiptoken for the next page (null on the last page).</summary>
	public string? SkipToken { get; init; }
	/// <summary>Watermark the run started from (<c>Timestamp</c>).</summary>
	public required long MaxTimestamp { get; init; }
	/// <summary>Watermark the run started from (<c>Modified</c>).</summary>
	public DateTime? MaxModified { get; init; }
	/// <summary>Final list of selected fields (identifier/timestamp/modified added automatically).</summary>
	public required string[] Fields { get; init; }
	/// <summary>Chosen endpoint: <c>Sync</c>, <c>Bulk</c> or <c>Single</c>.</summary>
	public required EndpointTypeEnum EndpointType { get; init; }
	/// <summary>Cancellation token for the run.</summary>
	public required CancellationToken CancellationToken { get; init; }
}

/// <summary>Context passed to the per-page delete handler.</summary>
public sealed class DeletedPageContext
{
	/// <summary>Initializes a delete-page context.</summary>
	public DeletedPageContext(Guid[] entityKeys, int pageIndex, string? skipToken, long maxTimestamp, CancellationToken cancellationToken)
	{
		EntityKeys = entityKeys;
		PageIndex = pageIndex;
		SkipToken = skipToken;
		MaxTimestamp = maxTimestamp;
		CancellationToken = cancellationToken;
	}

	/// <summary>Entity keys reported as deleted on this page.</summary>
	public Guid[] EntityKeys { get; }
	/// <summary>0-based page counter within the delete loop.</summary>
	public int PageIndex { get; }
	/// <summary>Skiptoken for the next delete page (<see langword="null"/> on the last page).</summary>
	public string? SkipToken { get; }
	/// <summary>Watermark the run started from (<c>Timestamp</c>).</summary>
	public long MaxTimestamp { get; }
	/// <summary>Cancellation token for the run.</summary>
	public CancellationToken CancellationToken { get; }
}

// ---------------------------------------------------------------------------
// Fluent entry point
// ---------------------------------------------------------------------------

/// <summary>Non-generic entry point so callers don't have to repeat the model type parameter.</summary>
public static class SyncOperation
{
	/// <summary>Creates a <see cref="SyncOperation{TModel}"/> for the given Exact Online client.</summary>
	public static SyncOperation<TModel> For<TModel>(ExactOnlineClient client)
		where TModel : class => new(client);
}

// ---------------------------------------------------------------------------
// The operation
// ---------------------------------------------------------------------------

/// <summary>
/// Orchestrates a sync of a single <typeparamref name="TModel"/> from Exact Online. Configure the stages you
/// need (watermark, upsert, deletion, progress) via the fluent <c>With*</c>/<c>On*</c>/<c>ReportProgress</c>
/// methods and finish with <see cref="RunAsync"/>.
/// </summary>
public sealed class SyncOperation<TModel> where TModel : class
{
	private readonly ExactOnlineClient _client;
	private readonly ExactOnlineQuery<TModel> _query;

	private bool _hasRun;
	private string[] _fields = [];
	private Func<CancellationToken, Task<long>>? _getMaxTimestamp;
	private Func<CancellationToken, Task<DateTime?>>? _getMaxModified;
	private Func<SyncPageContext<TModel>, Task<int>>? _onPage;
	private Func<DeletedPageContext, Task<int>>? _onDeletedPage;
	private Action<SyncProgress>? _progress;

	/// <summary>
	/// Creates a new sync operation bound to <paramref name="client"/>. The returned instance
	/// is single-use — <see cref="RunAsync"/> throws if called more than once.
	/// </summary>
	public SyncOperation(ExactOnlineClient client)
	{
		_client = client ?? throw new ArgumentNullException(nameof(client));
		_query = client.For<TModel>();
	}

	/// <summary>Fields to include in <c>$select</c>. Identifier and timestamp/modified fields are added automatically.</summary>
	public SyncOperation<TModel> WithFields(params string[] fields)
	{
		_fields = fields ?? [];
		if (_fields.Length > 0)
		{
			_query.Select(_fields);
		}
		return this;
	}

	/// <summary>Supply the highest already-known <c>Timestamp</c>. Invoked once at the start of the run (sync endpoint only).</summary>
	public SyncOperation<TModel> WithMaxTimestamp(Func<CancellationToken, Task<long>> getMaxTimestampAsync)
	{
		_getMaxTimestamp = getMaxTimestampAsync ?? throw new ArgumentNullException(nameof(getMaxTimestampAsync));
		return this;
	}

	/// <summary>Supply the highest already-known <c>Modified</c>. Invoked once at the start of the run for non-sync endpoints on models with a <c>Modified</c> property.</summary>
	public SyncOperation<TModel> WithMaxModified(Func<CancellationToken, Task<DateTime?>> getMaxModifiedAsync)
	{
		_getMaxModified = getMaxModifiedAsync ?? throw new ArgumentNullException(nameof(getMaxModifiedAsync));
		return this;
	}

	/// <summary>Handle a single page of entities. Return the number of records actually inserted or updated.</summary>
	public SyncOperation<TModel> OnPage(Func<SyncPageContext<TModel>, Task<int>> onPageAsync)
	{
		_onPage = onPageAsync ?? throw new ArgumentNullException(nameof(onPageAsync));
		return this;
	}

	/// <summary>Handle a single page of deleted entity keys. Return the number of records actually deleted.</summary>
	public SyncOperation<TModel> OnDeletedPage(Func<DeletedPageContext, Task<int>> onDeletedPageAsync)
	{
		_onDeletedPage = onDeletedPageAsync ?? throw new ArgumentNullException(nameof(onDeletedPageAsync));
		return this;
	}

	/// <summary>Observe cumulative progress after each page (upsert and delete).</summary>
	public SyncOperation<TModel> ReportProgress(Action<SyncProgress> reportProgress)
	{
		_progress = reportProgress ?? throw new ArgumentNullException(nameof(reportProgress));
		return this;
	}

	/// <summary>
	/// Executes the configured sync: pulls upsert pages, optionally a deletion page, and reports
	/// progress. Throws <see cref="InvalidOperationException"/> if called more than once on the
	/// same instance — <see cref="PrepareForSync"/> mutates the underlying query, and a second
	/// run would stack projections and watermark filters from the first.
	/// </summary>
	public async Task<SyncResult> RunAsync(CancellationToken ct = default)
	{
		if (_hasRun)
		{
			throw new InvalidOperationException(
				$"{nameof(SyncOperation<TModel>)} is single-use; create a new instance for each run.");
		}
		_hasRun = true;

		var modelInfo = ModelInfo.For<TModel>();
		var endpointType = GetEndpointType(modelInfo);
		var result = new SyncResult(typeof(TModel), endpointType);
		var maxTimestamp = 0L;
		var maxModified = default(DateTime?);

		if (endpointType == EndpointTypeEnum.Sync && _getMaxTimestamp is { })
		{
			maxTimestamp = await _getMaxTimestamp(ct).ConfigureAwait(false);
		}
		else if (modelInfo.HasModifiedProperty && _getMaxModified is { })
		{
			maxModified = await _getMaxModified(ct).ConfigureAwait(false);
		}

		var fieldsList = _fields.ToList();
		PrepareForSync(_query, modelInfo, fieldsList, endpointType, maxTimestamp, maxModified);
		var fieldsArray = fieldsList.ToArray();

		await RunUpsertLoopAsync(modelInfo, endpointType, fieldsArray, maxTimestamp, maxModified, result, ct)
			.ConfigureAwait(false);

		if (endpointType == EndpointTypeEnum.Sync && modelInfo.HasDeletedEntityType)
		{
			await RunDeleteLoopAsync(modelInfo, maxTimestamp, result, ct).ConfigureAwait(false);
		}

		return result;
	}

	// -----------------------------------------------------------------------
	// Loop internals
	// -----------------------------------------------------------------------

	private async Task RunUpsertLoopAsync(
		ModelInfo modelInfo,
		EndpointTypeEnum endpointType,
		string[] fields,
		long maxTimestamp,
		DateTime? maxModified,
		SyncResult result,
		CancellationToken ct)
	{
		string? skiptoken = null;
		var pageIndex = 0;
		do
		{
			ct.ThrowIfCancellationRequested();

			var apiList = await _query.GetAsync(skiptoken, endpointType, ct).ConfigureAwait(false);
			skiptoken = apiList.SkipToken;
			var rawEntities = apiList.List;

			result.RecordsRead += rawEntities.Count;
			_progress?.Invoke(Snapshot(result, pageIndex));

			var entities = rawEntities;
			if (endpointType == EndpointTypeEnum.Sync)
			{
				entities = await FilterDoubles(
						rawEntities,
						modelInfo.IdentifierName ?? throw new InvalidOperationException("Identifier name is not set."))
					.ToDynamicListAsync<TModel>(ct)
					.ConfigureAwait(false);
			}

			if (entities.Count > 0 && _onPage is { })
			{
				var context = new SyncPageContext<TModel>
				{
					Entities = entities,
					RawEntities = rawEntities,
					PageIndex = pageIndex,
					SkipToken = skiptoken,
					MaxTimestamp = maxTimestamp,
					MaxModified = maxModified,
					Fields = fields,
					EndpointType = endpointType,
					CancellationToken = ct,
				};

				result.RecordsInsertedOrUpdated += await _onPage(context).ConfigureAwait(false);
			}

			_progress?.Invoke(Snapshot(result, pageIndex));
			pageIndex++;

		} while (!string.IsNullOrEmpty(skiptoken));
	}

	private async Task RunDeleteLoopAsync(ModelInfo modelInfo, long maxTimestamp, SyncResult result, CancellationToken ct)
	{
		var deletedQuery = DeletedFor(_client, modelInfo.DeletedEntityType, maxTimestamp);
		string? skiptoken = null;
		var pageIndex = 0;
		do
		{
			ct.ThrowIfCancellationRequested();

			var apiList = await deletedQuery.GetAsync(skiptoken, EndpointTypeEnum.Single, ct).ConfigureAwait(false);
			skiptoken = apiList.SkipToken;
			var keys = ToEntityKeyArray(apiList.List);

			result.RecordsDeletedRead += keys.Length;

			if (keys.Length > 0 && _onDeletedPage is { })
			{
				var context = new DeletedPageContext(
					entityKeys: keys,
					pageIndex: pageIndex,
					skipToken: skiptoken,
					maxTimestamp: maxTimestamp,
					cancellationToken: ct);

				result.RecordsDeleted += await _onDeletedPage(context).ConfigureAwait(false);
			}

			_progress?.Invoke(Snapshot(result, pageIndex));
			pageIndex++;

		} while (!string.IsNullOrEmpty(skiptoken));
	}

	private static SyncProgress Snapshot(SyncResult r, int pageIndex) =>
		new(r.RecordsRead, r.RecordsInsertedOrUpdated, r.RecordsDeletedRead, r.RecordsDeleted, pageIndex);

	// -----------------------------------------------------------------------
	// Inlined helpers — previously internal on ExactOnlineQueryExtensions.
	// These are all the pieces that let this file stand on its own.
	// -----------------------------------------------------------------------

	private static EndpointTypeEnum GetEndpointType(ModelInfo modelInfo)
	{
		if (modelInfo.SupportsSync) return EndpointTypeEnum.Sync;
		if (modelInfo.SupportsBulk) return EndpointTypeEnum.Bulk;
		return EndpointTypeEnum.Single;
	}

	// Make sure the query selects identifier + timestamp/modified, and apply the watermark filter.
	// Also mirrors the field additions back into the caller's fields list so the upsert handler sees them.
	private static void PrepareForSync(
		ExactOnlineQuery<TModel> query,
		ModelInfo modelInfo,
		List<string> fields,
		EndpointTypeEnum endpointType,
		long maxTimestamp,
		DateTime? maxModified)
	{
		var identifierParts = SplitAndTrim(modelInfo.IdentifierName);
		foreach (var item in identifierParts.Where(i => !fields.Contains(i)))
		{
			query.Select(item);
			fields.Add(item);
		}

		if (endpointType == EndpointTypeEnum.Sync)
		{
			if (!fields.Contains(ModelInfo.TimestampName))
			{
				query.Select(ModelInfo.TimestampName);
				fields.Add(ModelInfo.TimestampName);
			}
			query.Where(modelInfo.TimestampLambda<TModel>(), maxTimestamp, OperatorEnum.Gt);
		}
		else if (modelInfo.HasModifiedProperty)
		{
			if (!fields.Contains(ModelInfo.ModifiedName))
			{
				query.Select(ModelInfo.ModifiedName);
				fields.Add(ModelInfo.ModifiedName);
			}
			if (maxModified.HasValue)
			{
				query.Where(modelInfo.ModifiedLambda<TModel>(), maxModified, OperatorEnum.Gt);
			}
		}
	}

	// Sync-feed pages can contain duplicate rows for the same key. Keep only the last change per identifier.
	// System.Linq.Dynamic.Core requires "new (Col1, Col2)" to group on multiple columns — passing the raw
	// comma-joined string would be interpreted as a single property name and blow up at runtime.
	private static IQueryable FilterDoubles(IList<TModel> entities, string identifierName)
	{
		var parts = SplitAndTrim(identifierName);
		var groupBy = parts.Length <= 1
			? identifierName
			: $"new ({string.Join(", ", parts)})";
		return entities.AsQueryable()
			.GroupBy(groupBy)
			.Select($"it.OrderByDescending({ModelInfo.TimestampName}).First()");
	}

	private static string[] SplitAndTrim(string? value) =>
		value?.Split(',')
			.Select(p => p.Trim())
			.Where(p => p.Length > 0)
			.ToArray() ?? [];

	private static ExactOnlineQuery<Deleted> DeletedFor(ExactOnlineClient client, EntityType deletedEntityType, long maxTimestamp) =>
		client.For<Deleted>()
			.Where(d => d.Timestamp, maxTimestamp, OperatorEnum.Gt)
			.And(d => d.EntityType, deletedEntityType, OperatorEnum.Eq)
			.Select("EntityKey");

	private static Guid[] ToEntityKeyArray(IList<Deleted> deleted) =>
		[.. deleted.Select(d => d.EntityKey)];
}

using System.Linq.Dynamic.Core;
using ExactOnline.Client.Models.Sync;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;

namespace ExactOnline.Client.Sdk.Sync;

/// <summary>
/// Orchestrates a sync of a single <typeparamref name="TModel"/> from Exact Online. Chained off
/// a query via <see cref="ExactOnlineQueryExtensions.Synchronize{TModel}"/>; configure the
/// watermark, upsert, deletion, and progress callbacks fluently and finish with <see cref="RunAsync"/>.
/// </summary>
public sealed class SyncOperation<TModel> where TModel : class
{
	private readonly ExactOnlineQuery<TModel> _query;
	private readonly ExactOnlineClient _client;

	private bool _hasRun;
	private Func<CancellationToken, Task<long>>? _getMaxTimestamp;
	private Func<CancellationToken, Task<DateTime?>>? _getMaxModified;
	private Func<SyncPageContext<TModel>, Task<int>>? _createOrUpdate;
	private Func<DeletedPageContext, Task<int>>? _delete;
	private Action<SyncProgress>? _progress;

	/// <summary>
	/// Creates a sync operation for <paramref name="query"/>. The query must have an associated
	/// <see cref="ExactOnlineClient"/> (i.e. have been created via <c>client.For&lt;T&gt;()</c>).
	/// The operation is single-use.
	/// </summary>
	public SyncOperation(ExactOnlineQuery<TModel> query)
	{
		_query = query ?? throw new ArgumentNullException(nameof(query));
		_client = query.Client ?? throw ExactOnlineQueryExtensions.ClientRequired(nameof(SyncOperation<TModel>));
	}

	/// <summary>Supply the highest already-known <c>Timestamp</c>. Invoked once at the start of the run (sync endpoint only).</summary>
	public SyncOperation<TModel> OnGetMaxTimestamp(Func<CancellationToken, Task<long>> getMaxTimestampAsync)
	{
		_getMaxTimestamp = getMaxTimestampAsync ?? throw new ArgumentNullException(nameof(getMaxTimestampAsync));
		return this;
	}

	/// <summary>Supply the highest already-known <c>Modified</c>. Invoked once at the start of the run for non-sync endpoints on models with a <c>Modified</c> property.</summary>
	public SyncOperation<TModel> OnGetMaxModified(Func<CancellationToken, Task<DateTime?>> getMaxModifiedAsync)
	{
		_getMaxModified = getMaxModifiedAsync ?? throw new ArgumentNullException(nameof(getMaxModifiedAsync));
		return this;
	}

	/// <summary>Handle a single page of entities. Return the number of records actually inserted or updated.</summary>
	public SyncOperation<TModel> OnChangedEntities(Func<SyncPageContext<TModel>, Task<int>> onChangedAsync)
	{
		_createOrUpdate = onChangedAsync ?? throw new ArgumentNullException(nameof(onChangedAsync));
		return this;
	}

	/// <summary>Handle a single page of deleted entity keys. Return the number of records actually deleted.</summary>
	public SyncOperation<TModel> OnDeletedEntities(Func<DeletedPageContext, Task<int>> onDeletedAsync)
	{
		_delete = onDeletedAsync ?? throw new ArgumentNullException(nameof(onDeletedAsync));
		return this;
	}

	/// <summary>Observe cumulative progress after each page (upsert and delete).</summary>
	public SyncOperation<TModel> OnProgress(Action<SyncProgress> onProgress)
	{
		_progress = onProgress ?? throw new ArgumentNullException(nameof(onProgress));
		return this;
	}

	/// <summary>
	/// Executes the configured sync: pulls upsert pages, optionally a deletion page, and reports
	/// progress. Throws <see cref="InvalidOperationException"/> if called more than once on the
	/// same instance — <c>PrepareForSync</c> mutates the underlying query, and a second
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
		var endpointType = ExactOnlineQueryExtensions.GetEndpointType(modelInfo);
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

		var fieldsList = ExtractSelectedFields(_query);
		_query.PrepareForSync(modelInfo, fieldsList, endpointType, maxTimestamp, maxModified);
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

			if (entities.Count > 0 && _createOrUpdate is { })
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

				result.RecordsInsertedOrUpdated += await _createOrUpdate(context).ConfigureAwait(false);
			}

			_progress?.Invoke(Snapshot(result, pageIndex));
			pageIndex++;

		} while (!string.IsNullOrEmpty(skiptoken));
	}

	private async Task RunDeleteLoopAsync(ModelInfo modelInfo, long maxTimestamp, SyncResult result, CancellationToken ct)
	{
		var deletedQuery = _client.DeletedFor(modelInfo.DeletedEntityType, maxTimestamp);
		string? skiptoken = null;
		var pageIndex = 0;
		do
		{
			ct.ThrowIfCancellationRequested();

			var apiList = await deletedQuery.GetAsync(skiptoken, EndpointTypeEnum.Single, ct).ConfigureAwait(false);
			skiptoken = apiList.SkipToken;
			var keys = apiList.List.ToEntityKeyArray();

			result.RecordsDeletedRead += keys.Length;

			if (keys.Length > 0 && _delete is { })
			{
				var context = new DeletedPageContext(
					entityKeys: keys,
					pageIndex: pageIndex,
					skipToken: skiptoken,
					maxTimestamp: maxTimestamp,
					cancellationToken: ct);

				result.RecordsDeleted += await _delete(context).ConfigureAwait(false);
			}

			_progress?.Invoke(Snapshot(result, pageIndex));
			pageIndex++;

		} while (!string.IsNullOrEmpty(skiptoken));
	}

	private static SyncProgress Snapshot(SyncResult r, int pageIndex) =>
		new(r.RecordsRead, r.RecordsInsertedOrUpdated, r.RecordsDeletedRead, r.RecordsDeleted, pageIndex);

	// Read back the fields the caller already projected via Select(...) on the query — PrepareForSync
	// will append identifier/timestamp/modified fields to this list so the OnChangedEntities
	// callback receives the full projected set.
	private static List<string> ExtractSelectedFields(ExactOnlineQuery<TModel> query)
	{
		const string selectPrefix = "$select=";
		if (query._select is null || !query._select.StartsWith(selectPrefix, StringComparison.Ordinal))
		{
			return [];
		}
		return [.. query._select.Substring(selectPrefix.Length)
			.Split(',')
			.Select(s => s.Trim())
			.Where(s => s.Length > 0)];
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
}

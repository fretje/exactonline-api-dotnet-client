using System.Linq.Dynamic.Core;
using ExactOnline.Client.Models.Sync;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;
using Microsoft.Extensions.Logging;

namespace ExactOnline.Client.Sdk.Sync;

public static partial class ExactOnlineQueryExtensions
{
	public static SyncResult SynchronizeWith<TModel>(this ExactOnlineQuery<TModel> query, ISyncTarget syncTarget, ExactOnlineClient client, string[]? fields = null)
		where TModel : class
	{
		var modelInfo = ModelInfo.For<TModel>();
		var endpointType = GetEndpointType(modelInfo);
		var targetController = syncTarget.ControllerFor<TModel>();
		SyncResult result = new(typeof(TModel), endpointType);
		var maxTimestamp = 0L;
		DateTime? maxModified = null;

		if (endpointType == EndpointTypeEnum.Sync)
		{
			maxTimestamp = targetController.GetMaxTimestamp();
		}
		else if (modelInfo.HasModifiedProperty)
		{
			maxModified = targetController.GetMaxModified();
		}

		var fieldsList = fields?.ToList() ?? [];
		query.PrepareForSync(modelInfo, fieldsList, endpointType, maxTimestamp, maxModified);

		var skiptoken = default(string);
		do
		{
			var entities = query.Get(ref skiptoken, endpointType);

			result.RecordsRead += entities.Count;

			if (endpointType == EndpointTypeEnum.Sync)
			{
				entities = entities
					.FilterDoubles(modelInfo.IdentifierName ?? throw new InvalidOperationException("Identifier name is not set."))
					.ToDynamicList<TModel>();
			}

			if (entities.Count > 0)
			{
				result.RecordsInsertedOrUpdated += targetController
					.CreateOrUpdateEntities(entities, [.. fieldsList]);
			}

		} while (!string.IsNullOrEmpty(skiptoken));

		if (endpointType == EndpointTypeEnum.Sync && modelInfo.HasDeletedEntityType)
		{
			var deleted = client
				.DeletedFor(modelInfo.DeletedEntityType, maxTimestamp)
				.Get()
				.ToEntityKeyArray();

			result.RecordsDeletedRead += deleted.Length;

			if (deleted.Length > 0)
			{
				result.RecordsDeleted = targetController
					.DeleteEntities(deleted);
			}
		}

		LogSyncResult(client.Log, result);

		return result;
	}

	public static async Task<SyncResult> SynchronizeWithAsync<TModel>(this ExactOnlineQuery<TModel> query, ISyncTarget syncTarget, ExactOnlineClient client, string[]? fields = null, Action<int, int>? reportProgress = null, CancellationToken ct = default)
		where TModel : class
	{
		var targetController = syncTarget.ControllerFor<TModel>();

		// Preserve legacy semantics: ISyncTargetController.DeleteEntitiesAsync is called once, with all deleted
		// keys accumulated across pages — implementers may wrap it in a single transaction.
		var accumulatedDeletedKeys = new List<Guid>();

		var operation = SyncOperation.For<TModel>(client)
			.WithFields(fields ?? [])
			.WithMaxTimestamp(targetController.GetMaxTimestampAsync)
			.WithMaxModified(targetController.GetMaxModifiedAsync)
			.OnPage(page => targetController.CreateOrUpdateEntitiesAsync(
				[.. page.Entities], page.Fields, page.CancellationToken))
			.OnDeletedPage(deletedPage =>
			{
				accumulatedDeletedKeys.AddRange(deletedPage.EntityKeys);
				return Task.FromResult(0);
			});

		if (reportProgress is { })
		{
			operation.ReportProgress(p => reportProgress(p.RecordsRead, p.RecordsInsertedOrUpdated));
		}

		var result = await operation.RunAsync(ct).ConfigureAwait(false);

		if (accumulatedDeletedKeys.Count > 0)
		{
			result.RecordsDeleted = await targetController
				.DeleteEntitiesAsync([.. accumulatedDeletedKeys], ct).ConfigureAwait(false);
		}

		if (client.Log is { } log)
		{
			LogSyncResult(log, result);
		}

		return result;
	}

	// Sync results can contain duplicate entries for the same unique key.
	// Here we take only the last change into account and filter out all the previous ones.
	internal static IQueryable FilterDoubles<TModel>(this IList<TModel> entities, string identifierName) =>
		entities.AsQueryable()
			.GroupBy(identifierName)
			.Select($"it.OrderByDescending({ModelInfo.TimestampName}).First()");

	internal static EndpointTypeEnum GetEndpointType(ModelInfo modelInfo) =>
		modelInfo.SupportsSync ? EndpointTypeEnum.Sync
							   : modelInfo.SupportsBulk ? EndpointTypeEnum.Bulk
							   : EndpointTypeEnum.Single;

	// Make sure we select all the necessary fields (add id and timestamp/modified fields)
	// This also updates the fields list that is then sent later to the CreateOrUpdateEntities method
	// And filter the query according to maxTimestamp or maxModified
	internal static void PrepareForSync<TModel>(this ExactOnlineQuery<TModel> query, ModelInfo modelInfo, List<string> fields, EndpointTypeEnum endpointType, long maxTimestamp, DateTime? maxModified)
		where TModel : class
	{
		foreach (var item in modelInfo.IdentifierName?.Split(',') ?? [])
		{
			if (!fields.Contains(item))
			{
				query.Select(item);
				fields.Add(item);
			}
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

	internal static ExactOnlineQuery<Deleted> DeletedFor(this ExactOnlineClient client, EntityType deletedEntityType, long maxTimestamp) =>
		client.For<Deleted>()
			.Where(d => d.Timestamp, maxTimestamp, OperatorEnum.Gt)
			.And(d => d.EntityType, deletedEntityType, OperatorEnum.Eq)
			.Select("EntityKey");

	internal static Guid[] ToEntityKeyArray(this IList<Deleted> deleted) =>
		[.. deleted.Select(d => d.EntityKey)];

	[LoggerMessage(EventId = 100, Level = LogLevel.Information, Message = "ExactOnline Sdk: {SyncResult}")]
	internal static partial void LogSyncResult(ILogger logger, SyncResult syncResult);
}

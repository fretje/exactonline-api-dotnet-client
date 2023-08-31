using System.Linq.Dynamic.Core;
using ExactOnline.Client.Models.Sync;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;
using Microsoft.Extensions.Logging;

namespace ExactOnline.Client.Sdk.Sync;

public static class ExactOnlineQueryExtensions
{
	public static SyncResult SynchronizeWith<TModel>(this ExactOnlineQuery<TModel> query, ISyncTarget syncTarget, ExactOnlineClient client, string[] fields = null)
		where TModel : class
	{
		var modelInfo = ModelInfo.For<TModel>();
		var endpointType = GetEndpointType(modelInfo);
		var targetController = syncTarget.ControllerFor<TModel>();
		var result = new SyncResult(typeof(TModel), endpointType);
		var maxTimestamp = 0L;
		var maxModified = default(DateTime?);

		if (endpointType == EndpointTypeEnum.Sync)
		{
			maxTimestamp = targetController.GetMaxTimestamp();
		}
		else if (modelInfo.HasModifiedProperty)
		{
			maxModified = targetController.GetMaxModified();
		}

		var fieldsList = fields.ToList();
		query.PrepareForSync(modelInfo, fieldsList, endpointType, maxTimestamp, maxModified);

		var skiptoken = default(string);
		do
		{
			var entities = query.Get(ref skiptoken, endpointType);

			result.RecordsRead += entities.Count;

			if (endpointType == EndpointTypeEnum.Sync)
			{
				entities = entities
					.FilterDoubles(modelInfo.IdentifierName)
					.ToDynamicList<TModel>();
			}

			if (entities.Count > 0)
			{
				result.RecordsInsertedOrUpdated += targetController
					.CreateOrUpdateEntities(entities, fieldsList.ToArray());
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

		if (client.Log is not null)
		{
			client.Log.LogInformation("ExactOnline Sdk: {SyncResult}", result);
		}

		return result;
	}

	public static async Task<SyncResult> SynchronizeWithAsync<TModel>(this ExactOnlineQuery<TModel> query, ISyncTarget syncTarget, ExactOnlineClient client, string[] fields, Action<int, int> reportProgress = null, CancellationToken ct = default)
		where TModel : class
	{
		var modelInfo = ModelInfo.For<TModel>();
		var endpointType = GetEndpointType(modelInfo);
		var targetController = syncTarget.ControllerFor<TModel>();
		var result = new SyncResult(typeof(TModel), endpointType);
		var maxTimestamp = 0L;
		var maxModified = default(DateTime?);

		if (endpointType == EndpointTypeEnum.Sync)
		{
			maxTimestamp = await targetController.GetMaxTimestampAsync(ct).ConfigureAwait(false);
		}
		else if (modelInfo.HasModifiedProperty)
		{
			maxModified = await targetController.GetMaxModifiedAsync(ct).ConfigureAwait(false);
		}

		var fieldsList = fields.ToList();
		PrepareForSync(query, modelInfo, fieldsList, endpointType, maxTimestamp, maxModified);

		var skiptoken = default(string);
		do
		{
			ct.ThrowIfCancellationRequested();

			var apiList = await query.GetAsync(skiptoken, endpointType, ct).ConfigureAwait(false);
			skiptoken = apiList.SkipToken;
			var entities = apiList.List;

			result.RecordsRead += entities.Count;

			reportProgress?.Invoke(result.RecordsRead, result.RecordsInsertedOrUpdated);

			if (endpointType == EndpointTypeEnum.Sync)
			{
				entities = await entities
					.FilterDoubles(modelInfo.IdentifierName)
					.ToDynamicListAsync<TModel>(ct).ConfigureAwait(false);
			}

			if (entities.Count > 0)
			{
				result.RecordsInsertedOrUpdated += await targetController
					.CreateOrUpdateEntitiesAsync(entities, fieldsList.ToArray(), ct).ConfigureAwait(false);
			}

			reportProgress?.Invoke(result.RecordsRead, result.RecordsInsertedOrUpdated);

		} while (!string.IsNullOrEmpty(skiptoken));

		if (endpointType == EndpointTypeEnum.Sync && modelInfo.HasDeletedEntityType)
		{
			ct.ThrowIfCancellationRequested();

			var deleted = (await client
				.DeletedFor(modelInfo.DeletedEntityType, maxTimestamp)
				.GetAsync(ct: ct).ConfigureAwait(false))
				.List
				.ToEntityKeyArray();

			result.RecordsDeletedRead += deleted.Length;

			if (deleted.Length > 0)
			{
				result.RecordsDeleted = await targetController
					.DeleteEntitiesAsync(deleted, ct).ConfigureAwait(false);
			}
		}

		if (client.Log is not null)
		{
			client.Log.LogInformation("ExactOnline Sdk: {SyncResult}", result);
		}

		return result;
	}

	// Sync results can contain duplicate entries for the same unique key.
	// Here we take only the last change into account and filter out all the previous ones.
	private static IQueryable FilterDoubles<TModel>(this IList<TModel> entities, string identifierName) =>
		entities.AsQueryable()
			.GroupBy(identifierName)
			.Select($"it.OrderByDescending({ModelInfo.TimestampName}).First()");

	private static EndpointTypeEnum GetEndpointType(ModelInfo modelInfo) =>
		modelInfo.SupportsSync ? EndpointTypeEnum.Sync
							   : modelInfo.SupportsBulk ? EndpointTypeEnum.Bulk
							   : EndpointTypeEnum.Single;

	// Make sure we select all the necessary fields (add id and timestamp/modified fields)
	// This also updates the fields list that is then sent later to the CreateOrUpdateEntities method
	// And filter the query according to maxTimestamp or maxModified
	private static void PrepareForSync<TModel>(this ExactOnlineQuery<TModel> query, ModelInfo modelInfo, List<string> fields, EndpointTypeEnum endpointType, long maxTimestamp, DateTime? maxModified)
		where TModel : class
	{
		foreach (var item in modelInfo.IdentifierName.Split(','))
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

	private static ExactOnlineQuery<Deleted> DeletedFor(this ExactOnlineClient client, EntityType deletedEntityType, long maxTimestamp) =>
		client.For<Deleted>()
			.Where(d => d.Timestamp, maxTimestamp, OperatorEnum.Gt)
			.And(d => d.EntityType, deletedEntityType, OperatorEnum.Eq)
			.Select("EntityKey");

	private static Guid[] ToEntityKeyArray(this IList<Deleted> deleted) =>
		deleted.Select(d => d.EntityKey).ToArray();
}

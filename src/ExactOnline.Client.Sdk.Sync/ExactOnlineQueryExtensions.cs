using ExactOnline.Client.Models.Sync;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Sync
{
	public static class ExactOnlineQueryExtensions
	{
		public static SyncResult SynchronizeWith<TModel>(this ExactOnlineQuery<TModel> query, ISyncTarget syncTarget, ExactOnlineClient client)
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

			query.PrepareForSync(modelInfo, endpointType, maxTimestamp, maxModified);

			var skiptoken = default(string);
			do
			{
				var entities = query.Get(ref skiptoken, endpointType);

				result.RecordsRead += entities.Count;

				result.RecordsInsertedOrUpdated +=
					targetController.CreateOrUpdateEntities(entities);

			} while (!string.IsNullOrEmpty(skiptoken));

			if (endpointType == EndpointTypeEnum.Sync && modelInfo.HasDeletedEntityType)
			{
				var deleted = client.DeletedFor(modelInfo.DeletedEntityType, maxTimestamp)
					.Get()
					.ToEntityKeyArray();

				result.RecordsDeletedRead += deleted.Length;

				result.RecordsDeleted = targetController.DeleteEntities(deleted);
			}

			Debug.WriteLine(result);

			return result;
		}

		public static async Task<SyncResult> SynchronizeWithAsync<TModel>(this ExactOnlineQuery<TModel> query, ISyncTarget syncTarget, ExactOnlineClient client)
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
				maxTimestamp = await targetController.GetMaxTimestampAsync().ConfigureAwait(false);
			}
			else if (modelInfo.HasModifiedProperty)
			{
				maxModified = await targetController.GetMaxModifiedAsync().ConfigureAwait(false);
			}

			PrepareForSync(query, modelInfo, endpointType, maxTimestamp, maxModified);

			var skiptoken = default(string);
			do
			{
				var apiList = await query.GetAsync(skiptoken, endpointType).ConfigureAwait(false);
				skiptoken = apiList.SkipToken;
				var entities = apiList.List;

				result.RecordsRead += entities.Count;

				result.RecordsInsertedOrUpdated +=
					await targetController.CreateOrUpdateEntitiesAsync(entities).ConfigureAwait(false);

			} while (!string.IsNullOrEmpty(skiptoken));

			if (endpointType == EndpointTypeEnum.Sync && modelInfo.HasDeletedEntityType)
			{
				var deleted = (await client.DeletedFor(modelInfo.DeletedEntityType, maxTimestamp)
					.GetAsync().ConfigureAwait(false))
					.List
					.ToEntityKeyArray();

				result.RecordsDeletedRead += deleted.Length;

				result.RecordsDeleted = await targetController.DeleteEntitiesAsync(deleted).ConfigureAwait(false);
			}

			Debug.WriteLine(result);

			return result;
		}

		private static EndpointTypeEnum GetEndpointType(ModelInfo modelInfo) =>
			modelInfo.SupportsSync ? EndpointTypeEnum.Sync
								   : modelInfo.SupportsBulk ? EndpointTypeEnum.Bulk
								   : EndpointTypeEnum.Single;

		// Make sure we select all the necessary fields (add id and timestamp/modified fields)
		// And filter the query according to maxTimestamp or maxModified
		private static void PrepareForSync<TModel>(this ExactOnlineQuery<TModel> query, ModelInfo modelInfo, EndpointTypeEnum endpointType, long maxTimestamp, DateTime? maxModified)
			where TModel : class
		{
			// IdentifierName can have multiple fields separated by ',' but this is no problem for this kind of select here
			query.Select(modelInfo.IdentifierName);

			if (endpointType == EndpointTypeEnum.Sync)
			{
				query.Select(ModelInfo.TimestampName);
				query.Where(modelInfo.TimestampLambda<TModel>(), maxTimestamp, OperatorEnum.Gt);
			}
			else if (modelInfo.HasModifiedProperty)
			{
				query.Select(ModelInfo.ModifiedName);
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
}

using ExactOnline.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Sync
{
	public abstract class SyncTargetControllerBase<TModel>
		: ISyncTargetController<TModel>
	{
		protected ModelInfo ModelInfo { get; } = ModelInfo.For<TModel>();

		public abstract long GetMaxTimestamp();
		public abstract Task<long> GetMaxTimestampAsync();

		public abstract DateTime? GetMaxModified();
		public abstract Task<DateTime?> GetMaxModifiedAsync();

		public abstract int CreateOrUpdateEntities(List<TModel> entities);
		public abstract Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities);

		public abstract int DeleteEntities(Guid[] deleted);
		public abstract Task<int> DeleteEntitiesAsync(Guid[] deleted);
	}
}

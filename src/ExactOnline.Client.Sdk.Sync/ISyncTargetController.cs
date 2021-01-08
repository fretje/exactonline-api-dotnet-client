using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Sync
{
	public interface ISyncTargetController<TModel>
	{
		long GetMaxTimestamp();
		Task<long> GetMaxTimestampAsync();

		DateTime? GetMaxModified();
		Task<DateTime?> GetMaxModifiedAsync();

		int CreateOrUpdateEntities(List<TModel> entities);
		Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities);

		int DeleteEntities(Guid[] deleted);
		Task<int> DeleteEntitiesAsync(Guid[] deleted);
	}
}

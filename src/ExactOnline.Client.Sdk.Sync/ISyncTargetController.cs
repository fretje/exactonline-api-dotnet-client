using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Sync
{
	public interface ISyncTargetController<TModel>
	{
		long GetMaxTimestamp();
		Task<long> GetMaxTimestampAsync(CancellationToken cancellationToken);

		DateTime? GetMaxModified();
		Task<DateTime?> GetMaxModifiedAsync(CancellationToken cancellationToken);

		int CreateOrUpdateEntities(List<TModel> entities);
		Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities, CancellationToken cancellationToken);

		int DeleteEntities(Guid[] deleted);
		Task<int> DeleteEntitiesAsync(Guid[] deleted, CancellationToken cancellationToken);
	}
}

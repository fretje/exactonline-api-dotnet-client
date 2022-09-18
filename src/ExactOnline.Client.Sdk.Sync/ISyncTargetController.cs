namespace ExactOnline.Client.Sdk.Sync;

public interface ISyncTargetController<TModel>
{
	long GetMaxTimestamp();
	Task<long> GetMaxTimestampAsync(CancellationToken ct);

	DateTime? GetMaxModified();
	Task<DateTime?> GetMaxModifiedAsync(CancellationToken ct);

	int CreateOrUpdateEntities(List<TModel> entities);
	Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities, CancellationToken ct);

	int DeleteEntities(Guid[] deleted);
	Task<int> DeleteEntitiesAsync(Guid[] deleted, CancellationToken ct);
}

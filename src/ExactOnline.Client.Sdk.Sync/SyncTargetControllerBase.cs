namespace ExactOnline.Client.Sdk.Sync;

public abstract class SyncTargetControllerBase<TModel>
	: ISyncTargetController<TModel>
{
	protected ModelInfo ModelInfo { get; } = ModelInfo.For<TModel>();

	public abstract long GetMaxTimestamp();
	public abstract Task<long> GetMaxTimestampAsync(CancellationToken ct);

	public abstract DateTime? GetMaxModified();
	public abstract Task<DateTime?> GetMaxModifiedAsync(CancellationToken ct);

	public abstract int CreateOrUpdateEntities(List<TModel> entities, string[] fields);
	public abstract Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities, string[] fields, CancellationToken ct);

	public abstract int DeleteEntities(Guid[] deleted);
	public abstract Task<int> DeleteEntitiesAsync(Guid[] deleted, CancellationToken ct);
}

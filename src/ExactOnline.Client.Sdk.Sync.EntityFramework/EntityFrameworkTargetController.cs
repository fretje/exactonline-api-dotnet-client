using System.Data.Entity;
using System.Linq.Dynamic.Core;

namespace ExactOnline.Client.Sdk.Sync.EntityFramework;

public class EntityFrameworkTargetController<TModel, TId>
	: SyncTargetControllerBase<TModel>
	where TModel : class
{
	private readonly string _nameOrConnectionString;

	public EntityFrameworkTargetController(string nameOrConnectionString)
		: base() => _nameOrConnectionString = nameOrConnectionString;

	public override long GetMaxTimestamp()
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		return db.Set<TModel>()
			.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
			.Max() ?? 0;
	}

	public override async Task<long> GetMaxTimestampAsync(CancellationToken ct)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		return await db.Set<TModel>()
			.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
			.MaxAsync(ct).ConfigureAwait(false) ?? 0;
	}

	public override DateTime? GetMaxModified()
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		return db.Set<TModel>()
			.Select(ModelInfo.ModifiedLambda<TModel>())
			.Max();
	}

	public override async Task<DateTime?> GetMaxModifiedAsync(CancellationToken ct)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		return await db.Set<TModel>()
			.Select(ModelInfo.ModifiedLambda<TModel>())
			.MaxAsync(ct).ConfigureAwait(false);
	}

	public override int CreateOrUpdateEntities(List<TModel> entities, string[] fields)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		CreateOrUpdateEntities(entities, db, GetExistingIds());
		return db.SaveChanges();
	}

	public override async Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities, string[] fields, CancellationToken ct)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		CreateOrUpdateEntities(entities, db, await GetExistingIdsAsync(ct).ConfigureAwait(false));
		return await db.SaveChangesAsync(ct).ConfigureAwait(false);
	}

	private TId[] GetExistingIds()
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		return db.Set<TModel>()
			.Select(ModelInfo.IdentifierLambda<TModel, TId>())
			.ToArray();
	}

	private async Task<TId[]> GetExistingIdsAsync(CancellationToken ct)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		return await db.Set<TModel>()
			.Select(ModelInfo.IdentifierLambda<TModel, TId>())
			.ToArrayAsync(ct).ConfigureAwait(false);
	}

	private void CreateOrUpdateEntities(List<TModel> entities, EntityFrameworkDbContext db, TId[] existingIds)
	{
		foreach (var entity in entities)
		{
			var idValue = ModelInfo.IdentifierValue<TModel, TId>(entity);
			db.Entry(entity).State = existingIds.Contains(idValue) ? EntityState.Modified : EntityState.Added;
		}
	}

	public override int DeleteEntities(Guid[] deleted)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		DeleteEntities(deleted, db);
		return db.SaveChanges();
	}

	public override async Task<int> DeleteEntitiesAsync(Guid[] deleted, CancellationToken ct)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		DeleteEntities(deleted, db);
		return await db.SaveChangesAsync(ct).ConfigureAwait(false);
	}

	private void DeleteEntities(Guid[] deleted, EntityFrameworkDbContext db) =>
		db.Set<TModel>().RemoveRange(
			db.Set<TModel>().Where($"{ModelInfo.IdentifierName} in @0", deleted));
}

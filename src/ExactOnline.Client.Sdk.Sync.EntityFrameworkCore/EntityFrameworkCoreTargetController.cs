using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

public class EntityFrameworkCoreTargetController<TModel, TId>
	: SyncTargetControllerBase<TModel>
	where TModel : class
{
	private readonly string _nameOrConnectionString;

	public EntityFrameworkCoreTargetController(string nameOrConnectionString)
		: base() => _nameOrConnectionString = nameOrConnectionString;

	public override long GetMaxTimestamp()
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		return db.Set<TModel>()
			.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
			.Max() ?? 0;
	}
	
	public override async Task<long> GetMaxTimestampAsync(CancellationToken ct)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		return await db.Set<TModel>()
			.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
			.MaxAsync(ct).ConfigureAwait(false) ?? 0;
	}

	public override DateTime? GetMaxModified()
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		return db.Set<TModel>()
			.Select(ModelInfo.ModifiedLambda<TModel>())
			.Max();
	}

	public override async Task<DateTime?> GetMaxModifiedAsync(CancellationToken ct)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		return await db.Set<TModel>()
			.Select(ModelInfo.ModifiedLambda<TModel>())
			.MaxAsync(ct).ConfigureAwait(false);
	}

	public override int CreateOrUpdateEntities(List<TModel> entities, string[] fields)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		CreateOrUpdateEntities(entities, db, GetExistingIds());

		return db.SaveChanges();
	}

	public override async Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities, string[] fields, CancellationToken ct)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		CreateOrUpdateEntities(entities, db, await GetExistingIdsAsync(ct).ConfigureAwait(false));

		return await db.SaveChangesAsync(ct).ConfigureAwait(false);
	}

	private TId[] GetExistingIds()
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		return [.. db.Set<TModel>().Select(ModelInfo.IdentifierLambda<TModel, TId>())];
	}

	private async Task<TId[]> GetExistingIdsAsync(CancellationToken ct)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		return await db.Set<TModel>()
			.Select(ModelInfo.IdentifierLambda<TModel, TId>())
			.ToArrayAsync(ct).ConfigureAwait(false);
	}

	private void CreateOrUpdateEntities(List<TModel> entities, EntityFrameworkCoreDbContext db, TId[] existingIds)
	{
		foreach (var entity in entities)
		{
			var idValue = ModelInfo.IdentifierValue<TModel, TId>(entity);
			db.Entry(entity).State = existingIds.Contains(idValue) ? EntityState.Modified : EntityState.Added;
		}
	}

	public override int DeleteEntities(Guid[] deleted)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		DeleteEntities(deleted, db);

		return db.SaveChanges();
	}

	public override async Task<int> DeleteEntitiesAsync(Guid[] deleted, CancellationToken ct)
	{
		using var db = new EntityFrameworkCoreDbContext(new DbContextOptionsBuilder().UseSqlServer(_nameOrConnectionString).Options);

		DeleteEntities(deleted, db);

		return await db.SaveChangesAsync(ct).ConfigureAwait(false);
	}

	private void DeleteEntities(Guid[] deleted, EntityFrameworkCoreDbContext db) =>
		db.Set<TModel>().RemoveRange(
			db.Set<TModel>().Where($"{ModelInfo.IdentifierName} in @0", deleted));
}

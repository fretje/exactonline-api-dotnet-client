using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Sync.EntityFramework
{
	public class EntityFrameworkTargetController<TModel, TId>
		: SyncTargetControllerBase<TModel>
		where TModel : class
	{
		private readonly string _nameOrConnectionString;

		public EntityFrameworkTargetController(string nameOrConnectionString)
			: base() => _nameOrConnectionString = nameOrConnectionString;

		public override long GetMaxTimestamp()
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return db.Set<TModel>()
					.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
					.Max() ?? 0;
			}
		}

		public override async Task<long> GetMaxTimestampAsync(CancellationToken cancellationToken)
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return await db.Set<TModel>()
					.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
					.MaxAsync(cancellationToken).ConfigureAwait(false) ?? 0;
			}
		}

		public override DateTime? GetMaxModified()
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return db.Set<TModel>()
					.Select(ModelInfo.ModifiedLambda<TModel>())
					.Max();
			}
		}

		public override async Task<DateTime?> GetMaxModifiedAsync(CancellationToken cancellationToken)
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return await db.Set<TModel>()
					.Select(ModelInfo.ModifiedLambda<TModel>())
					.MaxAsync(cancellationToken).ConfigureAwait(false);
			}
		}

		public override int CreateOrUpdateEntities(List<TModel> entities)
		{
			if (!entities.Any())
			{
				return 0;
			}
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				CreateOrUpdateEntities(entities, db, GetExistingIds());
				return db.SaveChanges();
			}
		}

		public override async Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities, CancellationToken cancellationToken)
		{
			if (!entities.Any())
			{
				return 0;
			}
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				CreateOrUpdateEntities(entities, db, await GetExistingIdsAsync(cancellationToken).ConfigureAwait(false));
				return await db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			}
		}

		private TId[] GetExistingIds()
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return db.Set<TModel>()
					.Select(ModelInfo.IdentifierLambda<TModel, TId>())
					.ToArray();
			}
		}

		private async Task<TId[]> GetExistingIdsAsync(CancellationToken cancellationToken)
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return await db.Set<TModel>()
					.Select(ModelInfo.IdentifierLambda<TModel, TId>())
					.ToArrayAsync(cancellationToken).ConfigureAwait(false);
			}
		}

		private void CreateOrUpdateEntities(List<TModel> entities, EntityFrameworkDbContext db, TId[] existingIds)
		{
			foreach (var entity in entities)
			{
				var idValue = ModelInfo.IdentifierValue<TModel, TId>(entity);
				var timestampValue = ModelInfo.TimestampValue(entity);
				if (timestampValue != null)
				{
					if (entities.AsQueryable().Any($"{ModelInfo.IdentifierName} = @0 and {ModelInfo.TimestampName} > @1", idValue, timestampValue))
					{
						// Sync results can contain duplicate entries for the same unique key.
						// Here we take only the last change into account and filter out all the previous ones.
						continue;
					}
				}
				db.Entry(entity).State = existingIds.Contains(idValue) ? EntityState.Modified : EntityState.Added;
			}
		}

		public override int DeleteEntities(Guid[] deleted)
		{
			if (deleted == null || deleted.Length == 0)
			{
				return 0;
			}
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				DeleteEntities(deleted, db);
				return db.SaveChanges();
			}
		}

		public override async Task<int> DeleteEntitiesAsync(Guid[] deleted, CancellationToken cancellationToken)
		{
			if (deleted == null || deleted.Length == 0)
			{
				return 0;
			}
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				DeleteEntities(deleted, db);
				return await db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
			}
		}

		private void DeleteEntities(Guid[] deleted, EntityFrameworkDbContext db) =>
			db.Set<TModel>().RemoveRange(
				db.Set<TModel>().Where($"{ModelInfo.IdentifierName} in @0", deleted));
	}
}

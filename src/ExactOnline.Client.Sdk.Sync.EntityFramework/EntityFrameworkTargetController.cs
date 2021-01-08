using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
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

		public override async Task<long> GetMaxTimestampAsync()
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return await db.Set<TModel>()
					.Select(ModelInfo.TimestampCastedToNullableLambda<TModel>())
					.MaxAsync().ConfigureAwait(false) ?? 0;
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

		public override async Task<DateTime?> GetMaxModifiedAsync()
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return await db.Set<TModel>()
					.Select(ModelInfo.ModifiedLambda<TModel>())
					.MaxAsync().ConfigureAwait(false);
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
				CreateOrUpdateEntities(entities, db);
				return db.SaveChanges();
			}
		}

		public override async Task<int> CreateOrUpdateEntitiesAsync(List<TModel> entities)
		{
			if (!entities.Any())
			{
				return 0;
			}
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				CreateOrUpdateEntities(entities, db);
				return await db.SaveChangesAsync().ConfigureAwait(false);
			}
		}

		private void CreateOrUpdateEntities(List<TModel> entities, EntityFrameworkDbContext db)
		{
			var existingIds = GetExistingIds();
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

		private TId[] GetExistingIds()
		{
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				return db.Set<TModel>()
					.Select(ModelInfo.IdentifierLambda<TModel, TId>())
					.ToArray();
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

		public override async Task<int> DeleteEntitiesAsync(Guid[] deleted)
		{
			if (deleted == null || deleted.Length == 0)
			{
				return 0;
			}
			using (var db = new EntityFrameworkDbContext(_nameOrConnectionString))
			{
				DeleteEntities(deleted, db);
				return await db.SaveChangesAsync().ConfigureAwait(false);
			}
		}

		private void DeleteEntities(Guid[] deleted, EntityFrameworkDbContext db)
			=> db.Set<TModel>().RemoveRange(
					db.Set<TModel>().Where(
						ModelInfo.IdentifierName.Contains(',')
							? $"new ({ModelInfo.IdentifierName}) in @0"
							: $"{ModelInfo.IdentifierName} in @0",
						deleted));
	}
}

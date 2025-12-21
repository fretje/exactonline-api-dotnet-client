using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

public class EntityFrameworkCoreTarget : SyncTargetBase
{
	private readonly string _connectionString;

	public EntityFrameworkCoreTarget(string connectionString) =>
		_connectionString = connectionString;

	public async Task InitializeDatabaseAsync(CancellationToken ct)
	{
		EntityFrameworkCoreDbContext db = new(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options);
		await db.Database.MigrateAsync(ct).ConfigureAwait(false);
	}

	protected override ISyncTargetController<TModel> CreateControllerFor<TModel>() =>
		(ISyncTargetController<TModel>)Activator.CreateInstance(
			typeof(EntityFrameworkCoreTargetController<,>)
				.MakeGenericType(typeof(TModel), ModelInfo.For<TModel>().IdentifierType ?? throw new InvalidOperationException("Identifier type is not set.")),
			_connectionString)!;


	private static readonly Lazy<Type[]> _supportedModelTypes =
		new(() =>
			[.. ExactOnlineSynchronizer.SupportedModelTypes
				.Where(type =>
					// We already have a Document entity under Models.Documents
					type != typeof(Client.Models.CRM.Document) &&
					// We already have a TimeTransaction entity under Models.Project
					type != typeof(Client.Models.Manufacturing.TimeTransaction) &&
					// We already have a Division entity under Models.SystemBase
					type != typeof(Client.Models.HRM.Division))]);

	public static Type[] SupportedModelTypes => _supportedModelTypes.Value;
}

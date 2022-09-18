using System.Linq.Dynamic.Core;

namespace ExactOnline.Client.Sdk.Sync.EntityFramework;

public class EntityFrameworkTarget : SyncTargetBase
{
	private readonly string _nameOrConnectionString;

	public EntityFrameworkTarget(string nameOrConnectionString = null) =>
		_nameOrConnectionString = nameOrConnectionString;

	public void InitializeDatabase(bool force)
	{
		using var db = new EntityFrameworkDbContext(_nameOrConnectionString);
		db.Database.Initialize(force);
	}

	protected override ISyncTargetController<TModel> CreateControllerFor<TModel>() =>
		Activator.CreateInstance(
			typeof(EntityFrameworkTargetController<,>)
				.MakeGenericType(typeof(TModel), ModelInfo.For<TModel>().IdentifierType),
			_nameOrConnectionString)
		as ISyncTargetController<TModel>;


	private static readonly Lazy<Type[]> _supportedModelTypes =
		new Lazy<Type[]>(() =>
			ExactOnlineSynchronizer.SupportedModelTypes
				.Where(type =>
					// We already have a Document entity under Models.Documents
					type != typeof(Client.Models.CRM.Document) &&
					// We already have a TimeTransaction entity under Models.Project
					type != typeof(Client.Models.Manufacturing.TimeTransaction) &&
					// We already have a Division entity under Models.SystemBase
					type != typeof(Client.Models.HRM.Division))
				.ToArray());

	public static Type[] SupportedModelTypes => _supportedModelTypes.Value;
}

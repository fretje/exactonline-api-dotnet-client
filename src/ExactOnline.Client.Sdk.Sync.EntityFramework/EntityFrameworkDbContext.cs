using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExactOnline.Client.Sdk.Sync.EntityFramework;

public class EntityFrameworkDbContext : DbContext
{
	public EntityFrameworkDbContext()
		: this(null)
	{ }

	public EntityFrameworkDbContext(string nameOrConnectionString)
		: base(string.IsNullOrEmpty(nameOrConnectionString)
			  ? typeof(EntityFrameworkDbContext).FullName
			  : nameOrConnectionString) =>
		Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntityFrameworkDbContext, Migrations.Configuration>(true));

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Don't pluralize tablenames
		modelBuilder.Conventions.Remove<IdKeyDiscoveryConvention>(); // The primary keys are defined by the IdentifierName of the ModelInfo (see below)
		modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>(); // Don't use databasegenerated option for integer id's

		modelBuilder.Properties()
			.Where(p =>
			{
				var identifierName = ModelInfo.For(p.DeclaringType).IdentifierName;
				return !string.IsNullOrEmpty(identifierName) && identifierName.Split(',').Any(i => i == p.Name);
			})
			.Configure(p =>
			{
				p.IsKey();
				var identifierName = ModelInfo.For(p.ClrPropertyInfo.DeclaringType).IdentifierName;
				var idNames = identifierName.Split(',');
				if (idNames.Length > 0)
				{
					p.HasColumnOrder(Array.IndexOf(idNames, p.ClrPropertyInfo.Name));
				}
			});

		foreach (var type in EntityFrameworkTarget.SupportedModelTypes)
		{
			modelBuilder.RegisterEntityType(type);
		}

		modelBuilder.ComplexType<Client.Models.Manufacturing.MaterialPlanCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.FixedCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.MaterialsPerPieceCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.PiecesPerMaterialCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.BarCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.SheetCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.CoilWireLengthCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.CoilWireWeightCalculator>();
		modelBuilder.ComplexType<Client.Models.Manufacturing.VolumeCalculator>();
	}
}

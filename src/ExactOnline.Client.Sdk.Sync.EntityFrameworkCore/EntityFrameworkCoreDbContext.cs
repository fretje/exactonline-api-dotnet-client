using ExactOnline.Client.Models.Inventory;
using ExactOnline.Client.Models.Manufacturing;
using Microsoft.EntityFrameworkCore;

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

public class EntityFrameworkCoreDbContext : DbContext
{
	public EntityFrameworkCoreDbContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var type in EntityFrameworkCoreTarget.SupportedModelTypes)
		{
			var identifierName = ModelInfo.For(type).IdentifierName;
			var identifierNames = !string.IsNullOrEmpty(identifierName) ? identifierName.Split(',') : null;
			if (identifierNames?.Length > 0)
			{
				var entityTypeBuilder = modelBuilder.Entity(type);
				entityTypeBuilder.HasKey(identifierNames);
				foreach (var identifier in identifierNames)
				{
					entityTypeBuilder.Property(identifier).ValueGeneratedNever();
				}
			}
		}

		modelBuilder.Entity<ShopOrderRoutingStepPlan>().Ignore(s => s.TimeTransactions);

		modelBuilder.Entity<ShopOrderMaterialPlanDetail>().OwnsOne(d => d.Calculator, c =>
		{
			c.OwnsOne(d => d.FixedCalculator);
			c.Navigation(e => e.FixedCalculator).IsRequired();
			c.OwnsOne(d => d.MaterialsPerPieceCalculator);
			c.Navigation(e => e.MaterialsPerPieceCalculator).IsRequired();
			c.OwnsOne(d => d.PiecesPerMaterialCalculator);
			c.Navigation(e => e.PiecesPerMaterialCalculator).IsRequired();
			c.OwnsOne(d => d.BarCalculator);
			c.Navigation(e => e.BarCalculator).IsRequired();
			c.OwnsOne(d => d.SheetCalculator);
			c.Navigation(e => e.SheetCalculator).IsRequired();
			c.OwnsOne(d => d.CoilWireLengthCalculator);
			c.Navigation(e => e.CoilWireLengthCalculator).IsRequired();
			c.OwnsOne(d => d.CoilWireWeightCalculator);
			c.Navigation(e => e.CoilWireWeightCalculator).IsRequired();
			c.OwnsOne(d => d.VolumeCalculator);
			c.Navigation(e => e.VolumeCalculator).IsRequired();
		});
		modelBuilder.Entity<ShopOrderMaterialPlanDetail>().Navigation(d => d.Calculator).IsRequired();

		modelBuilder.Entity<BatchNumber>().OwnsMany(b => b.StorageLocations);
		modelBuilder.Entity<BatchNumber>().OwnsMany(b => b.Warehouses);
	}
}

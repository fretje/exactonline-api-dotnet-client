using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

public class EntityFrameworkCoreDbContextFactory : IDesignTimeDbContextFactory<EntityFrameworkCoreDbContext>
{
	public EntityFrameworkCoreDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<EntityFrameworkCoreDbContext>();
		optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True");

		return new EntityFrameworkCoreDbContext(optionsBuilder.Options);
	}
}

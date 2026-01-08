using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

public class EntityFrameworkCoreDbContextFactory : IDesignTimeDbContextFactory<EntityFrameworkCoreDbContext>
{
	public EntityFrameworkCoreDbContext CreateDbContext(string[] args) =>
		new(new DbContextOptionsBuilder<EntityFrameworkCoreDbContext>()
			.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True")
			.Options);
}

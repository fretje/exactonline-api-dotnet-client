using ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

namespace ExactOnline.Client.Sdk.Sync.EnitityFrameworkCore.IntegrationTests;

public class EntityFrameworkCoreTargetTests
{
	[Fact]
	public async Task ShouldInitializeDatabase()
	{
		var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=exacttest;Integrated Security=True";
		var sut = new EntityFrameworkCoreTarget(connectionString);

		await sut.InitializeDatabaseAsync(default);

		// toso: check if the database actually exists with the right amount of tables
	}
}

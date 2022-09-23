using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;
using ExactOnline.Client.Sdk.TestContext;

namespace ExactOnline.Client.Sdk.Sync.EnitityFrameworkCore.IntegrationTests;

public class EntityFrameworkCoreTargetTests
{
	[Fact]
	public async Task ShouldInitializeDatabase()
	{
		var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True";
		var sut = new EntityFrameworkCoreTarget(connectionString);

		await sut.InitializeDatabaseAsync(default);

		// toso: check if the database actually exists with the right amount of tables
	}

	[Fact]
	public async Task ShouldSynchronizeTable()
	{
		var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True";
		var target = new EntityFrameworkCoreTarget(connectionString);

		var client = await new TestObjectsCreator().GetClientAsync();
		await client.SynchronizeWithAsync<Quotation>(target, ModelInfo.For<Quotation>().FieldNames(true));

	}
}

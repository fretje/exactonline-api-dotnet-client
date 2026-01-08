using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;
using ExactOnline.Client.Sdk.Test.Context;

namespace ExactOnline.Client.Sdk.Sync.EnitityFrameworkCore.IntegrationTests;

public class EntityFrameworkCoreTargetTests
{
	[Fact]
	public async Task ShouldInitializeDatabase()
	{
		var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True";
		EntityFrameworkCoreTarget sut = new(connectionString);

		await sut.InitializeDatabaseAsync(Xunit.TestContext.Current.CancellationToken);

		// todo: check if the database actually exists with the right amount of tables
	}

	[StaFact]
	public async Task ShouldSynchronizeTable()
	{
		var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True";
		EntityFrameworkCoreTarget target = new(connectionString);
		await target.InitializeDatabaseAsync(default);

		var client = await new TestObjectsCreator().GetClientAsync();
		await client.SynchronizeWithAsync<Account>(target, ModelInfo.For<Account>().FieldNames(true));
	}
}

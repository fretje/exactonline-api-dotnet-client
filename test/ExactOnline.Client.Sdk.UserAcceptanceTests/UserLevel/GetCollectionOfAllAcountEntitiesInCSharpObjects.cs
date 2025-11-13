using ExactOnline.Client.Models.CRM;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class GetCollectionOfAllAcountEntitiesInCSharpObjects
{
	public TestContext TestContext { get; set; }

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task GetCollectionOfAllAcountEntitiesInCSharpObjects_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var accounts = client.For<Account>().Select("ID").Get();

		Assert.IsNotEmpty(accounts, "Get Collection Of All Account Entities in CSharp Objects is not implemented corectly");
	}
}

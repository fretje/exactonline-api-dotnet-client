using ExactOnline.Client.Models.CRM;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class GetCollectionOfAllAcountEntitiesInCSharpObjects
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task GetCollectionOfAllAcountEntitiesInCSharpObjects_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		var accounts = client.For<Account>().Select("ID").Get();

		Assert.IsTrue(accounts.Count > 0, "Get Collection Of All Account Entities in CSharp Objects is not implemented corectly");
	}
}

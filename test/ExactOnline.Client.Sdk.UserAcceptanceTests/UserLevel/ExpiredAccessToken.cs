using ExactOnline.Client.Models.CRM;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class ExpiredAccessToken
{
	public TestContext TestContext { get; set; }

	// Run this test selectively because it takes 10 minutes
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	[Ignore]
	public async Task ExpiredAccessToken_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		Thread.Sleep(600000); //Sleep for 10 minutes, then the token is expired

		var accounts = client.For<Account>().Select("ID").Get();
		Assert.IsNotEmpty(accounts);
	}
}

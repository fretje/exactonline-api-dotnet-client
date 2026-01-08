using ExactOnline.Client.Models.CRM;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class DeleteAccountEntityWithDeleteMethod
{
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task DeleteAccountWithDeleteMethod()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		// Create new account
		Account newAccount = new() { Name = "Test account" };

		if (client.For<Account>().Insert(ref newAccount))
		{
			// Try to delete account
			if (!client.For<Account>().Delete(newAccount))
			{
				throw new Exception("Failed to delete test account entity. Possibly this test will not work as the database is now corrupt. Please delete account with name 'Account for 184249' manualy");
			}
		}
		else
		{
			throw new Exception("Cannot create test account entity");
		}
	}
}

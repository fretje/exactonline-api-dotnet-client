using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class DeleteAccountEntityWithDeleteMethod
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task DeleteAccountWithDeleteMethod()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		// Create new account
		var newAccount = new Account { Name = "Test account" };

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

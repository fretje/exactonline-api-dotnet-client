using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.LowLevel;

[TestClass]
public class GetCollectionOfAccountsInJsonFormat
{
	[TestCategory("User Acceptance Tests")]
	[TestMethod]
	public async Task GetCollectionOfAccountsInJsonFormat_Succeeds()
	{
		var toc = new TestObjectsCreator();
		var conn = new ApiConnection(toc.GetApiConnector(), TestObjectsCreator.UriCrmAccount(await toc.GetCurrentDivisionAsync()));

		var c = new SimpleController(conn);
		var accounts = c.GetDynamic(string.Empty);

		// Test if list has entities (easy test, because actual entity count isn't known)
		if (accounts.Count < 1)
		{
			throw new Exception("User Story not correctly implemented: List of CRM/Accounts is empty");
		}
	}
}

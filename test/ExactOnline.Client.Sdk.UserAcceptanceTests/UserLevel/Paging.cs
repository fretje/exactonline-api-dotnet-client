using ExactOnline.Client.Models.CRM;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class Paging
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task PagingResults()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		//// Get enumerator
		//var count = client.For<Account>().Count();
		//var result = client.For<Account>()
		//	.Expand("BankAccounts")
		//	.Skip(10)
		//	.Get();

		//Assert.IsTrue(result.Count == (count - 10));

		var accounts = client.For<Account>()
			.Select("ID,Code,Name")
			.Where("Name+eq+'Test Eurobike'")
			.Get();

		var hoi = "";
		foreach (var account in accounts)
		{
			hoi += account.Name + "\t" + account.Code + "\n";
		}
	}
}

using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class RobustEndpoints
{
	private TestObjectsCreator _toc;
	private int _currentDivision;

	[TestInitialize]
	public async Task InitializeSharedTestObjects()
	{
		_toc = new TestObjectsCreator();
		_currentDivision = (await _toc.GetClientAsync()).Division;
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task TestWithoutDivision()
	{
		var client = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, TestObjectsCreator.GetOAuthAuthenticationToken);
		await client.InitializeDivisionAsync();
		client.For<Account>().Select("Code").Get();
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public void TestWithDivision()
	{
		var client = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, _currentDivision, TestObjectsCreator.GetOAuthAuthenticationToken);
		client.For<Account>().Select("Code").Get();
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public void TestWithSlash()
	{
		var client = new ExactOnlineClient($"{TestObjectsCreator.ExactOnlineUrl}/", _currentDivision, TestObjectsCreator.GetOAuthAuthenticationToken);
		client.For<Account>().Select("Code").Get();
	}
}

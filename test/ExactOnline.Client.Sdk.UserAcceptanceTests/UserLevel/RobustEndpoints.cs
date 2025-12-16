using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class RobustEndpoints
{
	private TestObjectsCreator _toc = default!;
	private int _currentDivision;

	public TestContext TestContext { get; set; }

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
		var client = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, TestObjectsCreator.GetOAuthAuthenticationToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
		client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
		await client.InitializeDivisionAsync(TestContext.CancellationToken);
		client.For<Account>().Select("Code").Get();
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public void TestWithDivision()
	{
		var client = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, _currentDivision, TestObjectsCreator.GetOAuthAuthenticationToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
		client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
		client.For<Account>().Select("Code").Get();
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public void TestWithSlash()
	{
		var client = new ExactOnlineClient($"{TestObjectsCreator.ExactOnlineUrl}/", _currentDivision, TestObjectsCreator.GetOAuthAuthenticationToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
		client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
		client.For<Account>().Select("Code").Get();
	}
}

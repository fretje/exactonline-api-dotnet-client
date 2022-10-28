using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace ExactOnline.Client.Sdk.IntegrationTests;

[TestClass]
public class ExactOnlineClientTests
{
	[TestCategory("Integration Tests")]
	[TestMethod]
	public void ExactClient_TestEndPointWithSlash_Succeeds() =>
		_ = new ExactOnlineClient($"{TestObjectsCreator.ExactOnlineUrl}/", TestObjectsCreator.GetOAuthAuthenticationToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);

	[TestCategory("Integration Tests")]
	[TestMethod]
	public void ExactClient_TestEndPointWithoutSlash_Succeeds() =>
		_ = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, TestObjectsCreator.GetOAuthAuthenticationToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
}

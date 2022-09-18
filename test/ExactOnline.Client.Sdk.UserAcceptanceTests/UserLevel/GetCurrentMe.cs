using ExactOnline.Client.Models.Current;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class GetCurrentMe
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task ExactClient_GetCurrentMe_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		var currentMe = client.For<Me>().Select("CurrentDivision").Get().FirstOrDefault();

		Assert.IsNotNull(currentMe);
	}
}

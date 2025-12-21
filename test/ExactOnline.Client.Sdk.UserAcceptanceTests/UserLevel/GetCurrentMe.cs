using ExactOnline.Client.Models.Current;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class GetCurrentMe
{
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task ExactClient_GetCurrentMe_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var currentMe = client.For<Me>().Select("CurrentDivision").Get().FirstOrDefault();

		Assert.IsNotNull(currentMe);
	}
}

using ExactOnline.Client.Models.Financial;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class GetSpecificCollectionCusingOData184244
{
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task GetSpecificCollectionUsingOData()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var accounts = client.For<GLAccount>()
			.Select("Code")
			.Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
			.And($"Code+eq+'{TestObjectsCreator.SpecificGLAccountCode}'")
			.Get();

		Assert.IsTrue(accounts.Any());
	}
}

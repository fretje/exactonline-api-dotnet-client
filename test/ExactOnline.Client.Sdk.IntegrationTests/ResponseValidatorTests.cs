namespace ExactOnline.Client.Sdk.IntegrationTests;

[TestClass]
public class ResponseValidatorTests
{
	public TestContext TestContext { get; set; } = default!;

	[TestCategory("Integration Tests")]
	[TestMethod]
	// Tests if the API returns '"d"' and 'results' tags. If not, the controllers will not work correctly
	public async Task Test_ResponseHasCorrectTags_Succeeds()
	{
		TestObjectsCreator toc = new();
		var conn = toc.GetApiConnector();
		var currentDivision = await toc.GetCurrentDivisionAsync(TestContext.CancellationToken);

		var response = conn.DoGetRequest(TestObjectsCreator.UriGlAccount(currentDivision), "");

		if (!response.Contains("\"d\"") || !response.Contains("\"results\""))
		{
			throw new Exception("Response does not have correct tags (\"d\" or \"results\").");
		}
	}
}

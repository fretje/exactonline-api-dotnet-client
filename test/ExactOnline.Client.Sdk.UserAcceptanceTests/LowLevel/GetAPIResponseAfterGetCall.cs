using ExactOnline.Client.Sdk.Helpers;
using Newtonsoft.Json;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.LowLevel;

[TestClass]
public class GetApiResponseAfterGetCall
{
	public TestContext TestContext { get; set; } = default!;

	/// <summary>
	/// User Story: Get a text response in JSON format from the API after 
	/// executing a REST GET call so that I can read data from Exact Online.
	/// Constraints: The user retrieves a string in JSON format.
	/// </summary>
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task GetApiResponseAfterGetCall_Succeeds()
	{
		//APIConnector connector = new(accesstoken);
		TestObjectsCreator toc = new();
		ApiConnection conn = new(toc.GetApiConnector(), TestObjectsCreator.UriCrmAccount(await toc.GetCurrentDivisionAsync(TestContext.CancellationToken)));

		var result = conn.Get(string.Empty);
		if (string.IsNullOrEmpty(result))
		{
			throw new Exception("Return from API was empty");
		}
		else
		{
			// Check if the response is a JSON Value
			// Throws exception of not JSON
			JsonConvert.DeserializeObject(result);
		}
	}
}

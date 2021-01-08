using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExactOnline.Client.Sdk.IntegrationTests
{
    [TestClass]
    public class ResponseValidatorTests
    {
        [TestCategory("Integration Tests")]
        [TestMethod]
        // Tests if the API returns '"d"' and 'results' tags. If not, the controllers will not work correctly
        public void Test_ResponseHasCorrectTags_Succeeds()
        {
            var toc = new TestObjectsCreator();
            var conn = toc.GetApiConnector();
            var currentDivision = toc.GetCurrentDivision();

            var response = conn.DoGetRequest(TestObjectsCreator.UriGlAccount(currentDivision), string.Empty);

            if (!response.Contains("\"d\"") || !response.Contains("\"results\""))
            {
                throw new Exception("Response does not have correct tags (\"d\" or \"results\").");
            }
        }
    }
}

using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.IntegrationTests
{
    [TestClass]
    public class ExactOnlineClientTests
    {
        [TestCategory("Integration Tests")]
        [TestMethod]
        public void ExactClient_TestEndPointWithSlash_Succeeds() => 
            _ = new ExactOnlineClient($"{TestObjectsCreator.ExactOnlineUrl}/", TestObjectsCreator.GetOAuthAuthenticationToken);

        [TestCategory("Integration Tests")]
        [TestMethod]
        public void ExactClient_TestEndPointWithoutSlash_Succeeds() => 
            _ = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, TestObjectsCreator.GetOAuthAuthenticationToken);
    }
}

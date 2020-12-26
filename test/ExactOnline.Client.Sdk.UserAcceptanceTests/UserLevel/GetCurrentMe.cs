using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class GetCurrentMe
    {
        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void ExactClient_GetCurrentMe_Succeeds()
        {
            var client = new TestObjectsCreator().GetClient();

            Assert.IsNotNull(client.CurrentMe());
        }
    }
}

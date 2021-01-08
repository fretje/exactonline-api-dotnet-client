using ExactOnline.Client.Models.Current;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

			var currentMe = client.For<Me>().Select("CurrentDivision").Get().FirstOrDefault();

			Assert.IsNotNull(currentMe);
        }
    }
}

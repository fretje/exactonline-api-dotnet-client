using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class GetSpecificCollectionCusingOData184244
    {
        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void GetSpecificCollectionUsingOData()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<GLAccount>()
                .Select("Code")
                .Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
                .And($"Code+eq+'{TestObjectsCreator.SpecificGLAccountCode}'")
                .Get();

            Assert.IsTrue(accounts.Any());
        }
    }
}

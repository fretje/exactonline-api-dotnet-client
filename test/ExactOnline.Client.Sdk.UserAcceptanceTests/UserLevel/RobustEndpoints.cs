using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class RobustEndpoints
    {
        private TestObjectsCreator _toc;
        private int _currentDivision;

        [TestInitialize]
        public void InitializeSharedTestObjects()
        {
            _toc = new TestObjectsCreator();
            _currentDivision = _toc.GetClient().Division;
        }

        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void TestWithoutDivision()
        {
            var client = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, TestObjectsCreator.GetOAuthAuthenticationToken);
            client.For<Account>().Select("Code").Get();
        }

        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void TestWithDivision()
        {
            var client = new ExactOnlineClient(TestObjectsCreator.ExactOnlineUrl, _currentDivision, TestObjectsCreator.GetOAuthAuthenticationToken);
            client.For<Account>().Select("Code").Get();
        }

        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void TestWithSlash()
        {
            var client = new ExactOnlineClient($"{TestObjectsCreator.ExactOnlineUrl}/", _currentDivision, TestObjectsCreator.GetOAuthAuthenticationToken);
            client.For<Account>().Select("Code").Get();
        }
    }
}

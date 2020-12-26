using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class GetCollectionOfAllAcountEntitiesInCSharpObjects
    {
        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void GetCollectionOfAllAcountEntitiesInCSharpObjects_Succeeds()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<Account>().Select("ID").Get();

            Assert.IsTrue(accounts.Count > 0, "Get Collection Of All Account Entities in CSharp Objects is not implemented corectly");
        }
    }
}

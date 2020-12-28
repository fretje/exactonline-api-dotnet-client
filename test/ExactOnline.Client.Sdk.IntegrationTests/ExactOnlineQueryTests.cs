using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ExactOnline.Client.Sdk.IntegrationTests
{
    [TestClass]
    public class ExactOnlineQueryTests
    {
        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetSpecificCollectionUsingOData_WithOutOData()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<GLAccount>()
                .Select("Code")
                .Get();

            if (!accounts.Any())
            {
                throw new Exception("The collection of Account entities is empty");
            }
        }

        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetSpecificCollectionUsingOData_WithWhere()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<GLAccount>()
                .Select("Code")
                .Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
                .Get();

            if (!accounts.Any())
            {
                throw new Exception("The collection of Account entities is empty");
            }
        }

        [TestMethod]
        [TestCategory("Integration Tests")]
        public void GetSpecificCollectionUsingOData_WithWhereAndAnd()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<GLAccount>()
                .Select("Code")
                .Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
                .And($"Code+eq+'{TestObjectsCreator.SpecificGLAccountCode}'")
                .Get();

            if (!accounts.Any())
            {
                throw new Exception("The collection of Account entities is empty");
            }
        }

        // Is allready being tested in unit tests
        [TestMethod, Ignore]
        [TestCategory("Integration Tests"), ExpectedException(typeof(Exception))]
        public void GetSpecificCollectionUsingOData_WithNonExistingEntity()
        {
            var client = new TestObjectsCreator().GetClient();

            _ = client.For<object>()
                .Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
                .Get();
        }

        [TestMethod]
        [TestCategory("Integration Tests"), ExpectedException(typeof(BadRequestException))]
        public void GetSpecificCollectionUsingOData_WithNonExistingField()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<Account>()
                .Select("Code")
                .Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
                .Get();

            if (accounts.Count > 1)
            {
                throw new Exception("The collection has entities, but filter field does not exist. Exception expected.");
            }
        }

        [TestMethod]
        [TestCategory("Integration Tests")]
        public void ExactOnlineQuery_WithCorrectProperty_Succeeds()
        {
            var client = new TestObjectsCreator().GetClient();

            var accounts = client.For<Account>()
                .Select(new[] { "Code" })
                .Get();

            Assert.IsTrue(accounts.Count > 1);
        }

        [TestMethod, ExpectedException(typeof(BadRequestException))]
        [TestCategory("Integration Tests")]
        public void ExactOnlineQuery_WithWrongProperty_Fails()
        {
            var client = new TestObjectsCreator().GetClient();

            client.For<Account>().Select(new[] { "Xxx" }).Get();
        }
    }
}

using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class AccessLinkedEntities
    {
        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void AccessLinkedEntities_Succeeds()
        {
            var client = new TestObjectsCreator().GetClient();

            var salesinvoices = client.For<SalesInvoice>()
                .Select("InvoiceID,SalesInvoiceLines/ID")
                .Expand("SalesInvoiceLines")
                .Top(1)
                .Get();
            Assert.IsNotNull(salesinvoices);

            var salesinvoicelines = (List<SalesInvoiceLine>)salesinvoices.First().SalesInvoiceLines;
            Assert.IsTrue(salesinvoicelines.Count > 0);
        }
    }
}

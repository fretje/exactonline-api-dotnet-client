using ExactOnline.Client.Models.SalesInvoice;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class AccessLinkedEntities
{
	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task AccessLinkedEntities_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

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

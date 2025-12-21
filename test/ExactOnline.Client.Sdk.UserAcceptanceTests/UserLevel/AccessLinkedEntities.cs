using ExactOnline.Client.Models.SalesInvoice;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class AccessLinkedEntities
{
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task AccessLinkedEntities_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var salesinvoices = client.For<SalesInvoice>()
			.Select("InvoiceID,SalesInvoiceLines/ID")
			.Expand("SalesInvoiceLines")
			.Top(1)
			.Get();
		Assert.IsNotNull(salesinvoices);

		var salesinvoicelines = salesinvoices.First().SalesInvoiceLines;
		Assert.IsNotNull(salesinvoicelines);
		Assert.IsNotEmpty(salesinvoicelines);
	}
}

using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.Logistics;
using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Sdk.Controllers;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class EntityWithCollection
{
	public TestContext TestContext { get; set; }

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task CreateSalesInvoiceWithLine()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var customerId = GetCustomerId(client);
		var itemId = GetItemId(client);

		SalesInvoice newInvoice = new()
		{
			Currency = "EUR",
			OrderDate = DateTime.Now,
			InvoiceTo = customerId,
			OrderedBy = customerId,
			Description = "New invoice for Entity With Collection"
		};

		SalesInvoiceLine newInvoiceLine = new()
		{
			Description = "New invoice line for Entity With Collection",
			Item = itemId
		};

		List<SalesInvoiceLine> invoicelines = [newInvoiceLine];
		newInvoice.SalesInvoiceLines = invoicelines;

		// Add SalesInvoice to Database
		Assert.IsTrue(client.For<SalesInvoice>().Insert(ref newInvoice));

		// Get SalesInvoice and check if contains collections of InvoiceLines
		var salesInvoice = client.For<SalesInvoice>()
			.Expand("SalesInvoiceLines")
			.GetEntity(newInvoice.InvoiceID.ToString());

		Assert.IsNotNull(salesInvoice);
		Assert.AreEqual(1, salesInvoice.SalesInvoiceLines?.Count());
	}

	private static Guid GetCustomerId(ExactOnlineClient client)
	{
		var customers = client.For<Account>().Select("ID").Where("IsSales+eq+true").Get();
		return customers.First().ID;
	}

	private static Guid GetItemId(ExactOnlineClient client)
	{
		var customers = client.For<Item>().Select("ID").Where("IsSalesItem+eq+true").Get();
		return customers.First().ID;
	}
}

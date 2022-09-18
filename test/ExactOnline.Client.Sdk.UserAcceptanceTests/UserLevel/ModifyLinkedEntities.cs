using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.Logistics;
using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel;

[TestClass]
public class ModifyLinkedEntities
{

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task UpdateLinkedEntities()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		var salesInvoiceId = CreateSalesInvoice(client, 1);

		// Fetch sales invoice including sales invoice lines
		var salesInvoice = client.For<SalesInvoice>()
			.Select("InvoiceID,SalesInvoiceLines/ID,SalesInvoiceLines/InvoiceID,SalesInvoiceLines/Description")
			.Expand("SalesInvoiceLines")
			.GetEntity(salesInvoiceId);

		var salesInvoiceLines = (List<SalesInvoiceLine>)salesInvoice.SalesInvoiceLines;
		var orginialInvoiceline = salesInvoiceLines[0];

		// The original invoice line is not managed because it's taken as related entity from the sales invoice.
		// Call the api to get a managed invoice line that can be updated.
		var managedInvoiceLine = client.For<SalesInvoiceLine>().GetEntity(orginialInvoiceline.ID);
		managedInvoiceLine.Description = string.Format("Changed On {0}", DateTime.UtcNow);

		// Update and compare
		client.For<SalesInvoiceLine>().Update(managedInvoiceLine);
		Assert.AreNotEqual(orginialInvoiceline.Description, managedInvoiceLine.Description);
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task CreateLinkedEntities()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		// Fetch sales invoice
		var salesInvoiceId = CreateSalesInvoice(client, 1);
		var salesinvoice = client.For<SalesInvoice>().GetEntity(salesInvoiceId);

		// Fetch item
		var item = client.For<Item>().Top(1).Select("ID").Where("IsSalesItem+eq+true").Get().First();

		// add line
		var invoiceline = new SalesInvoiceLine
		{
			Description = "New Sales Invoice Line",
			InvoiceID = salesinvoice.InvoiceID,
			Item = item.ID
		};
		Assert.IsTrue(client.For<SalesInvoiceLine>().Insert(ref invoiceline));
	}

	[TestMethod]
	[TestCategory("User Acceptance Tests")]
	public async Task DeleteLinkedEntities()
	{
		var client = await new TestObjectsCreator().GetClientAsync();

		// Create a sales invoice with 2 lines
		var salesInvoiceId = CreateSalesInvoice(client, 2);

		// Get one of the invoice lines
		var filter = string.Format("InvoiceID+eq+guid'{0}'", salesInvoiceId);
		var invoiceLine = client.For<SalesInvoiceLine>().Select("ID").Where(filter).Get().First();

		// Delete the line
		var deleted = client.For<SalesInvoiceLine>().Delete(invoiceLine);
		Assert.IsTrue(deleted);
	}

	private static Guid CreateSalesInvoice(ExactOnlineClient client, int numberOfLines)
	{
		var item = client.For<Item>().Top(1).Select("ID").Where("IsSalesItem+eq+true").Get().First();
		var customer = client.For<Account>().Top(1).Select("ID").Where("IsSales+eq+true").Get().First();

		var salesInvoice = new SalesInvoice
		{
			OrderedBy = customer.ID,
			Description = "SDK User level test"
		};

		var salesInvoiceLines = new List<SalesInvoiceLine>();

		for (var iterator = 0; iterator < numberOfLines; iterator++)
		{
			var salesInvoiceLine = new SalesInvoiceLine
			{
				Item = item.ID,
				Quantity = 1,
				Description = "Line " + iterator
			};

			salesInvoiceLines.Add(salesInvoiceLine);
		}
		salesInvoice.SalesInvoiceLines = salesInvoiceLines;
		client.For<SalesInvoice>().Insert(ref salesInvoice);

		return salesInvoice.InvoiceID;
	}
}

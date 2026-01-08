using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Test.Infrastructure.MockObjects;

namespace ExactOnline.Client.Sdk.UnitTests;

[TestClass]
public class EntityControllerTest
{
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	[TestCategory("Unit Test")]
	public void EntityController_Update_WithNewLinkedEntity_Succeeds()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		SalesInvoice invoice = new() { Description = "New Description" };
		EntityController entityController = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);

		// Change State
		invoice.Description = "Description2";
		SalesInvoiceLine line = new() { Description = "InvoiceLine2" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		entityController.Update(invoice);

		var data = controllerMock.Data;
		Assert.Contains(@"""Description"":""Description2""", data);
		Assert.Contains(@"""Description"":""InvoiceLine2""", data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task EntityController_Update_WithNewLinkedEntity_SucceedsAsync()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		SalesInvoice invoice = new() { Description = "New Description" };
		EntityController entityController = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);

		// Change State
		invoice.Description = "Description2";
		SalesInvoiceLine line = new() { Description = "InvoiceLine2" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		await entityController.UpdateAsync(invoice, TestContext.CancellationToken);

		var data = controllerMock.Data;
		Assert.Contains(@"""Description"":""Description2""", data);
		Assert.Contains(@"""Description"":""InvoiceLine2""", data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void EntityController_Update_WithExistingLinkedEntity_Succeeds()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		SalesInvoice invoice = new() { Description = "New Description" };
		SalesInvoiceLine line = new() { Description = "InvoiceLine" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		EntityController entityController = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);
		Assert.IsTrue(controller.AddEntityToManagedEntitiesCollection(invoice));

		// Change State
		invoice.Description = "Description2";
		line.Description = "InvoiceLine2";

		entityController.Update(invoice);
		var data = controllerMock.Data;
		Assert.AreEqual("""{"Description":"Description2","SalesInvoiceLines":[{"Description":"InvoiceLine2"}]}""", data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task EntityController_Update_WithExistingLinkedEntity_SucceedsAsync()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		SalesInvoice invoice = new() { Description = "New Description" };
		SalesInvoiceLine line = new() { Description = "InvoiceLine" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		EntityController entityController = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);
		Assert.IsTrue(controller.AddEntityToManagedEntitiesCollection(invoice));

		// Change State
		invoice.Description = "Description2";
		line.Description = "InvoiceLine2";

		await entityController.UpdateAsync(invoice, TestContext.CancellationToken);
		var data = controllerMock.Data;
		Assert.AreEqual("""{"Description":"Description2","SalesInvoiceLines":[{"Description":"InvoiceLine2"}]}""", data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void EntityController_Update_WithNoFieldsAltered_Succeeds()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		SalesInvoice invoice = new() { Description = "New Description" };
		SalesInvoiceLine line = new() { Description = "Invoice Line" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		EntityController entityController = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);
		var returnValue = controller.AddEntityToManagedEntitiesCollection(invoice);

		Assert.IsTrue(returnValue);

		entityController.Update(invoice);
		var data = controllerMock.Data;
		Assert.IsNull(data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task EntityController_Update_WithNoFieldsAltered_SucceedsAsync()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		SalesInvoice invoice = new() { Description = "New Description" };
		SalesInvoiceLine line = new() { Description = "Invoice Line" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		EntityController entityController = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);
		var returnValue = controller.AddEntityToManagedEntitiesCollection(invoice);

		Assert.IsTrue(returnValue);

		await entityController.UpdateAsync(invoice, TestContext.CancellationToken);
		var data = controllerMock.Data;
		Assert.IsNull(data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void EntityController_Update_WithOnlyLinkedEntityFieldsAltered_Succeeds()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		SalesInvoice invoice = new() { Description = "New Description" };
		SalesInvoiceLine line = new() { Description = "InvoiceLine" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		EntityController ec = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);
		Assert.IsTrue(controller.AddEntityToManagedEntitiesCollection(invoice));

		// Change State
		line.Description = "InvoiceLine2";
		ec.Update(invoice);

		var result = controllerMock.Data;
		const string expected = "{\"SalesInvoiceLines\":[{\"Description\":\"InvoiceLine2\"}]}";
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task EntityController_Update_WithOnlyLinkedEntityFieldsAltered_SucceedsAsync()
	{
		ApiConnectionEntityControllerMock controllerMock = new();
		ApiConnectorMock apiConnectorMock = new();
		ControllerList controllerList = new(apiConnectorMock, "");

		SalesInvoice invoice = new() { Description = "New Description" };
		SalesInvoiceLine line = new() { Description = "InvoiceLine" };
		invoice.SalesInvoiceLines = (List<SalesInvoiceLine>)[line];

		var controller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		EntityController ec = new(invoice, "ID", invoice.InvoiceID.ToString(), controllerMock, controller.GetEntityController);
		Assert.IsTrue(controller.AddEntityToManagedEntitiesCollection(invoice));

		// Change State
		line.Description = "InvoiceLine2";
		await ec.UpdateAsync(invoice, TestContext.CancellationToken);

		var result = controllerMock.Data;
		const string expected = "{\"SalesInvoiceLines\":[{\"Description\":\"InvoiceLine2\"}]}";
		Assert.AreEqual(expected, result);
	}
}

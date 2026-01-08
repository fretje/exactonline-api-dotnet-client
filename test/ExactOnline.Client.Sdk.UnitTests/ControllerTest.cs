using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Test.Infrastructure.MockObjects;

namespace ExactOnline.Client.Sdk.UnitTests;

[TestClass()]
public class ControllerTest
{
	IApiConnection _mockConnection = default!;

	public TestContext TestContext { get; set; } = default!;

	[TestInitialize]
	public void Setup() => _mockConnection = new ApiConnectionMock();

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Constructor_With_CorrectTypeAndConnection_Succeeds() =>
		_ = new Controller<Account>(_mockConnection);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Constructor_WithoutValidType_Fails() =>
		Assert.Throws<Exception>(() => new Controller<object>(_mockConnection));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Create_WithoutValidTypeAndConnection_Fails() =>
		Assert.Throws<ArgumentException>(() => new Controller<object>(null!));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_GetIdentifierValueForCompoundKey_ReturnsNull()
	{
		// JournalStatus has a compound key
		Controller<JournalStatusList> journalStatusController = new(_mockConnection);
		JournalStatusList journalStatus = new();

		var idValue = journalStatusController.GetIdentifierValue(journalStatus);

		Assert.IsNull(idValue);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Delete_WithEntity_Succeeds()
	{
		Controller<Account> accountController = new(_mockConnection);
		var testAccount = accountController.GetEntity("dummyGUID", "");

		// Delete Entity and Test if Entity still exists
		Assert.IsTrue(accountController.Delete(testAccount));
		Assert.IsFalse(accountController.IsManagedEntity(testAccount));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_Delete_WithEntity_SucceedsAsync()
	{
		Controller<Account> accountController = new(_mockConnection);
		var testAccount = await accountController.GetEntityAsync("dummyGUID", "", TestContext.CancellationToken);

		// Delete Entity and Test if Entity still exists
		Assert.IsTrue(await accountController.DeleteAsync(testAccount, TestContext.CancellationToken));
		Assert.IsFalse(accountController.IsManagedEntity(testAccount));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Delete_WithoutEntity_Fails()
	{
		Controller<Account> accountController = new(_mockConnection);
		Assert.Throws<ArgumentException>(() => accountController.Delete(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_Delete_WithoutEntity_FailsAsync()
	{
		Controller<Account> accountController = new(_mockConnection);
		await Assert.ThrowsAsync<ArgumentException>(() => accountController.DeleteAsync(null!, TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Get_Succeeds()
	{
		Controller<Account> accountController = new(_mockConnection);
		accountController.Get("");
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_Get_SucceedsAsync()
	{
		Controller<Account> accountController = new(_mockConnection);
		await accountController.GetAsync("", TestContext.CancellationToken);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_GetMultipleTimes_Succeeds()
	{
		Controller<Account> accountController = new(_mockConnection);

		// Get accounts again to test for double entitycontrollers
		_ = accountController.Get("");
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_GetMultipleTimes_SucceedsAsync()
	{
		Controller<Account> accountController = new(_mockConnection);

		// Get accounts again to test for double entitycontrollers
		_ = await accountController.GetAsync("", TestContext.CancellationToken);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Update_WithoutEntity_Fails()
	{
		Controller<Account> accountController = new(_mockConnection);
		Assert.Throws<ArgumentException>(() => accountController.Update(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_Update_WithoutEntity_FailsAsync()
	{
		Controller<Account> accountController = new(_mockConnection);
		await Assert.ThrowsAsync<ArgumentException>(() => accountController.UpdateAsync(null!, TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Update_WithEntity_Succeeds()
	{
		Controller<Account> accountController = new(_mockConnection);
		var testAccount = accountController.GetEntity("dummyGUID", "");
		Assert.IsTrue(accountController.Update(testAccount));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_Update_WithEntity_SucceedsAsync()
	{
		Controller<Account> accountController = new(_mockConnection);
		var testAccount = await accountController.GetEntityAsync("dummyGUID", "", TestContext.CancellationToken);
		Assert.IsTrue(await accountController.UpdateAsync(testAccount, TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Controller_Test_ManagedEntities_WithLinkedEntities_Succeeds()
	{
		// Test if controller registrates linked entities
		IApiConnector conn = new ApiConnectorControllerMock();
		ControllerList controllerList = new(conn, "");

		var salesinvoicecontroller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		var invoicelines = (Controller<SalesInvoiceLine>)controllerList.GetController<SalesInvoiceLine>();

		// Verify if sales invoice lines are registrated entities
		var invoice = salesinvoicecontroller.Get("")[0];
		var line = invoice.SalesInvoiceLines?.First();
		Assert.IsNotNull(line);
		Assert.IsTrue(invoicelines.IsManagedEntity(line), "SalesInvoiceLine isn't a managed entity");
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task Controller_Test_ManagedEntities_WithLinkedEntities_SucceedsAsync()
	{
		// Test if controller registrates linked entities
		IApiConnector conn = new ApiConnectorControllerMock();
		ControllerList controllerList = new(conn, "");

		var salesinvoicecontroller = (Controller<SalesInvoice>)controllerList.GetController<SalesInvoice>();
		var invoicelines = (Controller<SalesInvoiceLine>)controllerList.GetController<SalesInvoiceLine>();

		// Verify if sales invoice lines are registrated entities
		var invoice = (await salesinvoicecontroller.GetAsync("", TestContext.CancellationToken)).List[0];
		var line = invoice.SalesInvoiceLines?.First();
		Assert.IsNotNull(line);
		Assert.IsTrue(invoicelines.IsManagedEntity(line), "SalesInvoiceLine isn't a managed entity");
	}
}

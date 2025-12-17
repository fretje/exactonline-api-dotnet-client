using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Test.Infrastructure.MockObjects;

[assembly: DoNotParallelize]

namespace ExactOnline.Client.Sdk.UnitTests;

[TestClass]
public class ExactOnlineQueryTest
{
	Controller<Account> _acccountController = default!;
	ControllerMock<Account> _controllerMock = default!;
	ApiConnectionMock _conn = default!;

	public TestContext TestContext { get; set; }

	[TestInitialize]
	public void Setup()
	{
		_conn = new();
		_controllerMock = new();
		_acccountController = new(_conn);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_TestAnd_WithCorrectString_Succeeds()
	{
		new ExactOnlineQuery<Account>(_controllerMock)
			.Select(["Code", "Name"])
			.Where("Name+eq+'Test Testname'")
			.And("Code+eq+'123'")
			.And("Code+eq+'456'")
			.Get();

		Assert.AreEqual("$filter=Name+eq+'Test Testname'+and+Code+eq+'123'+and+Code+eq+'456'&$select=Code,Name", _controllerMock.ODataQuery);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_TestAnd_WithCorrectString_SucceedsAsync()
	{
		await new ExactOnlineQuery<Account>(_controllerMock)
			.Select(["Code", "Name"])
			.Where("Name+eq+'Test Testname'")
			.And("Code+eq+'123'")
			.And("Code+eq+'456'")
			.GetAsync(ct: TestContext.CancellationToken);

		Assert.AreEqual("$filter=Name+eq+'Test Testname'+and+Code+eq+'123'+and+Code+eq+'456'&$select=Code,Name", _controllerMock.ODataQuery);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_TestAnd_WithNoWhereClause_Fails()
	{
		_controllerMock = new();
		Assert.Throws<ArgumentException>(() =>
			new ExactOnlineQuery<Account>(_controllerMock)
				.Select(["Code", "Name"])
				.And("Code+eq+'123'")
				.Get());
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_TestAnd_WithNoWhereClause_FailsAsync()
	{
		_controllerMock = new();
		await Assert.ThrowsAsync<ArgumentException>(async () =>
			await new ExactOnlineQuery<Account>(_controllerMock)
				.Select(["Code", "Name"])
				.And("Code+eq+'123'")
				.GetAsync(ct: TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_TestAnd_WithEmptyString_Fails() =>
		Assert.Throws<ArgumentException>(() =>
			new ExactOnlineQuery<Account>(_controllerMock)
				.Select(["Code", "Name"])
				.Where("Name+eq+'Test Testname'")
				.And(string.Empty)
				.Get());

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_TestAnd_WithEmptyString_FailsAsync() =>
		await Assert.ThrowsAsync<ArgumentException>(async () =>
			await new ExactOnlineQuery<Account>(_controllerMock)
				.Select(["Code", "Name"])
				.Where("Name+eq+'Test Testname'")
				.And(string.Empty)
				.GetAsync(ct: TestContext.CancellationToken));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Delete_WithEntity_Succeeds()
	{
		ExactOnlineQuery<Account> query = new(_controllerMock);
		Assert.IsTrue(query.Delete(new Account()));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_Delete_WithEntity_SucceedsAsync()
	{
		ExactOnlineQuery<Account> query = new(_controllerMock);
		Assert.IsTrue(await query.DeleteAsync(new Account(), TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQueryDelete_WithNullEntity_Fails()
	{
		ExactOnlineQuery<Account> query = new(_controllerMock);
		Assert.Throws<ArgumentException>(() => query.Delete(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQueryDelete_WithNullEntity_FailsAsync()
	{
		ExactOnlineQuery<Account> query = new(_controllerMock);
		await Assert.ThrowsAsync<ArgumentException>(async () => await query.DeleteAsync(null!, TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQueryFor_WithExistingEntity_Succeeds() =>
		new ExactOnlineQuery<Account>(_controllerMock).Select("Code").Get();

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQueryFor_WithExistingEntity_SucceedsAsync() =>
		new ExactOnlineQuery<Account>(_controllerMock).Select("Code").GetAsync(ct: TestContext.CancellationToken);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQueryFor_WithEmptyController_Fails() =>
		Assert.Throws<ArgumentNullException>(() => new ExactOnlineQuery<Account>(null!).Get());

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQueryFor_WithEmptyController_FailsAsync() =>
		Assert.ThrowsAsync<ArgumentNullException>(() => new ExactOnlineQuery<Account>(null!).GetAsync(ct: TestContext.CancellationToken));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Get_WithoutSelect_Fails() =>
		Assert.Throws<Exception>(() => new ExactOnlineQuery<Account>(_controllerMock).Get());

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQuery_Get_WithoutSelect_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => new ExactOnlineQuery<Account>(_controllerMock).GetAsync(ct: TestContext.CancellationToken));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Get_WithSelect_Succeeds() =>
		new ExactOnlineQuery<Account>(_controllerMock).Select("Code").Get();

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_Get_WithSelect_SucceedsAsync() =>
		await new ExactOnlineQuery<Account>(_controllerMock).Select("Code").GetAsync(ct: TestContext.CancellationToken);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_GetEntity_WithIdentifier_Succeeds() =>
		new ExactOnlineQuery<Account>(_acccountController).GetEntity("asdfasdfasdfadf");

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQuery_GetEntity_WithIdentifier_SucceedsAsync() =>
		new ExactOnlineQuery<Account>(_acccountController).GetEntityAsync("asdfasdfasdfadf", TestContext.CancellationToken);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_GetEntity_WithoutIdentifier_Fails() =>
		Assert.Throws<ArgumentException>(() => new ExactOnlineQuery<Account>(_acccountController).GetEntity(string.Empty));

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQuery_GetEntity_WithoutIdentifier_FailsAsync() =>
		Assert.ThrowsAsync<ArgumentException>(() => new ExactOnlineQuery<Account>(_acccountController).GetEntityAsync(string.Empty, TestContext.CancellationToken));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Insert_WithObject_Succeeds()
	{
		Account newAccount = new();
		new ExactOnlineQuery<Account>(_controllerMock).Insert(ref newAccount);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_Insert_WithObject_SucceedsAsync()
	{
		Account newAccount = new();
		var insertedAccount = await new ExactOnlineQuery<Account>(_controllerMock).InsertAsync(newAccount, TestContext.CancellationToken);
		Assert.IsNotNull(insertedAccount);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Insert_WithNullObject_Fails()
	{
		Account? newAccount = null;
		Assert.Throws<ArgumentException>(() => new ExactOnlineQuery<Account>(_controllerMock).Insert(ref newAccount!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_Insert_WithNullObject_FailsAsync()
	{
		Account? newAccount = null;
		await Assert.ThrowsAsync<ArgumentException>(() => new ExactOnlineQuery<Account>(_controllerMock).InsertAsync(newAccount!, TestContext.CancellationToken));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Update_WithNullObject_Fails() =>
		Assert.Throws<ArgumentException>(() => new ExactOnlineQuery<Account>(_controllerMock).Update(null!));

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQuery_Update_WithNullObject_FailsAsync() =>
		Assert.ThrowsAsync<ArgumentException>(() => new ExactOnlineQuery<Account>(_controllerMock).UpdateAsync(null!, TestContext.CancellationToken));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Update_WithObject_Succeeds() =>
		new ExactOnlineQuery<Account>(_controllerMock).Update(new Account());

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQuery_Update_WithObject_SucceedsAsync() =>
		new ExactOnlineQuery<Account>(_controllerMock).UpdateAsync(new Account(), TestContext.CancellationToken);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Where_WithString_Succeeds() =>
		new ExactOnlineQuery<Account>(_controllerMock)
			.Select(["Code", "Name"])
			.Where("Name+eq+'Test Testname'")
			.Get();

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ExactOnlineQuery_Where_WithString_SucceedsAsync() =>
		new ExactOnlineQuery<Account>(_controllerMock)
			.Select(["Code", "Name"])
			.Where("Name+eq+'Test Testname'")
			.GetAsync(ct: TestContext.CancellationToken);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Where_WithEmptyString_Fails() =>
		Assert.Throws<ArgumentException>(() =>
			new ExactOnlineQuery<Account>(_controllerMock)
				.Where(string.Empty)
				.Get());

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_Where_WithEmptyString_FailsAsync() =>
		await Assert.ThrowsAsync<ArgumentException>(() =>
			new ExactOnlineQuery<Account>(_controllerMock)
				.Where(string.Empty)
				.GetAsync(ct: TestContext.CancellationToken));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_SingleSelect_Succeeds()
	{
		new ExactOnlineQuery<Account>(_controllerMock).Select("Description").Get();
		const string expected = "$select=Description";
		var query = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, query);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_SingleSelect_SucceedsAsync()
	{
		await new ExactOnlineQuery<Account>(_controllerMock).Select("Description").GetAsync(ct: TestContext.CancellationToken);
		const string expected = "$select=Description";
		var query = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, query);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_MultipleSelect_Succeeds()
	{
		var query = new ExactOnlineQuery<Account>(_controllerMock).Select(["Description", "Name"]);
		_ = query.Get();

		const string expected = "$select=Description,Name";
		var result = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_MultipleSelect_SucceedsAsync()
	{
		var query = new ExactOnlineQuery<Account>(_controllerMock).Select(["Description", "Name"]);
		_ = await query.GetAsync(ct: TestContext.CancellationToken);

		const string expected = "$select=Description,Name";
		var result = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, result);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_Top_Succeeds()
	{
		new ExactOnlineQuery<Account>(_controllerMock).Top(10).Select(["Code", "Name"]).Get();
		const string expected = "$select=Code,Name&$top=10";
		var query = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, query);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_Top_SucceedsAsync()
	{
		await new ExactOnlineQuery<Account>(_controllerMock).Top(10).Select(["Code", "Name"]).GetAsync(ct: TestContext.CancellationToken);
		const string expected = "$select=Code,Name&$top=10";
		var query = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, query);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ExactOnlineQuery_WithAllOptions_Succeeds()
	{
		_ = new ExactOnlineQuery<Account>(_controllerMock)
			.Where("Name+eq+'Test'")
			.And("Name+eq+'Test2'")
			.Select(["Description", "Name"])
			.Expand("BankAccounts")
			.Skip(10)
			.Top(10).Get();

		const string expected = "$filter=Name+eq+'Test'+and+Name+eq+'Test2'&$select=Description,Name&$skip=10&$expand=BankAccounts&$top=10";
		var data = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, data);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public async Task ExactOnlineQuery_WithAllOptions_SucceedsAsync()
	{
		_ = await new ExactOnlineQuery<Account>(_controllerMock)
			.Where("Name+eq+'Test'")
			.And("Name+eq+'Test2'")
			.Select(["Description", "Name"])
			.Expand("BankAccounts")
			.Skip(10)
			.Top(10).GetAsync("mySkiptoken", ct: TestContext.CancellationToken);

		const string expected = "$filter=Name+eq+'Test'+and+Name+eq+'Test2'&$select=Description,Name&$skip=10&$expand=BankAccounts&$top=10&$skiptoken=mySkiptoken";
		var data = _controllerMock.ODataQuery;
		Assert.AreEqual(expected, data);
	}
}

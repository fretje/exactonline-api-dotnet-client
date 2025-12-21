using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Test.Infrastructure.MockObjects;

namespace ExactOnline.Client.Sdk.UnitTests;

/// <summary>
///This is a test class for APIConnectionTest and is intended
///to contain all APIConnectionTest Unit Tests
///</summary>
[TestClass]
public class ApiConnectionTest
{
	// For test, because a valid uri is necessary 
	private const string _uri = "http://localhost/WI_143620/api/v1/";
	private const string _currentDivision = "499156";

	IApiConnector _connector = default!;
	ApiConnection _conn = default!;

	public TestContext TestContext { get; set; }

	[TestInitialize]
	public void MyTestInitialize()
	{
		_connector = new ApiConnectorMock();
		_conn = new(_connector, _uri + _currentDivision + "/crm/Accounts");
	}

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Constructor_InitializeWithEmptyValues_Fails() =>
		Assert.Throws<ArgumentException>(() => new ApiConnection(null!, string.Empty));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Constructor_CreateWithEmptyConnector_Fails() =>
		Assert.Throws<ArgumentException>(() => new ApiConnection(null!, "financial/GLAccounts"));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Constructor_CreateWithEmptyEndpoint_Fails() =>
		Assert.Throws<ArgumentException>(() => new ApiConnection(_connector, string.Empty));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Constructor_InitializeWithEmptyEndpoint_Fails() =>
		Assert.Throws<ArgumentException>(() => new ApiConnection(null!, string.Empty));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_GetEntityWithGuidSpecified_Succeeds() =>
		_conn.GetEntity("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", string.Empty);

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_GetEntityWithGuidSpecified_SucceedsAsync() =>
		_conn.GetEntityAsync("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", string.Empty, TestContext.CancellationToken);

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_GetEntity_WithoutGuidSpecified_Fails() =>
		Assert.Throws<Exception>(() => _conn.GetEntity("ID", string.Empty, string.Empty));

	[TestMethod]
	public Task ApiConnection_GetEntity_WithoutGuidSpecified_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.GetEntityAsync("ID", string.Empty, string.Empty, TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_GetEntity_WithoutKeyNameSpecified_Fails() =>
		Assert.Throws<Exception>(() => _conn.GetEntity(string.Empty, "3c634e79-c4fe-44d2-9765-00b30573c2de", string.Empty));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_GetEntity_WithoutKeyNameSpecified_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.GetEntityAsync(string.Empty, "3c634e79-c4fe-44d2-9765-00b30573c2de", string.Empty, TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_GetEntity_WithoutKeynameAndGuidSpecified_Fails() =>
		Assert.Throws<Exception>(() => _conn.GetEntity(string.Empty, string.Empty, string.Empty));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_GetEntity_WithoutKeynameAndGuidSpecified_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.GetEntityAsync(string.Empty, string.Empty, string.Empty, TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Post_TestWithoutPostData_Fails() =>
		Assert.Throws<Exception>(() => _conn.Post(""));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Post_TestWithoutPostData_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.PostAsync("", TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Post_TestWithPostData_Succeeds() =>
		_conn.Post("{Test}");

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Post_TestWithPostData_SucceedsAsync() =>
		_conn.PostAsync("{Test}", TestContext.CancellationToken);

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithoutData_Fails() =>
		Assert.Throws<Exception>(() => _conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", ""));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithoutData_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.PutAsync("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "", TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithData_Succeeds() =>
		_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "Testdata");

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithData_SucceedsAsync() =>
		_conn.PutAsync("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "Testdata", TestContext.CancellationToken);

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithoutGuid_Fails() =>
		Assert.Throws<Exception>(() => _conn.Put("ID", "", "Testdata"));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithoutGuid_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.PutAsync("ID", "", "Testdata", TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithGuid_Succeeds() =>
		_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "Testdata");

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithGuid_SucceedsAsync() =>
		_conn.PutAsync("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "Testdata", TestContext.CancellationToken);

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithoutDataAndGuid_Fails() =>
		Assert.Throws<Exception>(() => _conn.Put("ID", "", ""));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithoutDataAndGuid_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.PutAsync("ID", "", "", TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithoutDataAndGuidAndKeyname_Fails() =>
		Assert.Throws<Exception>(() => _conn.Put("", "", ""));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithoutDataAndGuidAndKeyname_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.PutAsync("", "", "", TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Put_WithDataAndGuid_Succeeds() =>
		_conn.Put("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "TestData");

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Put_WithDataAndGuid_SucceedsAsync() =>
		_conn.PutAsync("ID", "3c634e79-c4fe-44d2-9765-00b30573c2de", "TestData", TestContext.CancellationToken);

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Delete_TestWithEmptyGuid_Fails() =>
		Assert.Throws<Exception>(() => _conn.Delete("ID", ""));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Delete_TestWithEmptyGuid_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.DeleteAsync("ID", "", TestContext.CancellationToken));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnectionDeleteTestWithGuidSucceeds() =>
		_conn.Delete("ID", "GUID");

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnectionDeleteTestWithGuidSucceedsAsync() =>
		_conn.DeleteAsync("ID", "GUID", TestContext.CancellationToken);

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiConnection_Delete_TestWithEmptyGuidAndNoKeyname_Fails() =>
		Assert.Throws<Exception>(() => _conn.Delete("", ""));

	[TestCategory("Unit Test")]
	[TestMethod]
	public Task ApiConnection_Delete_TestWithEmptyGuidAndNoKeyname_FailsAsync() =>
		Assert.ThrowsAsync<Exception>(() => _conn.DeleteAsync("", "", TestContext.CancellationToken));
}

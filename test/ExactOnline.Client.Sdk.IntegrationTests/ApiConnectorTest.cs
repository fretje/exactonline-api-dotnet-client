using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.IntegrationTests;

/// <summary>
///This is a test class for RESTConnectorTest and is intended
///to contain all RESTConnectorTest Unit Tests
///</summary>
[TestClass]
public class ApiConnectorTest
{
	TestObjectsCreator _toc;
	private int _currentDivision;

	[TestInitialize]
	public async Task Setup()
	{
		_toc = new TestObjectsCreator();
		_currentDivision = await _toc.GetCurrentDivisionAsync();
	}

	#region DoRequest Tests
	/// <summary>
	///A test for Do Request
	///</summary>
	[TestCategory("Integration Tests")]
	[TestMethod]
	public void DoRequest_DoNormalRequest_Succeeds()
	{
		var connector = _toc.GetApiConnector();
		connector.DoGetRequest(TestObjectsCreator.UriGlAccount(_currentDivision), string.Empty);
	}

	/// <summary>
	/// Test if a user can do a request without a endpoint specified
	/// </summary>
	[TestCategory("Integration Tests")]
	[TestMethod, ExpectedException(typeof(BadRequestException))]
	public void DoGetRequest_WithoutEndpoint_ThrowsExcepion()
	{
		var connector = _toc.GetApiConnector();
		connector.DoGetRequest(null, string.Empty);
	}

	/// <summary>
	/// Test if a get request can be made without a valid divisionnumber
	/// </summary>
	[TestCategory("Integration Tests")]
	[TestMethod, ExpectedException(typeof(ForbiddenException))]
	public void DoGetRequest_WithWrongDivisionNumber_ThrowsException()
	{
		var connector = _toc.GetApiConnector();
		connector.DoGetRequest(TestObjectsCreator.UriCrmAccount(999), string.Empty);
	}
	#endregion

	#region Put Tests

	[TestMethod, ExpectedException(typeof(BadRequestException))]
	[TestCategory("Integration Tests")]
	public void DoPutRequestWithoutGuid_ThrowsException()
	{
		const string putData = "{\"Description\":\"Test\"}";
		var connector = _toc.GetApiConnector();
		connector.DoPutRequest(TestObjectsCreator.UriGlAccount(_currentDivision), putData);
	}

	[TestMethod, ExpectedException(typeof(BadRequestException))]
	[TestCategory("Integration Tests")]
	public void DoPutRequestWithoutData_ThrowsException()
	{
		const string id = "3c534e79-c4fe-44d2-9765-00b30573c2de";
		const string putData = "";
		var endpoint = string.Format("{0}(guid'{1}')", TestObjectsCreator.UriGlAccount(_currentDivision), id);
		var connector = _toc.GetApiConnector();
		connector.DoPutRequest(endpoint, putData);
	}
	#endregion

	#region Delete Tests

	[TestMethod, ExpectedException(typeof(ForbiddenException))]
	[TestCategory("Integration Tests")]
	public void DoDeleteRequestWithNonExistingGuid_ThrowsException()
	{
		var connector = _toc.GetApiConnector();
		connector.DoDeleteRequest(TestObjectsCreator.UriGlAccount(_currentDivision) + "(guid'223F2BDD-5BD3-4CAC-8E46-1CA28C5A01F2')");
	}

	[TestMethod, ExpectedException(typeof(BadRequestException))]
	[TestCategory("Integration Tests")]
	public void DoDeleteRequestWithoutGuid_ThrowsException()
	{
		var connector = _toc.GetApiConnector();
		connector.DoDeleteRequest(TestObjectsCreator.UriGlAccount(_currentDivision));
	}
	#endregion

	#region Post Tests

	// Commented out because this only makes an entity. The next time it will run, it will try to make an entity with the same code
	[TestMethod, Ignore]
	[TestCategory("Integration Tests")]
	public void DoPostRequestWithData_Succeeds()
	{
		const string postdata = "{\"Code\":\"12368846846\",\"Description\":\"Test\"}";
		var connector = _toc.GetApiConnector();
		connector.DoPostRequest(TestObjectsCreator.UriGlAccount(_currentDivision), postdata);
	}

	// Ignored because this is too low level test
	[TestMethod, ExpectedException(typeof(InternalServerErrorException)), Ignore]
	[TestCategory("Integration Tests")]
	public void DoPostRequestWithExistingCode_Succeeds()
	{
		const string postdata = "{\"Code\":\"123\",\"Description\":\"Test\"}";
		var connector = _toc.GetApiConnector();
		connector.DoPostRequest(TestObjectsCreator.UriGlAccount(_currentDivision), postdata);
	}

	[TestMethod, ExpectedException(typeof(BadRequestException))]
	[TestCategory("Integration Tests")]
	public void DoPostRequestWithoutData_ThrowsException()
	{
		const string postdata = "";
		var connector = _toc.GetApiConnector();
		connector.DoPostRequest(TestObjectsCreator.UriGlAccount(_currentDivision), postdata);
	}
	#endregion
}

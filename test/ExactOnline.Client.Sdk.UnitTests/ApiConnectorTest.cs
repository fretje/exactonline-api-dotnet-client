using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Test.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UnitTests;

[TestClass]
public class ApiConnectorTest
{
	ApiConnector _connector;

	private static Task<string> GetAccessToken(CancellationToken ct) => Task.FromResult("accessToken");

	[TestInitialize]
	public void Setup()
	{
		_connector = new ApiConnector(GetAccessToken, new HttpClient(), ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
		_connector.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
	}

	[TestMethod]
	[TestCategory("Unit Test"), ExpectedException(typeof(ArgumentNullException))]
	public void ApiConnector_Constructor_WithoutDelegate_Fails() =>
		_ = new ApiConnector(null, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);

	[TestMethod]
	[TestCategory("Unit Test"), ExpectedException(typeof(ArgumentNullException))]
	public void ApiConnector_Constructor_WithoutHttpClient_Fails() =>
		_ = new ApiConnector(GetAccessToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ApiConnector_Constructor_WithDelegateAndHttpClient_Succeeds() =>
		_ = new ApiConnector(GetAccessToken, new HttpClient(), ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);

	[TestMethod]
	[TestCategory("Unit Test"), ExpectedException(typeof(BadRequestException))]
	public void ApiConnector_DoDeleteRequest_With_EmptyValues_Fails() =>
		_connector.DoDeleteRequest(string.Empty);

	[TestMethod]
	[TestCategory("Unit Test"), ExpectedException(typeof(BadRequestException))]
	public async Task ApiConnector_DoDeleteRequest_With_EmptyValues_FailsAsync() =>
		await _connector.DoDeleteRequestAsync(string.Empty, default);
}

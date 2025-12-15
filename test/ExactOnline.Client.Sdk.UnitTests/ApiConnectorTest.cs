using System.Net.Http;
using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace ExactOnline.Client.Sdk.UnitTests;

[TestClass]
public class ApiConnectorTest
{
	ApiConnector _connector;

	private static Task<string> GetAccessToken(CancellationToken ct) => Task.FromResult("accessToken");

	[TestInitialize]
	public void Setup()
	{
		_connector = new ApiConnector(GetAccessToken, new HttpClient(), ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage);
		_connector.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ApiConnector_Constructor_WithoutDelegate_Fails() =>
		Assert.Throws<ArgumentNullException>(() => new ApiConnector(null, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ApiConnector_Constructor_WithoutHttpClient_Fails() =>
		Assert.Throws<ArgumentNullException>(() => new ApiConnector(GetAccessToken, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ApiConnector_Constructor_WithDelegateAndHttpClient_Succeeds() =>
		_ = new ApiConnector(GetAccessToken, new HttpClient(), ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage);

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ApiConnector_DoDeleteRequest_With_EmptyValues_Fails() =>
		Assert.Throws<BadRequestException>(() => _connector.DoDeleteRequest(string.Empty));

	[TestMethod]
	[TestCategory("Unit Test")]
	public Task ApiConnector_DoDeleteRequest_With_EmptyValues_FailsAsync() =>
		Assert.ThrowsAsync<BadRequestException>(() => _connector.DoDeleteRequestAsync(string.Empty, default));
}

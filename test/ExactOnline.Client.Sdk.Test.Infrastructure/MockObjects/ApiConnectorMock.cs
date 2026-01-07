using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Test.Infrastructure.MockObjects;

/// <summary>
/// Simulates APIConnector class
/// </summary>
public class ApiConnectorMock : IApiConnector
{
	public string DoGetRequest(string endpoint, string? parameters) => "";
	public Task<string> DoGetRequestAsync(string endpoint, string? parameters, CancellationToken ct) => Task.FromResult(DoGetRequest(endpoint, parameters));

	public Stream DoGetFileRequest(string endpointy) => Stream.Null;
	public Task<Stream> DoGetFileRequestAsync(string endpointy, CancellationToken ct) => Task.FromResult(DoGetFileRequest(endpointy));

	public string DoPostRequest(string endpoint, string postdata) => "";
	public Task<string> DoPostRequestAsync(string endpoint, string postdata, CancellationToken ct) => Task.FromResult(DoPostRequest(endpoint, postdata));

	public string DoPutRequest(string endpoint, string putData) => "";
	public Task<string> DoPutRequestAsync(string endpoint, string putData, CancellationToken ct) => Task.FromResult(DoPutRequest(endpoint, putData));

	public string DoDeleteRequest(string endpoint) => "";
	public Task<string> DoDeleteRequestAsync(string endpoint, CancellationToken ct) => Task.FromResult(DoDeleteRequest(endpoint));

	public string DoCleanRequest(string endpoint, string? oDataQuery)
	{
		if (endpoint.EndsWith("/$count"))
		{
			return "42";
		}

		return "";
	}

	public Task<string> DoCleanRequestAsync(string endpoint, string? oDataQuery, CancellationToken ct) => Task.FromResult(DoCleanRequest(endpoint, oDataQuery));
}

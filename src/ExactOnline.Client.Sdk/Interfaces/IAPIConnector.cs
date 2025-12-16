namespace ExactOnline.Client.Sdk.Interfaces;

public interface IApiConnector
{
	string DoGetRequest(string endpoint, string? parameters);
	Task<string> DoGetRequestAsync(string endpoint, string? parameters, CancellationToken ct = default);

	Stream DoGetFileRequest(string endpoint);
	Task<Stream> DoGetFileRequestAsync(string endpoint, CancellationToken ct = default);

	string DoPostRequest(string endpoint, string postdata);
	Task<string> DoPostRequestAsync(string endpoint, string postdata, CancellationToken ct = default);

	string DoPutRequest(string endpoint, string putData);
	Task<string> DoPutRequestAsync(string endpoint, string putData, CancellationToken ct = default);

	string DoDeleteRequest(string endpoint);
	Task<string> DoDeleteRequestAsync(string endpoint, CancellationToken ct = default);

	string DoCleanRequest(string endpoint, string? parameters); // Request without Content-Type for $count function, including parameters
	Task<string> DoCleanRequestAsync(string endpoint, string? parameters, CancellationToken ct = default); // Request without Content-Type for $count function, including parameters
}

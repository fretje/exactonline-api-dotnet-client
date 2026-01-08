using System.Net;
using OAuth2.Client;
using RestSharp;

namespace OAuth2.Infrastructure;

public static class RestClientExtensions
{
	static RestResponse VerifyResponse(RestResponse response)
	{
		if (string.IsNullOrWhiteSpace(response.Content)
			|| (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created))
		{
			throw new UnexpectedResponseException(response);
		}

		return response;
	}

	public static async Task<RestResponse> ExecuteAndVerifyAsync(this RestClient client, RestRequest request, CancellationToken ct = default) =>
		VerifyResponse(await client.ExecuteAsync(request, ct).ConfigureAwait(false));
}

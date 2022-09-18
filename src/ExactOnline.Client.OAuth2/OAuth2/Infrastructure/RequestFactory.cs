using RestSharp;

namespace OAuth2.Infrastructure;

/// <summary>
/// Default implementation of <see cref="IRequestFactory"/>.
/// </summary>
public class RequestFactory : IRequestFactory
{
	/// <summary>
	/// Returns new REST client instance.
	/// </summary>
	public RestClient CreateClient(string baseUrl) => new(baseUrl);

	/// <summary>
	/// Returns new REST request instance.
	/// </summary>
	public RestRequest CreateRequest() => new();
}

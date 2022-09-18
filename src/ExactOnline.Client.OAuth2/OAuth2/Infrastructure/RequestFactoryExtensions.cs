using OAuth2.Client;
using RestSharp;

namespace OAuth2.Infrastructure;

public static class RequestFactoryExtensions
{
	public static RestClient CreateClient(this IRequestFactory factory, Endpoint endpoint) =>
		factory.CreateClient(endpoint.BaseUri);

	public static RestRequest CreateRequest(this IRequestFactory factory, Endpoint endpoint) =>
			CreateRequest(factory, endpoint, Method.Get);

	public static RestRequest CreateRequest(this IRequestFactory factory, Endpoint endpoint, Method method)
	{
		var request = factory.CreateRequest();
		request.Resource = endpoint.Resource;
		request.Method = method;
		return request;
	}
}

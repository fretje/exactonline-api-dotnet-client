using System.Collections.Specialized;
using OAuth2.Client;

namespace OAuth2.Infrastructure;

public static class NameValueCollectionExtensions
{
	public static string GetOrThrowUnexpectedResponse(this NameValueCollection collection, string key)
	{
		var value = collection[key];
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new UnexpectedResponseException(key);
		}
		return value;
	}
}

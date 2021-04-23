using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExactOnline.Client.OAuth
{
	public static class UserAuthorizations
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="authorization"></param>
		/// <param name="website"></param>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="redirectUri"></param>
		/// <param name="throwExceptionIfNotAuthorized">Indicates if an exception should be thrown when not authorized. When
		/// this value is true an exception is thrown if not authorized, when false a login dialog is shown to allow a user to login.</param>
		public static void ProcessAuthorization(HttpClient httpClient, UserAuthorization authorization, string website, string clientId, string clientSecret, Uri redirectUri, bool throwExceptionIfNotAuthorized = false)
		{
			var oAuthClient = CreateOAuthClient(httpClient, website, clientId, clientSecret, redirectUri);

			oAuthClient.Authorize(authorization, throwExceptionIfNotAuthorized);
		}

		public static async Task<Uri> GetUriIfAuthorizationNeeded(HttpClient httpClient, UserAuthorization authorization, string website, string clientId, string clientSecret, Uri redirectUri)
		{
			var oAuthClient = CreateOAuthClient(httpClient, website, clientId, clientSecret, redirectUri);

			var authNeeded = await oAuthClient.IsAuthorizationNeeded(authorization);
			if (authNeeded)
			{
				return oAuthClient.GetAuthorizationUri();
			}
			return null;
		}

		private static OAuthClient CreateOAuthClient(HttpClient httpClient, string website, string clientId, string clientSecret, Uri redirectUri)
		{
			Uri authorizationEndpoint = new Uri(string.Format("{0}/api/oauth2/auth", website));
			Uri tokenEndpoint = new Uri(string.Format("{0}/api/oauth2/token", website));
			return new OAuthClient(httpClient, authorizationEndpoint, tokenEndpoint, clientId, clientSecret, redirectUri);
		}
	}
}

using ExactOnline.Client.OAuth.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExactOnline.Client.OAuth
{
	public class OAuthClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly Uri _authorizationEndpoint;
		private readonly Uri _tokenEndpoint;
		private readonly Uri _redirectUri;

		public OAuthClient(HttpClient httpClient, Uri authorizationEndpoint, Uri tokenEndpoint, string clientId, string clientSecret, Uri redirectUri)
		{
			_httpClient = httpClient;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_authorizationEndpoint = authorizationEndpoint;
			_tokenEndpoint = tokenEndpoint;
			_redirectUri = redirectUri;
		}

		public void Authorize(UserAuthorization authorization, bool throwExceptionIfNotAuthorized)
		{
			if (IsAuthorizationNeeded(authorization).Result)
			{
				if (throwExceptionIfNotAuthorized)
				{
					//Throw an exception if a login dialog cannot be shown, for example the client is used in server side
					//code and cannot show a dialog to the user. This way the calling code can handle the exception and implement
					//it's own login dialog
					throw new UnauthorizedAccessException("Not authorized to use Exact Online API.");
				}
				else
				{
					using (var loginDialog = new LoginForm(_redirectUri))
					{
						loginDialog.AuthorizationUri = GetAuthorizationUri();
						loginDialog.ShowDialog();
						var success = ProcessAuthorisationCodeGrant(loginDialog.AuthorizationUri, authorization).Result;
					}
				}
			}
		}

		public async Task<bool> IsAuthorizationNeeded(UserAuthorization authorization)
		{
			if (authorization is null)
			{
				throw new ArgumentNullException(nameof(authorization));
			}

			var refreshFailed = false;
			if (AccessTokenHasToBeRefreshed(authorization))
			{
				refreshFailed = !(await RefreshAuthorization(authorization));
			}
			return authorization.AccessToken == null || refreshFailed;
		}

		private async Task<bool> RefreshAuthorization(UserAuthorization authorization)
		{
			var parameters = new Dictionary<String, String>
			{
				{ "refresh_token", authorization.RefreshToken },
				{ "grant_type", "refresh_token" },
				{ "client_id", _clientId },
				{ "client_secret", _clientSecret }
			};
			return await SendTokenRequest(authorization, parameters).ConfigureAwait(false);
		}

		private async Task<bool> ProcessAuthorisationCodeGrant(Uri authorizationUri, UserAuthorization authorization)
		{
			var query = QueryHelpers.ParseQuery(authorizationUri.Query);
			var parameters = new Dictionary<String, String>
			{
				{ "code", query["code"].Single()},
				{ "grant_type", "authorization_code" },
				{  "redirect_uri", _redirectUri.ToString() },
				{ "client_id", _clientId },
				{ "client_secret", _clientSecret }
			};
			return await SendTokenRequest(authorization, parameters).ConfigureAwait(false);
		}

		private async Task<bool> SendTokenRequest(UserAuthorization authorization, Dictionary<string, string> parameters)
		{
			var content = new FormUrlEncodedContent(parameters);
			using (HttpResponseMessage response = await _httpClient.PostAsync(_tokenEndpoint, content).ConfigureAwait(false))
			{
				if (response.StatusCode != HttpStatusCode.OK)
				{
					//The refreshtoken is not valid anymore
					return false;
				}
				var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				var authResult = JsonConvert.DeserializeObject<OAuthTokenResult>(result);
				authorization.AccessToken = authResult.AccessToken;
				authorization.RefreshToken = authResult.RefreshToken;
				authorization.AccessTokenExpiration = response.Headers.Date.Value.AddSeconds(authResult.ExpiresIn);
				return true;
			}
		}

		private static bool AccessTokenHasToBeRefreshed(UserAuthorization authorization)
		{
			if (authorization.AccessToken == null && authorization.RefreshToken != null)
			{
				return true;
			}

			if (authorization.AccessTokenExpiration != null)
			{
				var timeToExpire = authorization.AccessTokenExpiration.Value - DateTime.UtcNow;
				return timeToExpire.Minutes < 1;
			}
			return false;
		}

		public Uri GetAuthorizationUri()
		{
			var baseUri = _authorizationEndpoint;
			var parameters = new Dictionary<String, String>
			{
				{ "client_id", _clientId },
				{ "redirect_uri", _redirectUri.ToString() },
				{ "response_type", "code" },
				{ "force_login", "1" }
			};
			var authorizationUri = QueryHelpers.AddQueryString(baseUri.ToString(), parameters);
			return new Uri(authorizationUri);
		}
	}
}

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExactOnline.Client.OAuth
{
	public class RefreshTokenUpdatedEventArgs : EventArgs
	{
		public RefreshTokenUpdatedEventArgs(string newRefreshToken) =>
			NewRefreshToken = newRefreshToken;

		public string NewRefreshToken { get; }
	}

	public class AccessTokenUpdatedEventArgs : EventArgs
	{
		public AccessTokenUpdatedEventArgs(
			string newAccessToken, DateTimeOffset? newAccessTokenExpiration) =>
			(NewAccessToken, NewAccessTokenExpiration) =
			(newAccessToken, newAccessTokenExpiration);

		public string NewAccessToken { get; }
		public DateTimeOffset? NewAccessTokenExpiration { get; }
	}

	public class AnyTokenUpdatedEventArgs : EventArgs
	{
		public AnyTokenUpdatedEventArgs(
			string newRefreshToken, string newAccessToken, DateTimeOffset? newAccessTokenExpiration) =>
			(NewAccessToken, NewAccessTokenExpiration, NewRefreshToken) =
			(newAccessToken, newAccessTokenExpiration, newRefreshToken);

		public string NewRefreshToken { get; }
		public string NewAccessToken { get; }
		public DateTimeOffset? NewAccessTokenExpiration { get; }
	}

	public class ExactOnlineAuthorizer
	{
		private readonly HttpClient _httpClient;
		private readonly string _exactOnlineUrl;
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly Uri _callbackUrl;
		private readonly UserAuthorization _authorization;

		public ExactOnlineAuthorizer(HttpClient httpClient, string exactOnlineUrl, string clientId, string clientSecret, Uri callbackUrl,
			string refreshToken = null, string accessToken = null, DateTimeOffset? accessTokenExpiration = null)
		{
			_httpClient = httpClient;
			_exactOnlineUrl = exactOnlineUrl;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_callbackUrl = callbackUrl;
			_authorization = new UserAuthorization
			{
				RefreshToken = refreshToken,
				AccessToken = accessToken,
				AccessTokenExpiration = accessTokenExpiration
			};
		}

		public ExactOnlineAuthorizer(string exactOnlineUrl, string clientId, string clientSecret, Uri callbackUrl,
			string refreshToken = null, string accessToken = null, DateTime? accessTokenExpirationUtc = null)
			: this(new HttpClient(), exactOnlineUrl, clientId, clientSecret, callbackUrl, refreshToken, accessToken, accessTokenExpirationUtc)
		{
		}

		public event EventHandler<RefreshTokenUpdatedEventArgs> RefreshTokenUpdated;
		public event EventHandler<AccessTokenUpdatedEventArgs> AccessTokenUpdated;
		public event EventHandler<AnyTokenUpdatedEventArgs> AnyTokenUpdated;

		public async Task<Uri> GetUriIfAuthorizationNeeded()
		{
			var refreshToken = _authorization.RefreshToken;
			var accessToken = _authorization.AccessToken;

			var uri = await UserAuthorizations.GetUriIfAuthorizationNeeded(_httpClient, _authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl);

			FireUpdatedEvents(refreshToken, accessToken);

			return uri;
		}

		public void ProcessAuthorization(Uri actualRedirectUrl)
		{
			var refreshToken = _authorization.RefreshToken;
			var accessToken = _authorization.AccessToken;

			UserAuthorizations.ProcessAuthorization(_httpClient, _authorization, _exactOnlineUrl, _clientId, _clientSecret, actualRedirectUrl);

			FireUpdatedEvents(refreshToken, accessToken);
		}

		public string GetAccessToken()
		{
			ProcessAuthorization(_callbackUrl);

			return _authorization.AccessToken;
		}

		private void FireUpdatedEvents(string oldRefreshToken, string oldAccessToken)
		{
			if (_authorization.RefreshToken != oldRefreshToken)
			{
				OnRefreshTokenUpdated(_authorization.RefreshToken);
			}
			if (_authorization.AccessToken != oldAccessToken)
			{
				OnAccessTokenUpdated(_authorization.AccessToken, _authorization.AccessTokenExpiration);
			}
			if (_authorization.RefreshToken != oldRefreshToken || _authorization.AccessToken != oldAccessToken)
			{
				OnAnyTokenUpdated(_authorization.RefreshToken, _authorization.AccessToken, _authorization.AccessTokenExpiration);
			}
		}

		protected virtual void OnRefreshTokenUpdated(string newRefreshToken) =>
			RefreshTokenUpdated?.Invoke(this, new RefreshTokenUpdatedEventArgs(newRefreshToken));
		protected virtual void OnAccessTokenUpdated(string newAccessToken, DateTimeOffset? newAccessTokenExpiration) =>
			AccessTokenUpdated?.Invoke(this, new AccessTokenUpdatedEventArgs(newAccessToken, newAccessTokenExpiration));
		protected virtual void OnAnyTokenUpdated(string newRefreshToken, string newAccessToken, DateTimeOffset? newAccessTokenExpiration) =>
			AnyTokenUpdated?.Invoke(this, new AnyTokenUpdatedEventArgs(newRefreshToken, newAccessToken, newAccessTokenExpiration));
	}
}

using System;
using System.Threading;
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
			string newAccessToken, DateTime? newAccessTokenExpirationUtc) =>
			(NewAccessToken, NewAccessTokenExpirationUtc) =
			(newAccessToken, newAccessTokenExpirationUtc);

		public string NewAccessToken { get; }
		public DateTime? NewAccessTokenExpirationUtc { get; }
	}

	public class AnyTokenUpdatedEventArgs : EventArgs
	{
		public AnyTokenUpdatedEventArgs(
			string newRefreshToken, string newAccessToken, DateTime? newAccessTokenExpirationUtc) =>
			(NewAccessToken, NewAccessTokenExpirationUtc, NewRefreshToken) =
			(newAccessToken, newAccessTokenExpirationUtc, newRefreshToken);

		public string NewRefreshToken { get; }
		public string NewAccessToken { get; }
		public DateTime? NewAccessTokenExpirationUtc { get; }
	}

	public class ExactOnlineAuthorizer
	{
		private readonly string _exactOnlineUrl;
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly Uri _callbackUrl;
		private readonly UserAuthorization _authorization;

		public ExactOnlineAuthorizer(string exactOnlineUrl, string clientId, string clientSecret, Uri callbackUrl,
			string refreshToken = null, string accessToken = null, DateTime? accessTokenExpirationUtc = null)
		{
			_exactOnlineUrl = exactOnlineUrl;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_callbackUrl = callbackUrl;
			_authorization = new UserAuthorization
			{
				RefreshToken = refreshToken,
				AccessToken = accessToken,
				AccessTokenExpirationUtc = accessTokenExpirationUtc
			};
		}

		public event EventHandler<RefreshTokenUpdatedEventArgs> RefreshTokenUpdated;
		public event EventHandler<AccessTokenUpdatedEventArgs> AccessTokenUpdated;
		public event EventHandler<AnyTokenUpdatedEventArgs> AnyTokenUpdated;

		public bool IsAuthorizationNeeded(out Uri authorizationUrl)
		{
			var refreshToken = _authorization.RefreshToken;
			var accessToken = _authorization.AccessToken;

			var authNeeded = UserAuthorizations.IsAuthorizationNeeded(_authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl, out authorizationUrl);

			FireUpdatedEvents(refreshToken, accessToken);

			return authNeeded;
		}

		public void ProcessAuthorization(Uri actualRedirectUrl)
		{
			var refreshToken = _authorization.RefreshToken;
			var accessToken = _authorization.AccessToken;

			UserAuthorizations.ProcessAuthorization(_authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl, actualRedirectUrl);

			FireUpdatedEvents(refreshToken, accessToken);
		}

		public Task<string> GetAccessTokenAsync(CancellationToken ct)
		{
			var refreshToken = _authorization.RefreshToken;
			var accessToken = _authorization.AccessToken;

			UserAuthorizations.Authorize(_authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl);

			FireUpdatedEvents(refreshToken, accessToken);

			return Task.FromResult(_authorization.AccessToken);
		}

		private void FireUpdatedEvents(string oldRefreshToken, string oldAccessToken)
		{
			if (_authorization.RefreshToken != oldRefreshToken)
			{
				OnRefreshTokenUpdated(_authorization.RefreshToken);
			}
			if (_authorization.AccessToken != oldAccessToken)
			{
				OnAccessTokenUpdated(_authorization.AccessToken, _authorization.AccessTokenExpirationUtc);
			}
			if (_authorization.RefreshToken != oldRefreshToken || _authorization.AccessToken != oldAccessToken)
			{
				OnAnyTokenUpdated(_authorization.RefreshToken, _authorization.AccessToken, _authorization.AccessTokenExpirationUtc);
			}
		}

		protected virtual void OnRefreshTokenUpdated(string newRefreshToken) =>
			RefreshTokenUpdated?.Invoke(this, new RefreshTokenUpdatedEventArgs(newRefreshToken));
		protected virtual void OnAccessTokenUpdated(string newAccessToken, DateTime? newAccessTokenExpirationUtc) =>
			AccessTokenUpdated?.Invoke(this, new AccessTokenUpdatedEventArgs(newAccessToken, newAccessTokenExpirationUtc));
		protected virtual void OnAnyTokenUpdated(string newRefreshToken, string newAccessToken, DateTime? newAccessTokenExpirationUtc) =>
			AnyTokenUpdated?.Invoke(this, new AnyTokenUpdatedEventArgs(newRefreshToken, newAccessToken, newAccessTokenExpirationUtc));
	}
}

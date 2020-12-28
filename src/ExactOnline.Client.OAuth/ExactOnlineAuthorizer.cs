using System;

namespace ExactOnline.Client.OAuth
{
	public class RefreshTokenUpdatedEventArgs : EventArgs
	{
		public RefreshTokenUpdatedEventArgs(string newRefreshToken) =>
			NewRefreshToken = newRefreshToken;

		public string NewRefreshToken { get; }
	}

	public class ExactOnlineAuthorizer
	{
		private readonly string _exactOnlineUrl;
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly Uri _callbackUrl;
		private readonly UserAuthorization _authorization;

		public ExactOnlineAuthorizer(string exactOnlineUrl, string clientId, string clientSecret, Uri callbackUrl, string refreshToken = null)
		{
			_exactOnlineUrl = exactOnlineUrl;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_callbackUrl = callbackUrl;
			_authorization = new UserAuthorization
			{
				RefreshToken = refreshToken
			};
		}

		public event EventHandler<RefreshTokenUpdatedEventArgs> RefreshTokenUpdated;

		public bool IsAuthorizationNeeded(out Uri authorizationUrl)
		{
			var refreshToken = _authorization.RefreshToken;

			var authNeeded = UserAuthorizations.IsAuthorizationNeeded(_authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl, out authorizationUrl);

			if (_authorization.RefreshToken != refreshToken)
			{
				OnRefreshTokenUpdated(_authorization.RefreshToken);
			}

			return authNeeded;
		}

		public void ProcessAuthorization(Uri actualRedirectUrl)
		{
			var refreshToken = _authorization.RefreshToken;

			UserAuthorizations.ProcessAuthorization(_authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl, actualRedirectUrl);

			if (_authorization.RefreshToken != refreshToken)
			{
				OnRefreshTokenUpdated(_authorization.RefreshToken);
			}
		}

		public string GetAccessToken()
		{
			var refreshToken = _authorization.RefreshToken;

			UserAuthorizations.Authorize(_authorization, _exactOnlineUrl, _clientId, _clientSecret, _callbackUrl);

			if (_authorization.RefreshToken != refreshToken)
			{
				OnRefreshTokenUpdated(_authorization.RefreshToken);
			}

			return _authorization.AccessToken;
		}

		protected virtual void OnRefreshTokenUpdated(string newRefreshToken) =>
			RefreshTokenUpdated?.Invoke(this, new RefreshTokenUpdatedEventArgs(newRefreshToken));
	}
}

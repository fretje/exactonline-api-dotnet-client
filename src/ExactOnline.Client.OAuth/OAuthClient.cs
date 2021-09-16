using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth2;
using System;

namespace ExactOnline.Client.OAuth
{
	public class OAuthClient : UserAgentClient
    {
        private readonly Uri _redirectUri;

        public OAuthClient(AuthorizationServerDescription serverDescription, string clientId, string clientSecret, Uri redirectUri)
            : base(serverDescription, clientId, clientSecret)
        {
            _redirectUri = redirectUri;
            ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(clientSecret);
        }

        public void Authorize(ref IAuthorizationState authorization, string refreshToken) =>
			Authorize(ref authorization, refreshToken, false);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="authorization"></param>
		/// <param name="refreshToken"></param>
		/// <param name="throwExceptionIfNotAuthorized">Indicates if an exception should be thrown when not authorized. When
		/// this value is true an exception is thrown if not authorized, when false a login dialog is shown to allow a user to login.</param>
		public void Authorize(ref IAuthorizationState authorization, string refreshToken, bool throwExceptionIfNotAuthorized)
		{
			if (IsAuthorizationNeeded(ref authorization, refreshToken, out var authorizationUri))
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
						loginDialog.AuthorizationUri = authorizationUri;
						loginDialog.ShowDialog();
						ProcessUserAuthorization(loginDialog.AuthorizationUri, authorization);
					}
				}
			}
		}

		public bool IsAuthorizationNeeded(ref IAuthorizationState authorization, string refreshToken, out Uri authorizationUri)
		{
			if (authorization == null)
			{
				authorization = new AuthorizationState();
			}

			authorization.Callback = _redirectUri;
			authorization.RefreshToken = refreshToken;

			var refreshFailed = false;
			if (AccessTokenHasToBeRefreshed(authorization))
			{
				try
				{
					refreshFailed = !RefreshAuthorization(authorization);
				}
				catch (ProtocolException)
				{
					//The refreshtoken is not valid anymore
				}
			}

			if (authorization.AccessToken == null || refreshFailed)
			{
				authorizationUri = GetAuthorizationUri(authorization);
				return true;
			}

			authorizationUri = null;
			return false;
		}

		public IAuthorizationState ProcessAuthorization(Uri actualRedirectUri, IAuthorizationState authorization)
		{
			if (authorization == null)
			{
				authorization = new AuthorizationState();
			}

			authorization.Callback = _redirectUri;

			return ProcessUserAuthorization(actualRedirectUri, authorization);
		}

		private static bool AccessTokenHasToBeRefreshed(IAuthorizationState authorization)
        {
            if (authorization.AccessToken == null && authorization.RefreshToken != null)
            {
                return true;
            }

            if (authorization.AccessTokenExpirationUtc != null)
            {
                var timeToExpire = authorization.AccessTokenExpirationUtc.Value.Subtract(DateTime.UtcNow);
                return timeToExpire.Seconds < 30;
            }
            return false;
        }

        private Uri GetAuthorizationUri(IAuthorizationState authorization)
        {
            var baseUri = RequestUserAuthorization(authorization);

            var authorizationUriBuilder = new UriBuilder(baseUri)
            {
                Query = baseUri.Query.Substring(1) + "&force_login=1"
            };

            return authorizationUriBuilder.Uri;
        }
    }
}

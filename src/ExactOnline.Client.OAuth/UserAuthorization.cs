using DotNetOpenAuth.OAuth2;
using System;

namespace ExactOnline.Client.OAuth
{
    public class UserAuthorization
    {
        public UserAuthorization() => AuthorizationState = new AuthorizationState();

		public string RefreshToken
        {
            get => AuthorizationState.RefreshToken;
            set => AuthorizationState.RefreshToken = value;
        }

		public string AccessToken
		{
			get => AuthorizationState.AccessToken;
			set => AuthorizationState.AccessToken = value;
		}

		public DateTime? AccessTokenExpirationUtc
		{
			get => AuthorizationState.AccessTokenExpirationUtc;
			set => AuthorizationState.AccessTokenExpirationUtc = value;
		}

        public IAuthorizationState AuthorizationState { get; set; }
    }
}

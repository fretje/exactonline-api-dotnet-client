using DotNetOpenAuth.OAuth2;

namespace ExactOnline.Client.OAuth
{
    public class UserAuthorization
    {
        public UserAuthorization() => AuthorizationState = new AuthorizationState();

        public string AccessToken => AuthorizationState.AccessToken;

        public string RefreshToken
        {
            get => AuthorizationState.RefreshToken;
            set => AuthorizationState.RefreshToken = value;
        }

        public IAuthorizationState AuthorizationState { get; set; }
    }
}

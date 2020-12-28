using ExactOnline.Client.OAuth;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.TestContext
{
    public class TestObjectsCreator
    {
        public static string ExactOnlineUrl => "https://start.exactonline.be";
        public static string UriGlAccount(int currentDivision) => $"{ExactOnlineUrl}/api/v1/{currentDivision}/financial/GLAccounts";
        public static string UriCrmAccount(int currentDivision) => $"{ExactOnlineUrl}/api/v1/{currentDivision}/crm/Accounts";
        public static string SpecificGLAccountDescription => "Gebouwen";
        public static string SpecificGLAccountCode => "221000";

        private readonly static UserAuthorization _authorization = new UserAuthorization();
        private IApiConnector _connector;
        private ExactOnlineClient _client;

        public IApiConnector GetApiConnector() => _connector ?? (_connector = new ApiConnector(GetOAuthAuthenticationToken, GetClient()));

        public ExactOnlineClient GetClient() => _client ?? (_client = new ExactOnlineClient(ExactOnlineUrl, GetOAuthAuthenticationToken));

        public static string GetOAuthAuthenticationToken()
        {
            var testApp = new TestApp();
            UserAuthorizations.Authorize(_authorization, ExactOnlineUrl, testApp.ClientId.ToString(), testApp.ClientSecret, testApp.CallbackUrl);

            return _authorization.AccessToken;
        }

        public int GetCurrentDivision()
        {
            var currentDivision = -1;

            if (_connector == null)
            {
                GetApiConnector();
            }

            if (_connector != null)
            {
                currentDivision = _connector.GetCurrentDivision(ExactOnlineUrl);
            }

            return currentDivision;
        }
    }
}

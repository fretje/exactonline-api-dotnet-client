using ExactOnline.Client.OAuth;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using System.Net.Http;

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
        private HttpClient _httpClient;
        private IApiConnector _connector;
        private ExactOnlineClient _client;

        public HttpClient GetHttpClient() => _httpClient ?? (_httpClient = new HttpClient());

        public IApiConnector GetApiConnector() => _connector ?? (_connector = new ApiConnector(GetOAuthAuthenticationToken, GetHttpClient()));

        public ExactOnlineClient GetClient() => _client ?? (_client = new ExactOnlineClient(ExactOnlineUrl, 0, GetOAuthAuthenticationToken, GetHttpClient()));

        public static string GetOAuthAuthenticationToken()
        {
            var testApp = new TestApp();
            UserAuthorizations.Authorize(_authorization, ExactOnlineUrl, testApp.ClientId.ToString(), testApp.ClientSecret, testApp.CallbackUrl);

            return _authorization.AccessToken;
        }

        public int GetCurrentDivision()
        {
            if (_client == null)
            {
                GetClient();
            }

            if (_client != null)
            {
                return _client.Division;
            }

            return -1;
        }
    }
}

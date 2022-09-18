using ExactOnline.Client.OAuth2.WinForms;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace ExactOnline.Client.Sdk.TestContext;

public class TestObjectsCreator
{
	public static string ExactOnlineUrl => ExactOnlineTest.Url;
	public static string UriGlAccount(int currentDivision) => $"{ExactOnlineUrl}/api/v1/{currentDivision}/financial/GLAccounts";
	public static string UriCrmAccount(int currentDivision) => $"{ExactOnlineUrl}/api/v1/{currentDivision}/crm/Accounts";
	public static string SpecificGLAccountDescription => "Gebouwen";
	public static string SpecificGLAccountCode => "221000";

	private static readonly ExactOnlineWinFormsAuthorizer _authorizer;
	static TestObjectsCreator()
	{
		var testApp = new TestApp();
		_authorizer = new(testApp.ClientId, testApp.ClientSecret, testApp.CallbackUrl, ExactOnlineUrl, ExactOnlineTest.AccessToken, ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessTokenExpiresAt);
		_authorizer.TokensChanged += (sender, args) =>
			(ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessToken, ExactOnlineTest.AccessTokenExpiresAt) =
			(args.NewRefreshToken, args.NewAccessToken, args.NewExpiresAt);
	}

	private IApiConnector _connector;
	private ExactOnlineClient _client;

	public IApiConnector GetApiConnector() => _connector ??= new ApiConnector(GetOAuthAuthenticationToken, new HttpClient());

	public async Task<ExactOnlineClient> GetClientAsync(CancellationToken ct = default)
	{
		if (_client == null)
		{
			_client = new ExactOnlineClient(ExactOnlineUrl, GetOAuthAuthenticationToken);
			await _client.InitializeDivisionAsync(ct).ConfigureAwait(false);
		}
		return _client;
	}

	public static Task<string> GetOAuthAuthenticationToken(CancellationToken ct) => _authorizer.GetAccessTokenAsync(ct);

	public async Task<int> GetCurrentDivisionAsync(CancellationToken ct = default)
	{
		if (_client == null)
		{
			await GetClientAsync(ct).ConfigureAwait(false);
		}

		if (_client != null)
		{
			return _client.Division;
		}

		return -1;
	}
}

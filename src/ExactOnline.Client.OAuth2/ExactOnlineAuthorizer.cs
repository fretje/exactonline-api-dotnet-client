using OAuth2.Client;
using OAuth2.Configuration;
using OAuth2.Infrastructure;

namespace ExactOnline.Client.OAuth2;

/// <summary>
/// </summary>
public class ExactOnlineAuthorizer : OAuth2Client
{
	private readonly string _baseUrl;

	/// <summary>
	/// Initializes a new instance of the <see cref="ExactOnlineAuthorizer"/> class.
	/// </summary>
	public ExactOnlineAuthorizer(
		string clientId,
		string clientSecret,
		Uri callbackUrl,
		string baseUrl = "https://start.exactonline.be",
		string? accessToken = null,
		string? refreshToken = null,
		DateTime? expiresAt = null)
		: base(
			new RequestFactory(),
			new ClientConfiguration
			{
				ClientId = clientId,
				ClientSecret = clientSecret,
				RedirectUri = callbackUrl.ToString()
			},
			accessToken,
			refreshToken,
			expiresAt) =>
			_baseUrl = baseUrl;

	public event EventHandler<TokensChangedEventArgs>? TokensChanged;

	public async Task<bool> IsAuthorizationNeededAsync(CancellationToken ct)
	{
		try
		{
			return string.IsNullOrWhiteSpace(RefreshToken) || await GetCurrentTokenAsync(cancellationToken: ct) is null;
		}
		catch
		{
			return true;
		}
	}

	public async Task ProcessAuthorization(string code) => await GetTokenAsync(new() { { "code", code } });

	public Task<string?> GetAccessTokenAsync(CancellationToken ct) => GetCurrentTokenAsync(cancellationToken: ct);

	/// <summary>
	/// Exact Online client name
	/// </summary>
	public override string Name => "ExactOnline";

	/// <summary>
	/// The access code service endpoint
	/// </summary>
	protected override Endpoint AccessCodeServiceEndpoint =>
		new()
		{
			BaseUri = _baseUrl,
			Resource = "/api/oauth2/auth"
		};

	/// <summary>
	/// The acess token service endpoint
	/// </summary>
	protected override Endpoint AccessTokenServiceEndpoint =>
		new()
		{
			BaseUri = _baseUrl,
			Resource = "/api/oauth2/token"
		};

	/// <summary>
	/// Defines URI of service which allows to obtain information about user which is currently logged in.
	/// </summary>
	protected override Endpoint UserInfoServiceEndpoint =>
		new()
		{
			BaseUri = _baseUrl,
			Resource = "/api/v1/current/Me"
		};

	protected override void OnAfterTokensChanged() =>
		TokensChanged?.Invoke(this, new TokensChangedEventArgs(RefreshToken, AccessToken, ExpiresAt));
}

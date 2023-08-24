using ExactOnline.Client.Models.Current;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Models;
using Microsoft.Extensions.Logging;

namespace ExactOnline.Client.Sdk.Controllers;

/// <summary>
/// Front Controller for working with Exact Online Entities
/// </summary>
public class ExactOnlineClient
{
	private readonly ApiConnector _apiConnector;

	// https://start.exactonline.nl/api/v1
	public string ExactOnlineApiUrl { get; private set; }

	private ControllerList _controllers;

	public int Division { get; private set; }

	public EolResponseHeader EolResponseHeader => _apiConnector.EolResponseHeader;

	public ILogger Log { get; }

	public event EventHandler<MinutelyChangedEventArgs> MinutelyChanged
	{
		add => _apiConnector.MinutelyChanged += value;
		remove => _apiConnector.MinutelyChanged -= value;
	}

	/// <summary>
	/// Create instance of ExactClient
	/// </summary>
	/// <param name="exactOnlineUrl">{URI}/</param>
	/// <param name="accesstokenFunc">Valid oAuth AccessToken</param>
	public ExactOnlineClient(string exactOnlineUrl, Func<CancellationToken, Task<string>> accesstokenFunc, HttpClient httpClient = null, int minutelyRemaining = -1, DateTime minutelyResetTime = default, ILogger log = default)
		: this(exactOnlineUrl, 0, accesstokenFunc, httpClient, minutelyRemaining, minutelyResetTime, log)
	{
		Log = log;
	}

	/// <summary>
	/// Create instance of ExactClient
	/// </summary>
	/// <param name="exactOnlineUrl">The Exact Online URL for your country</param>
	/// <param name="division">Division number</param>
	/// <param name="accesstokenFunc">Delegate that will be executed the access token is expired</param>
	public ExactOnlineClient(string exactOnlineUrl, int division, Func<CancellationToken, Task<string>> accesstokenFunc, HttpClient httpClient = null, int minutelyRemaining = -1, DateTime minutelyResetTime = default, ILogger log = default)
	{
		if (!exactOnlineUrl.EndsWith("/"))
		{
			exactOnlineUrl += "/";
		}

		ExactOnlineApiUrl = exactOnlineUrl + "api/v1/";

		_apiConnector = new ApiConnector(accesstokenFunc, httpClient ?? new HttpClient(), minutelyRemaining, minutelyResetTime, log);

		Division = division;
		Log = log;
		if (Division > 0)
		{
			var baseUrl = ExactOnlineApiUrl + Division + "/";

			_controllers = new ControllerList(_apiConnector, baseUrl);
		}
	}

	public async Task InitializeDivisionAsync(CancellationToken ct = default)
	{
		Division = await GetDivisionAsync(ct).ConfigureAwait(false);

		var baseUrl = ExactOnlineApiUrl + Division + "/";

		_controllers = new ControllerList(_apiConnector, baseUrl);
	}

	/// <summary>
	/// Returns instance of ExactOnlineQuery that can be used to manipulate data in Exact Online
	/// </summary>
	public ExactOnlineQuery<T> For<T>() where T : class
	{
		CheckInitialized();
		var controller = _controllers.GetController<T>();
		return new ExactOnlineQuery<T>(controller);
	}

	/// <summary>
	/// returns the attachment for the given url
	/// </summary>
	/// <returns>Stream</returns>
	public Stream GetAttachment(string url)
	{
		CheckInitialized();
		var conn = new ApiConnection(_apiConnector, url);
		return conn.GetFile();
	}

	/// <summary>
	/// returns the attachment for the given url
	/// </summary>
	/// <returns>Stream</returns>
	public Task<Stream> GetAttachmentAsync(string url, CancellationToken ct)
	{
		CheckInitialized();
		var conn = new ApiConnection(_apiConnector, url);
		return conn.GetFileAsync(ct);
	}

	private void CheckInitialized()
	{
		if (Division == 0 || _controllers is null)
		{
			throw new InvalidOperationException("Please call InitializeDivisionAsync first or supply a valid division in the constructor.");
		}
	}

	private async Task<int> GetDivisionAsync(CancellationToken ct)
	{
		if (Division > 0)
		{
			return Division;
		}

		var currentMe = await CurrentMeAsync(ct).ConfigureAwait(false);
		if (currentMe != null)
		{
			Division = currentMe.CurrentDivision;
			return Division;
		}

		throw new Exception("Cannot get division. Please specify division explicitly via the constructor.");
	}

	private async Task<Me> CurrentMeAsync(CancellationToken ct)
	{
		var conn = new ApiConnection(_apiConnector, ExactOnlineApiUrl + "current/Me");
		var response = await conn.GetAsync("$select=CurrentDivision", ct).ConfigureAwait(false);
		response = ApiResponseCleaner.GetJsonArray(response);
		var currentMe = EntityConverter.ConvertJsonArrayToObjectList<Me>(response);
		return currentMe.FirstOrDefault();
	}
}

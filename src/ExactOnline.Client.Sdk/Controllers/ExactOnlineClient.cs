using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ExactOnline.Client.Models.Current;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Models;

namespace ExactOnline.Client.Sdk.Controllers;

/// <summary>
/// Front Controller for working with Exact Online Entities
/// </summary>
public class ExactOnlineClient
{
	private readonly ApiConnector _apiConnector;

	// https://start.exactonline.nl/api/v1
	public string ExactOnlineApiUrl { get; private set; }

	private readonly ControllerList _controllers;

	public int Division { get; private set; }

	public EolResponseHeader EolResponseHeader => _apiConnector.EolResponseHeader;

	/// <summary>
	/// Create instance of ExactClient
	/// </summary>
	/// <param name="exactOnlineUrl">{URI}/</param>
	/// <param name="accesstokenFunc">Valid oAuth AccessToken</param>
	public ExactOnlineClient(string exactOnlineUrl, Func<CancellationToken, Task<string>> accesstokenFunc, HttpClient httpClient = null)
		: this(exactOnlineUrl, 0, accesstokenFunc, httpClient)
	{ }

	/// <summary>
	/// Create instance of ExactClient
	/// </summary>
	/// <param name="exactOnlineUrl">The Exact Online URL for your country</param>
	/// <param name="division">Division number</param>
	/// <param name="accesstokenFunc">Delegate that will be executed the access token is expired</param>
	public ExactOnlineClient(string exactOnlineUrl, int division, Func<CancellationToken, Task<string>> accesstokenFunc, HttpClient httpClient = null)
	{
		if (!exactOnlineUrl.EndsWith("/"))
		{
			exactOnlineUrl += "/";
		}

		ExactOnlineApiUrl = exactOnlineUrl + "api/v1/";

		_apiConnector = new ApiConnector(accesstokenFunc, httpClient ?? new HttpClient());

		Division = (division > 0) ? division : GetDivision();

		var baseUrl = ExactOnlineApiUrl + Division + "/";

		_controllers = new ControllerList(_apiConnector, baseUrl);
	}

	/// <summary>
	/// Returns instance of ExactOnlineQuery that can be used to manipulate data in Exact Online
	/// </summary>
	public ExactOnlineQuery<T> For<T>() where T : class
	{
		var controller = _controllers.GetController<T>();
		return new ExactOnlineQuery<T>(controller);
	}

	/// <summary>
	/// returns the attachment for the given url
	/// </summary>
	/// <returns>Stream</returns>
	public Stream GetAttachment(string url)
	{
		var conn = new ApiConnection(_apiConnector, url);
		return conn.GetFile();
	}

	/// <summary>
	/// returns the attachment for the given url
	/// </summary>
	/// <returns>Stream</returns>
	public Task<Stream> GetAttachmentAsync(string url, CancellationToken ct)
	{
		var conn = new ApiConnection(_apiConnector, url);
		return conn.GetFileAsync(ct);
	}

	private int GetDivision()
	{
		if (Division > 0)
		{
			return Division;
		}

		var currentMe = CurrentMe();
		if (currentMe != null)
		{
			Division = currentMe.CurrentDivision;
			return Division;
		}

		throw new Exception("Cannot get division. Please specify division explicitly via the constructor.");
	}

	private Me CurrentMe()
	{
		var conn = new ApiConnection(_apiConnector, ExactOnlineApiUrl + "current/Me");
		var response = conn.Get("$select=CurrentDivision");
		response = ApiResponseCleaner.GetJsonArray(response);
		var currentMe = EntityConverter.ConvertJsonArrayToObjectList<Me>(response);
		return currentMe.FirstOrDefault();
	}
}

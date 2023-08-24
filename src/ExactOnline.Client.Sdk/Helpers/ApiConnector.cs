using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ExactOnline.Client.Sdk.Helpers;

/// <summary>
/// Class for doing request to REST API
/// </summary>
public class ApiConnector : IApiConnector
{
	private readonly Func<CancellationToken, Task<string>> _accessTokenFunc;
	private readonly HttpClient _httpClient;

	private int _minutelyRemaining = -1;
	private DateTime _minutelyResetTime;
	private readonly ILogger _log;

	public EolResponseHeader EolResponseHeader { get; set; }

	public event EventHandler<MinutelyChangedEventArgs> MinutelyChanged;

	/// <summary>
	/// Creates new instance of ApiConnector
	/// </summary>
	/// <param name="accessTokenFunc">Delegate that provides a valid oAuth Access Token</param>
	/// <param name="client">The ExactOnlineClient this connector is associated with</param>
	public ApiConnector(Func<CancellationToken, Task<string>> accessTokenFunc, HttpClient httpClient, int minutelyRemaining, DateTime minutelyResetTime, ILogger log = default)
	{
		_accessTokenFunc = accessTokenFunc ?? throw new ArgumentNullException(nameof(accessTokenFunc));
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		_minutelyRemaining = minutelyRemaining;
		_minutelyResetTime = minutelyResetTime;
		_log = log;
	}

	/// <summary>
	/// Read Data: Perform a GET Request on the API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="querystring">querystring</param>
	/// <returns>String with API Response in Json Format</returns>
	public string DoGetRequest(string endpoint, string querystring) =>
		GetResponse(CreateGetRequestAsync(endpoint, querystring).GetAwaiter().GetResult());

	/// <summary>
	/// Read Data: Perform a GET Request on the API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="querystring">querystring</param>
	/// <returns>String with API Response in Json Format</returns>
	public async Task<string> DoGetRequestAsync(string endpoint, string querystring, CancellationToken ct) =>
		await GetResponseAsync(await CreateGetRequestAsync(endpoint, querystring, ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	/// <summary>
	/// Read Data: Perform a GET Request on the API
	/// </summary>
	/// <param name="endpoint">full url</param>
	/// <returns>Stream</returns>
	public Stream DoGetFileRequest(string endpoint) =>
		GetResponseStream(CreateGetRequestAsync(endpoint).GetAwaiter().GetResult());

	/// <summary>
	/// Read Data: Perform a GET Request on the API
	/// </summary>
	/// <param name="endpoint">full url</param>
	/// <returns>Stream</returns>
	public async Task<Stream> DoGetFileRequestAsync(string endpoint, CancellationToken ct) =>
		await GetResponseStreamAsync(await CreateGetRequestAsync(endpoint, ct: ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	/// <summary>
	/// Create Data: Perform a POST Request on the API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="postdata">String containing data of new entity in Json format</param>
	/// <returns>String with API Response in Json Format</returns>
	public string DoPostRequest(string endpoint, string postdata) =>
		GetResponse(CreatePostRequestAsync(endpoint, postdata, default).GetAwaiter().GetResult());

	/// <summary>
	/// Create Data: Perform a POST Request on the API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="postdata">String containing data of new entity in Json format</param>
	/// <returns>String with API Response in Json Format</returns>
	public async Task<string> DoPostRequestAsync(string endpoint, string postdata, CancellationToken ct) =>
		await GetResponseAsync(await CreatePostRequestAsync(endpoint, postdata, ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	/// <summary>
	/// Update data: Perform a PUT Request on API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="putData">String containing updated entity data in Json format</param>
	/// <returns>String with API Response in Json Format</returns>
	public string DoPutRequest(string endpoint, string putData) =>
		GetResponse(CreatePutRequestAsync(endpoint, putData, default).GetAwaiter().GetResult());

	/// <summary>
	/// Update data: Perform a PUT Request on API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="putData">String containing updated entity data in Json format</param>
	/// <returns>String with API Response in Json Format</returns>
	public async Task<string> DoPutRequestAsync(string endpoint, string putData, CancellationToken ct) =>
		await GetResponseAsync(await CreatePutRequestAsync(endpoint, putData, ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	/// <summary>
	/// Delete entity: Perform a DELETE Request on API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <returns>String with API Response in Json Format</returns>
	public string DoDeleteRequest(string endpoint) =>
		GetResponse(CreateDeleteRequestAsync(endpoint, default).GetAwaiter().GetResult());

	/// <summary>
	/// Delete entity: Perform a DELETE Request on API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <returns>String with API Response in Json Format</returns>
	public async Task<string> DoDeleteRequestAsync(string endpoint, CancellationToken ct) =>
		await GetResponseAsync(await CreateDeleteRequestAsync(endpoint, ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	/// <summary>
	/// Request without 'Accept' Header, including parameters
	/// </summary>
	/// <param name="endpoint"></param>
	/// <param name="querystring">querystring</param>
	/// <returns></returns>
	public string DoCleanRequest(string endpoint, string querystring) =>
		GetResponse(CreateCleanRequestAsync(endpoint, querystring, default).GetAwaiter().GetResult());

	/// <summary>
	/// Request without 'Accept' Header, including parameters
	/// </summary>
	/// <param name="endpoint"></param>
	/// <param name="querystring">querystring</param>
	/// <returns></returns>
	public async Task<string> DoCleanRequestAsync(string endpoint, string querystring, CancellationToken ct) =>
		await GetResponseAsync(await CreateCleanRequestAsync(endpoint, querystring, ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	private Task<HttpRequestMessage> CreateGetRequestAsync(string endpoint, string querystring = null, CancellationToken ct = default) =>
		CreateRequestAsync(HttpMethod.Get, endpoint, querystring, ct: ct);
	private Task<HttpRequestMessage> CreatePostRequestAsync(string endpoint, string postdata, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Post, endpoint, data: postdata, ct: ct);
	private Task<HttpRequestMessage> CreatePutRequestAsync(string endpoint, string putData, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Put, endpoint, data: putData, ct: ct);
	private Task<HttpRequestMessage> CreateDeleteRequestAsync(string endpoint, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Delete, endpoint, ct: ct);
	private Task<HttpRequestMessage> CreateCleanRequestAsync(string endpoint, string querystring, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Get, endpoint, querystring, acceptContentType: null, ct: ct);

	private async Task<HttpRequestMessage> CreateRequestAsync(HttpMethod method, string endpoint, string querystring = null, string data = null, string acceptContentType = "application/json", CancellationToken ct = default)
	{
		if (string.IsNullOrEmpty(endpoint))
		{
			throw new BadRequestException("Cannot perform request with empty endpoint");
		}
		if ((method == HttpMethod.Post || method == HttpMethod.Put) && string.IsNullOrEmpty(data))
		{
			throw new BadRequestException("Cannot perform request with empty data");
		}

		var request = await CreateWebRequestAsync(endpoint, querystring, method, acceptContentType, ct).ConfigureAwait(false);

		if (!string.IsNullOrEmpty(data))
		{
			request.Content = new StringContent(data, Encoding.UTF8, "application/json");
		}

		if (_log is not null)
		{
			_log.LogInformation("ExactOnline Sdk: Executing Request: {Method} {Url}", method, request.RequestUri);
			if (!string.IsNullOrEmpty(data))
			{
				_log.LogDebug("ExactOnline Sdk: Request Data: {Data}", data);
			}
		}

		return request;
	}

	private async Task<HttpRequestMessage> CreateWebRequestAsync(string url, string querystring, HttpMethod method, string acceptContentType = "application/json", CancellationToken ct = default)
	{
		if (_minutelyRemaining == 0)
		{
			var minutelyWaitTime = GetMinutelyWaitTime();
			if (_log is not null)
			{
				_log.LogInformation("ExactOnline Sdk: WAITING {MinutelyWaitTime} to respect minutely rate limit.", minutelyWaitTime);
			}
			await Task.Delay(minutelyWaitTime, ct).ConfigureAwait(false);
		}

		if (!string.IsNullOrEmpty(querystring))
		{
			url += "?" + querystring;
		}

		var request = new HttpRequestMessage(method, url);

		// request.ServicePoint.Expect100Continue = false;

		if (!string.IsNullOrEmpty(acceptContentType))
		{
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptContentType));
		}

		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _accessTokenFunc(ct).ConfigureAwait(false));

		return request;
	}

	private string GetResponse(HttpRequestMessage request)
	{
		var responseValue = string.Empty;

		using (var responseStream = GetResponseStream(request))
		{
			if (responseStream != null)
			{
				using var reader = new StreamReader(responseStream);
				responseValue = reader.ReadToEnd();
			}
		}

		if (_log is not null)
		{
			_log.LogDebug("ExactOnline Sdk: Response Body: {Response}", responseValue);
		}

		return responseValue;
	}

	private async Task<string> GetResponseAsync(HttpRequestMessage request, CancellationToken ct)
	{
		var responseValue = string.Empty;

		using (var responseStream = await GetResponseStreamAsync(request, ct).ConfigureAwait(false))
		{
			if (responseStream != null)
			{
				using var reader = new StreamReader(responseStream);
				responseValue = await reader.ReadToEndAsync().ConfigureAwait(false);
			}
		}

		if (_log is not null)
		{
			_log.LogDebug("ExactOnline Sdk: Response Body: {Response}", responseValue);
		}

		return responseValue;
	}

	private Stream GetResponseStream(HttpRequestMessage request)
	{
		var response = default(HttpResponseMessage);

		// Get response. If this fails: Throw the correct Exception (for testability)
		try
		{
			response = _httpClient.SendAsync(request).GetAwaiter().GetResult();
			if (!response.IsSuccessStatusCode)
			{
				ThrowSpecificExceptionAsync(response).GetAwaiter().GetResult();
			}
			return response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
		}
		finally
		{
			SetEolResponseHeaders(response);
		}
	}

	private async Task<Stream> GetResponseStreamAsync(HttpRequestMessage request, CancellationToken ct)
	{
		var response = default(HttpResponseMessage);

		// Get response. If this fails: Throw the correct Exception (for testability)
		try
		{
			response = await _httpClient.SendAsync(request, ct).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
			{
				await ThrowSpecificExceptionAsync(response).ConfigureAwait(false);
			}
			return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		}
		finally
		{
			SetEolResponseHeaders(response);
		}
	}

	private TimeSpan GetMinutelyWaitTime()
	{
		var waitTime = _minutelyResetTime - DateTime.Now;
		return waitTime < TimeSpan.Zero ? TimeSpan.Zero : waitTime;
	}

	private async Task ThrowSpecificExceptionAsync(HttpResponseMessage response)
	{
		var statusCode = response.StatusCode;
		var messageFromServer = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)).ReadToEnd();
		if (_log is not null)
		{
			_log.LogError("ExactOnline Sdk: Request Failed: {Response}", response.ReasonPhrase);
			_log.LogError("ExactOnline Sdk: Message from Server: {MessageFromServer}", messageFromServer);
		}

		var messageError = default(ServerMessage);
		try
		{
			messageError = JsonConvert.DeserializeObject(messageFromServer, typeof(ServerMessage)) as ServerMessage;
		}
		catch { /* the response might not be a json payload */ }

		var message = messageError?.Error?.Message?.Value;
		if (string.IsNullOrEmpty(message))
		{
			message = response.ReasonPhrase;
		}

		switch (statusCode)
		{
			case HttpStatusCode.BadRequest: // 400
			case HttpStatusCode.MethodNotAllowed: // 405
				throw new BadRequestException(message);

			case HttpStatusCode.Unauthorized: //401
				throw new UnauthorizedException(message); // 401

			case HttpStatusCode.Forbidden:
				throw new ForbiddenException(message); // 403

			case HttpStatusCode.NotFound:
				throw new NotFoundException(message); // 404

			case HttpStatusCode.InternalServerError: // 500
				throw new InternalServerErrorException(message);

			case (HttpStatusCode)429: // 429: too many requests
				throw new TooManyRequestsException(message);
		}
	}

	private void SetEolResponseHeaders(HttpResponseMessage response)
	{
		if (response != null)
		{
			EolResponseHeader = new EolResponseHeader
			{
				RateLimit = new RateLimit
				{
					Limit = response.Headers.TryGetValues("X-RateLimit-Limit", out var limitHeaders) && limitHeaders.Any() ? limitHeaders.First().ToNullableInt() : null,
					Remaining = response.Headers.TryGetValues("X-RateLimit-Remaining", out var remainingHeaders) && remainingHeaders.Any() ? remainingHeaders.First().ToNullableInt() : null,
					Reset = response.Headers.TryGetValues("X-RateLimit-Reset", out var resetHeaders) && resetHeaders.Any() ? resetHeaders.First().ToNullableLong() : null,
					MinutelyLimit = response.Headers.TryGetValues("X-RateLimit-Minutely-Limit", out var minutelyLimitHeaders) && minutelyLimitHeaders.Any() ? minutelyLimitHeaders.First().ToNullableInt() : null,
					MinutelyRemaining = response.Headers.TryGetValues("X-RateLimit-Minutely-Remaining", out var mitutelyRemainingHeaders) && mitutelyRemainingHeaders.Any() ? mitutelyRemainingHeaders.First().ToNullableInt() : null,
					MinutelyReset = response.Headers.TryGetValues("X-RateLimit-Minutely-Reset", out var minutelyResetHeaders) && minutelyResetHeaders.Any() ? minutelyResetHeaders.First().ToNullableLong() : null
				}
			};

			if (_log is not null)
			{
				_log.LogDebug(@"ExactOnline Sdk: Response Headers: 
    X-RateLimit-Limit: {RateLimitLimit}
    X-RateLimit-Remaining: {RateLimitRemaining}
    X-RateLimit-Reset: {RateLimitResetDate}
    X-RateLimit-Minutely-Limit: {RateLimitMinutelyLimit}
    X-RateLimit-Minutely-Remaining: {RateLimitMinutelyRemaining}
    X-RateLimit-Minutely-Reset: {RateLimitMinutelyResetDate}",
					EolResponseHeader.RateLimit.Limit, EolResponseHeader.RateLimit.Remaining, EolResponseHeader.RateLimit.ResetDate,
					EolResponseHeader.RateLimit.MinutelyLimit, EolResponseHeader.RateLimit.MinutelyRemaining, EolResponseHeader.RateLimit.MinutelyResetDate);
			}

			if (EolResponseHeader.RateLimit.MinutelyLimit is int minutelyLimit &&
				EolResponseHeader.RateLimit.MinutelyRemaining is int minutelyRemaining)
			{
				if (_minutelyRemaining == -1 || minutelyRemaining == minutelyLimit - 1) // this means this is the first call of a 1 minute window
				{
					_minutelyResetTime = DateTime.Now + TimeSpan.FromMinutes(1); // set the reset time to one minute from now
				}
				_minutelyRemaining = minutelyRemaining;

				OnMinutelyChanged();
			}
		}
	}

	private void OnMinutelyChanged() =>
		MinutelyChanged?.Invoke(this, new MinutelyChangedEventArgs(_minutelyRemaining, _minutelyResetTime));
}

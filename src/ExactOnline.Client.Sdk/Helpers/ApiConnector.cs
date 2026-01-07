using System.Net;
using System.Text;
using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace ExactOnline.Client.Sdk.Helpers;

/// <summary>
/// Class for doing request to REST API
/// </summary>
/// <remarks>
/// Creates new instance of ApiConnector
/// </remarks>
/// <param name="accessTokenFunc">Delegate that provides a valid oAuth Access Token</param>
/// <param name="client">The ExactOnlineClient this connector is associated with</param>
public partial class ApiConnector(Func<CancellationToken, Task<string>> accessTokenFunc, HttpClient httpClient, int minutelyRemaining, DateTime minutelyResetTime, string? customDescriptionLanguage = null, ILogger? log = null) : IApiConnector
{
	private readonly Func<CancellationToken, Task<string>> _accessTokenFunc = accessTokenFunc ?? throw new ArgumentNullException(nameof(accessTokenFunc));
	private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	private readonly string? _customDescriptionLanguage = customDescriptionLanguage;
	private readonly ILogger _log = log ?? NullLogger.Instance;

	private int _minutelyRemaining = minutelyRemaining;
	private DateTime _minutelyResetTime = minutelyResetTime;

	public EolResponseHeader EolResponseHeader { get; set; } = new() { RateLimit = new() };

	public event EventHandler<MinutelyChangedEventArgs>? MinutelyChanged;

	/// <summary>
	/// Read Data: Perform a GET Request on the API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="querystring">querystring</param>
	/// <returns>String with API Response in Json Format</returns>
	public string DoGetRequest(string endpoint, string? querystring) =>
		GetResponse(CreateGetRequestAsync(endpoint, querystring).GetAwaiter().GetResult());

	/// <summary>
	/// Read Data: Perform a GET Request on the API
	/// </summary>
	/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
	/// <param name="querystring">querystring</param>
	/// <returns>String with API Response in Json Format</returns>
	public async Task<string> DoGetRequestAsync(string endpoint, string? querystring, CancellationToken ct) =>
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
	public string DoCleanRequest(string endpoint, string? querystring) =>
		GetResponse(CreateCleanRequestAsync(endpoint, querystring, default).GetAwaiter().GetResult());

	/// <summary>
	/// Request without 'Accept' Header, including parameters
	/// </summary>
	/// <param name="endpoint"></param>
	/// <param name="querystring">querystring</param>
	/// <returns></returns>
	public async Task<string> DoCleanRequestAsync(string endpoint, string? querystring, CancellationToken ct) =>
		await GetResponseAsync(await CreateCleanRequestAsync(endpoint, querystring, ct).ConfigureAwait(false), ct).ConfigureAwait(false);

	private Task<HttpRequestMessage> CreateGetRequestAsync(string endpoint, string? querystring = null, CancellationToken ct = default) =>
		CreateRequestAsync(HttpMethod.Get, endpoint, querystring, ct: ct);
	private Task<HttpRequestMessage> CreatePostRequestAsync(string endpoint, string postdata, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Post, endpoint, data: postdata, ct: ct);
	private Task<HttpRequestMessage> CreatePutRequestAsync(string endpoint, string putData, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Put, endpoint, data: putData, ct: ct);
	private Task<HttpRequestMessage> CreateDeleteRequestAsync(string endpoint, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Delete, endpoint, ct: ct);
	private Task<HttpRequestMessage> CreateCleanRequestAsync(string endpoint, string? querystring, CancellationToken ct) =>
		CreateRequestAsync(HttpMethod.Get, endpoint, querystring, acceptContentType: null, ct: ct);

	private async Task<HttpRequestMessage> CreateRequestAsync(HttpMethod method, string endpoint, string? querystring = null, string? data = null, string? acceptContentType = "application/json", CancellationToken ct = default)
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

		LogExecutingRequest(_log, method, request.RequestUri);
		if (!string.IsNullOrEmpty(data))
		{
			LogRequestData(_log, data!);
		}

		return request;
	}

	private async Task<HttpRequestMessage> CreateWebRequestAsync(string url, string? querystring, HttpMethod method, string? acceptContentType = "application/json", CancellationToken ct = default)
	{
		if (_minutelyRemaining == 0)
		{
			var minutelyWaitTime = GetMinutelyWaitTime();
			LogWaitingForRateLimit(_log, minutelyWaitTime);
			await Task.Delay(minutelyWaitTime, ct).ConfigureAwait(false);
		}

		if (!string.IsNullOrEmpty(querystring))
		{
			url += "?" + querystring;
		}

		HttpRequestMessage request = new(method, url);

		// request.ServicePoint.Expect100Continue = false;

		if (!string.IsNullOrEmpty(acceptContentType))
		{
			request.Headers.Accept.Add(new(acceptContentType));
		}

		if (!string.IsNullOrEmpty(_customDescriptionLanguage))
		{
			request.Headers.Add("CustomDescriptionLanguage", _customDescriptionLanguage);
		}

		request.Headers.Authorization = new("Bearer", await _accessTokenFunc(ct).ConfigureAwait(false));

		return request;
	}

	private string GetResponse(HttpRequestMessage request)
	{
		var responseValue = "";

		using (var responseStream = GetResponseStream(request))
		{
			using StreamReader reader = new(responseStream);
			responseValue = reader.ReadToEnd();
		}

		LogResponseBody(_log, responseValue);

		return responseValue;
	}

	private async Task<string> GetResponseAsync(HttpRequestMessage request, CancellationToken ct)
	{
		var responseValue = "";

		using (var responseStream = await GetResponseStreamAsync(request, ct).ConfigureAwait(false))
		{
			using StreamReader reader = new(responseStream);
			responseValue = await reader.ReadToEndAsync().ConfigureAwait(false);
		}

		LogResponseBody(_log, responseValue);

		return responseValue;
	}

	private Stream GetResponseStream(HttpRequestMessage request)
	{
		// Get response. If this fails: Throw the correct Exception (for testability)
		var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();
		SetEolResponseHeader(response);
		if (!response.IsSuccessStatusCode)
		{
			ThrowSpecificExceptionAsync(response).GetAwaiter().GetResult();
		}
		return response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
	}

	private async Task<Stream> GetResponseStreamAsync(HttpRequestMessage request, CancellationToken ct)
	{
		// Get response. If this fails: Throw the correct Exception (for testability)
		var response = await _httpClient.SendAsync(request, ct).ConfigureAwait(false);
		SetEolResponseHeader(response);
		if (!response.IsSuccessStatusCode)
		{
			await ThrowSpecificExceptionAsync(response).ConfigureAwait(false);
		}
		return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
	}

	private TimeSpan GetMinutelyWaitTime()
	{
		var waitTime = _minutelyResetTime - DateTime.Now;
		return waitTime < TimeSpan.Zero ? TimeSpan.Zero : waitTime;
	}

	private async Task ThrowSpecificExceptionAsync(HttpResponseMessage response)
	{
		var statusCode = response.StatusCode;
		var messageFromServer = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
		
		LogRequestFailed(_log, response.ReasonPhrase);
		LogMessageFromServer(_log, messageFromServer);

		var messageError = default(ServerMessage);
		try
		{
			messageError = JsonConvert.DeserializeObject<ServerMessage>(messageFromServer);
		}
		catch { /* the response might not be a json payload */ }

		var message = messageError?.Error?.Message?.Value
			?? response.ReasonPhrase
			?? "";

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

	private void SetEolResponseHeader(HttpResponseMessage response)
	{
		EolResponseHeader = new()
		{
			RateLimit = new()
			{
				Limit = response.Headers.TryGetValues("X-RateLimit-Limit", out var limitHeaders) && limitHeaders.Any() ? limitHeaders.First().ToNullableInt() : null,
				Remaining = response.Headers.TryGetValues("X-RateLimit-Remaining", out var remainingHeaders) && remainingHeaders.Any() ? remainingHeaders.First().ToNullableInt() : null,
				Reset = response.Headers.TryGetValues("X-RateLimit-Reset", out var resetHeaders) && resetHeaders.Any() ? resetHeaders.First().ToNullableLong() : null,
				MinutelyLimit = response.Headers.TryGetValues("X-RateLimit-Minutely-Limit", out var minutelyLimitHeaders) && minutelyLimitHeaders.Any() ? minutelyLimitHeaders.First().ToNullableInt() : null,
				MinutelyRemaining = response.Headers.TryGetValues("X-RateLimit-Minutely-Remaining", out var mitutelyRemainingHeaders) && mitutelyRemainingHeaders.Any() ? mitutelyRemainingHeaders.First().ToNullableInt() : null,
				MinutelyReset = response.Headers.TryGetValues("X-RateLimit-Minutely-Reset", out var minutelyResetHeaders) && minutelyResetHeaders.Any() ? minutelyResetHeaders.First().ToNullableLong() : null
			}
		};

		LogResponseHeaders(_log,
			EolResponseHeader.RateLimit.Limit, EolResponseHeader.RateLimit.Remaining, EolResponseHeader.RateLimit.ResetDate,
			EolResponseHeader.RateLimit.MinutelyLimit, EolResponseHeader.RateLimit.MinutelyRemaining, EolResponseHeader.RateLimit.MinutelyResetDate);

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

	private void OnMinutelyChanged() =>
		MinutelyChanged?.Invoke(this, new(_minutelyRemaining, _minutelyResetTime));

	[LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "ExactOnline Sdk: Executing Request: {Method} {Url}")]
	private static partial void LogExecutingRequest(ILogger logger, HttpMethod method, Uri? url);

	[LoggerMessage(EventId = 2, Level = LogLevel.Debug, Message = "ExactOnline Sdk: Request Data: {Data}")]
	private static partial void LogRequestData(ILogger logger, string data);

	[LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "ExactOnline Sdk: WAITING {MinutelyWaitTime} to respect minutely rate limit.")]
	private static partial void LogWaitingForRateLimit(ILogger logger, TimeSpan minutelyWaitTime);

	[LoggerMessage(EventId = 4, Level = LogLevel.Trace, Message = "ExactOnline Sdk: Response Body: {Response}")]
	private static partial void LogResponseBody(ILogger logger, string response);

	[LoggerMessage(EventId = 5, Level = LogLevel.Error, Message = "ExactOnline Sdk: Request Failed: {Response}")]
	private static partial void LogRequestFailed(ILogger logger, string? response);

	[LoggerMessage(EventId = 6, Level = LogLevel.Error, Message = "ExactOnline Sdk: Message from Server: {MessageFromServer}")]
	private static partial void LogMessageFromServer(ILogger logger, string messageFromServer);

	[LoggerMessage(EventId = 7, Level = LogLevel.Debug, Message = """
		ExactOnline Sdk: Response Headers: 
			X-RateLimit-Limit: {RateLimitLimit}
			X-RateLimit-Remaining: {RateLimitRemaining}
			X-RateLimit-Reset: {RateLimitResetDate}
			X-RateLimit-Minutely-Limit: {RateLimitMinutelyLimit}
			X-RateLimit-Minutely-Remaining: {RateLimitMinutelyRemaining}
			X-RateLimit-Minutely-Reset: {RateLimitMinutelyResetDate}
		""")]
	private static partial void LogResponseHeaders(ILogger logger, int? rateLimitLimit, int? rateLimitRemaining, DateTimeOffset? rateLimitResetDate, int? rateLimitMinutelyLimit, int? rateLimitMinutelyRemaining, DateTimeOffset? rateLimitMinutelyResetDate);
}

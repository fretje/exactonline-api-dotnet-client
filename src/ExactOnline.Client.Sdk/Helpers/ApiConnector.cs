using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Delegates;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Helpers
{
	/// <summary>
	/// Class for doing request to REST API
	/// </summary>
	public class ApiConnector : IApiConnector
	{
		private readonly AccessTokenManagerDelegate _accessTokenDelegate;
		private readonly HttpClient _httpClient;
		public EolResponseHeader EolResponseHeader { get; set; }

		private int _minutelyRemaining = -1;
		private DateTime _minutelyResetTime;
		private TimeSpan _minutelyWaitTime
		{
			get
			{
				var waitTime = _minutelyResetTime - DateTime.Now;
				return waitTime < TimeSpan.Zero ? TimeSpan.Zero : waitTime;
			}
		}

		/// <summary>
		/// Creates new instance of ApiConnector
		/// </summary>
		/// <param name="accessTokenDelegate">Delegate that provides a valid oAuth Access Token</param>
		/// <param name="client">The ExactOnlineClient this connector is associated with</param>
		public ApiConnector(AccessTokenManagerDelegate accessTokenDelegate, HttpClient httpClient)
		{
			_accessTokenDelegate = accessTokenDelegate ?? throw new ArgumentNullException(nameof(accessTokenDelegate));
			_httpClient = httpClient;
		}

		/// <summary>
		/// Read Data: Perform a GET Request on the API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <param name="querystring">querystring</param>
		/// <returns>String with API Response in Json Format</returns>
		public string DoGetRequest(string endpoint, string querystring) =>
			GetResponse(CreateGetRequest(endpoint, querystring));

		/// <summary>
		/// Read Data: Perform a GET Request on the API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <param name="querystring">querystring</param>
		/// <returns>String with API Response in Json Format</returns>
		public Task<string> DoGetRequestAsync(string endpoint, string querystring) =>
			GetResponseAsync(CreateGetRequest(endpoint, querystring));

		/// <summary>
		/// Read Data: Perform a GET Request on the API
		/// </summary>
		/// <param name="endpoint">full url</param>
		/// <returns>Stream</returns>
		public Stream DoGetFileRequest(string endpoint) =>
			GetResponseStream(CreateGetRequest(endpoint));

		/// <summary>
		/// Read Data: Perform a GET Request on the API
		/// </summary>
		/// <param name="endpoint">full url</param>
		/// <returns>Stream</returns>
		public Task<Stream> DoGetFileRequestAsync(string endpoint) =>
			GetResponseStreamAsync(CreateGetRequest(endpoint));

		/// <summary>
		/// Create Data: Perform a POST Request on the API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <param name="postdata">String containing data of new entity in Json format</param>
		/// <returns>String with API Response in Json Format</returns>
		public string DoPostRequest(string endpoint, string postdata) =>
			GetResponse(CreatePostRequest(endpoint, postdata));

		/// <summary>
		/// Create Data: Perform a POST Request on the API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <param name="postdata">String containing data of new entity in Json format</param>
		/// <returns>String with API Response in Json Format</returns>
		public Task<string> DoPostRequestAsync(string endpoint, string postdata) =>
			GetResponseAsync(CreatePostRequest(endpoint, postdata));

		/// <summary>
		/// Update data: Perform a PUT Request on API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <param name="putData">String containing updated entity data in Json format</param>
		/// <returns>String with API Response in Json Format</returns>
		public string DoPutRequest(string endpoint, string putData) =>
			GetResponse(CreatePutRequest(endpoint, putData));

		/// <summary>
		/// Update data: Perform a PUT Request on API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <param name="putData">String containing updated entity data in Json format</param>
		/// <returns>String with API Response in Json Format</returns>
		public Task<string> DoPutRequestAsync(string endpoint, string putData) =>
			GetResponseAsync(CreatePutRequest(endpoint, putData));

		/// <summary>
		/// Delete entity: Perform a DELETE Request on API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <returns>String with API Response in Json Format</returns>
		public string DoDeleteRequest(string endpoint) =>
			GetResponse(CreateDeleteRequest(endpoint));

		/// <summary>
		/// Delete entity: Perform a DELETE Request on API
		/// </summary>
		/// <param name="endpoint">{URI}/{Division}/{Resource}/{Entity}</param>
		/// <returns>String with API Response in Json Format</returns>
		public Task<string> DoDeleteRequestAsync(string endpoint) =>
			GetResponseAsync(CreateDeleteRequest(endpoint));

		/// <summary>
		/// Request without 'Accept' Header, including parameters
		/// </summary>
		/// <param name="endpoint"></param>
		/// <param name="querystring">querystring</param>
		/// <returns></returns>
		public string DoCleanRequest(string endpoint, string querystring) =>
			GetResponse(CreateCleanRequest(endpoint, querystring));

		/// <summary>
		/// Request without 'Accept' Header, including parameters
		/// </summary>
		/// <param name="endpoint"></param>
		/// <param name="querystring">querystring</param>
		/// <returns></returns>
		public Task<string> DoCleanRequestAsync(string endpoint, string querystring) =>
			GetResponseAsync(CreateCleanRequest(endpoint, querystring));

		private HttpRequestMessage CreateGetRequest(string endpoint, string querystring = null) =>
			CreateRequest(HttpMethod.Get, endpoint, querystring);
		private HttpRequestMessage CreatePostRequest(string endpoint, string postdata) =>
			CreateRequest(HttpMethod.Post, endpoint, data: postdata);
		private HttpRequestMessage CreatePutRequest(string endpoint, string putData) =>
			CreateRequest(HttpMethod.Put, endpoint, data: putData);
		private HttpRequestMessage CreateDeleteRequest(string endpoint) =>
			CreateRequest(HttpMethod.Delete, endpoint);
		private HttpRequestMessage CreateCleanRequest(string endpoint, string querystring) =>
			CreateRequest(HttpMethod.Get, endpoint, querystring, acceptContentType: null);

		private HttpRequestMessage CreateRequest(HttpMethod httpMethod, string endpoint, string querystring = null, string data = null, string acceptContentType = "application/json")
		{
			if (string.IsNullOrEmpty(endpoint))
			{
				throw new BadRequestException("Cannot perform request with empty endpoint");
			}
			if ((httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put) && string.IsNullOrEmpty(data))
			{
				throw new BadRequestException("Cannot perform request with empty data");
			}

			var request = CreateWebRequest(endpoint, querystring, httpMethod, acceptContentType);

			if (!string.IsNullOrEmpty(data))
			{
				request.Content = new StringContent(data, Encoding.UTF8, "application/json");
			}
			Debug.Write(httpMethod.ToString() + " ");
			Debug.WriteLine(request.RequestUri);
			if (!string.IsNullOrEmpty(data))
			{
				Debug.WriteLine(data);
			}

			return request;
		}

		private HttpRequestMessage CreateWebRequest(string url, string querystring, HttpMethod httpMethod, string acceptContentType = "application/json")
		{
			if (!string.IsNullOrEmpty(querystring))
			{
				url += "?" + querystring;
			}

			HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);
			if (!string.IsNullOrEmpty(acceptContentType))
			{
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptContentType));
			}
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessTokenDelegate());

			return request;
		}

		private string GetResponse(HttpRequestMessage request)
		{
			var responseValue = string.Empty;

			using (var responseStream = GetResponseStream(request))
			{
				if (responseStream != null)
				{
					using (var reader = new StreamReader(responseStream))
					{
						responseValue = reader.ReadToEnd();
					}
				}
			}

			Debug.WriteLine(responseValue);
			Debug.WriteLine("");

			return responseValue;
		}

		private async Task<string> GetResponseAsync(HttpRequestMessage request)
		{
			var responseValue = string.Empty;

			using (var responseStream = await GetResponseStreamAsync(request).ConfigureAwait(false))
			{
				if (responseStream != null)
				{
					using (var reader = new StreamReader(responseStream))
					{
						responseValue = await reader.ReadToEndAsync().ConfigureAwait(false);
					}
				}
			}

			Debug.WriteLine("BODY");
			Debug.WriteLine(responseValue);
			Debug.WriteLine("");

			return responseValue;
		}

		private Stream GetResponseStream(HttpRequestMessage request)
		{
			if (_minutelyRemaining == 0)
			{
				Debug.WriteLine($"WAITING {_minutelyWaitTime} to respect minutely rate limit.");
				Thread.Sleep(_minutelyWaitTime);
			}

			Debug.WriteLine("RESPONSE");
			var response = default(HttpResponseMessage);


			// Get response. If this fails: Throw the correct Exception (for testability)
			try
			{
				response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
				response.EnsureSuccessStatusCode();
				return response.Content.ReadAsStreamAsync().Result;
			}
			catch (HttpRequestException ex)
			{
				ThrowSpecificException(ex, response, request);
				throw;
			}
			finally
			{
				SetEolResponseHeaders(response);
			}
		}

		private async Task<Stream> GetResponseStreamAsync(HttpRequestMessage request)
		{
			if (_minutelyRemaining == 0)
			{
				Debug.WriteLine($"WAITING {_minutelyWaitTime} to respect minutely rate limit.");
				await Task.Delay(_minutelyWaitTime).ConfigureAwait(false);
			}

			Debug.WriteLine("RESPONSE");

			var response = default(HttpResponseMessage);

			// Get response. If this fails: Throw the correct Exception (for testability)
			try
			{
				response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			}
			catch (HttpRequestException ex)
			{
				ThrowSpecificException(ex, response, request);
				throw;
			}
			finally
			{
				SetEolResponseHeaders(response);
			}
		}

		private static void ThrowSpecificException(HttpRequestException ex, HttpResponseMessage response, HttpRequestMessage request = null)
		{
			var statusCode = response.StatusCode;
			Debug.WriteLine(ex.Message);

			var messageFromServer = response.Content.ReadAsStringAsync().Result;
			Debug.WriteLine(messageFromServer);
			Debug.WriteLine("");
			var messageError = default(ServerMessage);
			try
			{
				messageError = JsonConvert.DeserializeObject(messageFromServer, typeof(ServerMessage)) as ServerMessage;
			}
			catch { /* the response might not be a json payload */ }
			var message = messageError?.Error?.Message?.Value;
			if (string.IsNullOrEmpty(message))
			{
				message = ex.Message;
			}

			switch (statusCode)
			{
				case HttpStatusCode.BadRequest: // 400
				case HttpStatusCode.MethodNotAllowed: // 405
					throw new BadRequestException(message, ex);

				case HttpStatusCode.Unauthorized: //401
					throw new UnauthorizedException(message, ex); // 401

				case HttpStatusCode.Forbidden:
					throw new ForbiddenException(message, ex); // 403

				case HttpStatusCode.NotFound:
					throw new NotFoundException(message, ex); // 404

				case HttpStatusCode.InternalServerError: // 500
					throw new InternalServerErrorException(message, ex);

				case (HttpStatusCode)429: // 429: too many requests
					throw new TooManyRequestsException(message, ex);
			}
		}


		private void SetEolResponseHeaders(HttpResponseMessage response)
		{
			if (response != null)
			{
				IEnumerable<String> output;
				var rateLimit = new RateLimit();
				if (response.Headers.TryGetValues("X-RateLimit-Limit", out output))
				{
					rateLimit.Limit = output.Single().ToNullableInt();
				}
				if (response.Headers.TryGetValues("X-RateLimit-Remaining", out output))
				{
					rateLimit.Remaining = output.Single().ToNullableInt();
				}
				if (response.Headers.TryGetValues("X-RateLimit-Reset", out output))
				{
					rateLimit.Reset = output.Single().ToNullableLong();
				}
				if (response.Headers.TryGetValues("X-RateLimit-Minutely-Limit", out output))
				{
					rateLimit.MinutelyLimit = output.Single().ToNullableInt();
				}
				if (response.Headers.TryGetValues("X-RateLimit-Minutely-Remaining", out output))
				{
					rateLimit.MinutelyRemaining = output.Single().ToNullableInt();
				}
				if (response.Headers.TryGetValues("X-RateLimit-Minutely-Reset", out output))
				{
					rateLimit.MinutelyReset = output.Single().ToNullableLong();
				}
				Debug.WriteLine("HEADERS");
				Debug.WriteLine($"X-RateLimit-Limit: {_client.EolResponseHeader.RateLimit.Limit} - X-RateLimit-Remaining: {_client.EolResponseHeader.RateLimit.Remaining} - X-RateLimit-Reset: {_client.EolResponseHeader.RateLimit.ResetDate}");
				Debug.WriteLine($"X-RateLimit-Minutely-Limit: {_client.EolResponseHeader.RateLimit.MinutelyLimit} - X-RateLimit-Minutely-Remaining: {_client.EolResponseHeader.RateLimit.MinutelyRemaining} - X-RateLimit-Minutely-Reset: {_client.EolResponseHeader.RateLimit.MinutelyResetDate}");
				if (rateLimit.MinutelyLimit is int minutelyLimit && rateLimit.MinutelyRemaining is int minutelyRemaining)
				{
					if (_minutelyRemaining == -1 || minutelyRemaining == minutelyLimit - 1) // this means this is the first call of a 1 minute window
					{
						_minutelyResetTime = DateTime.Now + TimeSpan.FromMinutes(1); // set the reset time to one minute from now
					}
					_minutelyRemaining = minutelyRemaining;
				}
				EolResponseHeader = new EolResponseHeader(RateLimit);
			};
		}
	}
}


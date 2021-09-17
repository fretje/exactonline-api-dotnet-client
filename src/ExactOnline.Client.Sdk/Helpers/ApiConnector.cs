using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Delegates;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Interfaces;
using ExactOnline.Client.Sdk.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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
        private readonly ExactOnlineClient _client;

		private int _minutelyRemaining = -1;
		private DateTime _minutelyResetTime;
		private TimeSpan _minutelyWaitTime => _minutelyResetTime - DateTime.Now;

		/// <summary>
		/// Creates new instance of ApiConnector
		/// </summary>
		/// <param name="accessTokenDelegate">Delegate that provides a valid oAuth Access Token</param>
		/// <param name="client">The ExactOnlineClient this connector is associated with</param>
		public ApiConnector(AccessTokenManagerDelegate accessTokenDelegate, ExactOnlineClient client)
        {
            _accessTokenDelegate = accessTokenDelegate ?? throw new ArgumentNullException(nameof(accessTokenDelegate));
            _client = client;
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

        private HttpWebRequest CreateGetRequest(string endpoint, string querystring = null) =>
            CreateRequest(RequestTypeEnum.GET, endpoint, querystring);
        private HttpWebRequest CreatePostRequest(string endpoint, string postdata) =>
            CreateRequest(RequestTypeEnum.POST, endpoint, data: postdata);
        private HttpWebRequest CreatePutRequest(string endpoint, string putData) =>
            CreateRequest(RequestTypeEnum.PUT, endpoint, data: putData);
        private HttpWebRequest CreateDeleteRequest(string endpoint) =>
            CreateRequest(RequestTypeEnum.DELETE, endpoint);
        private HttpWebRequest CreateCleanRequest(string endpoint, string querystring) =>
            CreateRequest(RequestTypeEnum.GET, endpoint, querystring, acceptContentType: null);

        private HttpWebRequest CreateRequest(RequestTypeEnum requestType, string endpoint, string querystring = null, string data = null, string acceptContentType = "application/json")
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new BadRequestException("Cannot perform request with empty endpoint");
            }
            if ((requestType == RequestTypeEnum.POST || requestType == RequestTypeEnum.PUT) && string.IsNullOrEmpty(data))
            {
                throw new BadRequestException("Cannot perform request with empty data");
            }

            var request = CreateWebRequest(endpoint, querystring, requestType, acceptContentType);

            if (!string.IsNullOrEmpty(data))
            {
                var bytes = Encoding.GetEncoding("utf-8").GetBytes(data);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            Debug.Write(requestType.ToString() + " ");
            Debug.WriteLine(request.RequestUri);
            if (!string.IsNullOrEmpty(data))
            {
                Debug.WriteLine(data);
            }

            return request;
        }

        private HttpWebRequest CreateWebRequest(string url, string querystring, RequestTypeEnum method, string acceptContentType = "application/json")
        {
            if (!string.IsNullOrEmpty(querystring))
            {
                url += "?" + querystring;
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.Expect100Continue = false;
            request.Method = method.ToString();
            request.ContentType = "application/json";
            if (!string.IsNullOrEmpty(acceptContentType))
            {
                request.Accept = acceptContentType;
            }
            request.Headers.Add("Authorization", "Bearer " + _accessTokenDelegate());

            return request;
        }

        private string GetResponse(HttpWebRequest request)
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

        private async Task<string> GetResponseAsync(HttpWebRequest request)
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

        private Stream GetResponseStream(HttpWebRequest request)
		{
			if (_minutelyRemaining == 0)
			{
				Debug.WriteLine($"WAITING {_minutelyWaitTime} to respect minutely rate limit.");
				Thread.Sleep(_minutelyWaitTime);
			}

			Debug.WriteLine("RESPONSE");

			var response = default(WebResponse);

			// Get response. If this fails: Throw the correct Exception (for testability)
			try
			{
				response = request.GetResponse();
				return response.GetResponseStream();
			}
			catch (WebException ex)
			{
				response = ex.Response;
				ThrowSpecificException(ex);
				throw;
			}
			finally
			{
				SetEolResponseHeaders(response);
			}
		}

		private async Task<Stream> GetResponseStreamAsync(HttpWebRequest request)
        {
			if (_minutelyRemaining == 0)
			{
				Debug.WriteLine($"WAITING {_minutelyWaitTime} to respect minutely rate limit.");
				await Task.Delay(_minutelyWaitTime).ConfigureAwait(false);
			}

			Debug.WriteLine("RESPONSE");

            var response = default(WebResponse);

            // Get response. If this fails: Throw the correct Exception (for testability)
            try
            {
                response = await request.GetResponseAsync().ConfigureAwait(false);
                return response.GetResponseStream();
            }
            catch (WebException ex)
            {
                response = ex.Response;
                ThrowSpecificException(ex);
                throw;
            }
            finally
            {
                SetEolResponseHeaders(response);
            }
        }

        private static void ThrowSpecificException(WebException ex)
        {
            var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
            Debug.WriteLine(ex.Message);

            var messageFromServer = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
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

        private void SetEolResponseHeaders(WebResponse response)
        {
            if (response != null)
			{
				_client.EolResponseHeader = new EolResponseHeader
				{
					RateLimit = new RateLimit
					{
						Limit = response.Headers["X-RateLimit-Limit"].ToNullableInt(),
						Remaining = response.Headers["X-RateLimit-Remaining"].ToNullableInt(),
						Reset = response.Headers["X-RateLimit-Reset"].ToNullableLong(),
						MinutelyLimit = response.Headers["X-RateLimit-Minutely-Limit"].ToNullableInt(),
						MinutelyRemaining = response.Headers["X-RateLimit-Minutely-Remaining"].ToNullableInt(),
						MinutelyReset = response.Headers["X-RateLimit-Minutely-Reset"].ToNullableLong()
					}
				};

				Debug.WriteLine("HEADERS");
				Debug.WriteLine($"X-RateLimit-Limit: {_client.EolResponseHeader.RateLimit.Limit} - X-RateLimit-Remaining: {_client.EolResponseHeader.RateLimit.Remaining} - X-RateLimit-Reset: {_client.EolResponseHeader.RateLimit.ResetDate}");
				Debug.WriteLine($"X-RateLimit-Minutely-Limit: {_client.EolResponseHeader.RateLimit.MinutelyLimit} - X-RateLimit-Minutely-Remaining: {_client.EolResponseHeader.RateLimit.MinutelyRemaining} - X-RateLimit-Minutely-Reset: {_client.EolResponseHeader.RateLimit.MinutelyResetDate}");

				if (_client.EolResponseHeader.RateLimit.MinutelyLimit is int minutelyLimit &&
					_client.EolResponseHeader.RateLimit.MinutelyRemaining is int minutelyRemaining)
				{
					if (_minutelyRemaining == -1 || minutelyRemaining == minutelyLimit - 1) // this means this is the first call of a 1 minute window
					{
						_minutelyResetTime = DateTime.Now + TimeSpan.FromMinutes(1); // set the reset time to one minute from now
					}
					_minutelyRemaining = minutelyRemaining;
				}
			}
		}
	}
}

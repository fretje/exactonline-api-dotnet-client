using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExactOnline.Client.Models.Current;
using ExactOnline.Client.Sdk.Delegates;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Models;

namespace ExactOnline.Client.Sdk.Controllers
{
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

        public EolResponseHeader EolResponseHeader => this._apiConnector.EolResponseHeader;

        /// <summary>
        /// Create instance of ExactClient
        /// </summary>
        /// <param name="exactOnlineUrl">{URI}/</param>
        /// <param name="accesstokenDelegate">Valid oAuth AccessToken</param>
        public ExactOnlineClient(string exactOnlineUrl, AccessTokenManagerDelegate accesstokenDelegate)
            : this(exactOnlineUrl, 0, accesstokenDelegate)
        { }

        /// <summary>
        /// Create instance of ExactClient
        /// </summary>
        /// <param name="exactOnlineUrl">The Exact Online URL for your country</param>
        /// <param name="division">Division number</param>
        /// <param name="apiConnector">IApiConnector instance to communicate with the API</param>
        public ExactOnlineClient(string exactOnlineUrl, int division, ApiConnector apiConnector)
        {
            if (!exactOnlineUrl.EndsWith("/"))
            {
                exactOnlineUrl += "/";
            }

            ExactOnlineApiUrl = exactOnlineUrl + "api/v1/";
            _apiConnector = apiConnector;

			Division = (division > 0) ? division : GetDivision();

            var baseUrl = ExactOnlineApiUrl + Division + "/";

            _controllers = new ControllerList(_apiConnector, baseUrl);
		}

        /// <summary>
        /// Create instance of ExactClient
        /// </summary>
        /// <param name="exactOnlineUrl">The Exact Online URL for your country</param>
        /// <param name="division">Division number</param>
        /// <param name="accesstokenDelegate">Delegate that will be executed the access token is expired</param>
        /// <param name="httpClient">A HttpClient instance to perform HTTP requests</param>
        public ExactOnlineClient(string exactOnlineUrl, int division, AccessTokenManagerDelegate accesstokenDelegate, HttpClient httpClient = null)
            : this(exactOnlineUrl, division, new ApiConnector(accesstokenDelegate, httpClient ?? new HttpClient()))
        {
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
        public Task<Stream> GetAttachmentAsync(string url)
        {
            var conn = new ApiConnection(_apiConnector, url);
            return conn.GetFileAsync();
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
}

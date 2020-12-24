using System;
using System.IO;
using System.Threading.Tasks;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Helpers
{
    /// <summary>
    /// Class for connection to a specific part of the REST API (for example: Account, Invoice, Sales, etc.)
    /// </summary>
    public class ApiConnection : IApiConnection
    {
        private readonly IApiConnector _connector;
        private readonly string _endPoint;
        private readonly string _baseUrl;

        /// <summary>
        /// Creates a new instance of APIConnection
        /// </summary>
        /// <param name="conn">Instance of APIConnector</param>
        /// <param name="endPoint">Specific endpoint of API</param>
        /// <param name="baseUrl">The base url of the API (leave empty if included in the endpoint, but it's mandatory for connections to sync/bulk endpoints)</param>
        public ApiConnection(IApiConnector conn, string endPoint, string baseUrl = default)
        {
            if (conn != null && endPoint != string.Empty)
            {
                _connector = conn;
                _endPoint = endPoint;
                _baseUrl = baseUrl;
            }
            else
            {
                throw new ArgumentException("APIConnector and/or endPoint are required");
            }
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <returns>Json String</returns>
        public string Get(string parameters)
        {
            return Get(parameters, EndpointTypeEnum.Single);
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <param name="endpointType">Which EndpointType to use</param>
        /// <returns>Json String</returns>
        public string Get(string parameters, EndpointTypeEnum endpointType)
        {
            string response = _connector.DoGetRequest(GetEndpointUrl(endpointType), parameters);
            if (response.Contains("Object moved"))
            {
                throw new Exception("Invalid Access Token");
            }
            return response;
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <returns>Json String</returns>
        public async Task<string> GetAsync(string parameters)
        {
            return await GetAsync(parameters, EndpointTypeEnum.Single);
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <param name="endpointType">Which EndpointType to use</param>
        /// <returns>Json String</returns>
        public async Task<string> GetAsync(string parameters, EndpointTypeEnum endpointType)
        {
            string response = await _connector.DoGetRequestAsync(GetEndpointUrl(endpointType), parameters).ConfigureAwait(false);
            if (response.Contains("Object moved"))
            {
                throw new Exception("Invalid Access Token");
            }
            return response;
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <returns>Stream</returns>
        public Stream GetFile()
        {
            Stream response = _connector.DoGetFileRequest(GetEndpointUrl());
            return response;
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <returns>Stream</returns>
        public Task<Stream> GetFileAsync()
        {
            return _connector.DoGetFileRequestAsync(GetEndpointUrl());
        }

        /// <summary>
        /// Performs a GET (Read) request on the API for one specific entity
        /// </summary>
        /// <param name="keyname">Name of the field that is the unique identifier</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Json String</returns>
        public string GetEntity(string keyname, string guid, string parameters)
        {
            if (guid == string.Empty || keyname == string.Empty)
            {
                throw new Exception("guid and/or Keyname are not specified");
            }

            // Create call
            string endpoint = GetEndpointUrl();
            if (keyname.Contains("ID"))
            {
                endpoint += "(guid'" + guid + "')";
            }
            else
            {
                endpoint += "(" + guid + ")";
            }

            string response = _connector.DoGetRequest(endpoint, parameters);
            return response;
        }

        /// <summary>
        /// Performs a GET (Read) request on the API for one specific entity
        /// </summary>
        /// <param name="keyname">Name of the field that is the unique identifier</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Json String</returns>
        public Task<string> GetEntityAsync(string keyname, string guid, string parameters)
        {
            if (guid == string.Empty || keyname == string.Empty)
            {
                throw new Exception("guid and/or Keyname are not specified");
            }

            // Create call
            string endpoint = GetEndpointUrl();
            if (keyname.Contains("ID"))
            {
                endpoint += "(guid'" + guid + "')";
            }
            else
            {
                endpoint += "(" + guid + ")";
            }

            return _connector.DoGetRequestAsync(endpoint, parameters);
        }

        /// <summary>
        /// Performs a POST (Create) request on the API
        /// </summary>
        /// <param name="data">Json String that representes new entity</param>
        /// <returns>Result from the API in Json Format</returns>
        public string Post(string data)
        {
            string response;
            if (data != string.Empty)
            {
                response = _connector.DoPostRequest(GetEndpointUrl(), data);
            }
            else
            {
                throw new Exception("No postdata specified");
            }
            return response;
        }

        /// <summary>
        /// Performs a POST (Create) request on the API
        /// </summary>
        /// <param name="data">Json String that representes new entity</param>
        /// <returns>Result from the API in Json Format</returns>
        public async Task<string> PostAsync(string data)
        {
            string response;
            if (data != string.Empty)
            {
                response = await _connector.DoPostRequestAsync(GetEndpointUrl(), data).ConfigureAwait(false);
            }
            else
            {
                throw new Exception("No postdata specified");
            }
            return response;
        }

        /// <summary>
        /// Performs a PUT Request (Update) on the API
        /// </summary>
        /// <param name="keyName">Name of key field</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="data">Json String that represents the new state of the entity</param>
        /// <returns>True if succeeded</returns>
        public Boolean Put(string keyName, string guid, string data)
        {
            Boolean returnValue = false;
            if (guid != string.Empty && data != string.Empty && keyName != string.Empty)
            {
                // Create correct endpoint
                string endpoint = GetEndpointUrl();
                if (keyName.Contains("ID")) endpoint += "(guid'" + guid + "')";
                else endpoint += "(" + guid + ")";

                string response = _connector.DoPutRequest(endpoint, data);

                // Reponse is empty on success
                if (!response.Contains("error"))
                {
                    returnValue = true;
                }
            }
            else
            {
                throw new Exception("No Guid, keyName or data specified");
            }
            return returnValue;
        }

        /// <summary>
        /// Performs a PUT Request (Update) on the API
        /// </summary>
        /// <param name="keyName">Name of key field</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="data">Json String that represents the new state of the entity</param>
        /// <returns>True if succeeded</returns>
        public async Task<Boolean> PutAsync(string keyName, string guid, string data)
        {
            Boolean returnValue = false;
            if (guid != string.Empty && data != string.Empty && keyName != string.Empty)
            {
                // Create correct endpoint
                string endpoint = GetEndpointUrl();
                if (keyName.Contains("ID")) endpoint += "(guid'" + guid + "')";
                else endpoint += "(" + guid + ")";

                string response = await _connector.DoPutRequestAsync(endpoint, data).ConfigureAwait(false);

                // Reponse is empty on success
                if (!response.Contains("error"))
                {
                    returnValue = true;
                }
            }
            else
            {
                throw new Exception("No Guid, keyName or data specified");
            }
            return returnValue;
        }

        /// <summary>
        /// Performs a DELETE Request on the API
        /// </summary>
        /// <param name="keyName">Name of key field</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <returns>True if succeeded</returns>
        public Boolean Delete(string keyName, string guid)
        {
            Boolean returnValue = false;
            if (guid != string.Empty && keyName != string.Empty)
            {
                // Create correct endpoint
                string endpoint = GetEndpointUrl();
                if (keyName.Contains("ID")) endpoint += "(guid'" + guid + "')";
                else endpoint += "(" + guid + ")";

                // Create endpoint and get response
                string response = _connector.DoDeleteRequest(endpoint);

                // Reponse is empty on success
                if (response == string.Empty)
                {
                    returnValue = true;
                }
            }
            else
            {
                throw new Exception("No GUID specified");
            }
            return returnValue;
        }

        /// <summary>
        /// Performs a DELETE Request on the API
        /// </summary>
        /// <param name="keyName">Name of key field</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <returns>True if succeeded</returns>
        public async Task<Boolean> DeleteAsync(string keyName, string guid)
        {
            Boolean returnValue = false;
            if (guid != string.Empty && keyName != string.Empty)
            {
                // Create correct endpoint
                string endpoint = GetEndpointUrl();
                if (keyName.Contains("ID")) endpoint += "(guid'" + guid + "')";
                else endpoint += "(" + guid + ")";

                // Create endpoint and get response
                string response = await _connector.DoDeleteRequestAsync(endpoint).ConfigureAwait(false);

                // Reponse is empty on success
                if (response == string.Empty)
                {
                    returnValue = true;
                }
            }
            else
            {
                throw new Exception("No GUID specified");
            }
            return returnValue;
        }

        /// <summary>
        /// Counts the number of resources/entities, including parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public int Count(string parameters)
        {
            string response = _connector.DoCleanRequest(GetEndpointUrl() + "/$count", parameters);
            return int.Parse(response);
        }

        /// <summary>
        /// Counts the number of resources/entities, including parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public async Task<int> CountAsync(string parameters)
        {
            string response = await _connector.DoCleanRequestAsync(GetEndpointUrl() + "/$count", parameters).ConfigureAwait(false);
            return int.Parse(response);
        }

        private string GetEndpointUrl(EndpointTypeEnum endpointType = EndpointTypeEnum.Single)
        {
            var typePart = endpointType == EndpointTypeEnum.Bulk ? "bulk/"
                         : endpointType == EndpointTypeEnum.Sync ? "sync/"
                         : "";
            return _baseUrl + typePart + _endPoint;
        }
    }
}
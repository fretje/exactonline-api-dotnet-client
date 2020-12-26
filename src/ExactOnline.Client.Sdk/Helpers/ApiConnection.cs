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
            if (conn != null && !string.IsNullOrEmpty(endPoint))
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
        public string Get(string parameters) => Get(parameters, EndpointTypeEnum.Single);

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <param name="endpointType">Which EndpointType to use</param>
        /// <returns>Json String</returns>
        public string Get(string parameters, EndpointTypeEnum endpointType)
        {
            var response = _connector.DoGetRequest(GetEndpointUrl(endpointType), parameters);
            return response.Contains("Object moved") ? throw new Exception("Invalid Access Token") : response;
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <returns>Json String</returns>
        public Task<string> GetAsync(string parameters) => GetAsync(parameters, EndpointTypeEnum.Single);

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <param name="parameters">oData Parameters</param>
        /// <param name="endpointType">Which EndpointType to use</param>
        /// <returns>Json String</returns>
        public async Task<string> GetAsync(string parameters, EndpointTypeEnum endpointType)
        {
            var response = await _connector.DoGetRequestAsync(GetEndpointUrl(endpointType), parameters).ConfigureAwait(false);
            return response.Contains("Object moved") ? throw new Exception("Invalid Access Token") : response;
        }

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <returns>Stream</returns>
        public Stream GetFile() => _connector.DoGetFileRequest(GetEndpointUrl());

        /// <summary>
        /// Perform a GET (Read) request on the API
        /// </summary>
        /// <returns>Stream</returns>
        public Task<Stream> GetFileAsync() => _connector.DoGetFileRequestAsync(GetEndpointUrl());

        /// <summary>
        /// Performs a GET (Read) request on the API for one specific entity
        /// </summary>
        /// <param name="keyname">Name of the field that is the unique identifier</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Json String</returns>
        public string GetEntity(string keyname, string guid, string parameters)
        {
            if (string.IsNullOrEmpty(guid) || string.IsNullOrEmpty(keyname))
            {
                throw new Exception("guid and/or Keyname are not specified");
            }

            // Create call
            var endpoint = GetEndpointUrl();
            if (keyname.Contains("ID"))
            {
                endpoint += "(guid'" + guid + "')";
            }
            else
            {
                endpoint += "(" + guid + ")";
            }

            return _connector.DoGetRequest(endpoint, parameters);
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
            if (string.IsNullOrEmpty(guid) || string.IsNullOrEmpty(keyname))
            {
                throw new Exception("guid and/or Keyname are not specified");
            }

            // Create call
            var endpoint = GetEndpointUrl();
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
        public string Post(string data) =>
            string.IsNullOrEmpty(data)
                ? throw new Exception("No postdata specified")
                : _connector.DoPostRequest(GetEndpointUrl(), data);

        /// <summary>
        /// Performs a POST (Create) request on the API
        /// </summary>
        /// <param name="data">Json String that representes new entity</param>
        /// <returns>Result from the API in Json Format</returns>
        public Task<string> PostAsync(string data) =>
            string.IsNullOrEmpty(data)
                ? throw new Exception("No postdata specified")
                : _connector.DoPostRequestAsync(GetEndpointUrl(), data);

        /// <summary>
        /// Performs a PUT Request (Update) on the API
        /// </summary>
        /// <param name="keyName">Name of key field</param>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="data">Json String that represents the new state of the entity</param>
        /// <returns>True if succeeded</returns>
        public bool Put(string keyName, string guid, string data)
        {
            var returnValue = false;
            if (!string.IsNullOrEmpty(guid) && !string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(keyName))
            {
                // Create correct endpoint
                var endpoint = GetEndpointUrl();
                if (keyName.Contains("ID"))
                {
                    endpoint += "(guid'" + guid + "')";
                }
                else
                {
                    endpoint += "(" + guid + ")";
                }

                var response = _connector.DoPutRequest(endpoint, data);

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
        public async Task<bool> PutAsync(string keyName, string guid, string data)
        {
            var returnValue = false;
            if (!string.IsNullOrEmpty(guid) && !string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(keyName))
            {
                // Create correct endpoint
                var endpoint = GetEndpointUrl();
                if (keyName.Contains("ID"))
                {
                    endpoint += "(guid'" + guid + "')";
                }
                else
                {
                    endpoint += "(" + guid + ")";
                }

                var response = await _connector.DoPutRequestAsync(endpoint, data).ConfigureAwait(false);

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
        public bool Delete(string keyName, string guid)
        {
            var returnValue = false;
            if (!string.IsNullOrEmpty(guid) && !string.IsNullOrEmpty(keyName))
            {
                // Create correct endpoint
                var endpoint = GetEndpointUrl();
                if (keyName.Contains("ID"))
                {
                    endpoint += "(guid'" + guid + "')";
                }
                else
                {
                    endpoint += "(" + guid + ")";
                }

                // Create endpoint and get response
                var response = _connector.DoDeleteRequest(endpoint);

                // Reponse is empty on success
                if (string.IsNullOrEmpty(response))
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
        public async Task<bool> DeleteAsync(string keyName, string guid)
        {
            var returnValue = false;
            if (!string.IsNullOrEmpty(guid) && !string.IsNullOrEmpty(keyName))
            {
                // Create correct endpoint
                var endpoint = GetEndpointUrl();
                if (keyName.Contains("ID"))
                {
                    endpoint += "(guid'" + guid + "')";
                }
                else
                {
                    endpoint += "(" + guid + ")";
                }

                // Create endpoint and get response
                var response = await _connector.DoDeleteRequestAsync(endpoint).ConfigureAwait(false);

                // Reponse is empty on success
                if (string.IsNullOrEmpty(response))
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
        public int Count(string parameters) => int.Parse(_connector.DoCleanRequest(GetEndpointUrl() + "/$count", parameters));

        /// <summary>
        /// Counts the number of resources/entities, including parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public async Task<int> CountAsync(string parameters) =>
            int.Parse(await _connector.DoCleanRequestAsync(GetEndpointUrl() + "/$count", parameters).ConfigureAwait(false));

        private string GetEndpointUrl(EndpointTypeEnum endpointType = EndpointTypeEnum.Single)
        {
            var typePart = endpointType == EndpointTypeEnum.Bulk ? "bulk/"
                         : endpointType == EndpointTypeEnum.Sync ? "sync/"
                         : "";
            return _baseUrl + typePart + _endPoint;
        }
    }
}

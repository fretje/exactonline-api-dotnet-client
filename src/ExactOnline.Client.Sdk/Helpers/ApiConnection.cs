using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Helpers;

/// <summary>
/// Class for connection to a specific part of the REST API (for example: Account, Invoice, Sales, etc.)
/// </summary>
public class ApiConnection : IApiConnection
{
	private readonly IApiConnector _connector;
	private readonly string _endPoint;
	private readonly string? _baseUrl;

	/// <summary>
	/// Creates a new instance of APIConnection
	/// </summary>
	/// <param name="conn">Instance of APIConnector</param>
	/// <param name="endPoint">Specific endpoint of API</param>
	/// <param name="baseUrl">The base url of the API (leave empty if included in the endpoint, but it's mandatory for connections to sync/bulk endpoints)</param>
	public ApiConnection(IApiConnector conn, string endPoint, string? baseUrl = null)
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
	public string Get(string? parameters) => Get(parameters, EndpointTypeEnum.Single);

	/// <summary>
	/// Perform a GET (Read) request on the API
	/// </summary>
	/// <param name="parameters">oData Parameters</param>
	/// <param name="endpointType">Which EndpointType to use</param>
	/// <returns>Json String</returns>
	public string Get(string? parameters, EndpointTypeEnum endpointType)
	{
		var response = _connector.DoGetRequest(EndpointUrl(endpointType), parameters);
		return response.Contains("Object moved") ? throw new Exception("Invalid Access Token") : response;
	}

	/// <summary>
	/// Perform a GET (Read) request on the API
	/// </summary>
	/// <param name="parameters">oData Parameters</param>
	/// <returns>Json String</returns>
	public Task<string> GetAsync(string? parameters, CancellationToken ct) =>
		GetAsync(parameters, EndpointTypeEnum.Single, ct);

	/// <summary>
	/// Perform a GET (Read) request on the API
	/// </summary>
	/// <param name="parameters">oData Parameters</param>
	/// <param name="endpointType">Which EndpointType to use</param>
	/// <returns>Json String</returns>
	public async Task<string> GetAsync(string? parameters, EndpointTypeEnum endpointType, CancellationToken ct = default)
	{
		var response = await _connector.DoGetRequestAsync(EndpointUrl(endpointType), parameters, ct).ConfigureAwait(false);
		return response.Contains("Object moved") ? throw new Exception("Invalid Access Token") : response;
	}

	/// <summary>
	/// Perform a GET (Read) request on the API
	/// </summary>
	/// <returns>Stream</returns>
	public Stream GetFile() =>
		_connector.DoGetFileRequest(EndpointUrl());

	/// <summary>
	/// Perform a GET (Read) request on the API
	/// </summary>
	/// <returns>Stream</returns>
	public Task<Stream> GetFileAsync(CancellationToken ct = default) =>
		_connector.DoGetFileRequestAsync(EndpointUrl(), ct);

	/// <summary>
	/// Performs a GET (Read) request on the API for one specific entity
	/// </summary>
	/// <param name="keyname">Name of the field that is the unique identifier</param>
	/// <param name="guid">Global Unique Identifier of the entity</param>
	/// <param name="parameters">Parameters</param>
	/// <returns>Json String</returns>
	public string GetEntity(string keyname, string guid, string? parameters) =>
		_connector.DoGetRequest(EndpointUrlWithKey(keyname, guid), parameters);

	/// <summary>
	/// Performs a GET (Read) request on the API for one specific entity
	/// </summary>
	/// <param name="keyname">Name of the field that is the unique identifier</param>
	/// <param name="guid">Global Unique Identifier of the entity</param>
	/// <param name="parameters">Parameters</param>
	/// <returns>Json String</returns>
	public Task<string> GetEntityAsync(string keyname, string guid, string? parameters, CancellationToken ct = default) =>
		_connector.DoGetRequestAsync(EndpointUrlWithKey(keyname, guid), parameters, ct);

	/// <summary>
	/// Performs a POST (Create) request on the API
	/// </summary>
	/// <param name="data">Json String that representes new entity</param>
	/// <returns>Result from the API in Json Format</returns>
	public string Post(string data) =>
		string.IsNullOrEmpty(data)
			? throw new Exception("No postdata specified")
			: _connector.DoPostRequest(EndpointUrl(), data);

	/// <summary>
	/// Performs a POST (Create) request on the API
	/// </summary>
	/// <param name="data">Json String that representes new entity</param>
	/// <returns>Result from the API in Json Format</returns>
	public Task<string> PostAsync(string data, CancellationToken ct = default) =>
		string.IsNullOrEmpty(data)
			? throw new Exception("No postdata specified")
			: _connector.DoPostRequestAsync(EndpointUrl(), data, ct);

	/// <summary>
	/// Performs a PUT Request (Update) on the API
	/// </summary>
	/// <param name="keyname">Name of key field</param>
	/// <param name="guid">Global Unique Identifier of the entity</param>
	/// <param name="data">Json String that represents the new state of the entity</param>
	/// <returns>True if succeeded</returns>
	public bool Put(string keyname, string guid, string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			throw new Exception("No data specified");
		}
		var response = _connector.DoPutRequest(EndpointUrlWithKey(keyname, guid), data);
		return !response.Contains("error");
	}

	/// <summary>
	/// Performs a PUT Request (Update) on the API
	/// </summary>
	/// <param name="keyname">Name of key field</param>
	/// <param name="guid">Global Unique Identifier of the entity</param>
	/// <param name="data">Json String that represents the new state of the entity</param>
	/// <returns>True if succeeded</returns>
	public async Task<bool> PutAsync(string keyname, string guid, string data, CancellationToken ct = default)
	{
		if (string.IsNullOrEmpty(data))
		{
			throw new Exception("No data specified");
		}
		var response = await _connector.DoPutRequestAsync(EndpointUrlWithKey(keyname, guid), data, ct).ConfigureAwait(false);
		return !response.Contains("error");
	}

	/// <summary>
	/// Performs a DELETE Request on the API
	/// </summary>
	/// <param name="keyname">Name of key field</param>
	/// <param name="guid">Global Unique Identifier of the entity</param>
	/// <returns>True if succeeded</returns>
	public bool Delete(string keyname, string guid) =>
		string.IsNullOrEmpty(_connector.DoDeleteRequest(EndpointUrlWithKey(keyname, guid)));

	/// <summary>
	/// Performs a DELETE Request on the API
	/// </summary>
	/// <param name="keyname">Name of key field</param>
	/// <param name="guid">Global Unique Identifier of the entity</param>
	/// <returns>True if succeeded</returns>
	public async Task<bool> DeleteAsync(string keyname, string guid, CancellationToken ct = default) =>
		string.IsNullOrEmpty(await _connector.DoDeleteRequestAsync(EndpointUrlWithKey(keyname, guid), ct).ConfigureAwait(false));

	/// <summary>
	/// Counts the number of resources/entities, including parameters
	/// </summary>
	/// <param name="parameters">Parameters</param>
	/// <returns></returns>
	public int Count(string? parameters) =>
		int.Parse(_connector.DoCleanRequest(EndpointUrl() + "/$count", parameters));

	/// <summary>
	/// Counts the number of resources/entities, including parameters
	/// </summary>
	/// <param name="parameters">Parameters</param>
	/// <returns></returns>
	public async Task<int> CountAsync(string? parameters, CancellationToken ct = default) =>
		int.Parse(await _connector.DoCleanRequestAsync(EndpointUrl() + "/$count", parameters, ct).ConfigureAwait(false));

	private string EndpointUrl(EndpointTypeEnum endpointType = EndpointTypeEnum.Single)
	{
		var typePart = endpointType == EndpointTypeEnum.Bulk ? "bulk/"
					 : endpointType == EndpointTypeEnum.Sync ? "sync/"
					 : "";

		var endpoint =
			(endpointType == EndpointTypeEnum.Bulk || endpointType == EndpointTypeEnum.Sync)
				&& _endPoint == "FinancialTransaction/TransactionLines"
				? "Financial/TransactionLines"
				: _endPoint;

		return _baseUrl + typePart + endpoint;
	}

	private string EndpointUrlWithKey(string keyname, string guid)
	{
		if (string.IsNullOrEmpty(keyname) || string.IsNullOrEmpty(guid))
		{
			throw new Exception("keyname and/or guid are not specified");
		}

		return keyname.Contains("ID")
			? $"{EndpointUrl()}(guid'{guid}')"
			: $"{EndpointUrl()}({guid})";
	}
}

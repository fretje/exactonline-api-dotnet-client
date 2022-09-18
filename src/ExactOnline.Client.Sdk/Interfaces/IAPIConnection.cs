using ExactOnline.Client.Sdk.Enums;

namespace ExactOnline.Client.Sdk.Interfaces;

public interface IApiConnection
{
	string Get(string parameters);
	string Get(string parameters, EndpointTypeEnum endpointType);
	Task<string> GetAsync(string parameters, CancellationToken ct = default);
	Task<string> GetAsync(string parameters, EndpointTypeEnum endpointType, CancellationToken ct = default);

	string GetEntity(string keyname, string guid, string parameters);
	Task<string> GetEntityAsync(string keyname, string guid, string parameters, CancellationToken ct = default);

	string Post(string data);
	Task<string> PostAsync(string data, CancellationToken ct = default);

	bool Put(string keyName, string guid, string data);
	Task<bool> PutAsync(string keyName, string guid, string data, CancellationToken ct = default);

	bool Delete(string keyName, string guid);
	Task<bool> DeleteAsync(string keyName, string guid, CancellationToken ct = default);

	int Count(string parameters);
	Task<int> CountAsync(string parameters, CancellationToken ct = default);
}

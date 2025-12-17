using ExactOnline.Client.Sdk.Enums;

namespace ExactOnline.Client.Sdk.Interfaces;

public interface IController<T>
{
	List<T> Get(string query);
	List<T> Get(string query, EndpointTypeEnum endpointType);
	List<T> Get(string query, ref string? skipToken);
	List<T> Get(string query, ref string? skipToken, EndpointTypeEnum endpointType);
	Task<Models.ApiList<T>> GetAsync(string query, CancellationToken ct = default);
	Task<Models.ApiList<T>> GetAsync(string query, EndpointTypeEnum endpointType, CancellationToken ct = default);

	T GetEntity(string guid, string parameters);
	Task<T> GetEntityAsync(string guid, string parameters, CancellationToken ct = default);

	T GetFunctionResult(string querystring);

	bool Create(ref T entity);
	Task<T> CreateAsync(T entity, CancellationToken ct = default);

	bool Update(T entity);
	Task<bool> UpdateAsync(T entity, CancellationToken ct = default);

	bool Delete(T entity);
	Task<bool> DeleteAsync(T entity, CancellationToken ct = default);

	int Count(string query); // For $count function API
	Task<int> CountAsync(string query, CancellationToken ct = default); // For $count function API

	void RegistrateLinkedEntityField(string fieldname);
}

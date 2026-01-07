using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Test.Infrastructure.MockObjects;

public sealed class ControllerMock<T> : IController<T>
{
	public string ODataQuery { get; set; } = default!;

	List<T> IController<T>.Get(string query) => (this as IController<T>).Get(query, EndpointTypeEnum.Single);
	List<T> IController<T>.Get(string query, EndpointTypeEnum endpointType)
	{
		ODataQuery = query;
		return [];
	}

	public List<T> Get(string query, ref string? skipToken) => Get(query, ref skipToken, EndpointTypeEnum.Single);
	public List<T> Get(string query, ref string? skipToken, EndpointTypeEnum endpointType)
	{
		skipToken = null;
		ODataQuery = query;
		return [];
	}

	public Task<Models.ApiList<T>> GetAsync(string query, CancellationToken ct) => GetAsync(query, EndpointTypeEnum.Single, ct);
	public Task<Models.ApiList<T>> GetAsync(string query, EndpointTypeEnum endpointType, CancellationToken ct)
	{
		ODataQuery = query;
		return Task.FromResult(new Models.ApiList<T>([], null));
	}

	T IController<T>.GetEntity(string guid, string parameters) => throw new NotImplementedException();
	public Task<T> GetEntityAsync(string guid, string parameters, CancellationToken ct) => Task.FromResult(GetEntity(guid, parameters));

	bool IController<T>.Create(ref T entity) => true;
	Task<T> IController<T>.CreateAsync(T entity, CancellationToken ct) => Task.FromResult(entity);

	bool IController<T>.Update(T entity) => true;
	Task<bool> IController<T>.UpdateAsync(T entity, CancellationToken ct) => Task.FromResult((this as IController<T>).Update(entity));

	bool IController<T>.Delete(T entity) => true;
	Task<bool> IController<T>.DeleteAsync(T entity, CancellationToken ct) => Task.FromResult((this as IController<T>).Delete(entity));

	public int Count(string query)
	{
		ODataQuery = query;
		return 0;
	}

	public Task<int> CountAsync(string query, CancellationToken ct) => Task.FromResult(Count(query));

	public bool IsManagedEntity(T entity) => true;

	public T GetEntity(string guid, string parameters) => throw new NotImplementedException();

	public void RegistrateLinkedEntityField(string fieldname)
	{
	}

	public T GetFunctionResult(string querystring) => throw new NotImplementedException();
}

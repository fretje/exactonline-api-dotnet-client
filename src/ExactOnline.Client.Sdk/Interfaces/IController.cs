using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Interfaces
{
	public interface IController<T>
	{
        List<T> Get(string query);
        List<T> Get(string query, bool useBulkEndpoint);

        T GetEntity(string guid, string parameters);
        Task<T> GetEntityAsync(string guid, string parameters);

        Boolean Create(ref T entity);
        Task<T> CreateAsync(T entity);

        Boolean Update(T entity);
        Task<Boolean> UpdateAsync(T entity);

        Boolean Delete(T entity);
        Task<Boolean> DeleteAsync(T entity);

        int Count(string query); // For $count function API
        Task<int> CountAsync(string query); // For $count function API

        void RegistrateLinkedEntityField(string fieldname);

        List<T> Get(string query, ref string skipToken);
        List<T> Get(string query, ref string skipToken, bool useBulkEndpoint);
        Task<Models.ApiList<T>> GetAsync(string query);
        Task<Models.ApiList<T>> GetAsync(string query, bool useBulkEndpoint);
    }
}

using ExactOnline.Client.Sdk.Enums;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Interfaces
{
    public interface IApiConnection
    {
        string Get(string parameters);
        string Get(string parameters, EndpointTypeEnum endpointType);
        Task<string> GetAsync(string parameters);
        Task<string> GetAsync(string parameters, EndpointTypeEnum endpointType);

        string GetEntity(string keyname, string guid, string parameters);
        Task<string> GetEntityAsync(string keyname, string guid, string parameters);

        string Post(string data);
        Task<string> PostAsync(string data);

        bool Put(string keyName, string guid, string data);
        Task<bool> PutAsync(string keyName, string guid, string data);

        bool Delete(string keyName, string guid);
        Task<bool> DeleteAsync(string keyName, string guid);

        int Count(string parameters);
        Task<int> CountAsync(string parameters);
    }
}

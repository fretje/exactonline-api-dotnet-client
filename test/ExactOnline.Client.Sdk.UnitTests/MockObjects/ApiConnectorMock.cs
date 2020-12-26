using System.IO;
using System.Threading.Tasks;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.UnitTests.MockObjects
{

    /// <summary>
    /// Simulates APIConnector class
    /// </summary>
    public class ApiConnectorMock : IApiConnector
    {
        public string DoGetRequest(string endpoint, string parameters) => string.Empty;
        public Task<string> DoGetRequestAsync(string endpoint, string parameters) => Task.FromResult(DoGetRequest(endpoint, parameters));

        public Stream DoGetFileRequest(string endpointy) => Stream.Null;
        public Task<Stream> DoGetFileRequestAsync(string endpointy) => Task.FromResult(DoGetFileRequest(endpointy));

        public string DoPostRequest(string endpoint, string postdata) => string.Empty;
        public Task<string> DoPostRequestAsync(string endpoint, string postdata) => Task.FromResult(DoPostRequest(endpoint, postdata));

        public string DoPutRequest(string endpoint, string putData) => string.Empty;
        public Task<string> DoPutRequestAsync(string endpoint, string putData) => Task.FromResult(DoPutRequest(endpoint, putData));

        public string DoDeleteRequest(string endpoint) => string.Empty;
        public Task<string> DoDeleteRequestAsync(string endpoint) => Task.FromResult(DoDeleteRequest(endpoint));

        public string DoCleanRequest(string endpoint, string oDataQuery) => string.Empty;
        public Task<string> DoCleanRequestAsync(string endpoint, string oDataQuery) => Task.FromResult(DoCleanRequest(endpoint, oDataQuery));

        public int GetCurrentDivision(string endpoint) => -1;
        public Task<int> GetCurrentDivisionAsync(string endpoint) => Task.FromResult(GetCurrentDivision(endpoint));
    }
}

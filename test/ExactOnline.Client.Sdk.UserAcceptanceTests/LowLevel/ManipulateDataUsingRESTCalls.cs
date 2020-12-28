using System;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.LowLevel
{

    /// <summary>
    /// User story: As a user of the SDK I can execute a PUT, DELETE and POST 
    /// command on the API so that I can manipulate data in Exact Online
    /// Constraints: The user can update, delete and create data in Exact Online
    /// </summary>
    [TestClass]
    public class ManipulateDataUsingRestCalls
    {
        ApiConnection _conn;

        [TestInitialize]
        public void Setup()
        {
            var toc = new TestObjectsCreator();
            _conn = new ApiConnection(toc.GetApiConnector(), TestObjectsCreator.UriGlAccount(toc.GetCurrentDivision()));
        }

        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void Post_Put_DeleteData()
        {
            PostData();
            PutData();
            DeleteData();
        }

        private void PostData()
        {
            // Create new entity
            const string data = @"{ ""Code"":""SDKTest123456789"", ""Description"":""UAT GLAcount""}";
            if (_conn.Post(data).Contains("error"))
            {
                throw new Exception("GLAccount entity could not be created");
            }
        }

        private void PutData()
        {
            // Get GUID and set it in property for PUT and Delete functions
            var response = _conn.Get("$filter=Code+eq+'SDKTest123456789'");
            response = ApiResponseCleaner.GetJsonArray(response);
            dynamic dresponse = EntityConverter.ConvertJsonToDynamicObjectList(response);
            string id = dresponse[0].ID;

            _conn.Put("ID", id, @"{""Description"":""UAT GLAccount""}");
        }

        private void DeleteData()
        {
            // Get GUID and set it in property for PUT and Delete functions
            var response = _conn.Get("$filter=Code+eq+'SDKTest123456789'");
            response = ApiResponseCleaner.GetJsonArray(response);
            dynamic dresponse = EntityConverter.ConvertJsonToDynamicObjectList(response);
            string id = dresponse[0].ID;

            _conn.Delete("ID", id);
        }
    }
}

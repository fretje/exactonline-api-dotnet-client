using ExactOnline.Client.Sdk.Exceptions;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.UnitTests.Tools;

namespace ExactOnline.Client.Sdk.UnitTests;

[TestClass]
public class ApiResponseCleanerTest
{
	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonArray_WithCorrectValues_Succeeds() =>
		ApiResponseCleaner.GetJsonArray(JsonFileReader.GetJsonFromFile("ApiResponse_Json_Array.txt"));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonArray_WithOutDKeyValuePair_Fails() =>
		Assert.Throws<IncorrectJsonException>(() => ApiResponseCleaner.GetJsonArray(JsonFileReader.GetJsonFromFile("ApiResponse_Json_Array_WithoutDTag.txt")));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonArray_WithOutResultsKeyValuePair_Fails() =>
		Assert.Throws<IncorrectJsonException>(() => ApiResponseCleaner.GetJsonArray(JsonFileReader.GetJsonFromFile("ApiResponse_Json_Array_WithoutResultsTag.txt")));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleanerFetchJsonArrayWithEmptyLinkedEntitiesSucceeds()
	{
		const string expected = @"[{""BankAccounts"":[]}]";
		var clean = ApiResponseCleaner.GetJsonArray(JsonFileReader.GetJsonFromFile("ApiResponse_Json_Array_WithEmptyLinkedEntities.txt"));
		Assert.AreEqual(expected, clean);
	}

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonObject_WithCorrectValues_Succeeds() =>
		ApiResponseCleaner.GetJsonObject(JsonFileReader.GetJsonFromFile("ApiResponse_Json_Object.txt"));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonObject_Without_D_Fails() =>
		Assert.Throws<IncorrectJsonException>(() => ApiResponseCleaner.GetJsonObject(JsonFileReader.GetJsonFromFile("APIResponse_Json_Object_WithoutD.txt")));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonObject_WithEscapeCharacter_Succeeds()
	{
		const string sampleJsonResponse = @"{ ""d"": { ""Remarks"": ""\\escape test"" }}";

		var cleanedJson = ApiResponseCleaner.GetJsonObject(sampleJsonResponse);

		const string expectedCleanedJson = @"{""Remarks"":""\\escape test""}";

		Assert.AreEqual(expectedCleanedJson, cleanedJson);
	}

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_FetchJsonObject_WithoutDKeyValuePair_Fails() =>
		Assert.Throws<IncorrectJsonException>(() => ApiResponseCleaner.GetJsonObject(JsonFileReader.GetJsonFromFile("ApiResponse_Json_Object_WithoutD.txt")));

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_GetSkipToken_WithValidSkipToken_ReturnsToken()
	{
		const string response = """
		                        {
		                        	"d": {
		                        		"__next": "https://start.exactonline.nl/api/v1/1234/salesorder/SalesOrders?$skiptoken=abcdefg"
		                        	}
		                        }
		                        """;
		var token = ApiResponseCleaner.GetSkipToken(response);
		Assert.AreEqual("abcdefg", token);
	}

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_GetSkipToken_WithoutSkipToken_ReturnsEmptyString()
	{
		const string response = """
		                        {
		                        	"d": {
		                        		"__next": "https://start.exactonline.nl/api/v1/1234/salesorder/SalesOrders"
		                        	}
		                        }
		                        """;
		var token = ApiResponseCleaner.GetSkipToken(response);
		Assert.IsNull(token);
	}

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_GetSkipToken_WithoutNextKey_ReturnsEmptyString()
	{
		const string response = """
		                        {
		                        	"d": {
		                        		"SomeOtherKey": "value"
		                        	}
		                        }
		                        """;
		var token = ApiResponseCleaner.GetSkipToken(response);
		Assert.IsNull(token);
	}

	[TestCategory("Unit Test")]
	[TestMethod]
	public void ApiResponseCleaner_GetSkipToken_InvalidJson_ThrowsIncorrectJsonException()
	{
		const string response = @"{ invalid json }";
		Assert.Throws<IncorrectJsonException>(() => ApiResponseCleaner.GetSkipToken(response));
	}
}

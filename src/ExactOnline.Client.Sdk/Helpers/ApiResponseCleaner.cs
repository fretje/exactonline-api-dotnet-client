using System.Globalization;
using System.Text.RegularExpressions;
using ExactOnline.Client.Sdk.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExactOnline.Client.Sdk.Helpers;

/// <summary>
/// Class for stripping unnecessary Json tags from API Response
/// </summary>
public static class ApiResponseCleaner
{
	private static readonly JsonSerializerSettings _settings = new() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };

	/// <summary>
	/// Fetch Json Object (Json within ['d'] name/value pair) from response
	/// </summary>
	/// <param name="response"></param>
	/// <returns></returns>
	public static string GetJsonObject(string response)
	{
		var oldCulture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

		try
		{
			var jtoken = JsonConvert.DeserializeObject<JToken>(response, _settings);
			if (jtoken?["d"] is not JObject jobject)
			{
				throw new Exception("No 'd' property found in response");
			}
			return GetJsonFromObject(jobject);
		}
		catch (Exception e)
		{
			throw new IncorrectJsonException(e.Message);
		}
		finally
		{
			Thread.CurrentThread.CurrentCulture = oldCulture;
		}
	}

	public static string? GetSkipToken(string response)
	{
		var oldCulture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		string? token = null;
		try
		{
			var jtoken = JsonConvert.DeserializeObject<JToken>(response, _settings);
			if (jtoken?["d"] is JObject dObject)
			{
				if (dObject.ContainsKey("__next"))
				{
					var next = dObject["__next"]!.ToString();

					// Skiptoken has format "$skiptoken=xyz" in the url and we want to extract xyz.
					var match = Regex.Match(next ?? "", @"\$skiptoken=([^&#]*)");

					// Extract the skip token
					token = match.Success ? match.Groups[1].Value : null;
				}
			}
		}
		catch (Exception e)
		{
			throw new IncorrectJsonException(e.Message);
		}
		finally
		{
			Thread.CurrentThread.CurrentCulture = oldCulture;
		}
		return token;
	}

	/// <summary>
	/// Fetch Json Array (Json within ['d']['results']) from response
	/// </summary>
	public static string GetJsonArray(string response)
	{
		var oldCulture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		try
		{
			var results = default(JArray);
			var jtoken = JsonConvert.DeserializeObject(response, _settings) as JToken;
			if (jtoken?["d"] is JObject dObject && dObject["results"] is JArray resultsArray)
			{
				results = resultsArray;
			}
			else if (jtoken?["d"] is JArray dArray)
			{
				results = dArray;
			}
			else
			{
				throw new Exception("No ['d']['results'] token found in response");
			}
			return GetJsonFromArray(results);
		}
		catch (Exception e)
		{
			throw new IncorrectJsonException(e.Message);
		}
		finally
		{
			Thread.CurrentThread.CurrentCulture = oldCulture;
		}
	}

	/// <summary>
	/// Converts key/value pairs to json
	/// </summary>
	private static string GetJsonFromObject(JObject jObject)
	{
		var json = "{";

		foreach (var entry in jObject)
		{
			if (entry.Value is JValue jValue)
			{
				// Entry is of type keyvaluepair
				json += "\"" + entry.Key + "\":";
				if (jValue.Value == null)
				{
					json += "null";
				}
				else
				{
					json += JsonConvert.ToString(jValue.Value);
				}
				json += ",";
			}
			else if (entry.Value is JObject subcollection && subcollection.ContainsKey("results") && subcollection["results"] is JArray results)
			{
				// Create linked entities json
				var subjson = GetJsonFromArray(results);

				if (subjson.Length > 0)
				{
					json += "\"" + entry.Key + "\":";
					json += subjson;
					json += ",";
				}
			}
		}

		json = json.Remove(json.Length - 1, 1); // Remove last comma
		json += "}";

		return json;
	}

	private static string GetJsonFromArray(JArray results)
	{
		var json = "[";
		if (results.Count > 0)
		{
			foreach (var entity in results)
			{
				if (entity is not JObject jobject)
				{
					throw new IncorrectJsonException("Entity in results is not a JObject");	
				}
				json += GetJsonFromObject(jobject) + ",";
			}

			json = json.Remove(json.Length - 1, 1); // Remove last comma
		}
		json += "]";
		return json;
	}
}

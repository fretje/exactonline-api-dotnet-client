using System.Globalization;
using System.Text;
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
				if (dObject.TryGetValue("__next", out var nextToken))
				{
					var next = nextToken.ToString();

					// Skiptoken has format "$skiptoken=xyz" in the url and we want to extract xyz.
					var match = Regex.Match(next, @"\$skiptoken=([^&#]*)");

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
		StringBuilder json = new("{");
		foreach (var entry in jObject)
		{
			if (entry.Value is JValue jValue)
			{
				// Entry is of type keyvaluepair
				json.Append('"').Append(entry.Key).Append("\":");
				if (jValue.Value is null)
				{
					json.Append("null");
				}
				else
				{
					json.Append(JsonConvert.ToString(jValue.Value));
				}
				json.Append(',');
			}
			else if (entry.Value is JObject subObject
				&& subObject.TryGetValue("results", out var subResults)
				&& subResults is JArray subArray				
				&& GetJsonFromArray(subArray) is { Length: > 0 } subJson) // Create linked entities json
			{
				json.Append('"').Append(entry.Key).Append("\":");
				json.Append(subJson);
				json.Append(',');
			}
		}
		json.Length -= 1; // Remove last comma
		json.Append('}');
		return json.ToString();
	}

	private static string GetJsonFromArray(JArray results)
	{
		StringBuilder json = new("[");
		if (results.Count > 0)
		{
			foreach (var entity in results)
			{
				if (entity is not JObject jobject)
				{
					throw new IncorrectJsonException("Entity in results is not a JObject");	
				}
				json.Append(GetJsonFromObject(jobject)).Append(',');
			}

			json.Length -= 1; // Remove last comma
		}
		json.Append(']');
		return json.ToString();
	}
}

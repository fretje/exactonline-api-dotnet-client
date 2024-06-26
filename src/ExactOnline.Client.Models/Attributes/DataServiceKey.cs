using Newtonsoft.Json;

namespace ExactOnline.Client.Models;

public sealed class DataServiceKey : Attribute
{
	public DataServiceKey(string dataServiceKey) =>
		DataServiceKeyName = dataServiceKey;

	public DataServiceKey(string dataServiceKey, string dataServiceKey2) =>
		DataServiceKeyName = dataServiceKey;

	public DataServiceKey(string dataServiceKey, string dataServiceKey2, string dataServiceKey3) =>
		DataServiceKeyName = dataServiceKey;

	[JsonProperty(PropertyName = "dataServiceKey")]
	public string DataServiceKeyName { get; set; }
}

using Newtonsoft.Json;

namespace ExactOnline.Client.Models;

public sealed class DataServiceKey : Attribute
{
	public DataServiceKey(string? dataServiceKey) =>
		DataServiceKeyName = dataServiceKey;

	[JsonProperty(PropertyName = "dataServiceKey")]
	public string? DataServiceKeyName { get; set; }
}

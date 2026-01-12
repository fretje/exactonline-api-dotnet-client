using Newtonsoft.Json;

namespace ExactOnline.Client.Models;

public sealed class DataServiceKey(string? dataServiceKey) : Attribute
{
	[JsonProperty(PropertyName = "dataServiceKey")]
	public string? DataServiceKeyName { get; } = dataServiceKey;
}

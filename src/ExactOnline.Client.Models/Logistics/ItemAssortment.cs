namespace ExactOnline.Client.Models.Logistics;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class ItemAssortment
{
	/// <summary>Code of ItemAssortment</summary>
	public int Code { get; set; }
	/// <summary>Description of ItemAssortment</summary>
	public string? Description { get; set; }
	/// <summary>Division</summary>
	public int Division { get; set; }
	/// <summary>ID of ItemAssortment</summary>
	public Guid ID { get; set; }
	/// <summary>Properties of this ItemAssortment</summary>
	public IEnumerable<ItemAssortmentProperty>? Properties { get; set; }
}

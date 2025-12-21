namespace ExactOnline.Client.Models.Logistics;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class ItemAssortmentProperty
{
	/// <summary>Code of Property</summary>
	public string? Code { get; set; }
	/// <summary>Description of Property</summary>
	public string? Description { get; set; }
	/// <summary>Division</summary>
	public int Division { get; set; }
	/// <summary>ID of Property</summary>
	public Guid ID { get; set; }
	/// <summary>Code of ItemAssortment</summary>
	public int ItemAssortmentCode { get; set; }
}

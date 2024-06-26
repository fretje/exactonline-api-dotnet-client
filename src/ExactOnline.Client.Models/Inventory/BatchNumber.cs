namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class BatchNumber
{
	/// <summary>Available quantity of this batch number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? AvailableQuantity { get; set; }
	/// <summary>Human readable batch number</summary>
	[Newtonsoft.Json.JsonProperty(PropertyName = "BatchNumber")]
	public string BatchNumberName { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Expiry date of effective period for batch number</summary>
	public DateTime? ExpiryDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Boolean value indicating whether or not the batch number is blocked</summary>
	public byte? IsBlocked { get; set; }
	/// <summary>Item</summary>
	public Guid? Item { get; set; }
	/// <summary>Item code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Remarks</summary>
	public string Remarks { get; set; }
	/// <summary>Total quantity available per location</summary>
	public IEnumerable<BatchQuantitiesPerLocation> StorageLocations { get; set; }
	/// <summary>Total quantity available per warehouse</summary>
	public IEnumerable<BatchQuantitiesPerWarehouse> Warehouses { get; set; }
}

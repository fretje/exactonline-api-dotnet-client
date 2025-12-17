namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class WarehouseTransferLine
{
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Description</summary>
	public string? Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Item ID</summary>
	public Guid? Item { get; set; }
	/// <summary>Code of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemCode { get; set; }
	/// <summary>Description of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemDescription { get; set; }
	/// <summary>Line number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? LineNumber { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Quantity of transfer</summary>
	public double? Quantity { get; set; }
	/// <summary>ID of storage location to transfer item from (Premium Only)</summary>
	public Guid? StorageLocationFrom { get; set; }
	/// <summary>Code of storage location to transfer item from</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? StorageLocationFromCode { get; set; }
	/// <summary>Description of storage location to transfer item from</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? StorageLocationFromDescription { get; set; }
	/// <summary>ID of storage location to transfer item to (Premium Only)</summary>
	public Guid? StorageLocationTo { get; set; }
	/// <summary>Code of storage location to transfer item to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? StorageLocationToCode { get; set; }
	/// <summary>Description of storage location to transfer item to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? StorageLocationToDescription { get; set; }
	/// <summary>Entry number of the stock transaction</summary>
	public Guid? TransferID { get; set; }
	/// <summary>The standard unit code of this item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? UnitCode { get; set; }
	/// <summary>Description of item&apos;s unit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? UnitDescription { get; set; }
}

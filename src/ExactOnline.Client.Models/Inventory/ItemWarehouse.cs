namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ItemWarehouse
{
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Quantity that is currently on stock, sales/purchase orders excluded</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? CurrentStock { get; set; }
	/// <summary>This is a default storage location</summary>
	public Guid? DefaultStorageLocation { get; set; }
	/// <summary>Default storage location&apos;s code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DefaultStorageLocationCode { get; set; }
	/// <summary>Default storage location&apos;s description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DefaultStorageLocationDescription { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Item ID</summary>
	public Guid? Item { get; set; }
	/// <summary>Barcode of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemBarcode { get; set; }
	/// <summary>Code of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Indicates if fractions (for example 0.35) are allowed for quantities of this item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool? ItemIsFractionAllowedItem { get; set; }
	/// <summary>The standard unit code of this item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemUnit { get; set; }
	/// <summary>Description of item&apos;s unit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemUnitDescription { get; set; }
	/// <summary>Maximum number of stock could enter warehouse</summary>
	public double? MaximumStock { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>The quantity still open to be received based on i.e. purchase orders and assembly orders.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? PlannedStockIn { get; set; }
	/// <summary>The quantity still open to be delivered based on i.e. sales orders and assembly orders.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? PlannedStockOut { get; set; }
	/// <summary>URL of the stock planning details of this record</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PlanningDetailsUrl { get; set; }
	/// <summary>The quantity of stock projected given all planned future stock changes</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? ProjectedStock { get; set; }
	/// <summary>Reorder point when stock depletes</summary>
	public double? ReorderPoint { get; set; }
	/// <summary>The quantity in a back to back order process which is already received from the purchase order, but not yet delivered for the sales order.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? ReservedStock { get; set; }
	/// <summary>Safety stock</summary>
	public double? SafetyStock { get; set; }
	/// <summary>URL pointing to details of which storage locations this ItemWarehouse&apos;s stock is located</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string StorageLocationUrl { get; set; }
	/// <summary>Warehouse ID</summary>
	public Guid? Warehouse { get; set; }
	/// <summary>Code of warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseCode { get; set; }
	/// <summary>Description of warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseDescription { get; set; }
}

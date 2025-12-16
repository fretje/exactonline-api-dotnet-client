namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("StockCountID")]
public class StockCount
{
	/// <summary>Stock count user</summary>
	public Guid? CountedBy { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Description of the stock count</summary>
	public string? Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Entry number of the stock transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? EntryNumber { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Offset GL account of inventory</summary>
	public Guid? OffsetGLInventory { get; set; }
	/// <summary>GLAccount code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? OffsetGLInventoryCode { get; set; }
	/// <summary>GLAccount description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? OffsetGLInventoryDescription { get; set; }
	/// <summary>Source of stock count entry: 1-Manual entry, 2-Import, 3-Stock count, 4-Web service</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short? Source { get; set; }
	/// <summary>Stock count status: 12-Draft, 21-Processed</summary>
	public short? Status { get; set; }
	/// <summary>Stock count date</summary>
	public DateTime? StockCountDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid StockCountID { get; set; }
	/// <summary>Collection of stock count lines</summary>
	public IEnumerable<StockCountLine>? StockCountLines { get; set; }
	/// <summary>Human readable id of the stock count</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? StockCountNumber { get; set; }
	/// <summary>Warehouse</summary>
	public Guid? Warehouse { get; set; }
	/// <summary>Code of Warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseCode { get; set; }
	/// <summary>Description of Warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseDescription { get; set; }
}

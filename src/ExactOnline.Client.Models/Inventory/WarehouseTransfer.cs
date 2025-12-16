namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("TransferID")]
public class WarehouseTransfer
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
	/// <summary>Entry Date</summary>
	public DateTime? EntryDate { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Planned delivery date / Planned transfer date &lt;br&gt;It shows the date the items will be sent for transfer delivery.</summary>
	public DateTime? PlannedDeliveryDate { get; set; }
	/// <summary>Planned receipt date &lt;br&gt;It shows the date the items will arrive at the warehouse location.</summary>
	public DateTime? PlannedReceiptDate { get; set; }
	/// <summary>Remarks</summary>
	public string? Remarks { get; set; }
	/// <summary>Source of warehouse transfer entry: 1-Manual entry, 2-Import, 3-Transfer advice, 4-Web service</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short? Source { get; set; }
	/// <summary>Warehouse transfer status: 10-Draft, 50-Processed</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short Status { get; set; }
	/// <summary>Transfer Date of the processed warehouse transfer</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? TransferDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid TransferID { get; set; }
	/// <summary>Transfer Number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? TransferNumber { get; set; }
	/// <summary>ID of warehouse to transfer item from</summary>
	public Guid? WarehouseFrom { get; set; }
	/// <summary>Code of warehouse to transfer item from</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseFromCode { get; set; }
	/// <summary>Description of warehouse to transfer item from</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseFromDescription { get; set; }
	/// <summary>ID of warehouse to transfer item to</summary>
	public Guid? WarehouseTo { get; set; }
	/// <summary>Code of warehouse to transfer item to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseToCode { get; set; }
	/// <summary>Description of warehouse to transfer item to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseToDescription { get; set; }
	/// <summary>Collection of warehouse transfer lines</summary>
	public IEnumerable<WarehouseTransferLine>? WarehouseTransferLines { get; set; }
}

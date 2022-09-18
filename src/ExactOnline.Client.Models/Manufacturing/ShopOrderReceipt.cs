namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, false, false)]
[DataServiceKey("StockTransactionId")]
public class ShopOrderReceipt
{
	/// <summary>ID of creating user</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? CreatedBy { get; set; }
	/// <summary>Name of the creating user</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatedByFullName { get; set; }
	/// <summary>Date of this ShopOrderReceipt</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? CreatedDate { get; set; }
	/// <summary>Serial or batch numbers are reserved prior to a POST to ShopOrderReceipts. This DraftStockTransactionID represents the group of serial or batch numbers to be used in this transaction.</summary>
	public Guid? DraftStockTransactionID { get; set; }
	/// <summary>Indicates if this ShopOrderReceipt has a quantity eligible to be reversed via ShopOrderReversals</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool HasReversibleQuantity { get; set; }
	/// <summary>Does the shop order receipt&apos;s item use batch numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? IsBatch { get; set; }
	/// <summary>Indicates if fractions (for example 0.35) are allowed for quantities of the shop order receipt&apos;s item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? IsFractionAllowedItem { get; set; }
	/// <summary>Boolean indicating if this ShopOrderReceipt was part of an SubOrderReceipt</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool IsIssueToParent { get; set; }
	/// <summary>Does the shop order receipt&apos;s item use serial numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? IsSerial { get; set; }
	/// <summary>Item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Item { get; set; }
	/// <summary>Code of item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Picture url of shop order item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemPictureUrl { get; set; }
	/// <summary>Parent shop order if this ShopOrderReceipt is part of a SubOrderReceipt</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? ParentShopOrder { get; set; }
	/// <summary>Parent shop order number if this ShopOrderReceipt is part of a SubOrderReceipt</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? ParentShopOrderNumber { get; set; }
	/// <summary>Quantity of this ShopOrderReceipt</summary>
	public double? Quantity { get; set; }
	/// <summary>If this transaction was part of a SubOrderReceipt, this ID is the related MaterialIssue.StockTransactionID.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? RelatedStockTransaction { get; set; }
	/// <summary>Shop order finished</summary>
	public Guid? ShopOrder { get; set; }
	/// <summary>Number of shop order finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? ShopOrderNumber { get; set; }
	/// <summary>ID of stock transaction of this ShopOrderReceipt</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid StockTransactionId { get; set; }
	/// <summary>ID of storage location finished to</summary>
	public Guid? StorageLocation { get; set; }
	/// <summary>Code of storage location finished to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string StorageLocationCode { get; set; }
	/// <summary>Description of storage location finished to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string StorageLocationDescription { get; set; }
	/// <summary>Effective date of this ShopOrderReceipt</summary>
	public DateTime? TransactionDate { get; set; }
	/// <summary>Unit of measurement abbreviation of item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Unit { get; set; }
	/// <summary>Unit of measurement of item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string UnitDescription { get; set; }
	/// <summary>ID of warehouse finished to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Warehouse { get; set; }
	/// <summary>Code of warehouse finished to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseCode { get; set; }
	/// <summary>Description of warehouse finished to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseDescription { get; set; }
}

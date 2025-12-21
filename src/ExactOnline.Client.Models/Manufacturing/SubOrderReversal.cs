namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, false, false)]
[DataServiceKey("MaterialReversalStockTransactionId")]
public class SubOrderReversal
{
	/// <summary>ID of creating user</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? CreatedBy { get; set; }
	/// <summary>Name of the creating user</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatedByFullName { get; set; }
	/// <summary>Creation date of this SubOrderReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? CreatedDate { get; set; }
	/// <summary>Does the SubOrderReversal&apos;s item use batch numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? IsBatch { get; set; }
	/// <summary>Indicates if fractions (for example 0.35) are allowed for quantities of the SubOrderReversal&apos;s item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? IsFractionAllowedItem { get; set; }
	/// <summary>Does the SubOrderReversal&apos;s item use serial numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? IsSerial { get; set; }
	/// <summary>Item reversed</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Item { get; set; }
	/// <summary>Code of item reversed</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemCode { get; set; }
	/// <summary>Description of item reversed</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemDescription { get; set; }
	/// <summary>Picture url of shop order item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemPictureUrl { get; set; }
	/// <summary>MaterialReversal.StockTransactionId related to this SubOrderReversal&apos;s MaterialReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid MaterialReversalStockTransactionId { get; set; }
	/// <summary>Notes logged with this reversal</summary>
	public string? Note { get; set; }
	/// <summary>MaterialIssue.StockTransactionId related to this SubOrderReceipt&apos;s original MaterialIssue</summary>
	public Guid? OriginalMaterialIssueStockTransactionId { get; set; }
	/// <summary>ShopOrderReceipt.StockTransactionId related to this SubOrderReceipt&apos;s original ShopOrderReceipt</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? OriginalShopOrderReceiptStockTransactionId { get; set; }
	/// <summary>Shop order reversed from</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? ParentShopOrder { get; set; }
	/// <summary>Number of shop order reversed from</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? ParentShopOrderNumber { get; set; }
	/// <summary>Quantity of this SubOrderReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? Quantity { get; set; }
	/// <summary>ShopOrderReversal.StockTransactionId related to this SubOrderReversal&apos;s ShopOrderReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? ShopOrderReversalStockTransactionId { get; set; }
	/// <summary>Shop order reversed to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? SubShopOrder { get; set; }
	/// <summary>Number of shop order reversed to</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? SubShopOrderNumber { get; set; }
	/// <summary>Effective date of this SubOrderReversal</summary>
	public DateTime? TransactionDate { get; set; }
	/// <summary>Unit of measurement abbreviation of this SubOrderReversal&apos;s item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? Unit { get; set; }
	/// <summary>Unit of measurement of this SubOrderReversal&apos;s item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? UnitDescription { get; set; }
	/// <summary>ID of warehouse of this SubOrderReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Warehouse { get; set; }
	/// <summary>Code of warehouse of this SubOrderReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseCode { get; set; }
	/// <summary>Description of warehouse of this SubOrderReversal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WarehouseDescription { get; set; }
}

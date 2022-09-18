namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class ItemWarehousePlanningDetail
{
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>ID of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid Item { get; set; }
	/// <summary>Code of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Date which quantity in stock is planned to change</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime PlannedDate { get; set; }
	/// <summary>Amount by which quantity in stock is planned to change</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double PlannedQuantity { get; set; }
	/// <summary>Human readable description of the PlanningSource (translated to user&apos;s language) - Examples: Purchase Order, Sales Order, Shop Order, etc.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PlanningSourceDescription { get; set; }
	/// <summary>ID of the PlanningSource</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? PlanningSourceID { get; set; }
	/// <summary>Line number of the PlanningSource if the PlanningSourceType supports line numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? PlanningSourceLineNumber { get; set; }
	/// <summary>Human readable number of the PlanningSource - Examples: Shop order number &apos;201600001&apos; or Sales order number &apos;2016020001&apos;</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? PlanningSourceNumber { get; set; }
	/// <summary>REST API URL of this specific PlanningSource and PlanningSourceID (Assembly orders and warehouse transfers not supported over REST)</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PlanningSourceUrl { get; set; }
	/// <summary>Type of the PlanningSource - 120=GoodsDelivery, 124=WarehouseTransferDelivery, 130=GoodsReceipt, 134=WarehouseTransferReceipt, 140=ShopOrderStockReceipt, 147=ShopOrderByProductReceipt, 150=ShopOrderRequirement, 160=AssemblyOrderReceipt, 165=AssemblyOrderIssue</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? PlanningType { get; set; }
	/// <summary>Human readable description of the PlanningSourceType (translated to user&apos;s language) - Examples: &apos;Shop order stock receipt&apos; or &apos;Goods delivery&apos;</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PlanningTypeDescription { get; set; }
	/// <summary>ID of warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid Warehouse { get; set; }
	/// <summary>Code of warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseCode { get; set; }
	/// <summary>Description of warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseDescription { get; set; }
}

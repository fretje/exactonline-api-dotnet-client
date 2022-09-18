namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, false, false)]
[DataServiceKey("Id")]
public class StageForDeliveryReceipt
{
	/// <summary>ID of creating user</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? CreatedBy { get; set; }
	/// <summary>Name of the creating user</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatedByFullName { get; set; }
	/// <summary>Date this Stage for delivery wa created</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? CreatedDate { get; set; }
	/// <summary>Indicates if this StageForDeliveryReceipt has a quantity eligible to be reversed via StageForDeliveryReversals</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool HasReversibleQuantity { get; set; }
	/// <summary>ID of staged for delivery entry</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid Id { get; set; }
	/// <summary>Does the shop order receipt&apos;s item use batch numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte IsBatch { get; set; }
	/// <summary>Indicates if fractions (for example 0.35) are allowed for quantities of the stage for delivery receipt&apos;s item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte IsFractionAllowedItem { get; set; }
	/// <summary>Does the shop order receipt&apos;s item use serial numbers</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte IsSerial { get; set; }
	/// <summary>Item staged for delivery</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Item { get; set; }
	/// <summary>Code of item staged for delivery</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of item staged for delivery</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Picture url of shop order item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemPictureUrl { get; set; }
	/// <summary>Quantity of this StageForDeliveryReceipt</summary>
	public double? Quantity { get; set; }
	/// <summary>ID of the original stage for delivery entry</summary>
	public Guid? RelatedId { get; set; }
	/// <summary>Shop order staged for delivery</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid ShopOrder { get; set; }
	/// <summary>Number of shop order staged for delivery</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? ShopOrderNumber { get; set; }
	/// <summary>Effective date of this stage for delivery receipt</summary>
	public DateTime? TransactionDate { get; set; }
	/// <summary>Unit of measurement abbreviation of item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Unit { get; set; }
	/// <summary>Unit of measurement of item finished</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string UnitDescription { get; set; }
	/// <summary>ID of the shop order warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Warehouse { get; set; }
	/// <summary>Code of the shop order warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseCode { get; set; }
	/// <summary>Description of the shop order warehouse</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WarehouseDescription { get; set; }
}

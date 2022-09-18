namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ShopOrderMaterialPlan
{
	/// <summary>Indicates if this is a backflush step</summary>
	public byte? Backflush { get; set; }
	/// <summary>Calculator type</summary>
	public int? CalculatorType { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Description of the material</summary>
	public string Description { get; set; }
	/// <summary>Detail drawing reference</summary>
	public string DetailDrawing { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Reference to Items table</summary>
	public Guid? Item { get; set; }
	/// <summary>Item Code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of Item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>URL of the material item&apos;s picture</summary>
	public string ItemPictureUrl { get; set; }
	/// <summary>Line number</summary>
	public int? LineNumber { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Line notes</summary>
	public string Notes { get; set; }
	/// <summary>Planned amount in the currency of the transaction</summary>
	public double? PlannedAmountFC { get; set; }
	/// <summary>Date that the material is required.</summary>
	public DateTime? PlannedDate { get; set; }
	/// <summary>Planned price of the material</summary>
	public double? PlannedPriceFC { get; set; }
	/// <summary>Intended quantity</summary>
	public double? PlannedQuantity { get; set; }
	/// <summary>Intended quantity unit factor</summary>
	public double? PlannedQuantityFactor { get; set; }
	/// <summary>Reference to ShopOrders table</summary>
	public Guid? ShopOrder { get; set; }
	/// <summary>Line status</summary>
	public int? Status { get; set; }
	/// <summary>Description of Status</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string StatusDescription { get; set; }
	/// <summary>Type</summary>
	public int? Type { get; set; }
	/// <summary>Unit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Unit { get; set; }
	/// <summary>Unit description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string UnitDescription { get; set; }
}

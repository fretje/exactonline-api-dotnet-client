namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class BillOfMaterialMaterial
{
	/// <summary>Item average cost available when average cost method is used</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? AverageCost { get; set; }
	/// <summary>Indicates if this is a backflush item</summary>
	public byte? Backflush { get; set; }
	/// <summary>Calculator type</summary>
	public int? CalculatorType { get; set; }
	/// <summary>Cost batch</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? CostBatch { get; set; }
	/// <summary>Cost center</summary>
	public string CostCenter { get; set; }
	/// <summary>Cost center description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CostCenterDescription { get; set; }
	/// <summary>Cost unit</summary>
	public string CostUnit { get; set; }
	/// <summary>Cost unit description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CostUnitDescription { get; set; }
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
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid ID { get; set; }
	/// <summary>Key of item version</summary>
	public Guid? ItemVersion { get; set; }
	/// <summary>Line number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? LineNumber { get; set; }
	/// <summary>Net weight</summary>
	public double? NetWeight { get; set; }
	/// <summary>Net weight unit of measure</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string NetWeightUnit { get; set; }
	/// <summary>Notes</summary>
	public string Notes { get; set; }
	/// <summary>Key of part item</summary>
	public Guid? PartItem { get; set; }
	/// <summary>Part item code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PartItemCode { get; set; }
	/// <summary>Item standard cost available when standard cost method is used</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? PartItemCostPriceStandard { get; set; }
	/// <summary>Part item description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PartItemDescription { get; set; }
	/// <summary>Quantity</summary>
	public double? Quantity { get; set; }
	/// <summary>Quantity batch</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? QuantityBatch { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? syscreated { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? syscreator { get; set; }
	/// <summary>Modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? sysmodified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? sysmodifier { get; set; }
	/// <summary>Material type 1 indicates material, 2 indicates byproduct</summary>
	public int? Type { get; set; }
}

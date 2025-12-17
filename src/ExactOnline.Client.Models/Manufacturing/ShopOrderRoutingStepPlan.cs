namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ShopOrderRoutingStepPlan
{
	/// <summary>Reference to Account providing the Outsourced item</summary>
	public Guid? Account { get; set; }
	/// <summary>Account name</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? AccountName { get; set; }
	/// <summary>Account number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? AccountNumber { get; set; }
	/// <summary>Attended Percentage</summary>
	public double? AttendedPercentage { get; set; }
	/// <summary>Indicates if this is a backflush step</summary>
	public byte? Backflush { get; set; }
	/// <summary>Total cost / Shop order planned quantity</summary>
	public double? CostPerItem { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Description of the operation</summary>
	public string? Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Efficiency Percentage</summary>
	public double? EfficiencyPercentage { get; set; }
	/// <summary>Conversion factor type between Shop order Item and Subcontract purchase Unit</summary>
	public int? FactorType { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Sequential order of the operation</summary>
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
	/// <summary>Notes</summary>
	public string? Notes { get; set; }
	/// <summary>Reference to Operations</summary>
	public Guid? Operation { get; set; }
	/// <summary>Code of the routing step operation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? OperationCode { get; set; }
	/// <summary>Description of the operation step</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? OperationDescription { get; set; }
	/// <summary>Reference to OperationResources</summary>
	public Guid? OperationResource { get; set; }
	/// <summary>Planned end date</summary>
	public DateTime? PlannedEndDate { get; set; }
	/// <summary>Planned run hours</summary>
	public double? PlannedRunHours { get; set; }
	/// <summary>Planned setup hours</summary>
	public double? PlannedSetupHours { get; set; }
	/// <summary>Planned start date</summary>
	public DateTime? PlannedStartDate { get; set; }
	/// <summary>Setup hours + Run hours</summary>
	public double? PlannedTotalHours { get; set; }
	/// <summary>Reference to Units</summary>
	public string? PurchaseUnit { get; set; }
	/// <summary>Purchase Unit Factor</summary>
	public double? PurchaseUnitFactor { get; set; }
	/// <summary>Purchase Unit Price in the currency of the transaction</summary>
	public double? PurchaseUnitPriceFC { get; set; }
	/// <summary>Purchase unit quantity of the plan</summary>
	public double? PurchaseUnitQuantity { get; set; }
	/// <summary>Reference to RoutingStepTypes</summary>
	public int? RoutingStepType { get; set; }
	/// <summary>Used in conjunction with RunMethod, and EfficiencyPercentage to determine PlannedRunHours</summary>
	public double? Run { get; set; }
	/// <summary>Reference to OperationMethod</summary>
	public int? RunMethod { get; set; }
	/// <summary>Description of RunMethod</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? RunMethodDescription { get; set; }
	/// <summary>Used in conjunction with SetupCount and Setup Unit to determine PlannedSetupHours</summary>
	public double? Setup { get; set; }
	/// <summary>Reference to TimeUnits</summary>
	public string? SetupUnit { get; set; }
	/// <summary>Reference to Shop orders</summary>
	public Guid? ShopOrder { get; set; }
	/// <summary>Reference to OperationStatus</summary>
	public int? Status { get; set; }
	/// <summary>Description of Status</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? StatusDescription { get; set; }
	/// <summary>Subcontracted lead days</summary>
	public int? SubcontractedLeadDays { get; set; }
	/// <summary>Collection of TimeTransactions</summary>
	public IEnumerable<TimeTransaction>? TimeTransactions { get; set; }
	/// <summary>Total cost of the routing line</summary>
	public double? TotalCostDC { get; set; }
	/// <summary>Reference to Workcenters</summary>
	public Guid? Workcenter { get; set; }
	/// <summary>Workcenter code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WorkcenterCode { get; set; }
	/// <summary>Workcenter description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WorkcenterDescription { get; set; }
}

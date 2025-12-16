namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class OperationResource
{
	/// <summary>Reference to Accounts</summary>
	public Guid? Account { get; set; }
	/// <summary>Attended percentage</summary>
	public double? AttendedPercentage { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Reference to Currencies</summary>
	public string? Currency { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Efficiency percentage</summary>
	public double? EfficiencyPercentage { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Indicates if this is the primary operation of the workcenter</summary>
	public byte? IsPrimary { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Reference to Operations</summary>
	public Guid? Operation { get; set; }
	/// <summary>Description of Operation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? OperationDescription { get; set; }
	/// <summary>Lead days from purchase</summary>
	public int? PurchaseLeadDays { get; set; }
	/// <summary>Unit of purchased item from supplier</summary>
	public string? PurchaseUnit { get; set; }
	/// <summary>VAT code used for purchased item from supplier</summary>
	public string? PurchaseVATCode { get; set; }
	/// <summary>Used in conjuction with RunMethod and EfficiencyPercentage to determine PlannedRunHours</summary>
	public double? Run { get; set; }
	/// <summary>Reference to OperationRunMethods</summary>
	public int? RunMethod { get; set; }
	/// <summary>Used in conjunction with SetupCount and SetupUnit to determine PlannedSetupHours</summary>
	public double? Setup { get; set; }
	/// <summary>Reference to TimeUnits</summary>
	public string? SetupUnit { get; set; }
	/// <summary>Reference to RoutingStepTypes</summary>
	public int? Type { get; set; }
	/// <summary>Reference to Workcenter</summary>
	public Guid? Workcenter { get; set; }
	/// <summary>Description of Workcenter</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? WorkcenterDescription { get; set; }
}

namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class TimedTimeTransaction
{
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>ID of employee</summary>
	public Guid? Employee { get; set; }
	/// <summary>Name of employee</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string EmployeeFullName { get; set; }
	/// <summary>Time that operation was stopped</summary>
	public DateTime? EndTime { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Is the operation finished?</summary>
	public byte? IsOperationFinished { get; set; }
	/// <summary>Adjustable labor hours</summary>
	public double? LaborHours { get; set; }
	/// <summary>Adjustable machine hours</summary>
	public double? MachineHours { get; set; }
	/// <summary>Modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Notes - viewable in data collection</summary>
	public string Notes { get; set; }
	/// <summary>ID of operation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Operation { get; set; }
	/// <summary>Code of operation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string OperationCode { get; set; }
	/// <summary>Description of operation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string OperationDescription { get; set; }
	/// <summary>Percentage of operation completed within time period</summary>
	public double? PercentComplete { get; set; }
	/// <summary>Quantity of make item produced within time period</summary>
	public double? ProducedQuantity { get; set; }
	/// <summary>Production area of the work center</summary>
	public Guid? ProductionArea { get; set; }
	/// <summary>Code of production area of the work center</summary>
	public string ProductionAreaCode { get; set; }
	/// <summary>Description of production area of the work center</summary>
	public string ProductionAreaDescription { get; set; }
	/// <summary>ID of shop order</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? ShopOrder { get; set; }
	/// <summary>Description of shop order</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ShopOrderDescription { get; set; }
	/// <summary>Number of shop order</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? ShopOrderNumber { get; set; }
	/// <summary>Shop order routing step where work occurred</summary>
	public Guid? ShopOrderRoutingStepPlan { get; set; }
	/// <summary>Description of the routing step plan</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ShopOrderRoutingStepPlanDescription { get; set; }
	/// <summary>Remaining planned run hours of the routing step plan</summary>
	public double ShopOrderRoutingStepPlanRemainingRunHours { get; set; }
	/// <summary>Remaining planned setup hours of the routing step plan</summary>
	public double ShopOrderRoutingStepPlanRemainingSetupHours { get; set; }
	/// <summary>Source of the timed time transaction</summary>
	public int? Source { get; set; }
	/// <summary>Time that operation was started</summary>
	public DateTime? StartTime { get; set; }
	/// <summary>Status of the timed time transaction</summary>
	public int? Status { get; set; }
	/// <summary>Type of the timed time transaction: Setup = 10, Run = 20</summary>
	public int? Type { get; set; }
	/// <summary>Work center where work occurred</summary>
	public Guid? Workcenter { get; set; }
	/// <summary>Code of the work center</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WorkcenterCode { get; set; }
	/// <summary>Description of the work center</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string WorkcenterDescription { get; set; }
}

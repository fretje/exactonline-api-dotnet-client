namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class TimeTransaction
{
	/// <summary>Manufacturing time type: Setup = 10, Run = 20</summary>
	public int? Activity { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Date</summary>
	public DateTime? Date { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Employee linked to the transaction</summary>
	public Guid? Employee { get; set; }
	/// <summary>Machine hours</summary>
	public double? Hours { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Is the operation finished?</summary>
	public byte? IsOperationFinished { get; set; }
	/// <summary>Labor Hours on the operation</summary>
	public double? LaborHours { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Notes linked to the time transaction</summary>
	public string? Notes { get; set; }
	/// <summary>Percentage of the operation that is complete</summary>
	public double? PercentComplete { get; set; }
	/// <summary>Quantity</summary>
	public double? Quantity { get; set; }
	/// <summary>Routing step linked to the transaction</summary>
	public Guid? RoutingStepPlan { get; set; }
	/// <summary>Shop order linked to the transaction</summary>
	public Guid? ShopOrder { get; set; }
	/// <summary>Status of the transaction: Draft = 1, Rejected = 2, Submitted = 10, Final = 20</summary>
	public int? Status { get; set; }
	/// <summary>Timed time transaction linked to the transaction</summary>
	public Guid? TimedTimeTransaction { get; set; }
	/// <summary>Workcenter linked to the transaction</summary>
	public Guid? WorkCenter { get; set; }
}

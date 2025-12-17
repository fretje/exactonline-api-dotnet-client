namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("Id")]
public class RecentHour
{
	/// <summary>Code of Account</summary>
	public string? AccountCode { get; set; }
	/// <summary>Reference to Account</summary>
	public Guid? AccountId { get; set; }
	/// <summary>Name of Account</summary>
	public string? AccountName { get; set; }
	/// <summary>Reference to Activity</summary>
	public Guid? Activity { get; set; }
	/// <summary>Description of Activity</summary>
	public string? ActivityDescription { get; set; }
	/// <summary>Date</summary>
	public DateTime Date { get; set; }
	/// <summary>Entry ID</summary>
	public Guid? EntryId { get; set; }
	/// <summary>Hours approved</summary>
	public double HoursApproved { get; set; }
	/// <summary>Billable hours approved</summary>
	public double HoursApprovedBillable { get; set; }
	/// <summary>Hours draft</summary>
	public double HoursDraft { get; set; }
	/// <summary>Billable hours draft</summary>
	public double HoursDraftBillable { get; set; }
	/// <summary>Hours rejected</summary>
	public double HoursRejected { get; set; }
	/// <summary>Billable hours rejected</summary>
	public double HoursRejectedBillable { get; set; }
	/// <summary>Hours submitted</summary>
	public double HoursSubmitted { get; set; }
	/// <summary>Billable hours submitted</summary>
	public double HoursSubmittedBillable { get; set; }
	/// <summary>Primary key</summary>
	public int Id { get; set; }
	/// <summary>Code of Item</summary>
	public string? ItemCode { get; set; }
	/// <summary>Description of Item</summary>
	public string? ItemDescription { get; set; }
	/// <summary>Reference to Item</summary>
	public Guid? ItemId { get; set; }
	/// <summary>Remarks</summary>
	public string? Notes { get; set; }
	/// <summary>Code of Project</summary>
	public string? ProjectCode { get; set; }
	/// <summary>Description of Project</summary>
	public string? ProjectDescription { get; set; }
	/// <summary>Reference to Project</summary>
	public Guid? ProjectId { get; set; }
	/// <summary>Week number</summary>
	public int WeekNumber { get; set; }
}

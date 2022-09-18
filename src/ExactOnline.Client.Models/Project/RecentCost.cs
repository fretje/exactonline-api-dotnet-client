namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("Id")]
public class RecentCost
{
	/// <summary>Code of Account</summary>
	public string AccountCode { get; set; }
	/// <summary>Reference to Account</summary>
	public Guid? AccountId { get; set; }
	/// <summary>Name of Account</summary>
	public string AccountName { get; set; }
	/// <summary>Amount approved</summary>
	public double AmountApproved { get; set; }
	/// <summary>Amount draft</summary>
	public double AmountDraft { get; set; }
	/// <summary>Amount rejected</summary>
	public double AmountRejected { get; set; }
	/// <summary>Amount submitted</summary>
	public double AmountSubmitted { get; set; }
	/// <summary>Code of Currency</summary>
	public string CurrencyCode { get; set; }
	/// <summary>Date</summary>
	public DateTime Date { get; set; }
	/// <summary>Entry ID</summary>
	public Guid? EntryId { get; set; }
	/// <summary>Reference to Expense</summary>
	public Guid? Expense { get; set; }
	/// <summary>Description of Expense</summary>
	public string ExpenseDescription { get; set; }
	/// <summary>Primary key</summary>
	public int Id { get; set; }
	/// <summary>Code of Item</summary>
	public string ItemCode { get; set; }
	/// <summary>Description of Item</summary>
	public string ItemDescription { get; set; }
	/// <summary>Reference to Item</summary>
	public Guid? ItemId { get; set; }
	/// <summary>Remarks</summary>
	public string Notes { get; set; }
	/// <summary>Code of Project</summary>
	public string ProjectCode { get; set; }
	/// <summary>Description of Project</summary>
	public string ProjectDescription { get; set; }
	/// <summary>Reference to Project</summary>
	public Guid? ProjectId { get; set; }
	/// <summary>Quantity approved</summary>
	public double QuantityApproved { get; set; }
	/// <summary>Quantity draft</summary>
	public double QuantityDraft { get; set; }
	/// <summary>Quantity rejected</summary>
	public double QuantityRejected { get; set; }
	/// <summary>Quantity submitted</summary>
	public double QuantitySubmitted { get; set; }
	/// <summary>Week number</summary>
	public int WeekNumber { get; set; }
}

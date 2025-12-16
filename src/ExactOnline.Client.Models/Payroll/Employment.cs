namespace ExactOnline.Client.Models.Payroll;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class Employment
{
	/// <summary>Creation date</summary>
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	public string? CreatorFullName { get; set; }
	/// <summary>Division code</summary>
	public int? Division { get; set; }
	/// <summary>Employee ID</summary>
	public Guid? Employee { get; set; }
	/// <summary>Name of employee</summary>
	public string? EmployeeFullName { get; set; }
	/// <summary>Numeric number of Employee</summary>
	public int? EmployeeHID { get; set; }
	/// <summary>End date of employment</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>Numeric ID of the employment</summary>
	public int? HID { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Last modified date</summary>
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	public string? ModifierFullName { get; set; }
	/// <summary>ID of employment ended</summary>
	public int? ReasonEnd { get; set; }
	/// <summary>Reason of end of employment</summary>
	public string? ReasonEndDescription { get; set; }
	/// <summary>Reason of ended flexible employment</summary>
	public int? ReasonEndFlex { get; set; }
	/// <summary>Other reason for end of employment</summary>
	public string? ReasonEndFlexDescription { get; set; }
	/// <summary>Start date of employment</summary>
	public DateTime? StartDate { get; set; }
	/// <summary>Start date of the employee in the organization. This field is used to count the years in service.</summary>
	public DateTime? StartDateOrganization { get; set; }
}

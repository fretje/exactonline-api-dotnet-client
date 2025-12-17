namespace ExactOnline.Client.Models.Payroll;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class ActiveEmployment
{
	/// <summary>The average number of contract days that an employee works per week</summary>
	public double? AverageDaysPerWeek { get; set; }
	/// <summary>The average number of contract hours that an employee works per week</summary>
	public double? AverageHoursPerWeek { get; set; }
	/// <summary>Employment contract ID</summary>
	public Guid? Contract { get; set; }
	/// <summary>Document ID of the employment contract</summary>
	public Guid? ContractDocument { get; set; }
	/// <summary>End date of employment contract</summary>
	public DateTime? ContractEndDate { get; set; }
	/// <summary>Employment probation end date</summary>
	public DateTime? ContractProbationEndDate { get; set; }
	/// <summary>Employment probation period</summary>
	public int? ContractProbationPeriod { get; set; }
	/// <summary>Start date of employment contract</summary>
	public DateTime? ContractStartDate { get; set; }
	/// <summary>Type of employment contract. 1 - Definite, 2 - Indefinite, 3 - External</summary>
	public int? ContractType { get; set; }
	/// <summary>Description of employment contract type</summary>
	public string? ContractTypeDescription { get; set; }
	/// <summary>Creation date</summary>
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	public string? CreatorFullName { get; set; }
	/// <summary>Department of employee</summary>
	public Guid? Department { get; set; }
	/// <summary>Department code of employee</summary>
	public string? DepartmentCode { get; set; }
	/// <summary>Description of department</summary>
	public string? DepartmentDescription { get; set; }
	/// <summary>Division code</summary>
	public int? Division { get; set; }
	/// <summary>Employee ID</summary>
	public Guid? Employee { get; set; }
	/// <summary>Name of employee</summary>
	public string? EmployeeFullName { get; set; }
	/// <summary>Numeric number of Employee</summary>
	public int? EmployeeHID { get; set; }
	/// <summary>Organization of employment</summary>
	public Guid? EmploymentOrganization { get; set; }
	/// <summary>End date of employment</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>Numeric ID of the employment</summary>
	public int? HID { get; set; }
	/// <summary>Hourly wage</summary>
	public double? HourlyWage { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Internal rate for time &amp; billing or professional service user</summary>
	public double? InternalRate { get; set; }
	/// <summary>Job title of employee</summary>
	public Guid? Jobtitle { get; set; }
	/// <summary>Description of job title</summary>
	public string? JobtitleDescription { get; set; }
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
	/// <summary>Employment salary</summary>
	public Guid? Salary { get; set; }
	/// <summary>Work schedule</summary>
	public Guid? Schedule { get; set; }
	/// <summary>Average hours per week in a schedule.</summary>
	public double? ScheduleAverageHours { get; set; }
	/// <summary>Work schedule code</summary>
	public string? ScheduleCode { get; set; }
	/// <summary>Number of days of work per week</summary>
	public double? ScheduleDays { get; set; }
	/// <summary>Description of work schedule</summary>
	public string? ScheduleDescription { get; set; }
	/// <summary>Number of work hours per week.</summary>
	public double? ScheduleHours { get; set; }
	/// <summary>Start date of employment</summary>
	public DateTime? StartDate { get; set; }
	/// <summary>Start date of the employee in the organization. This field is used to count the years in service.</summary>
	public DateTime? StartDateOrganization { get; set; }
}

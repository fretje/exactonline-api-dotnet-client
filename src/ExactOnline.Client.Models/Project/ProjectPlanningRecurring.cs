namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ProjectPlanningRecurring
{
	/// <summary>Account linked to the recurring planning</summary>
	public Guid? Account { get; set; }
	/// <summary>Code of Account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string AccountCode { get; set; }
	/// <summary>Name of Account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string AccountName { get; set; }
	/// <summary>Status of the project planning process, 1 = To be processed, 2 = Processed, 3 = Failed</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short? BGTStatus { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Indicates whether the recurring planning is day of the month or weekday of the month</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? DayOrThe { get; set; }
	/// <summary>Description of recurring planning</summary>
	public string Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Employee linked to the recurring planning</summary>
	public Guid? Employee { get; set; }
	/// <summary>Code of employee</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string EmployeeCode { get; set; }
	/// <summary>Numeric ID of the employee</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? EmployeeHID { get; set; }
	/// <summary>End date of the recurring planning</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>Indicates whether the recurring planning is end on end date or end after number of times</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? EndDateOrAfter { get; set; }
	/// <summary>End time for the recurring planning to be active</summary>
	public DateTime? EndTime { get; set; }
	/// <summary>Number of hours for the recurring planning</summary>
	public double? Hours { get; set; }
	/// <summary>Hour type of the recurring planning, item with &apos;Time&apos; type</summary>
	public Guid? HourType { get; set; }
	/// <summary>Code of the hour type</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string HourTypeCode { get; set; }
	/// <summary>Description of the hour type</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string HourTypeDescription { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Date modified</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>Modifier user ID</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Modifier name</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Day of the monthly recurring</summary>
	public byte? MonthPatternDay { get; set; }
	/// <summary>Ordinal number of week day for the monthly recurring planning, 1 = first, 2 = second, 3 = third, 4 = fourth, 31 = last</summary>
	public byte? MonthPatternOrdinalDay { get; set; }
	/// <summary>Ordinal week day of the monthly recurring planning, 1 = Monday, 2 = Tuesday, 3 = Wednesday, 4 = Thursday, 5 = Friday, 6 = Saturday, 7 = Sunday</summary>
	public byte? MonthPatternOrdinalWeek { get; set; }
	/// <summary>For additional information about recurring planning</summary>
	public string Notes { get; set; }
	/// <summary>Number of times the planning recurs</summary>
	public short? NumberOfRecurrences { get; set; }
	/// <summary>Indicates whether the entries can have over allocated planning hours</summary>
	public bool? OverAllocate { get; set; }
	/// <summary>Number of planning times for weekly or monthly recurring planning</summary>
	public byte? PatternFrequency { get; set; }
	/// <summary>Project linked to the recurring planning</summary>
	public Guid? Project { get; set; }
	/// <summary>Code of project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectCode { get; set; }
	/// <summary>Description of project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectDescription { get; set; }
	/// <summary>Type of the recurring planning, 1 = weekly, 2 = monthly</summary>
	public byte? ProjectPlanningRecurringType { get; set; }
	/// <summary>WBS linked to the recurring planning</summary>
	public Guid? ProjectWBS { get; set; }
	/// <summary>Description of WBS</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectWBSDescription { get; set; }
	/// <summary>Start date of the recurring planning</summary>
	public DateTime? StartDate { get; set; }
	/// <summary>Start time for the recurring planning to be active</summary>
	public DateTime? StartTime { get; set; }
	/// <summary>Status of the project planning, 1 = Reserved, 2 = Planned</summary>
	public short? Status { get; set; }
	/// <summary>Week day for the weekly recurring planning</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte? WeekPatternDay { get; set; }
	/// <summary>Create planning on Friday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternFriday { get; set; }
	/// <summary>Create planning on Monday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternMonday { get; set; }
	/// <summary>Create planning on Saturday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternSaturday { get; set; }
	/// <summary>Create planning on Sunday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternSunday { get; set; }
	/// <summary>Create planning on Thursday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternThursday { get; set; }
	/// <summary>Create planning on Tuesday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternTuesday { get; set; }
	/// <summary>Create planning on Wednesday, apply to weekly pattern recurring planning only</summary>
	public bool? WeekPatternWednesday { get; set; }
}

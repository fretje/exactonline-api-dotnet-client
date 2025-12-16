namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class EmploymentInternalRate
{
	/// <summary>Creation date</summary>
	public DateTime Created { get; set; }
	/// <summary>Creator</summary>
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	public string? CreatorFullName { get; set; }
	/// <summary>Division code</summary>
	public int Division { get; set; }
	/// <summary>Employee</summary>
	public Guid Employee { get; set; }
	/// <summary>Name of employee</summary>
	public string? EmployeeFullName { get; set; }
	/// <summary>Employee number</summary>
	public int EmployeeHID { get; set; }
	/// <summary>Employment</summary>
	public Guid Employment { get; set; }
	/// <summary>Employment number</summary>
	public int EmploymentHID { get; set; }
	/// <summary>End date</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Internal rate</summary>
	public double? InternalRate { get; set; }
	/// <summary>Last modified date</summary>
	public DateTime Modified { get; set; }
	/// <summary>Modifier</summary>
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	public string? ModifierFullName { get; set; }
	/// <summary>Start date</summary>
	public DateTime StartDate { get; set; }
}

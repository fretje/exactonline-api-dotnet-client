namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ProjectRestrictionEmployee
{
	/// <summary>Date created</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>Creator user ID</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Creator name</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Employee linked to the restriction</summary>
	public Guid? Employee { get; set; }
	/// <summary>Name of employee</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string EmployeeFullName { get; set; }
	/// <summary>Readable ID of the employee</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? EmployeeHID { get; set; }
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
	/// <summary>Project linked to the restriction</summary>
	public Guid? Project { get; set; }
	/// <summary>Project code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectCode { get; set; }
	/// <summary>Project description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectDescription { get; set; }
}

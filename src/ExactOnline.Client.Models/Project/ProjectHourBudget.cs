namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ProjectHourBudget
{
	/// <summary>Number of hours</summary>
	public double? Budget { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Division number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Hour type of budget</summary>
	public Guid? Item { get; set; }
	/// <summary>Code of hour type</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemCode { get; set; }
	/// <summary>Description of hour type</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemDescription { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Reference to project</summary>
	public Guid Project { get; set; }
	/// <summary>Code of project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ProjectCode { get; set; }
	/// <summary>Description of project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ProjectDescription { get; set; }
}

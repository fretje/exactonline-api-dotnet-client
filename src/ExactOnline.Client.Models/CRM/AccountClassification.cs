namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class AccountClassification
{
	/// <summary>Reference to Account classification name</summary>
	public Guid? AccountClassificationName { get; set; }
	/// <summary>Description of AccountClassificationName</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string AccountClassificationNameDescription { get; set; }
	/// <summary>Account classification code</summary>
	public string Code { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Description</summary>
	public string Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
}

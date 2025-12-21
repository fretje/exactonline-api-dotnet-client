namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class ProductionArea
{
	/// <summary>Code of the production area group</summary>
	public string? Code { get; set; }
	/// <summary>Reference to Cost center</summary>
	public string? Costcenter { get; set; }
	/// <summary>Description of Costcenter</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CostcenterDescription { get; set; }
	/// <summary>Reference to Cost unit</summary>
	public string? Costunit { get; set; }
	/// <summary>Description of Costunit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CostunitDescription { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Description of the production area</summary>
	public string? Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Indicates if this is the default production area. This will be used when creating a new production area</summary>
	public byte IsDefault { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Production area notes</summary>
	public string? Notes { get; set; }
}

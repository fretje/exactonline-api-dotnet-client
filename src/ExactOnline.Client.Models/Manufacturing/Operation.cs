namespace ExactOnline.Client.Models.Manufacturing;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class Operation
{
	/// <summary>Code of the operation</summary>
	public string? Code { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Description of the operation</summary>
	public string? Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Indicates if the operation has suppliers associated with it</summary>
	public byte? HasSuppliers { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Reference to Items table</summary>
	public Guid? Item { get; set; }
	/// <summary>Description of Item</summary>
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
	/// <summary>Extra remarks</summary>
	public string? Notes { get; set; }
	/// <summary>Search code for the operation</summary>
	public string? Searchcode { get; set; }
	/// <summary>Status of the operation</summary>
	public int? Status { get; set; }
}

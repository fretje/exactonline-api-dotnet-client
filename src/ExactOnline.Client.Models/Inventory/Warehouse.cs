namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class Warehouse
{
	/// <summary>Code of the warehouse</summary>
	public string Code { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>The default storage location of this warehouse. Warehouses can have a default storage location in packages Manufacturing Premium or Wholesale Premium</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? DefaultStorageLocation { get; set; }
	/// <summary>Default storage location&apos;s code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DefaultStorageLocationCode { get; set; }
	/// <summary>Default storage location&apos;s description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DefaultStorageLocationDescription { get; set; }
	/// <summary>The description of the warehouse</summary>
	public string Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Email address</summary>
	public string EMail { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Indicates if this is the main warehouse. There&apos;s always exactly one main warehouse per administration</summary>
	public byte Main { get; set; }
	/// <summary>User reponsible for the warehouse</summary>
	public Guid? ManagerUser { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Indicates if this warehouse is using storage locations. The storage locations will not be removed when when this is deactivated</summary>
	public byte UseStorageLocations { get; set; }
}

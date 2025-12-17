namespace ExactOnline.Client.Models.Logistics;

[SupportedActionsSDK(false, true, false, false, allowsEmptySelect: true)]
[DataServiceKey(null)]
public class ItemExtraField
{
	/// <summary>Description of the free field</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? Description { get; set; }
	/// <summary>Item Identidy</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid ItemID { get; set; }
	/// <summary>Item last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>Used to determine the unique free field name as FreeField{Number}, first of all this is used for the external communication</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Number { get; set; }
	/// <summary>The value store in free field</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? Value { get; set; }
}

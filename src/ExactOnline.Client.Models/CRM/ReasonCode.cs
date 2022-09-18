namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class ReasonCode
{
	/// <summary>Indicates if the reason code is active.</summary>
	public byte? Active { get; set; }
	/// <summary>Code of the reason.</summary>
	public string Code { get; set; }
	/// <summary>Creation date.</summary>
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator.</summary>
	public string CreatorFullName { get; set; }
	/// <summary>Description of the reason code.</summary>
	public string Description { get; set; }
	/// <summary>Division code.</summary>
	public int? Division { get; set; }
	/// <summary>Primary key.</summary>
	public Guid ID { get; set; }
	/// <summary>Last modified date.</summary>
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier.</summary>
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier.</summary>
	public string ModifierFullName { get; set; }
	/// <summary>Extra notes.</summary>
	public string Notes { get; set; }
	/// <summary>Type of the reason code.</summary>
	public short? Type { get; set; }
	/// <summary>Description of the type of the reason code.</summary>
	public string TypeDescription { get; set; }
}

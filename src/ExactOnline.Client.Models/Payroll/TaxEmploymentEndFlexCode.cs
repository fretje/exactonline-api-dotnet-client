namespace ExactOnline.Client.Models.Payroll;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class TaxEmploymentEndFlexCode
{
	/// <summary>Code of flexible employment contract phase</summary>
	public string Code { get; set; }
	/// <summary>Creation date</summary>
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	public string CreatorFullName { get; set; }
	/// <summary>Description of flexible employment contract phase</summary>
	public string Description { get; set; }
	/// <summary>End date of flexible employment contract</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Last modified date</summary>
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	public string ModifierFullName { get; set; }
	/// <summary>Start date of flexible employment contract phase</summary>
	public DateTime? StartDate { get; set; }
}

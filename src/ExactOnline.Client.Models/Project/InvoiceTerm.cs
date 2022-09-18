namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class InvoiceTerm
{
	/// <summary>Amount in the currency of the transaction</summary>
	public double? Amount { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>WBS&apos;s deliverable linked to invoice term</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Deliverable { get; set; }
	/// <summary>Description of invoice term</summary>
	public string Description { get; set; }
	/// <summary>Division number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Execution date: From</summary>
	public DateTime? ExecutionFromDate { get; set; }
	/// <summary>Execution date: To</summary>
	public DateTime? ExecutionToDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Invoice date</summary>
	public DateTime? InvoiceDate { get; set; }
	/// <summary>Reference to item</summary>
	public Guid? Item { get; set; }
	/// <summary>Description of item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Notes</summary>
	public string Notes { get; set; }
	/// <summary>Percentage of amount per project&apos;s budgeted amount</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? Percentage { get; set; }
	/// <summary>Reference to project</summary>
	public Guid? Project { get; set; }
	/// <summary>Description of project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectDescription { get; set; }
	/// <summary>Reference to VATCode</summary>
	public string VATCode { get; set; }
	/// <summary>Description of VATCode</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string VATCodeDescription { get; set; }
	/// <summary>VATCode percentage</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? VATPercentage { get; set; }
}

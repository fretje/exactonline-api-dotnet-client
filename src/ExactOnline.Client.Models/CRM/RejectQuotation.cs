namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(true, false, false, false)]
[DataServiceKey("QuotationID")]
public class RejectQuotation
{
	/// <summary>Division code.</summary>
	public int Division { get; set; }
	/// <summary>Contains the error message if an error occurred during the rejection of the quotation.</summary>
	public string? ErrorMessage { get; set; }
	/// <summary>Identifier of the quotation.</summary>
	public Guid QuotationID { get; set; }
	/// <summary>Reason why the quotation was rejected.</summary>
	public Guid? ReasonCode { get; set; }
	/// <summary>Contains information if the quotation was successfully rejected.</summary>
	public string? SuccessMessage { get; set; }
}

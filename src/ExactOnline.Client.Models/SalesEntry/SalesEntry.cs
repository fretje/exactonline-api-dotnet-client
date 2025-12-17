namespace ExactOnline.Client.Models.SalesEntry;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("EntryID")]
public class SalesEntry
{
	/// <summary>Amount in the default currency of the company. For the header lines (LineNumber = 0) of an entry this is the SUM(AmountDC) of all lines</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountDC { get; set; }
	/// <summary>Amount in the currency of the transaction. For the header this is the sum of all lines, including VAT</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountFC { get; set; }
	/// <summary>The number of the batch of entries. Normally a batch consists of multiple entries. Batchnumbers are filled for invoices created by: - Fixed entries - Prolongation (only available with module hosting)</summary>
	public int? BatchNumber { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Currency for the invoice. By default this is the currency of the administration</summary>
	public string? Currency { get; set; }
	/// <summary>Reference to customer (account)</summary>
	public Guid? Customer { get; set; }
	/// <summary>Name of customer</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CustomerName { get; set; }
	/// <summary>Description. Can be different for header and lines</summary>
	public string? Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Division { get; set; }
	/// <summary>Document that is manually linked to the invoice</summary>
	public Guid? Document { get; set; }
	/// <summary>Number of the document</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? DocumentNumber { get; set; }
	/// <summary>Subject of the document</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? DocumentSubject { get; set; }
	/// <summary>The due date for payments. This date is calculated based on the EntryDate and the Paymentcondition</summary>
	public DateTime? DueDate { get; set; }
	/// <summary>The date when the invoice is entered</summary>
	public DateTime? EntryDate { get; set; }
	/// <summary>The unique ID of the entry. Via this ID all transaction lines of a single entry can be retrieved</summary>
	public Guid EntryID { get; set; }
	/// <summary>Entry number</summary>
	public int? EntryNumber { get; set; }
	/// <summary>Description of ExternalLink</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ExternalLinkDescription { get; set; }
	/// <summary>Reference of ExternalLink</summary>
	public string? ExternalLinkReference { get; set; }
	/// <summary>A positive value of the amount indicates that the amount is to be paid by the customer to your G bank account.In case of a credit invoice the amount should have negative value when retrieved or posted to Exact.</summary>
	public double? GAccountAmountFC { get; set; }
	/// <summary>Assigned at entry or at printing depending on setting. The number assigned is based on the freenumbers as defined for the Journal. When printing the field InvoiceNumber is copied to the fields EntryNumber and InvoiceNumber of the sales entry</summary>
	public int? InvoiceNumber { get; set; }
	/// <summary>Indicates whether the invoice has extra duty</summary>
	public bool? IsExtraDuty { get; set; }
	/// <summary>The journal code. Every invoice should be linked to a sales journal</summary>
	public string? Journal { get; set; }
	/// <summary>Description of Journal</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? JournalDescription { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>Number to indentify the invoice. Order numbers are not unique. Default the number is based on a setting for the first free number</summary>
	public int? OrderNumber { get; set; }
	/// <summary>The payment condition used for due date and discount calculation</summary>
	public string? PaymentCondition { get; set; }
	/// <summary>Description of PaymentCondition</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? PaymentConditionDescription { get; set; }
	/// <summary>The payment reference used for bank imports, VAT return and Tax reference</summary>
	public string? PaymentReference { get; set; }
	public int? ProcessNumber { get; set; }
	/// <summary>Foreign currency rate</summary>
	public double? Rate { get; set; }
	/// <summary>The period of the transaction lines. The period should exist in the period date table</summary>
	public short? ReportingPeriod { get; set; }
	/// <summary>The financial year to which the entry belongs. The financial year should exist in the period date table</summary>
	public short? ReportingYear { get; set; }
	/// <summary>Indicates if amounts are reversed</summary>
	public bool Reversal { get; set; }
	/// <summary>Collection of lines</summary>
	public IEnumerable<SalesEntryLine>? SalesEntryLines { get; set; }
	/// <summary>Status: 20 = Open, 50 = Processed</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short? Status { get; set; }
	/// <summary>Description of Status</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? StatusDescription { get; set; }
	/// <summary>Type: 20 = Sales entry, 21 = Sales credit note</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Type { get; set; }
	/// <summary>Description of Type</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? TypeDescription { get; set; }
	/// <summary>Vat amount in the default currency of the company</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? VATAmountDC { get; set; }
	/// <summary>Vat amount in the currency of the transaction</summary>
	public double? VATAmountFC { get; set; }
	/// <summary>Withholding tax amount</summary>
	public double? WithholdingTaxAmountDC { get; set; }
	/// <summary>Withholding tax base amount to calculate withholding amount</summary>
	public double? WithholdingTaxBaseAmount { get; set; }
	/// <summary>Withholding tax percentage</summary>
	public double? WithholdingTaxPercentage { get; set; }
	/// <summary>The invoice number of the customer</summary>
	public string? YourRef { get; set; }
}

namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
[DataServiceKey("QuotationID")]
public class Quotation
{
	/// <summary>Amount in the default currency of the company</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountDC { get; set; }
	/// <summary>Discount Amount in the currency of the transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountDiscount { get; set; }
	/// <summary>Discount Amount excluding VAT in the currency of the transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountDiscountExclVat { get; set; }
	/// <summary>Amount in the currency of the transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountFC { get; set; }
	/// <summary>Date on which the customer accepted or rejected the quotation version</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? CloseDate { get; set; }
	/// <summary>Date on which you expect to close/win the deal</summary>
	public DateTime? ClosingDate { get; set; }
	/// <summary>Date and time on which the quotation was created</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime Created { get; set; }
	/// <summary>User ID of the creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of the creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>The currency of the quotation</summary>
	public string Currency { get; set; }
	/// <summary>The account where the items should delivered</summary>
	public Guid? DeliveryAccount { get; set; }
	/// <summary>The code of the delivery account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DeliveryAccountCode { get; set; }
	/// <summary>The contact person of the delivery account</summary>
	public Guid? DeliveryAccountContact { get; set; }
	/// <summary>Full name of the delivery account contact person</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DeliveryAccountContactFullName { get; set; }
	/// <summary>The name of the delivery account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DeliveryAccountName { get; set; }
	/// <summary>The id of the delivery address</summary>
	public Guid? DeliveryAddress { get; set; }
	/// <summary>The description of the quotation</summary>
	public string Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Division { get; set; }
	/// <summary>Document linked to the quotation</summary>
	public Guid? Document { get; set; }
	/// <summary>The subject of the document</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DocumentSubject { get; set; }
	/// <summary>Date after which the quotation is no longer valid</summary>
	public DateTime? DueDate { get; set; }
	/// <summary>The account to which the invoice is sent</summary>
	public Guid? InvoiceAccount { get; set; }
	/// <summary>The code of the invoice account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string InvoiceAccountCode { get; set; }
	/// <summary>The contact person of the invoice account</summary>
	public Guid? InvoiceAccountContact { get; set; }
	/// <summary>Full name of the invoice account contact person</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string InvoiceAccountContactFullName { get; set; }
	/// <summary>The name of the invoice account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string InvoiceAccountName { get; set; }
	/// <summary>Date and time on which the quotation was last modified</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime Modified { get; set; }
	/// <summary>User ID of the modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of the modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Opportunity linked to the quotation</summary>
	public Guid? Opportunity { get; set; }
	/// <summary>The name of the opportunity</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string OpportunityName { get; set; }
	/// <summary>The account that requested the quotation</summary>
	public Guid? OrderAccount { get; set; }
	/// <summary>The code of the order account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string OrderAccountCode { get; set; }
	/// <summary>The contact person of the order account</summary>
	public Guid? OrderAccountContact { get; set; }
	/// <summary>Full name of the order account contact person</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string OrderAccountContactFullName { get; set; }
	/// <summary>The name of the order account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string OrderAccountName { get; set; }
	/// <summary>Payment condition code</summary>
	public string PaymentCondition { get; set; }
	/// <summary>Payment condition description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PaymentConditionDescription { get; set; }
	/// <summary>The project linked to the quotation</summary>
	public Guid? Project { get; set; }
	/// <summary>The code of the project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectCode { get; set; }
	/// <summary>The description of the project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectDescription { get; set; }
	/// <summary>Date on which the quotation version is entered or printed. Both during entering and printing this date can be adjusted</summary>
	public DateTime? QuotationDate { get; set; }
	/// <summary>Identifier of the quotation</summary>
	public Guid QuotationID { get; set; }
	/// <summary>The collection of quotation lines</summary>
	public IEnumerable<QuotationLine> QuotationLines { get; set; }
	/// <summary>Unique number to indentify the quotation. By default this number is based on the setting for first available number</summary>
	public int QuotationNumber { get; set; }
	/// <summary>Extra text that can be added to the quotation</summary>
	public string Remarks { get; set; }
	/// <summary>The user that is responsible for the quotation version</summary>
	public Guid? SalesPerson { get; set; }
	/// <summary>Full name of the sales person</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string SalesPersonFullName { get; set; }
	/// <summary>Shipping method ID</summary>
	public Guid? ShippingMethod { get; set; }
	/// <summary>Shipping method description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? ShippingMethodDescription { get; set; }
	/// <summary>The status of the quotation version. 5 = Rejected, 6 = Reviewed and closed, 10 = Recovery, 20 = Draft, 25 = Open, 35 = Processing... , 40 = Printed, 50 = Accepted</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short? Status { get; set; }
	/// <summary>The description of the status</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string StatusDescription { get; set; }
	/// <summary>Total VAT amount in the currency of the transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? VATAmountFC { get; set; }
	/// <summary>Number indicating the different reviews which are made for the quotation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int VersionNumber { get; set; }
	/// <summary>The number by which this quotation is identified by the order account</summary>
	public string YourRef { get; set; }
}

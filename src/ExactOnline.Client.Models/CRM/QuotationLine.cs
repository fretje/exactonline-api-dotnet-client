namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
[DataServiceKey("ID")]
public class QuotationLine
{
	/// <summary>Amount in the default currency of the company</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountDC { get; set; }
	/// <summary>Amount in the currency of the transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double AmountFC { get; set; }
	/// <summary>By default this contains the item description</summary>
	public string? Description { get; set; }
	/// <summary>Discount given on the default price. This is stored as a fraction. ie 5.5% is stored as .055</summary>
	public double? Discount { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int Division { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Reference to the item that is sold in this quotation line</summary>
	public Guid? Item { get; set; }
	/// <summary>Description of the item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ItemDescription { get; set; }
	/// <summary>Indicates the sequence of the lines within one quotation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int LineNumber { get; set; }
	/// <summary>Net price of the quotation line</summary>
	public double? NetPrice { get; set; }
	/// <summary>Extra notes</summary>
	public string? Notes { get; set; }
	/// <summary>The number of items sold in default units. The quantity shown in the entry screen is Quantity * UnitFactor</summary>
	public double? Quantity { get; set; }
	/// <summary>Identifies the quotation. All the lines of a quotation have the same QuotationID</summary>
	public Guid QuotationID { get; set; }
	/// <summary>Unique number to indentify the quotation. By default this number is based on the setting for first available number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int QuotationNumber { get; set; }
	/// <summary>Code of the item unit</summary>
	public string? UnitCode { get; set; }
	/// <summary>Description of the item unit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? UnitDescription { get; set; }
	/// <summary>Price per item unit</summary>
	public double? UnitPrice { get; set; }
	/// <summary>VAT amount of the line in the currency of the transaction</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? VATAmountFC { get; set; }
	/// <summary>The VAT code that is used when the quotation is invoiced</summary>
	public string? VATCode { get; set; }
	/// <summary>Description of the VAT code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? VATDescription { get; set; }
	/// <summary>The VAT percentage of the VAT code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? VATPercentage { get; set; }
	/// <summary>Number indicating the different reviews which are made for the quotation</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int VersionNumber { get; set; }
}

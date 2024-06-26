namespace ExactOnline.Client.Models.SalesInvoice;

[SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
[DataServiceKey("ID")]
public class SalesInvoiceLine
{
	/// <summary>Amount in the default currency of the company. For almost all lines this can be calculated like: AmountDC = AmountFC * RateFC</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public double? AmountDC { get; set; }
	/// <summary>For normal lines it&apos;s the amount excluding VAT</summary>
	public double? AmountFC { get; set; }
	/// <summary>Reference to Cost center</summary>
	public string CostCenter { get; set; }
	/// <summary>Description of CostCenter</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CostCenterDescription { get; set; }
	/// <summary>Reference to Cost unit</summary>
	public string CostUnit { get; set; }
	/// <summary>Description of CostUnit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CostUnitDescription { get; set; }
	/// <summary>Delivery date of an item in a sales invoice. This is used for VAT on prepayments, only if sales order is not used in the license.</summary>
	public DateTime? DeliveryDate { get; set; }
	/// <summary>Description. Can be different for header and lines</summary>
	public string Description { get; set; }
	/// <summary>Discount given on the default price. Discount = (DefaultPrice of Item - PriceItem in line) / DefaultPrice of Item</summary>
	public double? Discount { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Link to Employee originating from time and cost transactions</summary>
	public Guid? Employee { get; set; }
	/// <summary>Name of employee</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string EmployeeFullName { get; set; }
	/// <summary>EndTime is used to store the last date of a period. EndTime is used in combination with StartTime</summary>
	public DateTime? EndTime { get; set; }
	/// <summary>Extra duty amount in the currency of the transaction. Both extra duty amount and VAT amount need to be specified in order to differ this property from automatically calculated.</summary>
	public double? ExtraDutyAmountFC { get; set; }
	/// <summary>Extra duty percentage</summary>
	public double? ExtraDutyPercentage { get; set; }
	/// <summary>The GL Account of the sales invoice line. This field is mandatory. This field is generated based on the revenue account of the item (or the related item group). G/L Account is also used to determine whether the costcenter / costunit is mandatory</summary>
	public Guid? GLAccount { get; set; }
	/// <summary>Description of GLAccount</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string GLAccountDescription { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>The InvoiceID identifies the sales invoice. All the lines of a sales invoice have the same InvoiceID</summary>
	public Guid InvoiceID { get; set; }
	/// <summary>Reference to the item that is sold in this sales invoice line</summary>
	public Guid? Item { get; set; }
	/// <summary>Item code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemCode { get; set; }
	/// <summary>Description of Item</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ItemDescription { get; set; }
	/// <summary>Indicates the sequence of the lines within one invoice</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? LineNumber { get; set; }
	/// <summary>Net price of the sales invoice line</summary>
	public double? NetPrice { get; set; }
	/// <summary>Extra notes</summary>
	public string Notes { get; set; }
	/// <summary>Price list</summary>
	public Guid? Pricelist { get; set; }
	/// <summary>Description of Pricelist</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PricelistDescription { get; set; }
	/// <summary>The project to which the sales transaction line is linked. The project can be different per line. Sometimes also the project in the header is filled although this is not really used</summary>
	public Guid? Project { get; set; }
	/// <summary>Description of Project</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectDescription { get; set; }
	/// <summary>WBS linked to the sales invoice</summary>
	public Guid? ProjectWBS { get; set; }
	/// <summary>Description of WBS</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ProjectWBSDescription { get; set; }
	/// <summary>The number of items sold in default units. The quantity shown in the entry screen is Quantity * UnitFactor</summary>
	public double? Quantity { get; set; }
	/// <summary>Identifies the sales order this invoice line is based on</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? SalesOrder { get; set; }
	/// <summary>Identifies the sales order line this sales invoice line is based on</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? SalesOrderLine { get; set; }
	/// <summary>Then line number of the sales order line on which this invoice line is based on</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? SalesOrderLineNumber { get; set; }
	/// <summary>The order number of the sales order on which this invoice line is based on</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? SalesOrderNumber { get; set; }
	/// <summary>StartTime is used to store the first date of a period. StartTime is used in combination with EndTime</summary>
	public DateTime? StartTime { get; set; }
	/// <summary>When generating invoices from subscriptions, this field records the link between invoice lines and subscription lines</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Subscription { get; set; }
	/// <summary>Description of subscription line</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string SubscriptionDescription { get; set; }
	/// <summary>Obsolete</summary>
	public Guid? TaxSchedule { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string TaxScheduleCode { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string TaxScheduleDescription { get; set; }
	/// <summary>Code of Unit</summary>
	public string UnitCode { get; set; }
	/// <summary>Description of Unit</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string UnitDescription { get; set; }
	/// <summary>Price per unit</summary>
	public double? UnitPrice { get; set; }
	/// <summary>VAT amount in the default currency of the company</summary>
	public double? VATAmountDC { get; set; }
	/// <summary>VAT amount in the currency of the transaction</summary>
	public double? VATAmountFC { get; set; }
	/// <summary>The VAT code that is used when the invoice is registered</summary>
	public string VATCode { get; set; }
	/// <summary>Description of VATCode</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string VATCodeDescription { get; set; }
	/// <summary>The vat percentage of the VAT code. This is the percentage at the moment the invoice is created. It&apos;s also used for the default calculation of VAT amounts and VAT base amounts</summary>
	public double? VATPercentage { get; set; }
}

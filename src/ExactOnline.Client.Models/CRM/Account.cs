namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
[DataServiceKey("ID")]
public class Account : SupportsSync
{
	/// <summary>Reference to the accountant of the customer. Conditions: The referred accountant must have value &gt; 0 in the field IsAccountant</summary>
	public Guid? Accountant { get; set; }
	/// <summary>ID of the account manager</summary>
	public Guid? AccountManager { get; set; }
	/// <summary>Name of the account manager</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string AccountManagerFullName { get; set; }
	/// <summary>Number of the account manager  </summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? AccountManagerHID { get; set; }
	/// <summary>Reference to Activity sector of the account</summary>
	public Guid? ActivitySector { get; set; }
	/// <summary>Reference to Activity sub-sector of the account</summary>
	public Guid? ActivitySubSector { get; set; }
	/// <summary>Visit address first line</summary>
	public string AddressLine1 { get; set; }
	/// <summary>Visit address second line</summary>
	public string AddressLine2 { get; set; }
	/// <summary>Visit address third line</summary>
	public string AddressLine3 { get; set; }
	/// <summary>Collection of Bank accounts</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public IEnumerable<BankAccount> BankAccounts { get; set; }
	/// <summary>Indicates if the account is blocked</summary>
	public bool? Blocked { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? BRIN { get; set; }
	/// <summary>Reference to the business type of the account</summary>
	public Guid? BusinessType { get; set; }
	/// <summary>Indicates the default for the possibility to drop ship when an item is linked to a supplier</summary>
	public bool? CanDropShip { get; set; }
	/// <summary>Chamber of commerce number</summary>
	public string ChamberOfCommerce { get; set; }
	/// <summary>Visit address City</summary>
	public string City { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Classification { get; set; }
	/// <summary>Account classification 1</summary>
	public Guid? Classification1 { get; set; }
	/// <summary>Account classification 2</summary>
	public Guid? Classification2 { get; set; }
	/// <summary>Account classification 3</summary>
	public Guid? Classification3 { get; set; }
	/// <summary>Account classification 4</summary>
	public Guid? Classification4 { get; set; }
	/// <summary>Account classification 5</summary>
	public Guid? Classification5 { get; set; }
	/// <summary>Account classification 6</summary>
	public Guid? Classification6 { get; set; }
	/// <summary>Account classification 7</summary>
	public Guid? Classification7 { get; set; }
	/// <summary>Account classification 8</summary>
	public Guid? Classification8 { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ClassificationDescription { get; set; }
	/// <summary>Unique key, fixed length numeric string with leading spaces, length 18. IMPORTANT: When you use OData $filter on this field you have to make sure the filter parameter contains the leading spaces</summary>
	public string Code { get; set; }
	/// <summary>Code under which your own company is known at the account</summary>
	public string CodeAtSupplier { get; set; }
	/// <summary>Reference to Company size of the account</summary>
	public Guid? CompanySize { get; set; }
	/// <summary>Consolidation scenario (Time &amp; Billing). Values: 0 = No consolidation, 1 = Item, 2 = Item + Project, 3 = Item + Employee, 4 = Item + Employee + Project, 5 = Project + WBS + Item, 6 = Project + WBS + Item + Employee. Item means in this case including Unit and Price, these also have to be the same to consolidate</summary>
	public byte? ConsolidationScenario { get; set; }
	/// <summary>Date of the latest control of account data with external web service</summary>
	public DateTime? ControlledDate { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Costcenter { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CostcenterDescription { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte CostPaid { get; set; }
	/// <summary>Country code</summary>
	public string Country { get; set; }
	/// <summary>Country name</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CountryName { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Maximum amount of credit for Purchase. If no value has been defined, there is no credit limit</summary>
	public double? CreditLinePurchase { get; set; }
	/// <summary>Maximum amount of credit for sales. If no value has been defined, there is no credit limit</summary>
	public double? CreditLineSales { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Currency { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? CustomerSince { get; set; }
	/// <summary>DATEV creditor code for Germany legislation</summary>
	public string DatevCreditorCode { get; set; }
	/// <summary>DATEV debtor code for Germany legislation</summary>
	public string DatevDebtorCode { get; set; }
	/// <summary>Default discount percentage for purchase. This is stored as a fraction. ie 5.5% is stored as .055</summary>
	public double? DiscountPurchase { get; set; }
	/// <summary>Default discount percentage for sales. This is stored as a fraction. ie 5.5% is stored as .055</summary>
	public double? DiscountSales { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Document { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DunsNumber { get; set; }
	/// <summary>E-Mail address of the account</summary>
	public string Email { get; set; }
	/// <summary>Indicates whether payment link is activated for sales</summary>
	public bool? EnableSalesPaymentLink { get; set; }
	/// <summary>Determines in combination with the start date if the account is active. If the current date is &gt; end date the account is inactive</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>RegistrationDate</summary>
	public DateTime? EstablishedDate { get; set; }
	/// <summary>Fax number</summary>
	public string Fax { get; set; }
	/// <summary>Default (corporate) GL offset account for purchase (cost)</summary>
	public Guid? GLAccountPurchase { get; set; }
	/// <summary>Default (corporate) GL offset account for sales (revenue)</summary>
	public Guid? GLAccountSales { get; set; }
	/// <summary>Default GL account for Accounts Payable</summary>
	public Guid? GLAP { get; set; }
	/// <summary>Default GL account for Accounts Receivable</summary>
	public Guid? GLAR { get; set; }
	/// <summary>Global Location Number can be used by companies to identify their locations, giving them complete flexibility to identify any type or level of location required</summary>
	public string GlnNumber { get; set; }
	/// <summary>Indicates whether a customer has withholding tax on sales</summary>
	public bool? HasWithholdingTaxSales { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Suppressed warning message when there is duplication on the DATEV code</summary>
	public bool IgnoreDatevWarningMessage { get; set; }
	/// <summary>Intrastat Area</summary>
	public string IntraStatArea { get; set; }
	/// <summary>Intrastat delivery method</summary>
	public string IntraStatDeliveryTerm { get; set; }
	/// <summary>System for Intrastat</summary>
	public string IntraStatSystem { get; set; }
	/// <summary>Transaction type A for Intrastat</summary>
	public string IntraStatTransactionA { get; set; }
	/// <summary>Transaction type B for Intrastat</summary>
	public string IntraStatTransactionB { get; set; }
	/// <summary>Transport method for Intrastat</summary>
	public string IntraStatTransportMethod { get; set; }
	/// <summary>ID of account to be invoiced instead of this account</summary>
	public Guid? InvoiceAccount { get; set; }
	/// <summary>Code of InvoiceAccount</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string InvoiceAccountCode { get; set; }
	/// <summary>Name of InvoiceAccount</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string InvoiceAccountName { get; set; }
	/// <summary>Indicates which attachment types should be sent when a sales invoice is printed. Only values in related table with Invoice=1 are allowed</summary>
	public int? InvoiceAttachmentType { get; set; }
	/// <summary>Method of sending for sales invoices. Values: 1: Paper, 2: EMail, 4: Mailbox (electronic exchange)</summary>
	public int? InvoicingMethod { get; set; }
	/// <summary>Indicates whether the account is an accountant. Values: 0 = No accountant, 1 = True, but accountant doesn&apos;t want his name to be published in the list of accountants, 2 = True, and accountant is published in the list of accountants</summary>
	public byte IsAccountant { get; set; }
	/// <summary>Indicates whether the accounti is an agency</summary>
	public byte IsAgency { get; set; }
	/// <summary>Indicates whtether the account is anonymised.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte IsAnonymised { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool? IsBank { get; set; }
	/// <summary>Indicates whether the account is a competitor</summary>
	public byte IsCompetitor { get; set; }
	/// <summary>Indicates whether a customer is eligible for extra duty</summary>
	public bool? IsExtraDuty { get; set; }
	/// <summary>Indicates if the account is excluded from mailing marketing information</summary>
	public byte IsMailing { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool? IsMember { get; set; }
	/// <summary>Indicates whether the account is a pilot account</summary>
	public bool? IsPilot { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool? IsPurchase { get; set; }
	/// <summary>Indicates whether the account is a reseller</summary>
	public bool? IsReseller { get; set; }
	/// <summary>Indicates whether the account is allowed for sales</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public bool? IsSales { get; set; }
	/// <summary>Indicates whether the account is a supplier</summary>
	public bool? IsSupplier { get; set; }
	/// <summary>Language code</summary>
	public string Language { get; set; }
	/// <summary>Language description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string LanguageDescription { get; set; }
	/// <summary>Latitude (used by Google maps)</summary>
	public double? Latitude { get; set; }
	/// <summary>Reference to Lead purpose of an account</summary>
	public Guid? LeadPurpose { get; set; }
	/// <summary>Reference to Lead source of an account</summary>
	public Guid? LeadSource { get; set; }
	/// <summary>Bytes of the logo image</summary>
	public byte[] Logo { get; set; }
	/// <summary>The file name (without path, but with extension) of the image</summary>
	public string LogoFileName { get; set; }
	/// <summary>Thumbnail url of the logo</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string LogoThumbnailUrl { get; set; }
	/// <summary>Url to retrieve the logo</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string LogoUrl { get; set; }
	/// <summary>Longitude (used by Google maps)</summary>
	public double? Longitude { get; set; }
	/// <summary>Reference to main contact person</summary>
	public Guid? MainContact { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Account name</summary>
	public string Name { get; set; }
	/// <summary>Dutch government identification number</summary>
	public string OINNumber { get; set; }
	/// <summary>ID of the parent account</summary>
	public Guid? Parent { get; set; }
	/// <summary>Indicates the loan repayment plan for UK legislation</summary>
	public string PayAsYouEarn { get; set; }
	/// <summary>Code of default payment condition for purchase</summary>
	public string PaymentConditionPurchase { get; set; }
	/// <summary>Description of PaymentConditionPurchase</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PaymentConditionPurchaseDescription { get; set; }
	/// <summary>Code of default payment condition for sales</summary>
	public string PaymentConditionSales { get; set; }
	/// <summary>Description of PaymentConditionSales</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PaymentConditionSalesDescription { get; set; }
	/// <summary>Phone number</summary>
	public string Phone { get; set; }
	/// <summary>Phone number extention</summary>
	public string PhoneExtension { get; set; }
	/// <summary>Visit address postcode</summary>
	public string Postcode { get; set; }
	/// <summary>Default sales price list for account</summary>
	public Guid? PriceList { get; set; }
	/// <summary>Currency of purchase</summary>
	public string PurchaseCurrency { get; set; }
	/// <summary>Description of PurchaseCurrency</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PurchaseCurrencyDescription { get; set; }
	/// <summary>Indicates number of days required to receive a purchase. Acts as a default</summary>
	public int? PurchaseLeadDays { get; set; }
	/// <summary>Default VAT code used for purchase entries</summary>
	public string PurchaseVATCode { get; set; }
	/// <summary>Description of PurchaseVATCode</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string PurchaseVATCodeDescription { get; set; }
	/// <summary>Define the relation that should be taken in the official document of the rewarding fiscal fiches Belcotax</summary>
	public bool? RecepientOfCommissions { get; set; }
	/// <summary>Remarks</summary>
	public string Remarks { get; set; }
	/// <summary>ID of the reseller account. Conditions: the target account must have the property IsReseller turned on</summary>
	public Guid? Reseller { get; set; }
	/// <summary>Code of Reseller</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ResellerCode { get; set; }
	/// <summary>Name of Reseller</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ResellerName { get; set; }
	/// <summary>Fiscal number for NL legislation</summary>
	public string RSIN { get; set; }
	/// <summary>Currency of Sales used for Time &amp; Billing</summary>
	public string SalesCurrency { get; set; }
	/// <summary>Description of SalesCurrency</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string SalesCurrencyDescription { get; set; }
	/// <summary>Obsolete</summary>
	public Guid? SalesTaxSchedule { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string SalesTaxScheduleCode { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string SalesTaxScheduleDescription { get; set; }
	/// <summary>Default VAT code for a sales entry</summary>
	public string SalesVATCode { get; set; }
	/// <summary>Description of SalesVATCode</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string SalesVATCodeDescription { get; set; }
	/// <summary>Search code</summary>
	public string SearchCode { get; set; }
	/// <summary>Security level (0 - 100)</summary>
	public int? SecurityLevel { get; set; }
	/// <summary>Separate invoice per project (Time &amp; Billing)</summary>
	public byte SeparateInvPerProject { get; set; }
	/// <summary>Indicates how invoices are generated from subscriptions. 0 = subscriptions belonging to the same customer are combined in a single invoice. 1 = each subscription results in one invoice. In both cases, each individual subscription line results in one invoice line</summary>
	public byte SeparateInvPerSubscription { get; set; }
	/// <summary>Indicates the number of days it takes to send goods to the customer. Acts as a default</summary>
	public int? ShippingLeadDays { get; set; }
	/// <summary>Default shipping method</summary>
	public Guid? ShippingMethod { get; set; }
	/// <summary>Indicates in combination with the end date if the account is active</summary>
	public DateTime? StartDate { get; set; }
	/// <summary>State/Province/County code When changing the Country and the State is filled, the State must be assigned with a valid value from the selected country or set to empty</summary>
	public string State { get; set; }
	/// <summary>Name of State</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string StateName { get; set; }
	/// <summary>If the status field is filled this means the account is a customer. The value indicates the customer status. Possible values: A=None, S=Suspect, P=Prospect, C=Customer</summary>
	public string Status { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? StatusSince { get; set; }
	/// <summary>Trade name can be registered and shown with the client (for all legislations)</summary>
	public string TradeName { get; set; }
	/// <summary>Account type: Values: A = Relation, D = Division</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Type { get; set; }
	/// <summary>Unique taxpayer reference for UK legislation</summary>
	public string UniqueTaxpayerReference { get; set; }
	/// <summary>Indicates the VAT status of an account to be able to identify the relation that should be selected in the VAT debtor listing in Belgium</summary>
	public string VATLiability { get; set; }
	/// <summary>The number under which the account is known at the Value Added Tax collection agency</summary>
	public string VATNumber { get; set; }
	/// <summary>Website of the account</summary>
	public string Website { get; set; }
}

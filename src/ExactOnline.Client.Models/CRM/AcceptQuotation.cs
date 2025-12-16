namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(true, false, false, false)]
[DataServiceKey("QuotationID")]
public class AcceptQuotation
{
	/// <summary>0 = No action (Default), 1 = create sales order, 2 = create sales invoice, 3 = create project.</summary>
	public int Action { get; set; }
	/// <summary>Create a project work breakdown structure. Only needed when ProjectBudgetType = 2.</summary>
	public bool? CreateProjectWBS { get; set; }
	/// <summary>Division code</summary>
	public int Division { get; set; }
	/// <summary>Contains the error message if an error occurred during the acception of the quotation.</summary>
	public string? ErrorMessage { get; set; }
	/// <summary>The journal in which the sales invoice will be booked. Mandatory for Action = 2.</summary>
	public int InvoiceJournal { get; set; }
	/// <summary>The budget type of the project that will be created. Default = 0.</summary>
	public int? ProjectBudgetType { get; set; }
	/// <summary>The code of the project that will be created. Mandatory for Action = 3.</summary>
	public string? ProjectCode { get; set; }
	/// <summary>The description of the project that will be created. Mandatory for Action = 3.</summary>
	public string? ProjectDescription { get; set; }
	/// <summary>The invoicing date of the project. Mandatory for ProjectInvoicingAction = 2.</summary>
	public DateTime? ProjectInvoiceDate { get; set; }
	/// <summary>The project invoicing action. 0 = None (Default), 1 = Create invoice terms, 2 = As quoted.</summary>
	public int? ProjectInvoicingAction { get; set; }
	/// <summary>The prepaid type. Mandatory for ProjectType = 5. 1 = Retainer, 2 = Hour type bundle.</summary>
	public int? ProjectPrepaindTypes { get; set; }
	/// <summary>PriceAgreement.</summary>
	public double? ProjectPriceAgreement { get; set; }
	/// <summary>Contains information if the project was successfully created.</summary>
	public string? ProjectSuccess { get; set; }
	/// <summary>The type of the project that will be created. 2 = Fixed price (Default), 3 = Time and Material, 4 = Non billable, 5 = Prepaid.</summary>
	public int? ProjectType { get; set; }
	/// <summary>Identifier of the quotation.</summary>
	public Guid QuotationID { get; set; }
	/// <summary>Reason why the quotation was accepted.</summary>
	public Guid? ReasonCode { get; set; }
	/// <summary>Contains information if the sales invoice was successfully created.</summary>
	public string? SalesInvoiceSuccess { get; set; }
	/// <summary>Contains information if the sales order was successfully created.</summary>
	public string? SalesOrderSuccess { get; set; }
	/// <summary>Contains information if the quotation was successfully accepted.</summary>
	public string? SuccessMessage { get; set; }
}

﻿namespace ExactOnline.Client.Models.Financial;

[SupportedActionsSDK(true, true, false, false)]
[DataServiceKey("ID")]
public class OfficialReturn
{
	/// <summary>Total liquidation amount of the official return</summary>
	public double? Amount { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>CreatorFullName</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Description of the official return</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Document linked to the official return.</summary>
	public Guid? Document { get; set; }
	/// <summary>DocumentSubject</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string DocumentSubject { get; set; }
	/// <summary>Frequency Monthly = 10,	TwoMonthly = 20, Quarterly = 30, Yearly = 40,FinancialYearQuarter = 100</summary>
	public short? Frequency { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>IsCorrection</summary>
	public byte? IsCorrection { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>Financial period (for annual returns = 0)</summary>
	public short? Period { get; set; }
	/// <summary>Registration data of the presenting proof document, JSON serialized dictionary  &lt;table class=&quot;enum&quot; style=&quot;width:30%&quot;&gt;  &lt;tr&gt;&lt;td colspan=&quot;2&quot; align=&quot;center&quot;&gt;&lt;b&gt;Spanish legislation Keys:&lt;/b&gt;&lt;/td&gt;&lt;/tr&gt;  &lt;tr&gt;&lt;td&gt;registrationEntryNumber&lt;/td&gt;&lt;td&gt;Registration entry number&lt;/td&gt;&lt;/tr&gt;  &lt;tr&gt;&lt;td&gt;safeCodeVerification&lt;/td&gt;&lt;td&gt;Tax authorities CSV&lt;/td&gt;&lt;/tr&gt;  &lt;tr&gt;&lt;td&gt;vatPresenter&lt;/td&gt;&lt;td&gt;VAT number of the presenter&lt;/td&gt;&lt;/tr&gt;  &lt;tr&gt;&lt;td&gt;surnameNameCompanyName&lt;/td&gt;&lt;td&gt;Name of the presenter&lt;/td&gt;&lt;/tr&gt;  &lt;tr&gt;&lt;td&gt;capacityOf&lt;/td&gt;&lt;td&gt;COLABORADOR&lt;/td&gt;&lt;/tr&gt;  &lt;tr&gt;&lt;td&gt;receiptNumber&lt;/td&gt;&lt;td&gt;Receipt number&lt;/td&gt;&lt;/tr&gt;  &lt;/table&gt;</summary>
	public string PresentationData { get; set; }
	/// <summary>Presentation date of the official return to the tax authorities</summary>
	public DateTime? PresentationDate { get; set; }
	/// <summary>For performance reasons presentation attachment is Write-Only.</summary>
	public byte[] PresentationFile { get; set; }
	/// <summary>File name of presentation attachment.</summary>
	public string PresentationFileName { get; set; }
	/// <summary>Reference of the official return</summary>
	public string Reference { get; set; }
	/// <summary>Source of the official return : 1 - EOL, 2 - RestAPI</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public short? Source { get; set; }
	/// <summary>Status of the official return</summary>
	public short? Status { get; set; }
	/// <summary>Type of the official return</summary>
	public short? Type { get; set; }
	/// <summary>Official return type description</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string TypeDescription { get; set; }
	/// <summary>Financial year of the official return</summary>
	public short? Year { get; set; }
}

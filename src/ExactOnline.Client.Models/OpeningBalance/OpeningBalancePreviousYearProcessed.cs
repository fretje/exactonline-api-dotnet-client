namespace ExactOnline.Client.Models.OpeningBalance;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("Division,ReportingYear,GLAccount")]
public class OpeningBalancePreviousYearProcessed
{
	/// <summary>The opening balance amount of the G/L account.</summary>
	public double? Amount { get; set; }
	/// <summary>Indicates whether the G/L account is a debit or credit account. D = Debit, C = Credit.</summary>
	public string BalanceSide { get; set; }
	/// <summary>Division code.</summary>
	public int Division { get; set; }
	/// <summary>The balance sheet account.</summary>
	public Guid GLAccount { get; set; }
	/// <summary>The code of the G/L account.</summary>
	public string GLAccountCode { get; set; }
	/// <summary>The description of the G/L account.</summary>
	public string GLAccountDescription { get; set; }
	/// <summary>The reporting year of the opening balance.</summary>
	public int ReportingYear { get; set; }
}

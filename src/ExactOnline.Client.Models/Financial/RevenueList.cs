namespace ExactOnline.Client.Models.Financial
{
	[SupportedActionsSDK(false, true, false, false)]
	[DataServiceKey("Year,Period")]
	public class RevenueList
	{
		/// <summary>Total amount in the default currency of the company</summary>
		public double Amount { get; set; }
		/// <summary>Reporting period</summary>
		public int Period { get; set; }
		/// <summary>Current Reporting year</summary>
		public int Year { get; set; }
	}
}

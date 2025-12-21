namespace ExactOnline.Client.Models.Payroll
{
	[SupportedActionsSDK(false, true, false, false)]
	[DataServiceKey("ID")]
	public class EmploymentEndReason
	{
		/// <summary>Employment end reason description</summary>
		public string? Description { get; set; }
		/// <summary>Primary key</summary>
		public int ID { get; set; }
	}
}

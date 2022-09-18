namespace ExactOnline.Client.Models.Payroll
{
	[SupportedActionsSDK(false, true, false, false)]
	[DataServiceKey("ID")]
	public class EmploymentContractFlexPhase
	{
		/// <summary>Flexible employment contract phase description</summary>
		public string Description { get; set; }
		/// <summary>Primary key</summary>
		public int ID { get; set; }
	}
}

namespace ExactOnline.Client.Models.SystemBase
{
	[SupportedActionsSDK(false, true, false, false)]
	[DataServiceKey("ID")]
	public class AvailableFeature
	{
		/// <summary>The description of the feature.</summary>
		public string Description { get; set; }
		/// <summary>The ID of the feature.</summary>
		public int ID { get; set; }
	}
}

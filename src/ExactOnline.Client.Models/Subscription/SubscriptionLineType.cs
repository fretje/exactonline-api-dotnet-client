namespace ExactOnline.Client.Models.Subscription
{
	[SupportedActionsSDK(false, true, false, false)]
	[DataServiceKey("ID")]
	public class SubscriptionLineType
	{
		/// <summary>Description</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public string Description { get; set; }
		/// <summary>Primary key</summary>
		public short ID { get; set; }
	}
}

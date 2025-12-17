namespace ExactOnline.Client.Models.Project;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class TimeAndBillingAccountDetail
{
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Name</summary>
	public string? Name { get; set; }
}

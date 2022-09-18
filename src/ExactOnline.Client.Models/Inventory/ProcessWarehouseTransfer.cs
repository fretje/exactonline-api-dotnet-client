namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, false, false, false)]
[DataServiceKey("TransferID")]
public class ProcessWarehouseTransfer
{
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Transfer Date</summary>
	public DateTime? TransferDate { get; set; }
	/// <summary>Primary key</summary>
	public Guid TransferID { get; set; }
}

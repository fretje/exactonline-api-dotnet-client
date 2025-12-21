namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(true, false, false, false)]
[DataServiceKey("StockCountID")]
public class ProcessStockCount
{
	/// <summary>Division code</summary>
	public int? Division { get; set; }
	/// <summary>Contains the error message if an error occurred during the processing of the stock count.</summary>
	public string? ErrorMessage { get; set; }
	/// <summary>Primary key</summary>
	public Guid StockCountID { get; set; }
	/// <summary>Contains information if the stock count was successfully processed.</summary>
	public string? SuccessMessage { get; set; }
}

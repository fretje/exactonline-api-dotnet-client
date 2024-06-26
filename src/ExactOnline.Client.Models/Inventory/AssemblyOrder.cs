namespace ExactOnline.Client.Models.Inventory;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class AssemblyOrder
{
	/// <summary>Planned date for assembly of the item</summary>
	public DateTime? AssemblyDate { get; set; }
	/// <summary>Description of assembly order</summary>
	public string Description { get; set; }
	/// <summary>Division code</summary>
	public int Division { get; set; }
	/// <summary>Quantity of items that have actually been assembled</summary>
	public double FinishedQuantity { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Reference to item</summary>
	public Guid Item { get; set; }
	/// <summary>Item code</summary>
	public string ItemCode { get; set; }
	/// <summary>Description of item</summary>
	public string ItemDescription { get; set; }
	/// <summary>Notes of the assembly order</summary>
	public string Notes { get; set; }
	/// <summary>Date of the assembly order is initiated</summary>
	public DateTime? OrderDate { get; set; }
	/// <summary>Assembly order number </summary>
	public int OrderNumber { get; set; }
	/// <summary>Assembly order status: 20 = Open, 30 = Partial, 50 = Complete</summary>
	public int OrderStatus { get; set; }
	/// <summary>Collection of part items for assembly order</summary>

	/// <summary>Planned quantity of the item to be assembled</summary>
	public double PlannedQuantity { get; set; }
	/// <summary>Reference to storage location</summary>
	public Guid? StorageLocation { get; set; }
	/// <summary>Storage location code</summary>
	public string StorageLocationCode { get; set; }
	/// <summary>Storage location description</summary>
	public string StorageLocationDescription { get; set; }
	/// <summary>Warehouse</summary>
	public Guid? Warehouse { get; set; }
	/// <summary>Code of Warehouse</summary>
	public string WarehouseCode { get; set; }
	/// <summary>Description of Warehouse</summary>
	public string WarehouseDescription { get; set; }
}

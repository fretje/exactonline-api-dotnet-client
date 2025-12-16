namespace ExactOnline.Client.Models.Sales;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class SalesPriceListVolumeDiscount : SupportsSync
{
	/// <summary>ID of the base price</summary>
	public Guid? BasePrice { get; set; }
	/// <summary>Amount of the base price</summary>
	public double? BasePriceAmount { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? CreatorFullName { get; set; }
	/// <summary>Discount</summary>
	public double? Discount { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Indicates whether discount or the new price is leading : 1-Discount, 2-New price. &lt;br&gt;&lt;br&gt; Scenario &lt;br&gt;&lt;br&gt; 1. When entry method is Discount and use base price, Discounted price = (1- SalesPriceListDetails.Discount) * SalesPriceListDetails.BasePrice &lt;br&gt;&lt;br&gt; 2. When entry method is Discount and use Item&apos;s standard sales price, Discounted price = (1- SalesPriceListDetails.Discount) * SalesItemPrices.Price &lt;br&gt;&lt;br&gt; 3. When entry method is New price, Discounted price = SalesPriceListDetails.NewPrice</summary>
	public short EntryMethod { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Item</summary>
	public Guid? Item { get; set; }
	/// <summary>Description of the item</summary>
	public string? ItemDescription { get; set; }
	/// <summary>Item group ID</summary>
	public Guid? ItemGroup { get; set; }
	/// <summary>Item group code</summary>
	public string? ItemGroupCode { get; set; }
	/// <summary>Item group description</summary>
	public string? ItemGroupDescription { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string? ModifierFullName { get; set; }
	/// <summary>New price after discount</summary>
	public double? NewPrice { get; set; }
	/// <summary>Number of the item per unit</summary>
	public double? NumberOfItemsPerUnit { get; set; }
	/// <summary>Code of the PriceList</summary>
	public string? PriceListCode { get; set; }
	/// <summary>Description of the PriceList</summary>
	public string? PriceListDescription { get; set; }
	/// <summary>Period Id of the PriceList</summary>
	public Guid? PriceListPeriod { get; set; }
	/// <summary>Quantity</summary>
	public double? Quantity { get; set; }
	/// <summary>Unit</summary>
	public string? Unit { get; set; }
	/// <summary>Description of the unit</summary>
	public string? UnitDescription { get; set; }
}

namespace ExactOnline.Client.Models.Manufacturing
{
	[SupportedActionsSDK(false, true, false, false)]
	[DataServiceKey("Division")]
	public class ManufacturingSetting
	{
		/// <summary>This division.</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public int Division { get; set; }
		/// <summary>What is the division&apos;s main inventory method? Standard=3,Average=4</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public int InventoryMainMethod { get; set; }
		/// <summary>What is the division&apos;s sub inventory method? Perpetual=1,NonPerpetual=2,AngloSaxon=3</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public int InventorySubMethod { get; set; }
		/// <summary>Does the current division allow negative stock?</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public byte NegativeStockIsAllowed { get; set; }
		/// <summary>Are serial numbers mandatory in this division?</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public byte SerialNumbersAreMandatory { get; set; }
		/// <summary>Should ShopOrderMaterialPlans with Backflush=True be shown within Smart Shop Floor?</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public byte ShowBackflushMaterials { get; set; }
		/// <summary>Should ShopOrderMaterialPlans linked to a SubOrder be shown within Smart Shop Floor?</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public byte ShowSubOrderMaterials { get; set; }
	}
}

using System;

namespace ExactOnline.Client.Models.Logistics
{
    [SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
    [DataServiceKey("ID")]
    public class Item
    {
        /// <summary>Barcode of the item (numeric string)</summary>
        public string Barcode { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 1</summary>
        public string Class_01 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 2</summary>
        public string Class_02 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 3</summary>
        public string Class_03 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 4</summary>
        public string Class_04 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 5</summary>
        public string Class_05 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 6</summary>
        public string Class_06 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 7</summary>
        public string Class_07 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 8</summary>
        public string Class_08 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 9</summary>
        public string Class_09 { get; set; }
        /// <summary>Item class code referring to ItemClasses with ClassID 10</summary>
        public string Class_10 { get; set; }
        /// <summary>Item code</summary>
        public string Code { get; set; }
        /// <summary>Copy sales remarks to sales lines</summary>
        public byte CopyRemarks { get; set; }
        /// <summary>The currency of the current and proposed cost price</summary>
        public string CostPriceCurrency { get; set; }
        /// <summary>Proposed cost price</summary>
        public double? CostPriceNew { get; set; }
        /// <summary>The current standard cost price</summary>
        public double? CostPriceStandard { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Description of the item</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Together with StartDate this determines if the item is active</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Extra description text, slightly longer than the regular description (255 instead of 60)</summary>
        public string ExtraDescription { get; set; }
        /// <summary>Free boolean field 1</summary>
        public bool? FreeBoolField_01 { get; set; }
        /// <summary>Free boolean field 2</summary>
        public bool? FreeBoolField_02 { get; set; }
        /// <summary>Free boolean field 3</summary>
        public bool? FreeBoolField_03 { get; set; }
        /// <summary>Free boolean field 4</summary>
        public bool? FreeBoolField_04 { get; set; }
        /// <summary>Free boolean field 5</summary>
        public bool? FreeBoolField_05 { get; set; }
        /// <summary>Free date field 1</summary>
        public DateTime? FreeDateField_01 { get; set; }
        /// <summary>Free date field 2</summary>
        public DateTime? FreeDateField_02 { get; set; }
        /// <summary>Free date field 3</summary>
        public DateTime? FreeDateField_03 { get; set; }
        /// <summary>Free date field 4</summary>
        public DateTime? FreeDateField_04 { get; set; }
        /// <summary>Free date field 5</summary>
        public DateTime? FreeDateField_05 { get; set; }
        /// <summary>Free numeric field 1</summary>
        public double? FreeNumberField_01 { get; set; }
        /// <summary>Free numeric field 2</summary>
        public double? FreeNumberField_02 { get; set; }
        /// <summary>Free numeric field 3</summary>
        public double? FreeNumberField_03 { get; set; }
        /// <summary>Free numeric field 4</summary>
        public double? FreeNumberField_04 { get; set; }
        /// <summary>Free numeric field 5</summary>
        public double? FreeNumberField_05 { get; set; }
        /// <summary>Free numeric field 6</summary>
        public double? FreeNumberField_06 { get; set; }
        /// <summary>Free numeric field 7</summary>
        public double? FreeNumberField_07 { get; set; }
        /// <summary>Free numeric field 8</summary>
        public double? FreeNumberField_08 { get; set; }
        /// <summary>Free text field 1</summary>
        public string FreeTextField_01 { get; set; }
        /// <summary>Free text field 2</summary>
        public string FreeTextField_02 { get; set; }
        /// <summary>Free text field 3</summary>
        public string FreeTextField_03 { get; set; }
        /// <summary>Free text field 4</summary>
        public string FreeTextField_04 { get; set; }
        /// <summary>Free text field 5</summary>
        public string FreeTextField_05 { get; set; }
        /// <summary>Free text field 6</summary>
        public string FreeTextField_06 { get; set; }
        /// <summary>Free text field 7</summary>
        public string FreeTextField_07 { get; set; }
        /// <summary>Free text field 8</summary>
        public string FreeTextField_08 { get; set; }
        /// <summary>Free text field 9</summary>
        public string FreeTextField_09 { get; set; }
        /// <summary>Free text field 10</summary>
        public string FreeTextField_10 { get; set; }
        /// <summary>GL account the cost entries will be booked on. This overrules the GL account from the item group. If the license contains &apos;Intuit integration&apos; this property overrides the value in Settings, not the item group.</summary>
        public Guid? GLCosts { get; set; }
        /// <summary>Code of GL account for costs</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLCostsCode { get; set; }
        /// <summary>Description of GLCosts</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLCostsDescription { get; set; }
        /// <summary>GL account the revenue will be booked on. This overrules the GL account from the item group. If the license contains &apos;Intuit integration&apos; this property overrides the value in Settings, not the item group.</summary>
        public Guid? GLRevenue { get; set; }
        /// <summary>Code of GLRevenue</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLRevenueCode { get; set; }
        /// <summary>Description of GLRevenue</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLRevenueDescription { get; set; }
        /// <summary>GL account the stock entries will be booked on. This overrules the GL account from the item group. If the license contains &apos;Intuit integration&apos; this property overrides the value in Settings, not the item group.</summary>
        public Guid? GLStock { get; set; }
        /// <summary>Code of GL account for stock</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLStockCode { get; set; }
        /// <summary>Description of GLStock</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLStockDescription { get; set; }
        /// <summary>Gross weight for international goods shipments</summary>
        public double? GrossWeight { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Indicates if batches are used for this item</summary>
        public byte IsBatchItem { get; set; }
        /// <summary>This property is obsolete. Use property &apos;IsBatchItem&apos; instead.</summary>
        public byte IsBatchNumberItem { get; set; }
        /// <summary>Indicates if fractions (for example 0.35) are allowed for quantities of this item</summary>
        public bool? IsFractionAllowedItem { get; set; }
        /// <summary>Indicates that an Item is produced to Inventory, not purchased</summary>
        public byte IsMakeItem { get; set; }
        /// <summary>Only used for packages (IsPackageItem=1). To indicate if this package is a new contract type package</summary>
        public byte IsNewContract { get; set; }
        /// <summary>Is On demand Item</summary>
        public byte IsOnDemandItem { get; set; }
        /// <summary>Indicates if the item is a package item. Can only be created in the hosting administration</summary>
        public bool? IsPackageItem { get; set; }
        /// <summary>Indicates if the item can be purchased</summary>
        public bool? IsPurchaseItem { get; set; }
        /// <summary>Indicated if the item is used in voucher functionality</summary>
        public byte IsRegistrationCodeItem { get; set; }
        /// <summary>Indicates if the item can be sold</summary>
        public bool? IsSalesItem { get; set; }
        /// <summary>Indicates that serial numbers are used for this item</summary>
        public bool? IsSerialItem { get; set; }
        /// <summary>This property is obsolete. Use property &apos;IsSerialItem&apos; instead.</summary>
        public bool? IsSerialNumberItem { get; set; }
        /// <summary>If you have the Trade or Manufacturing license and you check this property the item will be shown in the stock positions overview, stock counts and transaction lists. If you have the Invoice module and you check this property you will get a general journal entry based on the Stock and Costs G/L accounts of the item group. If you don’t want the general journal entry to be created you should change the Stock/Costs G/L account on the Item group page to the type Costs instead of Inventory.</summary>
        public bool? IsStockItem { get; set; }
        /// <summary>Indicates if the item is provided by an outside supplier</summary>
        public bool? IsSubcontractedItem { get; set; }
        /// <summary>Indicates if tax needs to be calculated for this item</summary>
        public byte? IsTaxableItem { get; set; }
        /// <summary>Indicates if the item is a time unit item (for example a labor hour item)</summary>
        public byte IsTime { get; set; }
        /// <summary>Indicates if the item can be exported to a web shop</summary>
        public byte IsWebshopItem { get; set; }
        /// <summary>GUID of Item group of the item</summary>
        public Guid? ItemGroup { get; set; }
        /// <summary>Code of ItemGroup</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemGroupCode { get; set; }
        /// <summary>Description of ItemGroup</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemGroupDescription { get; set; }
        /// <summary>Last modified date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ModifierFullName { get; set; }
        /// <summary>Net weight for international goods shipments</summary>
        public double? NetWeight { get; set; }
        /// <summary>Net Weight unit for international goods shipment, only available in manufacturing packages</summary>
        public string NetWeightUnit { get; set; }
        /// <summary>Notes</summary>
        public string Notes { get; set; }
        /// <summary>File name of picture</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PictureName { get; set; }
        /// <summary>Url where thumbnail picture can be retrieved</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PictureThumbnailUrl { get; set; }
        /// <summary>Url where picture can be retrieved</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PictureUrl { get; set; }
        /// <summary>Code of SalesVat</summary>
        public string SalesVatCode { get; set; }
        /// <summary>Description of SalesVatCode</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SalesVatCodeDescription { get; set; }
        /// <summary>Search code of the item</summary>
        public string SearchCode { get; set; }
        /// <summary>Security level (0 - 100)</summary>
        public int? SecurityLevel { get; set; }
        /// <summary>Together with EndDate this determines if the item is active</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>Quantity that is in stock</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Stock { get; set; }
        /// <summary>The standard unit of this item</summary>
        public string Unit { get; set; }
        /// <summary>Description of Unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string UnitDescription { get; set; }
        /// <summary>Type of unit: A=Area, L=Length, O=Other, T=Time, V=Volume, W=Weight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string UnitType { get; set; }
    }
}

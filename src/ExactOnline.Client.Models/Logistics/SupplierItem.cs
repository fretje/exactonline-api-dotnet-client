using System;

namespace ExactOnline.Client.Models.Logistics
{
    [SupportedActionsSDK(true, true, true, true)]
    [DataServiceKey("ID")]
    public class SupplierItem
    {
        /// <summary>Copy purchase remarks to purchase lines</summary>
        public byte CopyRemarks { get; set; }
        /// <summary>Country of origin code</summary>
        public string CountryOfOrigin { get; set; }
        /// <summary>Description of country of origin</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CountryOfOriginDescription { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Currency of item price</summary>
        public string Currency { get; set; }
        /// <summary>Description of currency of item price</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CurrencyDescription { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Indicates that the supplier will deliver the item directly to customer. Values: 0 = No, 1 = Yes, 2 = Optional</summary>
        public byte? DropShipment { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Item ID</summary>
        public Guid? Item { get; set; }
        /// <summary>Item code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemCode { get; set; }
        /// <summary>Description of Item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemDescription { get; set; }
        /// <summary>Indicates this is a main supplier</summary>
        public bool? MainSupplier { get; set; }
        /// <summary>Minimum quantity of the item for purchase, only available for Wholesale &amp; Distribution (Premium only)</summary>
        public double? MinimumQuantity { get; set; }
        /// <summary>Last modified date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ModifierFullName { get; set; }
        /// <summary>Notes</summary>
        public string Notes { get; set; }
        /// <summary>The number of days between placing an order with a supplier and receiving items from the supplier</summary>
        public int? PurchaseLeadTime { get; set; }
        /// <summary>Purchase price</summary>
        public double? PurchasePrice { get; set; }
        /// <summary>Unit code</summary>
        public string PurchaseUnit { get; set; }
        /// <summary>Description of unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PurchaseUnitDescription { get; set; }
        /// <summary>This is the multiplication factor when going from default item unit to the unit of this price</summary>
        public double? PurchaseUnitFactor { get; set; }
        /// <summary>VAT code</summary>
        public string PurchaseVATCode { get; set; }
        /// <summary>Description of VAT</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PurchaseVATCodeDescription { get; set; }
        /// <summary>Supplier ID</summary>
        public Guid? Supplier { get; set; }
        /// <summary>Supplier code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SupplierCode { get; set; }
        /// <summary>Description of supplier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SupplierDescription { get; set; }
        /// <summary>Supplier’s item code</summary>
        public string SupplierItemCode { get; set; }
    }
}

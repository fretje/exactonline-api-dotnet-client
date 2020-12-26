using System;

namespace ExactOnline.Client.Models.Logistics
{
    [SupportedActionsSDK(true, true, true, true)]
    [DataServiceKey("ID")]
    public class SalesItemPrice
    {
        /// <summary>ID of the customer</summary>
        public Guid? Account { get; set; }
        /// <summary>Name of the customer account</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AccountName { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>The currency of the price</summary>
        public string Currency { get; set; }
        /// <summary>The default unit of the item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string DefaultItemUnit { get; set; }
        /// <summary>The description of the default item unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string DefaultItemUnitDescription { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Together with StartDate this determines whether the price is active</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Item ID</summary>
        public Guid? Item { get; set; }
        /// <summary>Code of Item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemCode { get; set; }
        /// <summary>Description of Item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemDescription { get; set; }
        /// <summary>Last modified date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ModifierFullName { get; set; }
        /// <summary>This is the multiplication factor when going from default item unit to the unit of this price.For example if the default item unit is &apos;gram&apos; and the price unit is &apos;kilogram&apos; then the value of this property is 1000.</summary>
        public double? NumberOfItemsPerUnit { get; set; }
        /// <summary>The actual price of this sales item</summary>
        public double? Price { get; set; }
        /// <summary>Minimum quantity to which the price is applicable</summary>
        public double? Quantity { get; set; }
        /// <summary>Together with EndDate this determines whether the price is active</summary>
        public DateTime StartDate { get; set; }
        /// <summary>The unit code of the price</summary>
        public string Unit { get; set; }
        /// <summary>Description of the price unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string UnitDescription { get; set; }
    }
}

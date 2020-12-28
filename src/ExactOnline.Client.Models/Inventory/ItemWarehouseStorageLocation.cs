using System;

namespace ExactOnline.Client.Models.Inventory
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class ItemWarehouseStorageLocation
    {
        /// <summary>Uniquely identifies the item, warehouse, storage location combination</summary>
        public Guid ID { get; set; }
        /// <summary>Does the item allow partial quantities (1.75 meters)</summary>
        public byte IsFractionAllowedItem { get; set; }
        /// <summary>Item</summary>
        public Guid Item { get; set; }
        /// <summary>Barcode of the item of this stock quantity</summary>
        public string ItemBarcode { get; set; }
        /// <summary>Code of the item of this stock quantity</summary>
        public string ItemCode { get; set; }
        /// <summary>Description of the item of this stock quantity</summary>
        public string ItemDescription { get; set; }
        /// <summary>Unit of the item</summary>
        public string ItemUnit { get; set; }
        /// <summary>Unit description of the item</summary>
        public string ItemUnitDescription { get; set; }
        /// <summary>Number of items in stock</summary>
        public double? Stock { get; set; }
        /// <summary>Storage location of this stock</summary>
        public Guid? StorageLocation { get; set; }
        /// <summary>Code of the storage location of this stock quantity</summary>
        public string StorageLocationCode { get; set; }
        /// <summary>Description of the storage location of this stock quantity</summary>
        public string StorageLocationDescription { get; set; }
        /// <summary>ID of Warehouse</summary>
        public Guid? Warehouse { get; set; }
        /// <summary>Code of the warehouse of this stock quantity</summary>
        public string WarehouseCode { get; set; }
        /// <summary>Description of the warehouse of this stock quantity</summary>
        public string WarehouseDescription { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace ExactOnline.Client.Models.Inventory
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class SerialNumber
    {
        /// <summary>Availability of this serial number</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public byte? Available { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>End date of effective period for serial number</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Boolean value indicating whether or not the serial number is blocked</summary>
        public byte? IsBlocked { get; set; }
        /// <summary>Item</summary>
        public Guid? Item { get; set; }
        /// <summary>Item code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemCode { get; set; }
        /// <summary>Description of item</summary>
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
        /// <summary>Remarks</summary>
        public string Remarks { get; set; }
        /// <summary>Human readable serial number</summary>
        [JsonProperty(PropertyName = "SerialNumber")]
        public string SerialNumberName { get; set; }
        /// <summary>Start date of effective period for serial number</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>ID of storage location where serial number is available</summary>
        public Guid? StorageLocation { get; set; }
        /// <summary>Code of storage location where serial number is available</summary>
        public string StorageLocationCode { get; set; }
        /// <summary>Description of storage location where serial number is available</summary>
        public string StorageLocationDescription { get; set; }
        /// <summary>ID of warehouse where serial number is available</summary>
        public Guid? Warehouse { get; set; }
        /// <summary>Code of warehouse where serial number is available</summary>
        public string WarehouseCode { get; set; }
        /// <summary>Description of warehouse where serial number is available</summary>
        public string WarehouseDescription { get; set; }
    }
}

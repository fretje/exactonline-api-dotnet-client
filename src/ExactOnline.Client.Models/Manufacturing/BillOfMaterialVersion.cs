using System;

namespace ExactOnline.Client.Models.Manufacturing
{
    [SupportedActionsSDK(true, true, true, true)]
    [DataServiceKey("ID")]
    public class BillOfMaterialVersion
    {
        /// <summary>Batch Quantity of Item Version</summary>
        public double? BatchQuantity { get; set; }
        /// <summary>Cad drawing URL</summary>
        public string CadDrawingUrl { get; set; }
        /// <summary>Calculated Cost Price of Item Version</summary>
        public double? CalculatedCostPrice { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Description of the item version</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Indicates if this is the default item version that will be assigned when a item is selected</summary>
        public byte IsDefault { get; set; }
        /// <summary>Reference to Items table</summary>
        public Guid Item { get; set; }
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
        /// <summary>Line notes</summary>
        public string Notes { get; set; }
        /// <summary>Order lead days for item</summary>
        public int? OrderLeadDays { get; set; }
        /// <summary>Production lead time in days of Item version</summary>
        public int? ProductionLeadDays { get; set; }
        /// <summary>Statuses of Item version: 10-Engineering change pending, 20-Engineering change approved, 30-Active &amp; 40-Historic</summary>
        public short? Status { get; set; }
        /// <summary>Description of Status</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string StatusDescription { get; set; }
        /// <summary>Type of Item version: 10-Sales bill of material, 20-Manufacturing recipe</summary>
        public short? Type { get; set; }
        /// <summary>Description of Type</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string TypeDescription { get; set; }
        /// <summary>Version date</summary>
        public DateTime? VersionDate { get; set; }
        /// <summary>Version Number</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? VersionNumber { get; set; }
    }
}

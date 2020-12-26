using System;

namespace ExactOnline.Client.Models.Logistics
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class ItemGroup
    {
        /// <summary>Code of the item group</summary>
        public string Code { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Description of the item group</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>GL account on which the costs of items of this group will be booked</summary>
        public Guid? GLCosts { get; set; }
        /// <summary>Code of GLCosts</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLCostsCode { get; set; }
        /// <summary>Description of GLCosts</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLCostsDescription { get; set; }
        /// <summary>GL Purchase account for purchase invoicing according to (non-) perpetual inventory method</summary>
        public Guid? GLPurchaseAccount { get; set; }
        /// <summary>Code of GLPurchase</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLPurchaseAccountCode { get; set; }
        /// <summary>Description of GLPurchaseAccount</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLPurchaseAccountDescription { get; set; }
        /// <summary>GL account that will be used for the &apos;Standard cost price&apos; valuation method to balance the difference between purchase price and cost price</summary>
        public Guid? GLPurchasePriceDifference { get; set; }
        /// <summary>Code of GLPurchasePriceDifference</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLPurchasePriceDifferenceCode { get; set; }
        /// <summary>Description of GLPurchasePriceDifference</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLPurchasePriceDifferenceDescr { get; set; }
        /// <summary>GL account on which the revenue for items of this group will be booked</summary>
        public Guid? GLRevenue { get; set; }
        /// <summary>Code of GLRevenue</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLRevenueCode { get; set; }
        /// <summary>Description of GLRevenue</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLRevenueDescription { get; set; }
        /// <summary>GL account on which stock entries will be booked for items of this group</summary>
        public Guid? GLStock { get; set; }
        /// <summary>Code of GLStock</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLStockCode { get; set; }
        /// <summary>Description of GLStock</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLStockDescription { get; set; }
        /// <summary>GL stock variance account for perpetual inventory</summary>
        public Guid? GLStockVariance { get; set; }
        /// <summary>Code of GLStockVariance</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLStockVarianceCode { get; set; }
        /// <summary>Description of GLStockVariance</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string GLStockVarianceDescription { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Indicates if this is the default item group that will be assigned when a new item is created</summary>
        public byte IsDefault { get; set; }
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
    }
}

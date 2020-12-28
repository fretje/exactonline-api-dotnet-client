using System;

namespace ExactOnline.Client.Models.Logistics
{
    [SupportedActionsSDK(false, true, false, false, allowsEmptySelect: true)]
    [DataServiceKey("ItemId")]
    public class StockPosition
    {
        /// <summary>Primary key item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid ItemId { get; set; }

        /// <summary>Number of items in stock</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? InStock { get; set; }
        /// <summary>Number of items that are planned to come ine</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlanningIn { get; set; }
        /// <summary>Number of items that are planned to go out</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlanningOut { get; set; }
    }
}

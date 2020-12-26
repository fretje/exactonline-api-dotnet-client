using System;

namespace ExactOnline.Client.Models.Manufacturing
{
    [SupportedActionsSDK(true, true, true, true)]
    [DataServiceKey("ID")]
    public class Workcenter
    {
        /// <summary>Capacity of the work center</summary>
        public int? Capacity { get; set; }
        /// <summary>Code of the work center</summary>
        public string Code { get; set; }
        /// <summary>Reference to CostCenters</summary>
        public string Costcenter { get; set; }
        /// <summary>Description of Costcenter</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CostcenterDescription { get; set; }
        /// <summary>Reference to CostUnits</summary>
        public string Costunit { get; set; }
        /// <summary>Description of Costunit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CostunitDescription { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Description of the work center</summary>
        public string Description { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>General burden rate</summary>
        public double? GeneralBurdenRate { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Indicates if labor burden is calculated as a percentage or amount</summary>
        public byte IsLaborBurdenPercent { get; set; }
        /// <summary>Labor burden rate</summary>
        public double? LaborBurdenRate { get; set; }
        /// <summary>Machine burden rate</summary>
        public double? MachineBurdenRate { get; set; }
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
        public string Notes { get; set; }
        /// <summary>Area to which the work center belongs.</summary>
        public Guid? ProductionArea { get; set; }
        /// <summary>Run labor rate</summary>
        public double? RunLaborRate { get; set; }
        /// <summary>Search code of the work center</summary>
        public string SearchCode { get; set; }
        /// <summary>Setup labor rate</summary>
        public double? SetupLaborRate { get; set; }
        /// <summary>Reference to WorkcenterStatus</summary>
        public int? Status { get; set; }
        /// <summary>Reference to WorkcenterTypes</summary>
        public int? Type { get; set; }
    }
}

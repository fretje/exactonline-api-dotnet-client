using System;

namespace ExactOnline.Client.Models.Accountancy
{
    [SupportedActionsSDK(true, true, true, true)]
    [DataServiceKey("ID")]
    public class TaskType
    {
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of the creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of the creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Name of the task type</summary>
        public string Description { get; set; }
        /// <summary>Term ID of the task type</summary>
        public int? DescriptionTermID { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Modified { get; set; }
        /// <summary>User ID of the modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Modifier { get; set; }
        /// <summary>Name of the modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ModifierFullName { get; set; }
    }
}

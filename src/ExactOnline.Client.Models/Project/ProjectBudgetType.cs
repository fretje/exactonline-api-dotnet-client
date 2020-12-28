namespace ExactOnline.Client.Models.Project
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class ProjectBudgetType
    {
        /// <summary>Description</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string Description { get; set; }
        /// <summary>Primary key</summary>
        public short ID { get; set; }
    }
}

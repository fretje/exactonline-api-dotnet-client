namespace ExactOnline.Client.Models.Financial
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class GLTransactionType
    {
        public string Description { get; set; }
        public string DescriptionSuffix { get; set; }
        public int ID { get; set; }
    }
}

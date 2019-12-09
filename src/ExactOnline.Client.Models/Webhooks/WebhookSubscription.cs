using System;

namespace ExactOnline.Client.Models.Webhooks
{
    [SupportedActionsSDK(true, true, false, true)]
    [DataServiceKey("ID")]
    public class WebhookSubscription
    {
        public Guid ID { get; set; }
        public string CallbackURL { get; set; }
        public Guid? ClientID { get; set; }
        public DateTime? Created { get; set; }
        public Guid? Creator { get; set; }
        public string CreatorFullName { get; set; }
        public string Description { get; set; }
        public int? Division { get; set; }
        public string Topic { get; set; }
    }
}

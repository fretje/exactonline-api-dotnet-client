using System;

namespace ExactOnline.Client.Models.SalesInvoice
{
    [SupportedActionsSDK(true, false, false, false)]
    [DataServiceKey("ID")]
    public class SalesOrderID
    {
        public Guid ID { get; set; }
    }
}

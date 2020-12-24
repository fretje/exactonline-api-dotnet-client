using System;

namespace ExactOnline.Client.Models.Sync
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class Deleted
    {
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int Division { get; set; }

        /// <summary>Entity Key</summary>
        public Guid EntityKey { get; set; }

        /// <summary>Entity Type</summary>
        public int EntityType { get; set; }

        /// <summary>Primary Key</summary>
        public Guid ID { get; set; }

        /// <summary>Timestamp for use with the sync service</summary>
        public long Timestamp { get; set; }
    }
}

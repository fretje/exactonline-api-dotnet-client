using System;

namespace ExactOnline.Client.Models.Sync
{
	public enum EntityType
	{
		GLTransactions = 1,
		Accounts = 2,
		Addresses = 3,
		Attachments = 4,
		Contacts = 5,
		Documents = 6,
		GLAccounts = 7,
		ItemPrices = 8,
		Items = 9,
		PaymentTerms = 10,
		Quotations = 11,
		SalesOrders = 12,
		SalesTransactions = 13,
		TimeCostTransactions = 14
	}

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
        public EntityType EntityType { get; set; }

        /// <summary>Primary Key</summary>
        public Guid ID { get; set; }

        /// <summary>Timestamp for use with the sync service</summary>
        public long Timestamp { get; set; }
    }
}

using System.Collections.Generic;
using System;

namespace ExactOnline.Client.Models.CRM
{
    [SupportedActionsSDK(false, true, false, false, canBulkRead: true)]
    [DataServiceKey("ID")]
    public class Document : SupportsSync
	{
        /// <summary>ID of the related account of this document</summary>
        public Guid? Account { get; set; }
        /// <summary>Attachments linked to the document. Binaries are not sent in the response.</summary>
        public IEnumerable<DocumentsAttachment> Attachments { get; set; }
        /// <summary>Body of this document</summary>
        public string Body { get; set; }
        /// <summary>ID of the related contact of this document</summary>
        public Guid? Contact { get; set; }
        /// <summary>Creation date</summary>
        public DateTime Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        public int Division { get; set; }
        /// <summary>Entry date of the incoming document</summary>
        public DateTime? DocumentDate { get; set; }
        /// <summary>Id of document folder</summary>
        public Guid? DocumentFolder { get; set; }
        /// <summary>Url to view the document</summary>
        public string DocumentViewUrl { get; set; }
        /// <summary>Indicates that the document body is empty</summary>
        public bool HasEmptyBody { get; set; }
        /// <summary>Human-readable ID, formatted as xx.xxx.xxx. Unique. May not be equal to zero</summary>
        public int HID { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>The opportunity linked to the document</summary>
        public Guid? Opportunity { get; set; }
        /// <summary>Purchase invoice number.</summary>
        public int? PurchaseInvoiceNumber { get; set; }
        /// <summary>Purchase order number.</summary>
        public int? PurchaseOrderNumber { get; set; }
        /// <summary>&apos;Our reference&apos; of the transaction that belongs to this document</summary>
        public int? SalesInvoiceNumber { get; set; }
        /// <summary>Number of the sales order</summary>
        public int? SalesOrderNumber { get; set; }
        /// <summary>Send Method</summary>
        public int? SendMethod { get; set; }
        public int Share { get; set; }
        /// <summary>Subject of this document</summary>
        public string Subject { get; set; }
        /// <summary>The document type</summary>
        public int Type { get; set; }
        /// <summary>Translated description of the document type. $filter and $orderby are not supported for this property.</summary>
        public string TypeDescription { get; set; }
        /// <summary>Translation id of the document type description</summary>
        public int TypeDescriptionTermId { get; set; }
        /// <summary>English description of the document type</summary>
        public string UntermedTypeDescription { get; set; }
    }
}

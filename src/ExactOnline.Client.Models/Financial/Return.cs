using System;

namespace ExactOnline.Client.Models.Financial
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("DocumentID")]
    public class Return
    {
        /// <summary>Amount in the currency of the transaction</summary>
        public double? Amount { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime Created { get; set; }
        /// <summary>Currency</summary>
        public string Currency { get; set; }
        /// <summary>Description</summary>
        public string Description { get; set; }
        /// <summary>Primary key, document ID</summary>
        public Guid DocumentID { get; set; }
        /// <summary>Url to view the document</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string DocumentViewUrl { get; set; }
        /// <summary>Due date</summary>
        public DateTime? DueDate { get; set; }
        /// <summary>Frequency</summary>
        public string Frequency { get; set; }
        /// <summary>Payroll declaration type</summary>
        public string PayrollDeclarationType { get; set; }
        /// <summary>Period</summary>
        public int Period { get; set; }
        /// <summary>Description of Period</summary>
        public string PeriodDescription { get; set; }
        /// <summary>Reference to request</summary>
        public Guid? Request { get; set; }
        /// <summary>Status</summary>
        public int Status { get; set; }
        /// <summary>Type</summary>
        public int Type { get; set; }
        /// <summary>Year</summary>
        public int Year { get; set; }
    }
}

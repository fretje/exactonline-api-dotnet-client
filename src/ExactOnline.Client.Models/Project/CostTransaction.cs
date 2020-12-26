using System;

namespace ExactOnline.Client.Models.Project
{
    [SupportedActionsSDK(true, true, true, true)]
    [DataServiceKey("ID")]
    public class CostTransaction
    {
        /// <summary>Account linked to the transaction</summary>
        public Guid? Account { get; set; }
        /// <summary>Name of Account</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AccountName { get; set; }
        /// <summary>This property is obsolete. Use property &apos;AmountFC&apos; instead.</summary>
        public double? Amount { get; set; }
        /// <summary>Amount of the transaction in the currency of the transaction</summary>
        public double? AmountFC { get; set; }
        /// <summary>Attachment linked to the transaction (not mandatory)</summary>
        public Guid? Attachment { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Currency of the amount</summary>
        public string Currency { get; set; }
        /// <summary>Date</summary>
        public DateTime? Date { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Description of Division</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string DivisionDescription { get; set; }
        /// <summary>Employee linked to the transaction</summary>
        public Guid? Employee { get; set; }
        /// <summary>Entrynumber</summary>
        public int? EntryNumber { get; set; }
        /// <summary>Errortext, used for the backgroundjobs</summary>
        public string ErrorText { get; set; }
        /// <summary>Reference to ProjectWBS (work breakdown structure)</summary>
        public Guid? Expense { get; set; }
        /// <summary>Description of ProjectWBS</summary>
        public string ExpenseDescription { get; set; }
        /// <summary>Status of the transaction</summary>
        public short? HourStatus { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Item linked to the transaction. Items of type &apos;time&apos; are linked to time transactionsItems of other types are linked to costtransactions</summary>
        public Guid? Item { get; set; }
        /// <summary>Description of Item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemDescription { get; set; }
        /// <summary>Indicates if fractional quantities of the item can be used, for example quantity = 0.4</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool? ItemDivisable { get; set; }
        /// <summary>Last modified date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ModifierFullName { get; set; }
        /// <summary>Notes linked to the transaction (not mandatory)</summary>
        public string Notes { get; set; }
        /// <summary>This property is obsolete. Use property &apos;PriceFC&apos; instead.</summary>
        public double? Price { get; set; }
        /// <summary>PriceFC (AmountFC = Quantity * PriceFC)</summary>
        public double? PriceFC { get; set; }
        /// <summary>Project linked to the transaction</summary>
        public Guid? Project { get; set; }
        /// <summary>Project account linked to the transaction (not mandatory)</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? ProjectAccount { get; set; }
        /// <summary>Project account code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ProjectAccountCode { get; set; }
        /// <summary>Project account name</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ProjectAccountName { get; set; }
        /// <summary>Description of Project</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ProjectDescription { get; set; }
        /// <summary>Quantity of the transaction</summary>
        public double? Quantity { get; set; }
        /// <summary>Skip validation</summary>
        public bool SkipValidation { get; set; }
        /// <summary>Subscription linked to the transaction</summary>
        public Guid? Subscription { get; set; }
        /// <summary>Account linked to the subscription</summary>
        public Guid? SubscriptionAccount { get; set; }
        /// <summary>Subscription account code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SubscriptionAccountCode { get; set; }
        /// <summary>Subscription account name</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SubscriptionAccountName { get; set; }
        /// <summary>Description of the subscription</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SubscriptionDescription { get; set; }
        /// <summary>Subscription number</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? SubscriptionNumber { get; set; }
        /// <summary>Type of the transaction</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public short? Type { get; set; }
    }
}

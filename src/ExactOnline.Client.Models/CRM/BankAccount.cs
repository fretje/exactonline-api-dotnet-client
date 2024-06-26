using Newtonsoft.Json;

namespace ExactOnline.Client.Models.CRM;

[SupportedActionsSDK(true, true, true, true)]
[DataServiceKey("ID")]
public class BankAccount
{
	/// <summary>Account (customer, supplier) to which the bank account belongs</summary>
	public Guid? Account { get; set; }
	/// <summary>The name of the account</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string AccountName { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Bank { get; set; }
	/// <summary>The bank account number</summary>
	[JsonProperty(PropertyName = "BankAccount")]
	public string BankAccountName { get; set; }
	/// <summary>Name of the holder of the bank account, as known by the bank</summary>
	public string BankAccountHolderName { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string BankDescription { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string BankName { get; set; }
	/// <summary>BIC code of the bank where the bank account is held</summary>
	public string BICCode { get; set; }
	/// <summary>Creation date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string CreatorFullName { get; set; }
	/// <summary>Description of the bank account</summary>
	public string Description { get; set; }
	/// <summary>Division code</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public int? Division { get; set; }
	/// <summary>Format that belongs to the bank account number</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Format { get; set; }
	/// <summary>Obsolete</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string IBAN { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Indicates if the bank account is the main bank account</summary>
	public bool? Main { get; set; }
	/// <summary>Last modified date</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string ModifierFullName { get; set; }
	/// <summary>ID of the Payment service account. Used when Type is &apos;P&apos; (Payment service)</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public Guid? PaymentServiceAccount { get; set; }
	/// <summary>The type indicates what entity the bank account is used for. A = Account (default), E = Employee, K = Cash, P = Payment service, R = Bank, S = Student, U = Unknown. Currently it&apos;s only possible to create &apos;Account&apos; type bank accounts.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string Type { get; set; }
	/// <summary>Description of the Type</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public string TypeDescription { get; set; }
}

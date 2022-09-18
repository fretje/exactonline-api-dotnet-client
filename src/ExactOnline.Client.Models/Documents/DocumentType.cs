namespace ExactOnline.Client.Models.Documents;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class DocumentType
{
	/// <summary>Creation date</summary>
	public DateTime? Created { get; set; }
	/// <summary>Document type description</summary>
	public string Description { get; set; }
	/// <summary>Indicates if documents of this type can be created</summary>
	public bool DocumentIsCreatable { get; set; }
	/// <summary>Indicates if documents of this type can be deleted</summary>
	public bool DocumentIsDeletable { get; set; }
	/// <summary>Indicates if documents of this type can be updated</summary>
	public bool DocumentIsUpdatable { get; set; }
	/// <summary>Indicates if documents of this type can be retrieved</summary>
	public bool DocumentIsViewable { get; set; }
	/// <summary>Primary key</summary>
	public int ID { get; set; }
	/// <summary>Last modified date</summary>
	public DateTime? Modified { get; set; }
	/// <summary>ID of the document type category</summary>
	public int? TypeCategory { get; set; }
}

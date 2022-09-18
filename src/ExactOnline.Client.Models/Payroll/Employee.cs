namespace ExactOnline.Client.Models.Payroll;

[SupportedActionsSDK(false, true, false, false)]
[DataServiceKey("ID")]
public class Employee
{
	/// <summary>Obsolete</summary>
	public byte? ActiveEmployment { get; set; }
	/// <summary>Second address line</summary>
	public string AddressLine2 { get; set; }
	/// <summary>Third address line</summary>
	public string AddressLine3 { get; set; }
	/// <summary>Street of address</summary>
	public string AddressStreet { get; set; }
	/// <summary>Street number of address</summary>
	public string AddressStreetNumber { get; set; }
	/// <summary>Street number suffix of address</summary>
	public string AddressStreetNumberSuffix { get; set; }
	/// <summary>Birth date</summary>
	public DateTime? BirthDate { get; set; }
	/// <summary>Birth name</summary>
	public string BirthName { get; set; }
	/// <summary>Birth middle name</summary>
	public string BirthNamePrefix { get; set; }
	/// <summary>Birth place</summary>
	public string BirthPlace { get; set; }
	/// <summary>Email of the employee at the office</summary>
	public string BusinessEmail { get; set; }
	/// <summary>Fax number of the employee at the office</summary>
	public string BusinessFax { get; set; }
	/// <summary>Office mobile number of the employee</summary>
	public string BusinessMobile { get; set; }
	/// <summary>Phone number of the employee at the office</summary>
	public string BusinessPhone { get; set; }
	/// <summary>Phone extension of the employee at the office</summary>
	public string BusinessPhoneExtension { get; set; }
	/// <summary>Obsolete</summary>
	public string CASONumber { get; set; }
	/// <summary>City</summary>
	public string City { get; set; }
	/// <summary>Code of the employee</summary>
	public string Code { get; set; }
	/// <summary>Country code</summary>
	public string Country { get; set; }
	/// <summary>Creation date</summary>
	public DateTime? Created { get; set; }
	/// <summary>User ID of creator</summary>
	public Guid? Creator { get; set; }
	/// <summary>Name of creator</summary>
	public string CreatorFullName { get; set; }
	/// <summary>Customer ID</summary>
	public Guid? Customer { get; set; }
	/// <summary>Division code</summary>
	public int? Division { get; set; }
	/// <summary>Email address</summary>
	public string Email { get; set; }
	/// <summary>Employee number</summary>
	public int? EmployeeHID { get; set; }
	/// <summary>End date of the employee</summary>
	public DateTime? EndDate { get; set; }
	/// <summary>First name of the employee</summary>
	public string FirstName { get; set; }
	/// <summary>Full name of the employee</summary>
	public string FullName { get; set; }
	/// <summary>Gender</summary>
	public string Gender { get; set; }
	/// <summary>Numeric ID of the employee</summary>
	public int? HID { get; set; }
	/// <summary>Primary key</summary>
	public Guid ID { get; set; }
	/// <summary>Initials</summary>
	public string Initials { get; set; }
	/// <summary>IsActive</summary>
	public bool IsActive { get; set; }
	/// <summary>Indicates whether the employee is anonymised.</summary>
	[SDKFieldType(FieldType.ReadOnly)]
	public byte IsAnonymised { get; set; }
	/// <summary>Language code</summary>
	public string Language { get; set; }
	/// <summary>Last name</summary>
	public string LastName { get; set; }
	/// <summary>Description of the location of the employee (where am I?)</summary>
	public string LocationDescription { get; set; }
	/// <summary>Direct manager of the employee</summary>
	public Guid? Manager { get; set; }
	/// <summary>Date of marriage</summary>
	public DateTime? MaritalDate { get; set; }
	/// <summary>Marital status</summary>
	public short? MaritalStatus { get; set; }
	/// <summary>Middle name</summary>
	public string MiddleName { get; set; }
	/// <summary>Mobile phone</summary>
	public string Mobile { get; set; }
	/// <summary>Last modified date</summary>
	public DateTime? Modified { get; set; }
	/// <summary>User ID of modifier</summary>
	public Guid? Modifier { get; set; }
	/// <summary>Name of modifier</summary>
	public string ModifierFullName { get; set; }
	/// <summary>Municipality</summary>
	public string Municipality { get; set; }
	public short? NameComposition { get; set; }
	/// <summary>Nationality</summary>
	public string Nationality { get; set; }
	/// <summary>Nick name</summary>
	public string NickName { get; set; }
	/// <summary>Additional notes</summary>
	public string Notes { get; set; }
	/// <summary>Name of partner</summary>
	public string PartnerName { get; set; }
	/// <summary>Middle name of partner</summary>
	public string PartnerNamePrefix { get; set; }
	/// <summary>Reference to the persons table in which the personal data of the employee is stored</summary>
	public Guid? Person { get; set; }
	/// <summary>Phone number</summary>
	public string Phone { get; set; }
	/// <summary>Phone number extension</summary>
	public string PhoneExtension { get; set; }
	/// <summary>Filename of picture</summary>
	public string PictureFileName { get; set; }
	/// <summary>Url of picture</summary>
	public string PictureUrl { get; set; }
	/// <summary>Postcode</summary>
	public string Postcode { get; set; }
	/// <summary>Private email address</summary>
	public string PrivateEmail { get; set; }
	/// <summary>Social security number</summary>
	public string SocialSecurityNumber { get; set; }
	/// <summary>Start date of the employee</summary>
	public DateTime? StartDate { get; set; }
	/// <summary>State</summary>
	public string State { get; set; }
	/// <summary>Title</summary>
	public string Title { get; set; }
	/// <summary>User ID of employee</summary>
	public Guid? User { get; set; }
	/// <summary>Name of user</summary>
	public string UserFullName { get; set; }
}

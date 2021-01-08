using System;

namespace ExactOnline.Client.Models.CRM
{
    [SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
    [DataServiceKey("ID")]
    public class Contact : SupportsSync
    {
        /// <summary>The account to which the contact belongs</summary>
        public Guid? Account { get; set; }
        /// <summary>Indicates if account is a customer</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool AccountIsCustomer { get; set; }
        /// <summary>Indicates if account is a supplier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool? AccountIsSupplier { get; set; }
        /// <summary>Reference to the main contact of the account</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? AccountMainContact { get; set; }
        /// <summary>Name of the account</summary>
        public string AccountName { get; set; }
        /// <summary>Second address line</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AddressLine2 { get; set; }
        /// <summary>Street name of the address</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AddressStreet { get; set; }
        /// <summary>Street number of the address</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AddressStreetNumber { get; set; }
        /// <summary>Street number suffix of the address</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AddressStreetNumberSuffix { get; set; }
        /// <summary>Obsolete</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? AllowMailing { get; set; }
        /// <summary>Birth date</summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>Obsolete. Please don&apos;t use this field anymore as it may overwrite LastName.</summary>
        public string BirthName { get; set; }
        /// <summary>Obsolete. Please don&apos;t use this field anymore as it may overwrite MiddleName.</summary>
        public string BirthNamePrefix { get; set; }
        /// <summary>Birth place</summary>
        public string BirthPlace { get; set; }
        /// <summary>Email address of the contact</summary>
        public string BusinessEmail { get; set; }
        /// <summary>Fax of the contact</summary>
        public string BusinessFax { get; set; }
        /// <summary>Mobile of the contact</summary>
        public string BusinessMobile { get; set; }
        /// <summary>Phone of the contact</summary>
        public string BusinessPhone { get; set; }
        /// <summary>Phone extension of the contact</summary>
        public string BusinessPhoneExtension { get; set; }
        /// <summary>City</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string City { get; set; }
        /// <summary>Code of the account</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string Code { get; set; }
        /// <summary>Country code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string Country { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of the creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of the creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Email address of the contact</summary>
        public string Email { get; set; }
        /// <summary>End date</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>First name. Provide at least first name or last name to create a new contact</summary>
        public string FirstName { get; set; }
        /// <summary>Full name (First name Middle name Last name)</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string FullName { get; set; }
        /// <summary>Gender</summary>
        public string Gender { get; set; }
        /// <summary>Contact ID</summary>
        public int? HID { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Identification date</summary>
        public DateTime? IdentificationDate { get; set; }
        /// <summary>Reference to the identification document of the contact</summary>
        public Guid? IdentificationDocument { get; set; }
        /// <summary>Reference to the user responsible for identification</summary>
        public Guid? IdentificationUser { get; set; }
        /// <summary>Initials</summary>
        public string Initials { get; set; }
        /// <summary>Indicates whether the contact is anonymised.</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public byte IsAnonymised { get; set; }
        /// <summary>Indicates whether contacts are excluded from the marketing list</summary>
        public bool? IsMailingExcluded { get; set; }
        /// <summary>Indicates if this is the main contact of the linked account</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool? IsMainContact { get; set; }
        /// <summary>Jobtitle of the contact</summary>
        public string JobTitleDescription { get; set; }
        /// <summary>Language code</summary>
        public string Language { get; set; }
        /// <summary>Last name. Provide at least first name or last name to create a new contact</summary>
        public string LastName { get; set; }
        /// <summary>Reference to purpose of an contact</summary>
        public Guid? LeadPurpose { get; set; }
        /// <summary>Reference to source of an contact</summary>
        public Guid? LeadSource { get; set; }
        /// <summary>The user should be able to do a full text search on these notes to gather contacts for a marketing campaign</summary>
        public string MarketingNotes { get; set; }
        /// <summary>Middle name</summary>
        public string MiddleName { get; set; }
        /// <summary>Business phone of the contact</summary>
        public string Mobile { get; set; }
        /// <summary>Last modified date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Modifier { get; set; }
        /// <summary>Name of the last modifier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ModifierFullName { get; set; }
        /// <summary>Nationality</summary>
        public string Nationality { get; set; }
        /// <summary>Extra remarks</summary>
        public string Notes { get; set; }
        /// <summary>Last name of partner</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PartnerName { get; set; }
        /// <summary>Middlename of partner</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PartnerNamePrefix { get; set; }
        /// <summary>Reference to the personal information of this contact such as name, gender, address etc.</summary>
        public Guid? Person { get; set; }
        /// <summary>Phone of the contact</summary>
        public string Phone { get; set; }
        /// <summary>Phone extension of the contact</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PhoneExtension { get; set; }
        /// <summary>This field is write-only. The picture can be downloaded through PictureUrl and PictureThumbnailUrl.</summary>
        public byte[] Picture { get; set; }
        /// <summary>Filename of the picture</summary>
        public string PictureName { get; set; }
        /// <summary>Url to retrieve the picture thumbnail</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PictureThumbnailUrl { get; set; }
        /// <summary>Url to retrieve the picture</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PictureUrl { get; set; }
        /// <summary>Postcode</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string Postcode { get; set; }
        /// <summary>Social security number</summary>
        public string SocialSecurityNumber { get; set; }
        /// <summary>Start date</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>State</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string State { get; set; }
        /// <summary>Title</summary>
        public string Title { get; set; }
    }
}

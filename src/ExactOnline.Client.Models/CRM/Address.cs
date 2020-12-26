using System;

namespace ExactOnline.Client.Models.CRM
{
    [SupportedActionsSDK(true, true, true, true, canBulkRead: true)]
    [DataServiceKey("ID")]
    public class Address : SupportsSync
    {
        /// <summary>Account linked to the address</summary>
        public Guid? Account { get; set; }
        /// <summary>Indicates if the account is a supplier</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool? AccountIsSupplier { get; set; }
        /// <summary>Name of the account</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AccountName { get; set; }
        /// <summary>First address line</summary>
        public string AddressLine1 { get; set; }
        /// <summary>Second address line</summary>
        public string AddressLine2 { get; set; }
        /// <summary>Third address line</summary>
        public string AddressLine3 { get; set; }
        /// <summary>City</summary>
        public string City { get; set; }
        /// <summary>Contact linked to Address</summary>
        public Guid? Contact { get; set; }
        /// <summary>Contact name</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ContactName { get; set; }
        /// <summary>Country code</summary>
        public string Country { get; set; }
        /// <summary>Country name</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CountryName { get; set; }
        /// <summary>Creation date</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? Division { get; set; }
        /// <summary>Fax number</summary>
        public string Fax { get; set; }
        /// <summary>Free boolean field 1</summary>
        public bool? FreeBoolField_01 { get; set; }
        /// <summary>Free boolean field 2</summary>
        public bool? FreeBoolField_02 { get; set; }
        /// <summary>Free boolean field 3</summary>
        public bool? FreeBoolField_03 { get; set; }
        /// <summary>Free boolean field 4</summary>
        public bool? FreeBoolField_04 { get; set; }
        /// <summary>Free boolean field 5</summary>
        public bool? FreeBoolField_05 { get; set; }
        /// <summary>Free date field 1</summary>
        public DateTime? FreeDateField_01 { get; set; }
        /// <summary>Free date field 2</summary>
        public DateTime? FreeDateField_02 { get; set; }
        /// <summary>Free date field 3</summary>
        public DateTime? FreeDateField_03 { get; set; }
        /// <summary>Free date field 4</summary>
        public DateTime? FreeDateField_04 { get; set; }
        /// <summary>Free date field 5</summary>
        public DateTime? FreeDateField_05 { get; set; }
        /// <summary>Free number field 1</summary>
        public double? FreeNumberField_01 { get; set; }
        /// <summary>Free number field 2</summary>
        public double? FreeNumberField_02 { get; set; }
        /// <summary>Free number field 3</summary>
        public double? FreeNumberField_03 { get; set; }
        /// <summary>Free number field 4</summary>
        public double? FreeNumberField_04 { get; set; }
        /// <summary>Free number field 5</summary>
        public double? FreeNumberField_05 { get; set; }
        /// <summary>Free text field 1</summary>
        public string FreeTextField_01 { get; set; }
        /// <summary>Free text field 2</summary>
        public string FreeTextField_02 { get; set; }
        /// <summary>Free text field 3</summary>
        public string FreeTextField_03 { get; set; }
        /// <summary>Free text field 4</summary>
        public string FreeTextField_04 { get; set; }
        /// <summary>Free text field 5</summary>
        public string FreeTextField_05 { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Mailbox</summary>
        public string Mailbox { get; set; }
        /// <summary>Indicates if the address is the main address for this type</summary>
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
        /// <summary>Last 5 digits of SIRET number which is an intern sequential number of 4 digits representing the identification of the localization of the office</summary>
        public string NicNumber { get; set; }
        /// <summary>Notes for an address</summary>
        public string Notes { get; set; }
        /// <summary>Phone number</summary>
        public string Phone { get; set; }
        /// <summary>Phone extension</summary>
        public string PhoneExtension { get; set; }
        /// <summary>Postcode</summary>
        public string Postcode { get; set; }
        /// <summary>State</summary>
        public string State { get; set; }
        /// <summary>Name of the State</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string StateDescription { get; set; }
        /// <summary>The type of address. Visit=1, Postal=2, Invoice=3, Delivery=4</summary>
        public short? Type { get; set; }
        /// <summary>The warehouse linked to the address, if a warehouse is linked the account will be empty. Can only be filled for type=Delivery</summary>
        public Guid? Warehouse { get; set; }
        /// <summary>Code of the warehoude</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string WarehouseCode { get; set; }
        /// <summary>Description of the warehouse</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string WarehouseDescription { get; set; }
    }
}

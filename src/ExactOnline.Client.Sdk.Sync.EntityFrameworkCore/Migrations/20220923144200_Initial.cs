using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceRegistration",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cause = table.Column<short>(type: "smallint", nullable: true),
                    CauseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: true),
                    KindCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceRegistration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceRegistrationTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbsenceRegistration = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    HoursFirstDay = table.Column<double>(type: "float", nullable: true),
                    HoursLastDay = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationMoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PercentageDisablement = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceRegistrationTransaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accountant = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountManager = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountManagerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountManagerHID = table.Column<int>(type: "int", nullable: true),
                    ActivitySector = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivitySubSector = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: true),
                    BRIN = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BusinessType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CanDropShip = table.Column<bool>(type: "bit", nullable: true),
                    ChamberOfCommerce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification3 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification4 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification5 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification6 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification7 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Classification8 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeAtSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySize = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsolidationScenario = table.Column<byte>(type: "tinyint", nullable: true),
                    ControlledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPaid = table.Column<byte>(type: "tinyint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditLinePurchase = table.Column<double>(type: "float", nullable: true),
                    CreditLineSales = table.Column<double>(type: "float", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerSince = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatevCreditorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatevDebtorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPurchase = table.Column<double>(type: "float", nullable: true),
                    DiscountSales = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DunsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountPurchase = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountSales = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAR = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GlnNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasWithholdingTaxSales = table.Column<bool>(type: "bit", nullable: true),
                    IgnoreDatevWarningMessage = table.Column<bool>(type: "bit", nullable: false),
                    IntraStatArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatDeliveryTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransactionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransactionB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransportMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAttachmentType = table.Column<int>(type: "int", nullable: true),
                    InvoicingMethod = table.Column<int>(type: "int", nullable: true),
                    IsAccountant = table.Column<byte>(type: "tinyint", nullable: false),
                    IsAgency = table.Column<byte>(type: "tinyint", nullable: false),
                    IsAnonymised = table.Column<byte>(type: "tinyint", nullable: false),
                    IsBank = table.Column<bool>(type: "bit", nullable: true),
                    IsCompetitor = table.Column<byte>(type: "tinyint", nullable: false),
                    IsExtraDuty = table.Column<bool>(type: "bit", nullable: true),
                    IsMailing = table.Column<byte>(type: "tinyint", nullable: false),
                    IsMember = table.Column<bool>(type: "bit", nullable: true),
                    IsPilot = table.Column<bool>(type: "bit", nullable: true),
                    IsPurchase = table.Column<bool>(type: "bit", nullable: true),
                    IsReseller = table.Column<bool>(type: "bit", nullable: true),
                    IsSales = table.Column<bool>(type: "bit", nullable: true),
                    IsSupplier = table.Column<bool>(type: "bit", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    LeadPurpose = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadSource = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LogoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    MainContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PayAsYouEarn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionPurchase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionPurchaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionSales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionSalesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceList = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseCurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseLeadDays = table.Column<int>(type: "int", nullable: true),
                    PurchaseVATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseVATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecepientOfCommissions = table.Column<bool>(type: "bit", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reseller = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResellerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RSIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesCurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesTaxSchedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesTaxScheduleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesTaxScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesVATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesVATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityLevel = table.Column<int>(type: "int", nullable: true),
                    SeparateInvPerProject = table.Column<byte>(type: "tinyint", nullable: false),
                    SeparateInvPerSubscription = table.Column<byte>(type: "tinyint", nullable: false),
                    ShippingLeadDays = table.Column<int>(type: "int", nullable: true),
                    ShippingMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSince = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueTaxpayerReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATLiability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountantInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccountant = table.Column<bool>(type: "bit", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MenuLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountantInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountClass",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditManagementScenario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountClassification",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountClassificationName = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountClassificationNameDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClassification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountClassificationName",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClassificationName", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountInvolvedAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    InvolvedAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvolvedAccountRelationTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvolvedAccountRelationTypeDescriptionTermId = table.Column<int>(type: "int", nullable: true),
                    InvolvedAccountRelationTypeId = table.Column<short>(type: "smallint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInvolvedAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountOwner",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shares = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActiveEmployment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageDaysPerWeek = table.Column<double>(type: "float", nullable: true),
                    AverageHoursPerWeek = table.Column<double>(type: "float", nullable: true),
                    Contract = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractDocument = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractProbationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractProbationPeriod = table.Column<int>(type: "int", nullable: true),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractType = table.Column<int>(type: "int", nullable: true),
                    ContractTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    EmploymentOrganization = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    HourlyWage = table.Column<double>(type: "float", nullable: true),
                    InternalRate = table.Column<double>(type: "float", nullable: true),
                    Jobtitle = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobtitleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonEnd = table.Column<int>(type: "int", nullable: true),
                    ReasonEndDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonEndFlex = table.Column<int>(type: "int", nullable: true),
                    ReasonEndFlexDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Schedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleAverageHours = table.Column<double>(type: "float", nullable: true),
                    ScheduleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDays = table.Column<double>(type: "float", nullable: true),
                    ScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleHours = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDateOrganization = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveEmployment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountIsSupplier = table.Column<bool>(type: "bit", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeBoolField_01 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_02 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_03 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_04 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_05 = table.Column<bool>(type: "bit", nullable: true),
                    FreeDateField_01 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_02 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_03 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_04 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_05 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeNumberField_01 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_02 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_03 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_04 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_05 = table.Column<double>(type: "float", nullable: true),
                    FreeTextField_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NicNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AddressState",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AgingOverview",
                columns: table => new
                {
                    AgeGroup = table.Column<int>(type: "int", nullable: false),
                    AgeGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountPayable = table.Column<double>(type: "float", nullable: false),
                    AmountReceivable = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgingOverview", x => x.AgeGroup);
                });

            migrationBuilder.CreateTable(
                name: "AgingPayablesList",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup1 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup1Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup2 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup2Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup3 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup3Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup4 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup4Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgingPayablesList", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AgingReceivablesList",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup1 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup1Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup2 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup2Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup3 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup3Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroup4 = table.Column<int>(type: "int", nullable: false),
                    AgeGroup4Amount = table.Column<double>(type: "float", nullable: false),
                    AgeGroup4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgingReceivablesList", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyOrder",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssemblyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    FinishedQuantity = table.Column<double>(type: "float", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PlannedQuantity = table.Column<double>(type: "float", nullable: false),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlreadyDepreciated = table.Column<byte>(type: "tinyint", nullable: false),
                    AssetFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetFromDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogueValue = table.Column<double>(type: "float", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeductionPercentage = table.Column<double>(type: "float", nullable: true),
                    DepreciatedAmount = table.Column<double>(type: "float", nullable: true),
                    DepreciatedPeriods = table.Column<int>(type: "int", nullable: true),
                    DepreciatedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EngineEmission = table.Column<short>(type: "smallint", nullable: true),
                    EngineType = table.Column<short>(type: "smallint", nullable: true),
                    GLTransactionLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLTransactionLineDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvestmentAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentAmountDC = table.Column<double>(type: "float", nullable: true),
                    InvestmentAmountFC = table.Column<double>(type: "float", nullable: true),
                    InvestmentCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentCurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvestmentDeduction = table.Column<short>(type: "smallint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PictureFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrimaryMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidualValue = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    TransactionEntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionEntryNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AssetGroup",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepreciationMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    GLAccountAssets = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountAssetsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountAssetsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDepreciationBS = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountDepreciationBSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDepreciationBSDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDepreciationPL = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountDepreciationPLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDepreciationPLDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountRevaluationBS = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountRevaluationBSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountRevaluationBSDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AvailableFeature",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableFeature", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BICCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BICCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentServiceAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankEntry",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankStatementDocument = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankStatementDocumentNumber = table.Column<int>(type: "int", nullable: true),
                    BankStatementDocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingBalanceFC = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    FinancialPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinancialYear = table.Column<short>(type: "smallint", nullable: true),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningBalanceFC = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEntry", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "BankEntryLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    AmountVATFC = table.Column<double>(type: "float", nullable: true),
                    Asset = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffsetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OurRef = table.Column<int>(type: "int", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true),
                    VATType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEntryLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BatchNumber",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableQuantity = table.Column<double>(type: "float", nullable: true),
                    BatchNumberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlocked = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchNumber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterialMaterial",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageCost = table.Column<double>(type: "float", nullable: true),
                    Backflush = table.Column<byte>(type: "tinyint", nullable: true),
                    CalculatorType = table.Column<int>(type: "int", nullable: true),
                    CostBatch = table.Column<double>(type: "float", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailDrawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    ItemVersion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    NetWeight = table.Column<double>(type: "float", nullable: true),
                    NetWeightUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartItem = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartItemCostPriceStandard = table.Column<double>(type: "float", nullable: true),
                    PartItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    QuantityBatch = table.Column<double>(type: "float", nullable: true),
                    syscreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    syscreator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    sysmodified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sysmodifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterialMaterial", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterialVersion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchQuantity = table.Column<double>(type: "float", nullable: true),
                    CadDrawingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculatedCostPrice = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<byte>(type: "tinyint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderLeadDays = table.Column<int>(type: "int", nullable: true),
                    ProductionLeadDays = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VersionNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterialVersion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    BudgetScenario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BudgetScenarioCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetScenarioDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<long>(type: "bigint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingPeriod = table.Column<short>(type: "smallint", nullable: true),
                    ReportingYear = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ByProductReceipt",
                columns: table => new
                {
                    StockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftStockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasReversibleQuantity = table.Column<bool>(type: "bit", nullable: false),
                    IsBackflush = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderMaterialPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByProductReceipt", x => x.StockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "ByProductReversal",
                columns: table => new
                {
                    ReversalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBackflush = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderMaterialPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByProductReversal", x => x.ReversalStockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "CashEntry",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingBalanceFC = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    FinancialPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinancialYear = table.Column<short>(type: "smallint", nullable: true),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningBalanceFC = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashEntry", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "CashEntryLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    AmountVATFC = table.Column<double>(type: "float", nullable: true),
                    Asset = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffsetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OurRef = table.Column<int>(type: "int", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true),
                    VATType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashEntryLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationNote",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationNote", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedToFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextAction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountIsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    AccountIsSupplier = table.Column<bool>(type: "bit", nullable: true),
                    AccountMainContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreetNumberSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowMailing = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthNamePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    IdentificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentificationDocument = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdentificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnonymised = table.Column<byte>(type: "tinyint", nullable: false),
                    IsMailingExcluded = table.Column<bool>(type: "bit", nullable: true),
                    IsMainContact = table.Column<bool>(type: "bit", nullable: true),
                    JobTitleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadPurpose = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadSource = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MarketingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerNamePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Costcenter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costcenter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CostTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    Attachment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DivisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ErrorText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expense = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourStatus = table.Column<short>(type: "smallint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDivisable = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    PriceFC = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SkipValidation = table.Column<bool>(type: "bit", nullable: false),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionNumber = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTransaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Costunit",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costunit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountPrecision = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PricePrecision = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DefaultMailbox",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForDivision = table.Column<int>(type: "int", nullable: true),
                    IsScanServiceMailbox = table.Column<bool>(type: "bit", nullable: false),
                    Mailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultMailbox", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Deleted",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EntityKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deleted", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepreciationMethod",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationInterval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    MaxPercentage = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    Percentage2 = table.Column<double>(type: "float", nullable: true),
                    Periods = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Years = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DirectDebitMandate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    FirstSend = table.Column<byte>(type: "tinyint", nullable: true),
                    Main = table.Column<byte>(type: "tinyint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<short>(type: "smallint", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectDebitMandate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChamberOfCommerceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current = table.Column<bool>(type: "bit", nullable: false),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hid = table.Column<long>(type: "bigint", nullable: false),
                    IsMainDivision = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VATNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DivisionClass",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassNameCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassNameDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassNameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTermID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionClass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DivisionClassName",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTermID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionClassName", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DivisionClassValue",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Class_01_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Class_02_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Class_03_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Class_04_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Class_05_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionClassValue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentFolder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentFolderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFolderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentViewUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialTransactionEntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasEmptyBody = table.Column<bool>(type: "bit", nullable: false),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesInvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    SendMethod = table.Column<int>(type: "int", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAttachment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAttachment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCategory",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFolder",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentFolder = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFolder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsAttachment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentFileSize = table.Column<double>(type: "float", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanShowInWebView = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsAttachment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentIsCreatable = table.Column<bool>(type: "bit", nullable: false),
                    DocumentIsDeletable = table.Column<bool>(type: "bit", nullable: false),
                    DocumentIsUpdatable = table.Column<bool>(type: "bit", nullable: false),
                    DocumentIsViewable = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeFolder",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    DocumentFolder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeFolder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveEmployment = table.Column<byte>(type: "tinyint", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreetNumberSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthNamePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CASONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAnonymised = table.Column<byte>(type: "tinyint", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaritalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<short>(type: "smallint", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameComposition = table.Column<short>(type: "smallint", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerNamePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonEnd = table.Column<int>(type: "int", nullable: true),
                    ReasonEndDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonEndFlex = table.Column<int>(type: "int", nullable: true),
                    ReasonEndFlexDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDateOrganization = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentContract",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractFlexPhase = table.Column<int>(type: "int", nullable: true),
                    ContractFlexPhaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    EmployeeType = table.Column<int>(type: "int", nullable: true),
                    EmployeeTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmploymentHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProbationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProbationPeriod = table.Column<int>(type: "int", nullable: true),
                    ReasonContract = table.Column<int>(type: "int", nullable: true),
                    ReasonContractDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentContract", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentContractFlexPhase",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentContractFlexPhase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentEndReason",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentEndReason", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentInternalRate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: false),
                    Employment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploymentHID = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InternalRate = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentInternalRate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentOrganization",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    Employment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmploymentHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobTitle = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobTitleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentOrganization", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentSalary",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageDaysPerWeek = table.Column<double>(type: "float", nullable: true),
                    AverageHoursPerWeek = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    Employment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmploymentHID = table.Column<int>(type: "int", nullable: true),
                    EmploymentSalaryType = table.Column<int>(type: "int", nullable: true),
                    EmploymentSalaryTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FulltimeAmount = table.Column<double>(type: "float", nullable: true),
                    HourlyWage = table.Column<double>(type: "float", nullable: true),
                    InternalRate = table.Column<double>(type: "float", nullable: true),
                    JobLevel = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParttimeAmount = table.Column<double>(type: "float", nullable: true),
                    ParttimeFactor = table.Column<double>(type: "float", nullable: true),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentSalary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    SourceCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceCurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TargetCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetCurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPeriod",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinYear = table.Column<short>(type: "smallint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GeneralJournalEntry",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    FinancialPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinancialYear = table.Column<short>(type: "smallint", nullable: true),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reversal = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralJournalEntry", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "GeneralJournalEntryLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    AmountVATDC = table.Column<double>(type: "float", nullable: true),
                    AmountVATFC = table.Column<double>(type: "float", nullable: true),
                    Asset = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffsetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OurRef = table.Column<int>(type: "int", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    VATBaseAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATBaseAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true),
                    VATType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralJournalEntryLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GLAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssimilatedVATBox = table.Column<short>(type: "smallint", nullable: true),
                    BalanceSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelcotaxType = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compress = table.Column<bool>(type: "bit", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    ExcludeVATListing = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpenseNonDeductiblePercentage = table.Column<double>(type: "float", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true),
                    Matching = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateGLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrivatePercentage = table.Column<double>(type: "float", nullable: true),
                    ReportingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevalueCurrency = table.Column<bool>(type: "bit", nullable: true),
                    SearchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCostcenter = table.Column<byte>(type: "tinyint", nullable: true),
                    UseCostunit = table.Column<byte>(type: "tinyint", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATGLAccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNonDeductibleGLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VATNonDeductiblePercentage = table.Column<double>(type: "float", nullable: true),
                    VATSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearEndCostGLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YearEndReflectionGLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GLClassification",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Abstract = table.Column<bool>(type: "bit", nullable: true),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    IsTupleSubElement = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nillable = table.Column<bool>(type: "bit", nullable: true),
                    Parent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeriodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubstitutionGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxonomyNamespace = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxonomyNamespaceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLClassification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GLScheme",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Main = table.Column<byte>(type: "tinyint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetNamespace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLScheme", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GLTransactionType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLTransactionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GoodsDelivery",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryNumber = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDelivery", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "GoodsDeliveryLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityDelivered = table.Column<double>(type: "float", nullable: true),
                    QuantityOrdered = table.Column<double>(type: "float", nullable: true),
                    SalesOrderLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderLineNumber = table.Column<int>(type: "int", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unitcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDeliveryLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceipt",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceipt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiptLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    GoodsReceiptID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseOrderNumber = table.Column<int>(type: "int", nullable: false),
                    QuantityOrdered = table.Column<double>(type: "float", nullable: true),
                    QuantityReceived = table.Column<double>(type: "float", nullable: true),
                    SupplierItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HostingOpportunity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Accountant = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    BackToLeadDevelopment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<short>(type: "smallint", nullable: true),
                    ChannelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDemandsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionMakingUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionMakingUnitRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionTimeframe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchToSales = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    IsAssociatedPrice = table.Column<byte>(type: "tinyint", nullable: true),
                    IsCustomerDemandsMeet = table.Column<byte>(type: "tinyint", nullable: true),
                    LeadDeveloper = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadSource = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadSourceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityDepartmentCode = table.Column<short>(type: "smallint", nullable: true),
                    OpportunityDepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityStage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityStageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityStatus = table.Column<int>(type: "int", nullable: true),
                    OpportunityType = table.Column<short>(type: "smallint", nullable: true),
                    OpportunityTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Probability = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateFC = table.Column<double>(type: "float", nullable: true),
                    ReasonBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reseller = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResellerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostingOpportunity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HourCostType",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourCostType", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "ImportNotification",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Result = table.Column<short>(type: "smallint", nullable: true),
                    ResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetriedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RetriedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportNotification", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ImportNotificationDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashflowImportNotification = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashflowTransactionFeed = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseCode = table.Column<short>(type: "smallint", nullable: false),
                    ResponseCodeArguments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportNotificationDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTerm",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deliverable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    ExecutionFromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTerm", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvolvedUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountIsSupplier = table.Column<bool>(type: "bit", nullable: true),
                    AccountLogoThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    InvolvedUserRole = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvolvedUserRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainContact = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonPhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonPictureThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvedUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvolvedUserRole",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTermID = table.Column<int>(type: "int", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvedUserRole", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_06 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_07 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_08 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_09 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyRemarks = table.Column<byte>(type: "tinyint", nullable: false),
                    CostPriceCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPriceNew = table.Column<double>(type: "float", nullable: true),
                    CostPriceStandard = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeBoolField_01 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_02 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_03 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_04 = table.Column<bool>(type: "bit", nullable: true),
                    FreeBoolField_05 = table.Column<bool>(type: "bit", nullable: true),
                    FreeDateField_01 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_02 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_03 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_04 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDateField_05 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeNumberField_01 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_02 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_03 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_04 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_05 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_06 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_07 = table.Column<double>(type: "float", nullable: true),
                    FreeNumberField_08 = table.Column<double>(type: "float", nullable: true),
                    FreeTextField_01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_05 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_06 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_07 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_08 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_09 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextField_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLCosts = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLCostsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLCostsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLRevenue = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLRevenueCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLRevenueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLStock = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLStockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLStockDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeight = table.Column<double>(type: "float", nullable: true),
                    IsBatchItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFractionAllowedItem = table.Column<bool>(type: "bit", nullable: true),
                    IsMakeItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsNewContract = table.Column<byte>(type: "tinyint", nullable: false),
                    IsOnDemandItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsPackageItem = table.Column<bool>(type: "bit", nullable: true),
                    IsPurchaseItem = table.Column<bool>(type: "bit", nullable: true),
                    IsRegistrationCodeItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsSalesItem = table.Column<bool>(type: "bit", nullable: true),
                    IsSerialItem = table.Column<bool>(type: "bit", nullable: true),
                    IsStockItem = table.Column<bool>(type: "bit", nullable: true),
                    IsSubcontractedItem = table.Column<bool>(type: "bit", nullable: true),
                    IsTaxableItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsTime = table.Column<byte>(type: "tinyint", nullable: false),
                    IsWebshopItem = table.Column<byte>(type: "tinyint", nullable: false),
                    ItemGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetWeight = table.Column<double>(type: "float", nullable: true),
                    NetWeightUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesVatCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesVatCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityLevel = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Stock = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemAssortment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAssortment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemAssortmentProperty",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    ItemAssortmentCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAssortmentProperty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroup",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    GLCosts = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLCostsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLCostsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLPurchaseAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLPurchaseAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLPurchaseAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLPurchasePriceDifference = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLPurchasePriceDifferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLPurchasePriceDifferenceDescr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLRevenue = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLRevenueCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLRevenueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLStock = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLStockCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLStockDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLStockVariance = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLStockVarianceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLStockVarianceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<byte>(type: "tinyint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemVersion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchQuantity = table.Column<double>(type: "float", nullable: true),
                    CalculatedCostPrice = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<byte>(type: "tinyint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadTime = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVersion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemWarehouse",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStock = table.Column<double>(type: "float", nullable: true),
                    DefaultStorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DefaultStorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultStorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemIsFractionAllowedItem = table.Column<bool>(type: "bit", nullable: true),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumStock = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedStockIn = table.Column<double>(type: "float", nullable: true),
                    PlannedStockOut = table.Column<double>(type: "float", nullable: true),
                    PlanningDetailsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectedStock = table.Column<double>(type: "float", nullable: true),
                    ReorderPoint = table.Column<double>(type: "float", nullable: true),
                    ReservedStock = table.Column<double>(type: "float", nullable: true),
                    SafetyStock = table.Column<double>(type: "float", nullable: true),
                    StorageLocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemWarehouse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemWarehousePlanningDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedQuantity = table.Column<double>(type: "float", nullable: false),
                    PlanningSourceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanningSourceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanningSourceLineNumber = table.Column<int>(type: "int", nullable: true),
                    PlanningSourceNumber = table.Column<int>(type: "int", nullable: true),
                    PlanningSourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanningType = table.Column<int>(type: "int", nullable: true),
                    PlanningTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemWarehousePlanningDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemWarehouseStorageLocation",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<double>(type: "float", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemWarehouseStorageLocation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobGroup",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobLevelFrom = table.Column<int>(type: "int", nullable: true),
                    JobLevelTo = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowVariableCurrency = table.Column<bool>(type: "bit", nullable: true),
                    AllowVariableExchangeRate = table.Column<bool>(type: "bit", nullable: true),
                    AllowVAT = table.Column<bool>(type: "bit", nullable: true),
                    AutoSave = table.Column<bool>(type: "bit", nullable: true),
                    Bank = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountBICCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountIBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountIncludingMask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountUseSEPA = table.Column<bool>(type: "bit", nullable: true),
                    BankAccountUseSepaDirectDebit = table.Column<bool>(type: "bit", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountType = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentInTransitAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentServiceAccountIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentServiceProvider = table.Column<int>(type: "int", nullable: true),
                    PaymentServiceProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JournalStatusList",
                columns: table => new
                {
                    Journal = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalType = table.Column<int>(type: "int", nullable: false),
                    JournalTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalStatusList", x => new { x.Year, x.Period, x.Journal });
                });

            migrationBuilder.CreateTable(
                name: "Layout",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveBuildUpRegistration",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    LeaveType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBuildUpRegistration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRegistration",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    HoursFirstDay = table.Column<double>(type: "float", nullable: true),
                    HoursLastDay = table.Column<double>(type: "float", nullable: true),
                    LeaveType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRegistration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mailbox",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForDivision = table.Column<int>(type: "int", nullable: true),
                    ForDivisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailboxName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publish = table.Column<byte>(type: "tinyint", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mailbox", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MailMessageAttachment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AttachmentFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    MailMessageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipientAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SenderAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessageAttachment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MailMessagesReceived",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bank = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForDivision = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<short>(type: "smallint", nullable: true),
                    OriginalMessage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginalMessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RecipientAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecipientDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    RecipientMailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientMailboxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientMailboxID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecipientStatus = table.Column<short>(type: "smallint", nullable: true),
                    RecipientStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SenderDateSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    SenderIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMailboxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMailboxID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SynchronizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessagesReceived", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MailMessagesSent",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bank = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForDivision = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<short>(type: "smallint", nullable: true),
                    OriginalMessage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginalMessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RecipientAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecipientDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    RecipientMailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientMailboxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientMailboxID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecipientStatus = table.Column<short>(type: "smallint", nullable: true),
                    RecipientStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SenderDateSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    SenderIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMailboxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMailboxID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SynchronizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessagesSent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingSetting",
                columns: table => new
                {
                    Division = table.Column<int>(type: "int", nullable: false),
                    InventoryMainMethod = table.Column<int>(type: "int", nullable: false),
                    InventorySubMethod = table.Column<int>(type: "int", nullable: false),
                    NegativeStockIsAllowed = table.Column<byte>(type: "tinyint", nullable: false),
                    SerialNumbersAreMandatory = table.Column<byte>(type: "tinyint", nullable: false),
                    ShowBackflushMaterials = table.Column<byte>(type: "tinyint", nullable: false),
                    ShowSubOrderMaterials = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingSetting", x => x.Division);
                });

            migrationBuilder.CreateTable(
                name: "MaterialIssue",
                columns: table => new
                {
                    StockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftStockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasReversibleQuantity = table.Column<bool>(type: "bit", nullable: false),
                    IsBackflush = table.Column<byte>(type: "tinyint", nullable: true),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsIssueFromChild = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RelatedStockTransaction = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderMaterialPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialIssue", x => x.StockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialReversal",
                columns: table => new
                {
                    ReversalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBackflush = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderMaterialPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReversal", x => x.ReversalStockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Me",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentDivision = table.Column<int>(type: "int", nullable: false),
                    DivisionCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DivisionCustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionCustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legislation = table.Column<long>(type: "bigint", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerUtcOffset = table.Column<double>(type: "float", nullable: false),
                    ThumbnailPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThumbnailPictureFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Me", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "OfficialReturn",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<short>(type: "smallint", nullable: true),
                    IsCorrection = table.Column<byte>(type: "tinyint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<short>(type: "smallint", nullable: true),
                    PresentationData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresentationFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PresentationFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialReturn", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalanceAfterEntry",
                columns: table => new
                {
                    Division = table.Column<int>(type: "int", nullable: false),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingYear = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    BalanceSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalanceAfterEntry", x => new { x.Division, x.ReportingYear, x.GLAccount });
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalancePreviousYearAfterEntry",
                columns: table => new
                {
                    Division = table.Column<int>(type: "int", nullable: false),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingYear = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    BalanceSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalancePreviousYearAfterEntry", x => new { x.Division, x.ReportingYear, x.GLAccount });
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalancePreviousYearProcessed",
                columns: table => new
                {
                    Division = table.Column<int>(type: "int", nullable: false),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingYear = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    BalanceSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalancePreviousYearProcessed", x => new { x.Division, x.ReportingYear, x.GLAccount });
                });

            migrationBuilder.CreateTable(
                name: "OpeningBalanceProcessed",
                columns: table => new
                {
                    Division = table.Column<int>(type: "int", nullable: false),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingYear = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    BalanceSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningBalanceProcessed", x => new { x.Division, x.ReportingYear, x.GLAccount });
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    HasSuppliers = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Searchcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OperationResource",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttendedPercentage = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EfficiencyPercentage = table.Column<double>(type: "float", nullable: true),
                    IsPrimary = table.Column<byte>(type: "tinyint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseLeadDays = table.Column<int>(type: "int", nullable: true),
                    PurchaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseVATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Run = table.Column<double>(type: "float", nullable: true),
                    RunMethod = table.Column<int>(type: "int", nullable: true),
                    Setup = table.Column<double>(type: "float", nullable: true),
                    SetupUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Workcenter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationResource", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Accountant = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<short>(type: "smallint", nullable: true),
                    ChannelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    LeadSource = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeadSourceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityDepartmentCode = table.Column<short>(type: "smallint", nullable: true),
                    OpportunityDepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityStage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityStageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpportunityStatus = table.Column<int>(type: "int", nullable: true),
                    OpportunityType = table.Column<short>(type: "smallint", nullable: true),
                    OpportunityTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Probability = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateFC = table.Column<double>(type: "float", nullable: true),
                    ReasonCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reseller = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResellerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityContact",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountIsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    AccountIsSupplier = table.Column<bool>(type: "bit", nullable: true),
                    AccountMainContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressStreetNumberSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowMailing = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthNamePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    IdentificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentificationDocument = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdentificationUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnonymised = table.Column<byte>(type: "tinyint", nullable: false),
                    IsMailingExcluded = table.Column<bool>(type: "bit", nullable: true),
                    IsMainContact = table.Column<bool>(type: "bit", nullable: true),
                    JobTitleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerNamePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityContact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OutstandingInvoicesOverview",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OutstandingPayableInvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    OutstandingPayableInvoiceCount = table.Column<double>(type: "float", nullable: false),
                    OutstandingReceivableInvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    OutstandingReceivableInvoiceCount = table.Column<double>(type: "float", nullable: false),
                    OverduePayableInvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    OverduePayableInvoiceCount = table.Column<double>(type: "float", nullable: false),
                    OverdueReceivableInvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    OverdueReceivableInvoiceCount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstandingInvoicesOverview", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "PayablesList",
                columns: table => new
                {
                    HID = table.Column<long>(type: "bigint", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AmountInTransit = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryNumber = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayablesList", x => x.HID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountBankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountBankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountDiscountDC = table.Column<double>(type: "float", nullable: false),
                    AmountDiscountFC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    BankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashflowTransactionBatchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndPeriod = table.Column<short>(type: "smallint", nullable: true),
                    EndYear = table.Column<short>(type: "smallint", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    IsBatchBooking = table.Column<byte>(type: "tinyint", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentBatchNumber = table.Column<int>(type: "int", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDays = table.Column<int>(type: "int", nullable: true),
                    PaymentDaysDiscount = table.Column<int>(type: "int", nullable: true),
                    PaymentDiscountPercentage = table.Column<double>(type: "float", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentSelected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentSelector = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentSelectorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateFC = table.Column<double>(type: "float", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    TransactionAmountDC = table.Column<double>(type: "float", nullable: false),
                    TransactionAmountFC = table.Column<double>(type: "float", nullable: false),
                    TransactionDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionEntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionIsReversal = table.Column<bool>(type: "bit", nullable: false),
                    TransactionReportingPeriod = table.Column<short>(type: "smallint", nullable: true),
                    TransactionReportingYear = table.Column<short>(type: "smallint", nullable: true),
                    TransactionStatus = table.Column<short>(type: "smallint", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCondition",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditManagementScenario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditManagementScenarioCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditManagementScenarioDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountCalculation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPaymentDays = table.Column<int>(type: "int", nullable: true),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDays = table.Column<int>(type: "int", nullable: true),
                    PaymentDiscountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentEndOfMonths = table.Column<int>(type: "int", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    VATCalculation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCondition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PreferredMailbox",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForDivision = table.Column<int>(type: "int", nullable: true),
                    IsScanServiceMailbox = table.Column<bool>(type: "bit", nullable: false),
                    Mailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredMailbox", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DivisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entity = table.Column<short>(type: "smallint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductionArea",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<byte>(type: "tinyint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionArea", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProfitLossOverview",
                columns: table => new
                {
                    CurrentYear = table.Column<int>(type: "int", nullable: false),
                    CostsCurrentPeriod = table.Column<double>(type: "float", nullable: false),
                    CostsCurrentYear = table.Column<double>(type: "float", nullable: false),
                    CostsPreviousYear = table.Column<double>(type: "float", nullable: false),
                    CostsPreviousYearPeriod = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPeriod = table.Column<int>(type: "int", nullable: false),
                    PreviousYear = table.Column<int>(type: "int", nullable: false),
                    PreviousYearPeriod = table.Column<int>(type: "int", nullable: false),
                    ResultCurrentPeriod = table.Column<double>(type: "float", nullable: false),
                    ResultCurrentYear = table.Column<double>(type: "float", nullable: false),
                    ResultPreviousYear = table.Column<double>(type: "float", nullable: false),
                    ResultPreviousYearPeriod = table.Column<double>(type: "float", nullable: false),
                    RevenueCurrentPeriod = table.Column<double>(type: "float", nullable: false),
                    RevenueCurrentYear = table.Column<double>(type: "float", nullable: false),
                    RevenuePreviousYear = table.Column<double>(type: "float", nullable: false),
                    RevenuePreviousYearPeriod = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfitLossOverview", x => x.CurrentYear);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowAdditionalInvoicing = table.Column<bool>(type: "bit", nullable: true),
                    BlockEntry = table.Column<bool>(type: "bit", nullable: true),
                    BlockRebilling = table.Column<bool>(type: "bit", nullable: true),
                    BudgetedAmount = table.Column<double>(type: "float", nullable: true),
                    BudgetedCosts = table.Column<double>(type: "float", nullable: true),
                    BudgetedRevenue = table.Column<double>(type: "float", nullable: true),
                    BudgetOverrunHours = table.Column<byte>(type: "tinyint", nullable: true),
                    BudgetType = table.Column<short>(type: "smallint", nullable: true),
                    BudgetTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostsAmountFC = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPOnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FixedPriceItem = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FixedPriceItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAsQuoted = table.Column<bool>(type: "bit", nullable: false),
                    Manager = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManagerFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkupPercentage = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrepaidItem = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrepaidItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrepaidType = table.Column<short>(type: "smallint", nullable: true),
                    PrepaidTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesTimeQuantity = table.Column<double>(type: "float", nullable: true),
                    SourceQuotation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeQuantityToAlert = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseBillingMilestones = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectBudgetType",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBudgetType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectHourBudget",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectHourBudget", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlanning",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGTStatus = table.Column<short>(type: "smallint", nullable: true),
                    CommunicationErrorStatus = table.Column<short>(type: "smallint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    HourType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HourTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBrokenRecurrence = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverAllocate = table.Column<bool>(type: "bit", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPlanningRecurring = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectWBS = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectWBSDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlanning", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPlanningRecurring",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGTStatus = table.Column<short>(type: "smallint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayOrThe = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateOrAfter = table.Column<int>(type: "int", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    HourType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HourTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthPatternDay = table.Column<byte>(type: "tinyint", nullable: true),
                    MonthPatternOrdinalDay = table.Column<byte>(type: "tinyint", nullable: true),
                    MonthPatternOrdinalWeek = table.Column<byte>(type: "tinyint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfRecurrences = table.Column<short>(type: "smallint", nullable: true),
                    OverAllocate = table.Column<bool>(type: "bit", nullable: true),
                    PatternFrequency = table.Column<byte>(type: "tinyint", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPlanningRecurringType = table.Column<byte>(type: "tinyint", nullable: true),
                    ProjectWBS = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectWBSDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    WeekPatternDay = table.Column<byte>(type: "tinyint", nullable: true),
                    WeekPatternFriday = table.Column<bool>(type: "bit", nullable: true),
                    WeekPatternMonday = table.Column<bool>(type: "bit", nullable: true),
                    WeekPatternSaturday = table.Column<bool>(type: "bit", nullable: true),
                    WeekPatternSunday = table.Column<bool>(type: "bit", nullable: true),
                    WeekPatternThursday = table.Column<bool>(type: "bit", nullable: true),
                    WeekPatternTuesday = table.Column<bool>(type: "bit", nullable: true),
                    WeekPatternWednesday = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlanningRecurring", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRestrictionEmployee",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRestrictionEmployee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRestrictionItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemIsTime = table.Column<byte>(type: "tinyint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRestrictionItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRestrictionRebilling",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostTypeRebill = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostTypeRebillCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostTypeRebillDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRestrictionRebilling", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEntry",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    BatchNumber = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExternalLinkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalLinkReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GAccountAmountFC = table.Column<double>(type: "float", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessNumber = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    ReportingPeriod = table.Column<short>(type: "smallint", nullable: true),
                    ReportingYear = table.Column<short>(type: "smallint", nullable: true),
                    Reversal = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEntry", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEntryLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    Asset = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatDeliveryTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransactionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransportMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticalNetWeight = table.Column<double>(type: "float", nullable: true),
                    StatisticalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticalQuantity = table.Column<double>(type: "float", nullable: true),
                    StatisticalValue = table.Column<double>(type: "float", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrackingNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrackingNumberDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    VATAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATBaseAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATBaseAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNonDeductiblePercentage = table.Column<double>(type: "float", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true),
                    WithholdingAmountDC = table.Column<double>(type: "float", nullable: true),
                    WithholdingTax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEntryLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoice",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    FinancialPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinancialYear = table.Column<short>(type: "smallint", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Supplier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    VATAmount = table.Column<double>(type: "float", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetPrice = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseOrderLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    QuantityInDefaultUnits = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    VATAmount = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropShipment = table.Column<bool>(type: "bit", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseAgent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseAgentFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiptStatus = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShippingMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: true),
                    Supplier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATAmount = table.Column<double>(type: "float", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Expense = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<double>(type: "float", nullable: true),
                    InvoicedQuantity = table.Column<double>(type: "float", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDivisable = table.Column<bool>(type: "bit", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetPrice = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectedStock = table.Column<double>(type: "float", nullable: true),
                    PurchaseOrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    QuantityInPurchaseUnits = table.Column<double>(type: "float", nullable: true),
                    Rebill = table.Column<bool>(type: "bit", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedQuantity = table.Column<double>(type: "float", nullable: true),
                    SalesOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderLineNumber = table.Column<int>(type: "int", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    SupplierItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    VATAmount = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    QuotationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountDiscount = table.Column<double>(type: "float", nullable: false),
                    AmountDiscountExclVat = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccountContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryAccountContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAccountContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceAccountContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAccountContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderAccountContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuotationNumber = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingMethodDescription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.QuotationID);
                });

            migrationBuilder.CreateTable(
                name: "QuotationLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    NetPrice = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    QuotationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuotationNumber = table.Column<int>(type: "int", nullable: false),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true),
                    VersionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReasonCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<byte>(type: "tinyint", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Receivable",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountBankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountBankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountContact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountDiscountDC = table.Column<double>(type: "float", nullable: false),
                    AmountDiscountFC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    BankAccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashflowTransactionBatchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectDebitMandate = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectDebitMandateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectDebitMandatePaymentType = table.Column<short>(type: "smallint", nullable: true),
                    DirectDebitMandateReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectDebitMandateType = table.Column<short>(type: "smallint", nullable: true),
                    DiscountDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndPeriod = table.Column<short>(type: "smallint", nullable: true),
                    EndToEndID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndYear = table.Column<short>(type: "smallint", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    IsBatchBooking = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFullyPaid = table.Column<bool>(type: "bit", nullable: false),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDays = table.Column<int>(type: "int", nullable: true),
                    PaymentDaysDiscount = table.Column<int>(type: "int", nullable: true),
                    PaymentDiscountPercentage = table.Column<double>(type: "float", nullable: true),
                    PaymentInformationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateFC = table.Column<double>(type: "float", nullable: true),
                    ReceivableBatchNumber = table.Column<int>(type: "int", nullable: true),
                    ReceivableSelected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivableSelector = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceivableSelectorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    TransactionAmountDC = table.Column<double>(type: "float", nullable: false),
                    TransactionAmountFC = table.Column<double>(type: "float", nullable: false),
                    TransactionDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionEntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionIsReversal = table.Column<bool>(type: "bit", nullable: false),
                    TransactionReportingPeriod = table.Column<short>(type: "smallint", nullable: true),
                    TransactionReportingYear = table.Column<short>(type: "smallint", nullable: true),
                    TransactionStatus = table.Column<short>(type: "smallint", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReceivablesList",
                columns: table => new
                {
                    HID = table.Column<long>(type: "bigint", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AmountInTransit = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryNumber = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivablesList", x => x.HID);
                });

            migrationBuilder.CreateTable(
                name: "RecentCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountApproved = table.Column<double>(type: "float", nullable: false),
                    AmountDraft = table.Column<double>(type: "float", nullable: false),
                    AmountRejected = table.Column<double>(type: "float", nullable: false),
                    AmountSubmitted = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Expense = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuantityApproved = table.Column<double>(type: "float", nullable: false),
                    QuantityDraft = table.Column<double>(type: "float", nullable: false),
                    QuantityRejected = table.Column<double>(type: "float", nullable: false),
                    QuantitySubmitted = table.Column<double>(type: "float", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentCost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecentHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HoursApproved = table.Column<double>(type: "float", nullable: false),
                    HoursApprovedBillable = table.Column<double>(type: "float", nullable: false),
                    HoursDraft = table.Column<double>(type: "float", nullable: false),
                    HoursDraftBillable = table.Column<double>(type: "float", nullable: false),
                    HoursRejected = table.Column<double>(type: "float", nullable: false),
                    HoursRejectedBillable = table.Column<double>(type: "float", nullable: false),
                    HoursSubmitted = table.Column<double>(type: "float", nullable: false),
                    HoursSubmittedBillable = table.Column<double>(type: "float", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WeekNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentHour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecentTimeTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCount = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<short>(type: "smallint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HourStatus = table.Column<short>(type: "smallint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsOperationFinished = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborHours = table.Column<double>(type: "float", nullable: true),
                    MachineHours = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentComplete = table.Column<double>(type: "float", nullable: true),
                    ProducedQuantity = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderCount = table.Column<int>(type: "int", nullable: true),
                    SalesOrderLineNumber = table.Column<int>(type: "int", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrderPlannedQuantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrderRoutingStepPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderRoutingStepPlanAttendedPercentage = table.Column<double>(type: "float", nullable: true),
                    ShopOrderRoutingStepPlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Workcenter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkcenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentTimeTransaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReportingBalance",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    AmountCredit = table.Column<double>(type: "float", nullable: true),
                    AmountDebit = table.Column<double>(type: "float", nullable: true),
                    BalanceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingPeriod = table.Column<int>(type: "int", nullable: true),
                    ReportingYear = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportingBalance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RequestAttachment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    Request = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAttachment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Return",
                columns: table => new
                {
                    DocumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentViewUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollDeclarationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<int>(type: "int", nullable: false),
                    PeriodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.DocumentID);
                });

            migrationBuilder.CreateTable(
                name: "RevenueList",
                columns: table => new
                {
                    Period = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueList", x => new { x.Year, x.Period });
                });

            migrationBuilder.CreateTable(
                name: "SalesEntry",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    BatchNumber = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExternalLinkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalLinkReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GAccountAmountFC = table.Column<double>(type: "float", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    IsExtraDuty = table.Column<bool>(type: "bit", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessNumber = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    ReportingPeriod = table.Column<short>(type: "smallint", nullable: true),
                    ReportingYear = table.Column<short>(type: "smallint", nullable: true),
                    Reversal = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    WithholdingTaxAmountDC = table.Column<double>(type: "float", nullable: true),
                    WithholdingTaxBaseAmount = table.Column<double>(type: "float", nullable: true),
                    WithholdingTaxPercentage = table.Column<double>(type: "float", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesEntry", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "SalesEntryLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    Asset = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraDutyAmountFC = table.Column<double>(type: "float", nullable: true),
                    ExtraDutyPercentage = table.Column<double>(type: "float", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatDeliveryTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransactionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStatTransportMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticalNetWeight = table.Column<double>(type: "float", nullable: true),
                    StatisticalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticalQuantity = table.Column<double>(type: "float", nullable: true),
                    StatisticalValue = table.Column<double>(type: "float", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxSchedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrackingNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrackingNumberDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    VATAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATBaseAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATBaseAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesEntryLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice",
                columns: table => new
                {
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountDiscount = table.Column<double>(type: "float", nullable: true),
                    AmountDiscountExclVat = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    AmountFCExclVat = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliverToAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliverToContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliverToContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    DiscountType = table.Column<short>(type: "smallint", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraDutyAmountFC = table.Column<double>(type: "float", nullable: true),
                    GAccountAmountFC = table.Column<double>(type: "float", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    InvoiceTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceToContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceToContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExtraDuty = table.Column<bool>(type: "bit", nullable: true),
                    Journal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedByContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedByContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salesperson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalespersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarterSalesInvoiceStatus = table.Column<short>(type: "smallint", nullable: true),
                    StarterSalesInvoiceStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxSchedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxScheduleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WithholdingTaxAmountFC = table.Column<double>(type: "float", nullable: true),
                    WithholdingTaxBaseAmount = table.Column<double>(type: "float", nullable: true),
                    WithholdingTaxPercentage = table.Column<double>(type: "float", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraDutyAmountFC = table.Column<double>(type: "float", nullable: true),
                    ExtraDutyPercentage = table.Column<double>(type: "float", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    NetPrice = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricelist = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PricelistDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectWBS = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectWBSDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SalesOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesOrderLineNumber = table.Column<int>(type: "int", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxSchedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxScheduleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    VATAmountDC = table.Column<double>(type: "float", nullable: true),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesItemPrice",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultItemUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfItemsPerUnit = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItemPrice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountDiscount = table.Column<double>(type: "float", nullable: true),
                    AmountDiscountExclVat = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    AmountFCExclVat = table.Column<double>(type: "float", nullable: true),
                    ApprovalStatus = table.Column<short>(type: "smallint", nullable: false),
                    ApprovalStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Approver = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApproverFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliverToContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliverToContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryStatus = table.Column<short>(type: "smallint", nullable: true),
                    DeliveryStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceStatus = table.Column<short>(type: "smallint", nullable: true),
                    InvoiceStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceToContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceToContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedByContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedByContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salesperson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalespersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingMethod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxSchedule = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxScheduleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPriceFC = table.Column<double>(type: "float", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemVersion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemVersionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Margin = table.Column<double>(type: "float", nullable: true),
                    NetPrice = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Pricelist = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PricelistDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseOrderLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseOrderLineNumber = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    QuantityDelivered = table.Column<double>(type: "float", nullable: true),
                    QuantityInvoiced = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    UseDropShipment = table.Column<byte>(type: "tinyint", nullable: false),
                    VATAmount = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesPriceListDetail",
                columns: table => new
                {
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePrice = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BasePriceAmount = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryMethod = table.Column<short>(type: "smallint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewPrice = table.Column<double>(type: "float", nullable: true),
                    NumberOfItemsPerUnit = table.Column<double>(type: "float", nullable: true),
                    PriceListCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPriceListDetail", x => new { x.ID, x.Account });
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<byte>(type: "tinyint", nullable: true),
                    AverageHours = table.Column<double>(type: "float", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmploymentHID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    LeaveHoursCompensation = table.Column<double>(type: "float", nullable: true),
                    Main = table.Column<byte>(type: "tinyint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentParttimeFactor = table.Column<double>(type: "float", nullable: true),
                    ScheduleType = table.Column<int>(type: "int", nullable: true),
                    ScheduleTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartWeek = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SerialNumber",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Available = table.Column<byte>(type: "tinyint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlocked = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequest",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedToFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextAction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingRatesURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrder",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CADDrawingURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsInPlanning = table.Column<byte>(type: "tinyint", nullable: false),
                    IsOnHold = table.Column<byte>(type: "tinyint", nullable: false),
                    IsReleased = table.Column<byte>(type: "tinyint", nullable: false),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemVersion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemVersionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedQuantity = table.Column<double>(type: "float", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProducedQuantity = table.Column<double>(type: "float", nullable: true),
                    ProductionLeadDays = table.Column<int>(type: "int", nullable: false),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadyToShipQuantity = table.Column<double>(type: "float", nullable: true),
                    SalesOrderLineCount = table.Column<int>(type: "int", nullable: false),
                    ShopOrderByProductPlanBackflushCount = table.Column<int>(type: "int", nullable: false),
                    ShopOrderByProductPlanCount = table.Column<int>(type: "int", nullable: false),
                    ShopOrderMain = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderMainNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrderMaterialPlanBackflushCount = table.Column<int>(type: "int", nullable: false),
                    ShopOrderMaterialPlanCount = table.Column<int>(type: "int", nullable: false),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrderNumberString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrderParent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderParentNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrderRoutingStepPlanCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    SubShopOrderCount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderMaterialPlan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Backflush = table.Column<byte>(type: "tinyint", nullable: true),
                    CalculatorType = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailDrawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedAmountFC = table.Column<double>(type: "float", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedPriceFC = table.Column<double>(type: "float", nullable: true),
                    PlannedQuantity = table.Column<double>(type: "float", nullable: true),
                    PlannedQuantityFactor = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderMaterialPlan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderMaterialPlanDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Backflush = table.Column<byte>(type: "tinyint", nullable: true),
                    CalculatorType = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailDrawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    IssuedQuantity = table.Column<double>(type: "float", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedAmountFC = table.Column<double>(type: "float", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedIn = table.Column<double>(type: "float", nullable: true),
                    PlannedOut = table.Column<double>(type: "float", nullable: true),
                    PlannedPriceFC = table.Column<double>(type: "float", nullable: true),
                    PlannedQuantity = table.Column<double>(type: "float", nullable: true),
                    PlannedQuantityFactor = table.Column<double>(type: "float", nullable: true),
                    RemainingQuantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<double>(type: "float", nullable: true),
                    SubShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderMaterialPlanDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderReceipt",
                columns: table => new
                {
                    StockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftStockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasReversibleQuantity = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsIssueToParent = table.Column<bool>(type: "bit", nullable: false),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RelatedStockTransaction = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderReceipt", x => x.StockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderReversal",
                columns: table => new
                {
                    ReversalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderReversal", x => x.ReversalStockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderRoutingStepPlan",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendedPercentage = table.Column<double>(type: "float", nullable: true),
                    Backflush = table.Column<byte>(type: "tinyint", nullable: true),
                    CostPerItem = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EfficiencyPercentage = table.Column<double>(type: "float", nullable: true),
                    FactorType = table.Column<int>(type: "int", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationResource = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedRunHours = table.Column<double>(type: "float", nullable: true),
                    PlannedSetupHours = table.Column<double>(type: "float", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedTotalHours = table.Column<double>(type: "float", nullable: true),
                    PurchaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseUnitFactor = table.Column<double>(type: "float", nullable: true),
                    PurchaseUnitPriceFC = table.Column<double>(type: "float", nullable: true),
                    PurchaseUnitQuantity = table.Column<double>(type: "float", nullable: true),
                    RoutingStepType = table.Column<int>(type: "int", nullable: true),
                    Run = table.Column<double>(type: "float", nullable: true),
                    RunMethod = table.Column<int>(type: "int", nullable: true),
                    RunMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Setup = table.Column<double>(type: "float", nullable: true),
                    SetupUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubcontractedLeadDays = table.Column<int>(type: "int", nullable: true),
                    TotalCostDC = table.Column<double>(type: "float", nullable: true),
                    Workcenter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkcenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderRoutingStepPlan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SolutionLink",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    ExternalSolutionCode = table.Column<int>(type: "int", nullable: true),
                    ExternalSolutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalSolutionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalSolutionDivision = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherExternalSolutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionLink", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StageForDeliveryReceipt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasReversibleQuantity = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RelatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageForDeliveryReceipt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageForDeliveryReversal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: false),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: false),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    RelatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageForDeliveryReversal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StartedTimedTimeTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCount = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<short>(type: "smallint", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsFractionAllowedItem = table.Column<bool>(type: "bit", nullable: true),
                    IsOperationFinished = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborHours = table.Column<double>(type: "float", nullable: true),
                    MachineHours = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentComplete = table.Column<double>(type: "float", nullable: true),
                    ProducedQuantity = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderCount = table.Column<int>(type: "int", nullable: true),
                    SalesOrderLineNumber = table.Column<int>(type: "int", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrderPlannedQuantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrderRoutingStepPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderRoutingStepPlanAttendedPercentage = table.Column<double>(type: "float", nullable: true),
                    ShopOrderRoutingStepPlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Workcenter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkcenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartedTimedTimeTransaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockBatchNumber",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchNumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DraftStockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlocked = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDraft = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCountLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockTransactionType = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBatchNumber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockCount",
                columns: table => new
                {
                    StockCountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffsetGLInventory = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OffsetGLInventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffsetGLInventoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StockCountDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StockCountNumber = table.Column<int>(type: "int", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCount", x => x.StockCountID);
                });

            migrationBuilder.CreateTable(
                name: "StockCountLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostPrice = table.Column<double>(type: "float", nullable: true),
                    CountedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCostPrice = table.Column<double>(type: "float", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDivisable = table.Column<bool>(type: "bit", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityDifference = table.Column<double>(type: "float", nullable: true),
                    QuantityInStock = table.Column<double>(type: "float", nullable: true),
                    QuantityNew = table.Column<double>(type: "float", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StockCountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockKeepingUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCountLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockSerialNumber",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DraftStockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlocked = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDraft = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StockCountLine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockTransactionType = table.Column<int>(type: "int", nullable: true),
                    StorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSerialNumber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocation",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Main = table.Column<byte>(type: "tinyint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubOrderReceipt",
                columns: table => new
                {
                    ShopOrderReceiptStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftStockTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasReversibleQuantity = table.Column<bool>(type: "bit", nullable: false),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialIssueStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentShopOrderMaterialPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SubShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOrderReceipt", x => x.ShopOrderReceiptStockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "SubOrderReversal",
                columns: table => new
                {
                    MaterialReversalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBatch = table.Column<byte>(type: "tinyint", nullable: true),
                    IsFractionAllowedItem = table.Column<byte>(type: "tinyint", nullable: true),
                    IsSerial = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalMaterialIssueStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginalShopOrderReceiptStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ShopOrderReversalStockTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warehouse = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOrderReversal", x => x.MaterialReversalStockTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockEntry = table.Column<bool>(type: "bit", nullable: true),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Classification = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceDay = table.Column<byte>(type: "tinyint", nullable: true),
                    InvoicedTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceToContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceToContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicingStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    OrderedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedByContactPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderedByContactPersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    ReasonCancelled = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonCancelledCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonCancelledDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    LineType = table.Column<short>(type: "smallint", nullable: true),
                    LineTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetPrice = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    VATAmountFC = table.Column<double>(type: "float", nullable: true),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionLineType",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionLineType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionReasonCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionReasonCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionRestrictionEmployee",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionRestrictionEmployee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionRestrictionItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionRestrictionItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CopyRemarks = table.Column<byte>(type: "tinyint", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOriginDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DropShipment = table.Column<byte>(type: "tinyint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainSupplier = table.Column<bool>(type: "bit", nullable: true),
                    MinimumQuantity = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseLeadTime = table.Column<int>(type: "int", nullable: true),
                    PurchasePrice = table.Column<double>(type: "float", nullable: true),
                    PurchaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseUnitFactor = table.Column<double>(type: "float", nullable: true),
                    PurchaseVATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseVATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contact = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomTaskType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HID = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpportunityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskType = table.Column<int>(type: "int", nullable: true),
                    TaskTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionTermID = table.Column<int>(type: "int", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaxEmploymentEndFlexCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxEmploymentEndFlexCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingAccountDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingAccountDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingActivitiesAndExpense",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingActivitiesAndExpense", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingEntryAccount",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingEntryAccount", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingEntryProject",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingEntryProject", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingEntryRecentAccount",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastUsed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingEntryRecentAccount", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingEntryRecentActivitiesAndExpense",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateLastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingEntryRecentActivitiesAndExpense", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingEntryRecentHourCostType",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateLastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingEntryRecentHourCostType", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingEntryRecentProject",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateLastUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingEntryRecentProject", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingItemDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFractionAllowedItem = table.Column<bool>(type: "bit", nullable: false),
                    IsSalesItem = table.Column<bool>(type: "bit", nullable: false),
                    SalesCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingItemDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeAndBillingProjectDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAndBillingProjectDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeCorrection",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCorrection", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimedTimeTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOperationFinished = table.Column<byte>(type: "tinyint", nullable: true),
                    LaborHours = table.Column<double>(type: "float", nullable: true),
                    MachineHours = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OperationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentComplete = table.Column<double>(type: "float", nullable: true),
                    ProducedQuantity = table.Column<double>(type: "float", nullable: true),
                    ProductionArea = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductionAreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionAreaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrderNumber = table.Column<int>(type: "int", nullable: true),
                    ShopOrderRoutingStepPlan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShopOrderRoutingStepPlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopOrderRoutingStepPlanRemainingRunHours = table.Column<double>(type: "float", nullable: false),
                    ShopOrderRoutingStepPlanRemainingSetupHours = table.Column<double>(type: "float", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Workcenter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkcenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimedTimeTransaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    AmountFC = table.Column<double>(type: "float", nullable: true),
                    Attachment = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    DivisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ErrorText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourStatus = table.Column<short>(type: "smallint", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDivisable = table.Column<bool>(type: "bit", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    PriceFC = table.Column<double>(type: "float", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SkipValidation = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionNumber = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTransaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingBalanceFC = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExternalLinkDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalLinkReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinancialYear = table.Column<short>(type: "smallint", nullable: true),
                    IsExtraDuty = table.Column<bool>(type: "bit", nullable: true),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningBalanceFC = table.Column<double>(type: "float", nullable: true),
                    PaymentConditionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDC = table.Column<double>(type: "float", nullable: false),
                    AmountFC = table.Column<double>(type: "float", nullable: false),
                    AmountVATBaseFC = table.Column<double>(type: "float", nullable: true),
                    AmountVATFC = table.Column<double>(type: "float", nullable: true),
                    Asset = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostUnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryNumber = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    ExtraDutyAmountFC = table.Column<double>(type: "float", nullable: true),
                    ExtraDutyPercentage = table.Column<double>(type: "float", nullable: true),
                    FinancialPeriod = table.Column<short>(type: "smallint", nullable: true),
                    FinancialYear = table.Column<short>(type: "smallint", nullable: true),
                    GLAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLAccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    LineType = table.Column<short>(type: "smallint", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffsetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    PaymentDiscountAmount = table.Column<double>(type: "float", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    Subscription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumberDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATPercentage = table.Column<double>(type: "float", nullable: true),
                    VATType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YourRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Main = table.Column<byte>(type: "tinyint", nullable: true),
                    TimeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasRegisteredForTwoStepVerification = table.Column<bool>(type: "bit", nullable: false),
                    HasTwoStepVerification = table.Column<bool>(type: "bit", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDivision = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypesList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    RoleLevel = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesPerDivision",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    RoleLevel = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesPerDivision", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VATCode",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculationBasis = table.Column<byte>(type: "tinyint", nullable: true),
                    Charged = table.Column<bool>(type: "bit", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EUSalesListing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLDiscountPurchase = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLDiscountPurchaseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLDiscountPurchaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLDiscountSales = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLDiscountSalesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLDiscountSalesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLToClaim = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLToClaimCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLToClaimDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLToPay = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLToPayCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLToPayDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntraStat = table.Column<bool>(type: "bit", nullable: true),
                    IntrastatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true),
                    LegalText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    TaxReturnType = table.Column<short>(type: "smallint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatDocType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatMargin = table.Column<byte>(type: "tinyint", nullable: false),
                    VATPartialRatio = table.Column<short>(type: "smallint", nullable: true),
                    VATTransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VATCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VatPercentage",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    VATCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatPercentage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultStorageLocation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DefaultStorageLocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultStorageLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<byte>(type: "tinyint", nullable: false),
                    ManagerUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseStorageLocations = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseTransfer",
                columns: table => new
                {
                    TransferID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransferNumber = table.Column<int>(type: "int", nullable: true),
                    WarehouseFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseFromCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseFromDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarehouseToCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseToDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseTransfer", x => x.TransferID);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseTransferLine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    StorageLocationFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationFromCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationFromDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageLocationToCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationToDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseTransferLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WebhookSubscription",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallbackURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookSubscription", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workcenter",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costcenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostcenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costunit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    GeneralBurdenRate = table.Column<double>(type: "float", nullable: true),
                    IsLaborBurdenPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    LaborBurdenRate = table.Column<double>(type: "float", nullable: true),
                    MachineBurdenRate = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionArea = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RunLaborRate = table.Column<double>(type: "float", nullable: true),
                    SearchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetupLaborRate = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workcenter", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsenceRegistration");

            migrationBuilder.DropTable(
                name: "AbsenceRegistrationTransaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AccountantInfo");

            migrationBuilder.DropTable(
                name: "AccountClass");

            migrationBuilder.DropTable(
                name: "AccountClassification");

            migrationBuilder.DropTable(
                name: "AccountClassificationName");

            migrationBuilder.DropTable(
                name: "AccountInvolvedAccount");

            migrationBuilder.DropTable(
                name: "AccountOwner");

            migrationBuilder.DropTable(
                name: "ActiveEmployment");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AddressState");

            migrationBuilder.DropTable(
                name: "AgingOverview");

            migrationBuilder.DropTable(
                name: "AgingPayablesList");

            migrationBuilder.DropTable(
                name: "AgingReceivablesList");

            migrationBuilder.DropTable(
                name: "AssemblyOrder");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetGroup");

            migrationBuilder.DropTable(
                name: "AvailableFeature");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "BankEntry");

            migrationBuilder.DropTable(
                name: "BankEntryLine");

            migrationBuilder.DropTable(
                name: "BatchNumber");

            migrationBuilder.DropTable(
                name: "BillOfMaterialMaterial");

            migrationBuilder.DropTable(
                name: "BillOfMaterialVersion");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "ByProductReceipt");

            migrationBuilder.DropTable(
                name: "ByProductReversal");

            migrationBuilder.DropTable(
                name: "CashEntry");

            migrationBuilder.DropTable(
                name: "CashEntryLine");

            migrationBuilder.DropTable(
                name: "CommunicationNote");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Costcenter");

            migrationBuilder.DropTable(
                name: "CostTransaction");

            migrationBuilder.DropTable(
                name: "Costunit");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DefaultMailbox");

            migrationBuilder.DropTable(
                name: "Deleted");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "DepreciationMethod");

            migrationBuilder.DropTable(
                name: "DirectDebitMandate");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "DivisionClass");

            migrationBuilder.DropTable(
                name: "DivisionClassName");

            migrationBuilder.DropTable(
                name: "DivisionClassValue");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "DocumentAttachment");

            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.DropTable(
                name: "DocumentFolder");

            migrationBuilder.DropTable(
                name: "DocumentsAttachment");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "DocumentTypeCategory");

            migrationBuilder.DropTable(
                name: "DocumentTypeFolder");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Employment");

            migrationBuilder.DropTable(
                name: "EmploymentContract");

            migrationBuilder.DropTable(
                name: "EmploymentContractFlexPhase");

            migrationBuilder.DropTable(
                name: "EmploymentEndReason");

            migrationBuilder.DropTable(
                name: "EmploymentInternalRate");

            migrationBuilder.DropTable(
                name: "EmploymentOrganization");

            migrationBuilder.DropTable(
                name: "EmploymentSalary");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ExchangeRate");

            migrationBuilder.DropTable(
                name: "FinancialPeriod");

            migrationBuilder.DropTable(
                name: "GeneralJournalEntry");

            migrationBuilder.DropTable(
                name: "GeneralJournalEntryLine");

            migrationBuilder.DropTable(
                name: "GLAccount");

            migrationBuilder.DropTable(
                name: "GLClassification");

            migrationBuilder.DropTable(
                name: "GLScheme");

            migrationBuilder.DropTable(
                name: "GLTransactionType");

            migrationBuilder.DropTable(
                name: "GoodsDelivery");

            migrationBuilder.DropTable(
                name: "GoodsDeliveryLine");

            migrationBuilder.DropTable(
                name: "GoodsReceipt");

            migrationBuilder.DropTable(
                name: "GoodsReceiptLine");

            migrationBuilder.DropTable(
                name: "HostingOpportunity");

            migrationBuilder.DropTable(
                name: "HourCostType");

            migrationBuilder.DropTable(
                name: "ImportNotification");

            migrationBuilder.DropTable(
                name: "ImportNotificationDetail");

            migrationBuilder.DropTable(
                name: "InvoiceTerm");

            migrationBuilder.DropTable(
                name: "InvolvedUser");

            migrationBuilder.DropTable(
                name: "InvolvedUserRole");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemAssortment");

            migrationBuilder.DropTable(
                name: "ItemAssortmentProperty");

            migrationBuilder.DropTable(
                name: "ItemGroup");

            migrationBuilder.DropTable(
                name: "ItemVersion");

            migrationBuilder.DropTable(
                name: "ItemWarehouse");

            migrationBuilder.DropTable(
                name: "ItemWarehousePlanningDetail");

            migrationBuilder.DropTable(
                name: "ItemWarehouseStorageLocation");

            migrationBuilder.DropTable(
                name: "JobGroup");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "JournalStatusList");

            migrationBuilder.DropTable(
                name: "Layout");

            migrationBuilder.DropTable(
                name: "LeaveBuildUpRegistration");

            migrationBuilder.DropTable(
                name: "LeaveRegistration");

            migrationBuilder.DropTable(
                name: "Mailbox");

            migrationBuilder.DropTable(
                name: "MailMessageAttachment");

            migrationBuilder.DropTable(
                name: "MailMessagesReceived");

            migrationBuilder.DropTable(
                name: "MailMessagesSent");

            migrationBuilder.DropTable(
                name: "ManufacturingSetting");

            migrationBuilder.DropTable(
                name: "MaterialIssue");

            migrationBuilder.DropTable(
                name: "MaterialReversal");

            migrationBuilder.DropTable(
                name: "Me");

            migrationBuilder.DropTable(
                name: "OfficialReturn");

            migrationBuilder.DropTable(
                name: "OpeningBalanceAfterEntry");

            migrationBuilder.DropTable(
                name: "OpeningBalancePreviousYearAfterEntry");

            migrationBuilder.DropTable(
                name: "OpeningBalancePreviousYearProcessed");

            migrationBuilder.DropTable(
                name: "OpeningBalanceProcessed");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "OperationResource");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "OpportunityContact");

            migrationBuilder.DropTable(
                name: "OutstandingInvoicesOverview");

            migrationBuilder.DropTable(
                name: "PayablesList");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PaymentCondition");

            migrationBuilder.DropTable(
                name: "PreferredMailbox");

            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropTable(
                name: "ProductionArea");

            migrationBuilder.DropTable(
                name: "ProfitLossOverview");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectBudgetType");

            migrationBuilder.DropTable(
                name: "ProjectHourBudget");

            migrationBuilder.DropTable(
                name: "ProjectPlanning");

            migrationBuilder.DropTable(
                name: "ProjectPlanningRecurring");

            migrationBuilder.DropTable(
                name: "ProjectRestrictionEmployee");

            migrationBuilder.DropTable(
                name: "ProjectRestrictionItem");

            migrationBuilder.DropTable(
                name: "ProjectRestrictionRebilling");

            migrationBuilder.DropTable(
                name: "PurchaseEntry");

            migrationBuilder.DropTable(
                name: "PurchaseEntryLine");

            migrationBuilder.DropTable(
                name: "PurchaseInvoice");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceLine");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "Quotation");

            migrationBuilder.DropTable(
                name: "QuotationLine");

            migrationBuilder.DropTable(
                name: "ReasonCode");

            migrationBuilder.DropTable(
                name: "Receivable");

            migrationBuilder.DropTable(
                name: "ReceivablesList");

            migrationBuilder.DropTable(
                name: "RecentCost");

            migrationBuilder.DropTable(
                name: "RecentHour");

            migrationBuilder.DropTable(
                name: "RecentTimeTransaction");

            migrationBuilder.DropTable(
                name: "ReportingBalance");

            migrationBuilder.DropTable(
                name: "RequestAttachment");

            migrationBuilder.DropTable(
                name: "Return");

            migrationBuilder.DropTable(
                name: "RevenueList");

            migrationBuilder.DropTable(
                name: "SalesEntry");

            migrationBuilder.DropTable(
                name: "SalesEntryLine");

            migrationBuilder.DropTable(
                name: "SalesInvoice");

            migrationBuilder.DropTable(
                name: "SalesInvoiceLine");

            migrationBuilder.DropTable(
                name: "SalesItemPrice");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "SalesOrderLine");

            migrationBuilder.DropTable(
                name: "SalesPriceListDetail");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "SerialNumber");

            migrationBuilder.DropTable(
                name: "ServiceRequest");

            migrationBuilder.DropTable(
                name: "ShippingMethod");

            migrationBuilder.DropTable(
                name: "ShopOrder");

            migrationBuilder.DropTable(
                name: "ShopOrderMaterialPlan");

            migrationBuilder.DropTable(
                name: "ShopOrderMaterialPlanDetail");

            migrationBuilder.DropTable(
                name: "ShopOrderReceipt");

            migrationBuilder.DropTable(
                name: "ShopOrderReversal");

            migrationBuilder.DropTable(
                name: "ShopOrderRoutingStepPlan");

            migrationBuilder.DropTable(
                name: "SolutionLink");

            migrationBuilder.DropTable(
                name: "StageForDeliveryReceipt");

            migrationBuilder.DropTable(
                name: "StageForDeliveryReversal");

            migrationBuilder.DropTable(
                name: "StartedTimedTimeTransaction");

            migrationBuilder.DropTable(
                name: "StockBatchNumber");

            migrationBuilder.DropTable(
                name: "StockCount");

            migrationBuilder.DropTable(
                name: "StockCountLine");

            migrationBuilder.DropTable(
                name: "StockSerialNumber");

            migrationBuilder.DropTable(
                name: "StorageLocation");

            migrationBuilder.DropTable(
                name: "SubOrderReceipt");

            migrationBuilder.DropTable(
                name: "SubOrderReversal");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "SubscriptionLine");

            migrationBuilder.DropTable(
                name: "SubscriptionLineType");

            migrationBuilder.DropTable(
                name: "SubscriptionReasonCode");

            migrationBuilder.DropTable(
                name: "SubscriptionRestrictionEmployee");

            migrationBuilder.DropTable(
                name: "SubscriptionRestrictionItem");

            migrationBuilder.DropTable(
                name: "SubscriptionType");

            migrationBuilder.DropTable(
                name: "SupplierItem");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropTable(
                name: "TaxEmploymentEndFlexCode");

            migrationBuilder.DropTable(
                name: "TimeAndBillingAccountDetail");

            migrationBuilder.DropTable(
                name: "TimeAndBillingActivitiesAndExpense");

            migrationBuilder.DropTable(
                name: "TimeAndBillingEntryAccount");

            migrationBuilder.DropTable(
                name: "TimeAndBillingEntryProject");

            migrationBuilder.DropTable(
                name: "TimeAndBillingEntryRecentAccount");

            migrationBuilder.DropTable(
                name: "TimeAndBillingEntryRecentActivitiesAndExpense");

            migrationBuilder.DropTable(
                name: "TimeAndBillingEntryRecentHourCostType");

            migrationBuilder.DropTable(
                name: "TimeAndBillingEntryRecentProject");

            migrationBuilder.DropTable(
                name: "TimeAndBillingItemDetail");

            migrationBuilder.DropTable(
                name: "TimeAndBillingProjectDetail");

            migrationBuilder.DropTable(
                name: "TimeCorrection");

            migrationBuilder.DropTable(
                name: "TimedTimeTransaction");

            migrationBuilder.DropTable(
                name: "TimeTransaction");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionLine");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserRolesPerDivision");

            migrationBuilder.DropTable(
                name: "VATCode");

            migrationBuilder.DropTable(
                name: "VatPercentage");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "WarehouseTransfer");

            migrationBuilder.DropTable(
                name: "WarehouseTransferLine");

            migrationBuilder.DropTable(
                name: "WebhookSubscription");

            migrationBuilder.DropTable(
                name: "Workcenter");
        }
    }
}

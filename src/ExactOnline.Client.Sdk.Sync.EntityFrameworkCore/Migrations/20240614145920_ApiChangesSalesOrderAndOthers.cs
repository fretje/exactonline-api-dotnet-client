using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore.Migrations
{
	/// <inheritdoc />
	public partial class ApiChangesSalesOrderAndOthers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropTable(
                name: "SalesPriceListDetail");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Quotation");

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "TitleAbbreviation",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleDescription",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesPriceList",
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
                    Entity = table.Column<short>(type: "smallint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPriceList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesPriceListVolumeDiscount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasePrice = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BasePriceAmount = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Division = table.Column<int>(type: "int", nullable: true),
                    EntryMethod = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    Item = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewPrice = table.Column<double>(type: "float", nullable: true),
                    NumberOfItemsPerUnit = table.Column<double>(type: "float", nullable: true),
                    PriceListCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceListDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceListPeriod = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPriceListVolumeDiscount", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPriceList");

            migrationBuilder.DropTable(
                name: "SalesPriceListVolumeDiscount");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TitleAbbreviation",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "TitleDescription",
                table: "Contact");

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "SalesOrder",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Quotation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "SalesPriceListDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Account = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    EntryMethod = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
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
        }
    }
}

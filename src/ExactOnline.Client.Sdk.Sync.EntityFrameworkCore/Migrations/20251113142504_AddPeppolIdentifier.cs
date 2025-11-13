using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddPeppolIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PeppolIdentifier",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeppolIdentifierType",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeppolIdentifier",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PeppolIdentifierType",
                table: "Account");
        }
    }
}

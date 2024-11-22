using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class CrmAccountAddEnableSalesPaymentLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnableSalesPaymentLink",
                table: "Account",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableSalesPaymentLink",
                table: "Account");
        }
    }
}

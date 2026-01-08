using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore.Migrations
{
	/// <inheritdoc />
	public partial class UpdatePeppolIdentifierType : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) =>
			migrationBuilder.AlterColumn<int>(
				name: "PeppolIdentifierType",
				table: "Account",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "int",
				oldDefaultValue: 0);

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) =>
			migrationBuilder.AlterColumn<int>(
				name: "PeppolIdentifierType",
				table: "Account",
				type: "int",
				nullable: false,
				defaultValue: 0,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);
	}
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercialApp.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "CustomerAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: true);

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: true);

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "State",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "CustomerAccounts");
        }
    }
}

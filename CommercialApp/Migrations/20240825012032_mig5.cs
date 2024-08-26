using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercialApp.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "CustomerAccounts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password123");

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "password123");

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "password123");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "CustomerAccounts");
        }
    }
}

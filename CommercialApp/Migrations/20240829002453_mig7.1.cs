using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercialApp.Migrations
{
    public partial class mig71 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CargoTrackings",
                type: "VarChar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CargoTrackings",
                type: "VarChar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(150)");
        }
    }
}

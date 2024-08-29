using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercialApp.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Employees",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Employees",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "Image", "Name", "Surname", "Title" },
                values: new object[,]
                {
                    { 1, 1, "@gmail.com", "img", "Emre", "Alpay", "title" },
                    { 2, 2, "@gmail.com", "img", "Elif", "Su", "title" },
                    { 3, 3, "@gmail.com", "img", "Cenk", "Cem", "title" },
                    { 4, 4, "@gmail.com", "img", "Buse", "Gül", "title" }
                });
        }
    }
}

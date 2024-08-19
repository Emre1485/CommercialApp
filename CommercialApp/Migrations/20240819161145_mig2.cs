using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercialApp.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Invoices",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.AlterColumn<DateTime>(
        //        name: "Time",
        //        table: "Invoices",
        //        type: "timestamp with time zone",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "character varying(5)",
        //        oldMaxLength: 5);
        //}
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Invoices",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5,
                oldNullable: false)
            .Annotation("Npgsql:PostgresExtension", null)
            .OldAnnotation("Npgsql:PostgresExtension", "USING \"Time\"::timestamp with time zone");
        }

    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeePortal.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { new Guid("0681be5c-f2b2-4eec-b444-c6f1eb4b7f7d"), "jhon@gmail.com", "Jhon", "1234567891", 0m },
                    { new Guid("5d80b3f5-de5b-4cdc-8d43-940239834594"), "JhonWick@gmail.com", "JhonWick", null, 0m },
                    { new Guid("b6e6f70c-ad32-48c3-911e-3e55ac5e9b23"), "Sena@gmail.com", "Sena", null, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0681be5c-f2b2-4eec-b444-c6f1eb4b7f7d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("5d80b3f5-de5b-4cdc-8d43-940239834594"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b6e6f70c-ad32-48c3-911e-3e55ac5e9b23"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class initialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348d97c4-100d-4fca-8271-9e39e9561bc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89ada5ab-6096-4aea-b86a-b1f63564f48b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9f41699-db1b-4344-91bc-10a9e3798af7", null, "Admin", "ADMIN" },
                    { "e2c00ac8-4c7c-42af-8d5d-e6050294d594", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9f41699-db1b-4344-91bc-10a9e3798af7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2c00ac8-4c7c-42af-8d5d-e6050294d594");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "348d97c4-100d-4fca-8271-9e39e9561bc9", null, "Admin", "ADMIN" },
                    { "89ada5ab-6096-4aea-b86a-b1f63564f48b", null, "User", "USER" }
                });
        }
    }
}

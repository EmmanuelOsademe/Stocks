using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "08664365-f758-444c-a19d-b1f8bebdb419", null, "Admin", "ADMIN" },
                    { "37f6dd7a-8e9c-4457-b0ca-f10d3ef63ddd", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08664365-f758-444c-a19d-b1f8bebdb419");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37f6dd7a-8e9c-4457-b0ca-f10d3ef63ddd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9f41699-db1b-4344-91bc-10a9e3798af7", null, "Admin", "ADMIN" },
                    { "e2c00ac8-4c7c-42af-8d5d-e6050294d594", null, "User", "USER" }
                });
        }
    }
}

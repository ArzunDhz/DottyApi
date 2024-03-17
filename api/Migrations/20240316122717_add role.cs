using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class addrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b83a7328-b524-41c2-a5eb-4aa101602018", null, "Admin", "ADMIN" },
                    { "da4209ac-c3d6-4580-b266-6b04fc66eb18", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b83a7328-b524-41c2-a5eb-4aa101602018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da4209ac-c3d6-4580-b266-6b04fc66eb18");

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Industry", "LastDiv", "MarkCap", "Name", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Technology", 2m, 200000000000L, "Apple Inc.", 150m, null },
                    { 2, "Technology", 10m, 1500000000000L, "Alphabet Inc.", 2500m, null }
                });
        }
    }
}

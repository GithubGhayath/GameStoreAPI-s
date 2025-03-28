using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStoreApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGeners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Geners",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "Roleplaying" },
                    { 3, "Sports" },
                    { 4, "Racing" },
                    { 5, "Kids and Family" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Geners",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Geners",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Geners",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Geners",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Geners",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}

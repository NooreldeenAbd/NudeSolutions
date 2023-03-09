using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dev_Assignment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InsuredItems",
                columns: new[] { "Id", "Name", "catagoryId", "value" },
                values: new object[,]
                {
                    { 1, "TV", 1, 2500 },
                    { 2, "Playstation 5", 1, 500 },
                    { 3, "Laptop", 1, 1500 },
                    { 4, "Electric guitar", 1, 4000 },
                    { 5, "Shoes", 2, 100 },
                    { 6, "Suit", 2, 2000 },
                    { 7, "Jacket", 2, 400 },
                    { 8, "Oven", 3, 2200 },
                    { 9, "Dishwasher", 3, 1500 },
                    { 10, "Microwave", 3, 790 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "InsuredItems",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

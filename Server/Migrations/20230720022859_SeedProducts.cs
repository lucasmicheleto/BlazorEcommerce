using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "The latest iPhone model with 5G technology", "https://fdn2.gsmarena.com/vv/bigpic/apple-iphone-13.jpg", 799.00m, "Apple iPhone 13" },
                    { 2, "The latest Samsung Galaxy model with 5G technology", "https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-s21-5g-r.jpg", 799.99m, "Samsung Galaxy S21" },
                    { 3, "The latest Google Pixel model with 5G technology", "https://fdn2.gsmarena.com/vv/bigpic/google-pixel-6.jpg", 699.00m, "Google Pixel 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

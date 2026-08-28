using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cis_proj.Migrations
{
    /// <inheritdoc />
    public partial class CreateDrinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A refreshing cocktail made with rum, lime juice, sugar, mint leaves, and soda water.", "Mojito", 8.50m },
                    { 2, "A classic cocktail made with tequila, lime juice, and orange liqueur, served in a salt-rimmed glass.", "Margarita", 9.00m },
                    { 3, "A timeless cocktail made with bourbon or rye whiskey, sugar, bitters, and a twist of citrus.", "Old Fashioned", 10.00m },
                    { 4, "A stylish cocktail made with vodka, triple sec, cranberry juice, and lime juice.", "Cosmopolitan", 9.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

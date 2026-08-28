using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cis_proj.Migrations
{
    /// <inheritdoc />
    public partial class AddDrinkToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DrinkId",
                table: "Order",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Drinks_DrinkId",
                table: "Order",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Drinks_DrinkId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DrinkId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Order");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cis_proj.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaffUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "bartender@bar.com", "Sam Barkeep", "4523f961e3845992b04ae19a48d846a986d87062e5c9e91c785b4c691dbd4636", "Bartender" },
                    { 2, "server@bar.com", "Riley Server", "14bf075c90460abf992eded5e80766dc474229ecc33a72b63e6844cce4a5f32c", "Server" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

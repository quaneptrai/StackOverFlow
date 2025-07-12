using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverFlow.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsernameId",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsernameId", "Email", "Firstname", "LastName", "Password", "Role" },
                values: new object[] { -1, "admin@gmail.com", "Admin", "User", "admin123", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsernameId",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsernameId", "Email", "Firstname", "LastName", "Password", "Role" },
                values: new object[] { 1, "admin@example.com", "Admin", "User", "admin123", "Admin" });
        }
    }
}

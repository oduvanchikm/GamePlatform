using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePlatform.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "NameRole" },
                values: new object[] { "Admin" });
            
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "NameRole" },
                values: new object[] { "User" });
            
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "NameRole" },
                values: new object[] { "Unauthenticated user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "NameRole",
                keyValue: "Admin");
            
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "NameRole",
                keyValue: "User");
            
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "NameRole",
                keyValue: "Unauthenticated user");
        }
    }
}

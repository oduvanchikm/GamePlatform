using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePlatform.Migrations
{
    /// <inheritdoc />
    public partial class addAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Email", "PasswordHash", "RoleId", "UserName", "UserSurname", "UserGenderId", "DateOfBirth" },
                values: new object[] {
                    "admin@admin.com", 
                    "8396bee0b8a9b72bd9c7607a8ce7f2cf96d68d3af20f59bb6f143508f9e4943e",
                    1,
                    "Admin",
                    "Admin",
                    1,
                    new DateTimeOffset(new DateTime(2005, 1, 20), TimeSpan.Zero)
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Email",
                keyValue: "Admin");
        }
    }
}

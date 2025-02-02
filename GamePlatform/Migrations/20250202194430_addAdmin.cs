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
                columns: new[] { "Email", "PasswordHash", "RoleId" },
                values: new object[] { 
                    "admin@example.com", 
                    "$2a$11$o.sTnyjh8Mr9ArOWpr5Q..rsRPFHJ7EJ6pIeFUyVEfP2fe5b1riHm",
                    1
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

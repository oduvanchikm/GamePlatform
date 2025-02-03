using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePlatform.Migrations
{
    /// <inheritdoc />
    public partial class addGenderInDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "NameGender" },
                values: new object[] { "Female" });
            
            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "NameGender" },
                values: new object[] { "Male" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "NameGender",
                keyValue: "Female");
            
            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "NameGender",
                keyValue: "Male");
        }
    }
}

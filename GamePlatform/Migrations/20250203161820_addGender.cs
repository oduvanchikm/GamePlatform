using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GamePlatform.Migrations
{
    /// <inheritdoc />
    public partial class addGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGender",
                table: "User");

            migrationBuilder.AddColumn<long>(
                name: "UserGenderId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameGender = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserGenderId",
                table: "User",
                column: "UserGenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Gender_UserGenderId",
                table: "User",
                column: "UserGenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Gender_UserGenderId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_User_UserGenderId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserGenderId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "UserGender",
                table: "User",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concretos.Migrations
{
    /// <inheritdoc />
    public partial class UserNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastNames",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNames",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Users");
        }
    }
}

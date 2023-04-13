using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concretos.Migrations
{
    /// <inheritdoc />
    public partial class Reactives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FabricationMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricationMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FabricationMethodId = table.Column<int>(type: "int", nullable: false),
                    Equation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactives_FabricationMethods_FabricationMethodId",
                        column: x => x.FabricationMethodId,
                        principalTable: "FabricationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reactives_FabricationMethodId",
                table: "Reactives",
                column: "FabricationMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reactives");

            migrationBuilder.DropTable(
                name: "FabricationMethods");
        }
    }
}

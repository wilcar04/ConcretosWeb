using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concretos.Migrations
{
    /// <inheritdoc />
    public partial class Ecuations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactives_FabricationMethods_FabricationMethodId",
                table: "Reactives");

            migrationBuilder.DropIndex(
                name: "IX_Reactives_FabricationMethodId",
                table: "Reactives");

            migrationBuilder.DropColumn(
                name: "FabricationMethodId",
                table: "Reactives");

            migrationBuilder.CreateTable(
                name: "Ecuations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricationMethodId = table.Column<int>(type: "int", nullable: false),
                    ReactiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecuations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecuations_FabricationMethods_FabricationMethodId",
                        column: x => x.FabricationMethodId,
                        principalTable: "FabricationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ecuations_Reactives_FabricationMethodId",
                        column: x => x.FabricationMethodId,
                        principalTable: "Reactives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ecuations_FabricationMethodId",
                table: "Ecuations",
                column: "FabricationMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ecuations");

            migrationBuilder.AddColumn<int>(
                name: "FabricationMethodId",
                table: "Reactives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reactives_FabricationMethodId",
                table: "Reactives",
                column: "FabricationMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactives_FabricationMethods_FabricationMethodId",
                table: "Reactives",
                column: "FabricationMethodId",
                principalTable: "FabricationMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concretos.Migrations
{
    /// <inheritdoc />
    public partial class EcuationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecuations_Reactives_FabricationMethodId",
                table: "Ecuations");

            migrationBuilder.CreateIndex(
                name: "IX_Ecuations_ReactiveId",
                table: "Ecuations",
                column: "ReactiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecuations_Reactives_ReactiveId",
                table: "Ecuations",
                column: "ReactiveId",
                principalTable: "Reactives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecuations_Reactives_ReactiveId",
                table: "Ecuations");

            migrationBuilder.DropIndex(
                name: "IX_Ecuations_ReactiveId",
                table: "Ecuations");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecuations_Reactives_FabricationMethodId",
                table: "Ecuations",
                column: "FabricationMethodId",
                principalTable: "Reactives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

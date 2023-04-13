using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concretos.Migrations
{
    /// <inheritdoc />
    public partial class Measure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equation",
                table: "Reactives");

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consecutive = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExperimentalPorosity = table.Column<float>(type: "real", nullable: false),
                    ExpectedDensity = table.Column<float>(type: "real", nullable: false),
                    ExpectedResistence = table.Column<float>(type: "real", nullable: false),
                    FabricationMethodId = table.Column<int>(type: "int", nullable: false),
                    ReactiveId = table.Column<int>(type: "int", nullable: false),
                    StudyId = table.Column<int>(type: "int", nullable: false),
                    ExperimentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExperimentalDensity = table.Column<float>(type: "real", nullable: false),
                    ExperimentalResistence = table.Column<float>(type: "real", nullable: false),
                    DifferencePercentage = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measures_FabricationMethods_FabricationMethodId",
                        column: x => x.FabricationMethodId,
                        principalTable: "FabricationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measures_Reactives_ReactiveId",
                        column: x => x.ReactiveId,
                        principalTable: "Reactives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measures_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measures_FabricationMethodId",
                table: "Measures",
                column: "FabricationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_ReactiveId",
                table: "Measures",
                column: "ReactiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_StudyId",
                table: "Measures",
                column: "StudyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.AddColumn<string>(
                name: "Equation",
                table: "Reactives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

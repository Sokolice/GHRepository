using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_240218_08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantPlant_Plants_AvoidPlantsId",
                table: "PlantPlant");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantPlant_Plants_CompanionPlantsId",
                table: "PlantPlant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantPlant",
                table: "PlantPlant");

            migrationBuilder.RenameTable(
                name: "PlantPlant",
                newName: "PlantCompanionPlant");

            migrationBuilder.RenameColumn(
                name: "AvoidPlantsId",
                table: "PlantCompanionPlant",
                newName: "CompanionPlants2Id");

            migrationBuilder.RenameIndex(
                name: "IX_PlantPlant_CompanionPlantsId",
                table: "PlantCompanionPlant",
                newName: "IX_PlantCompanionPlant_CompanionPlantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantCompanionPlant",
                table: "PlantCompanionPlant",
                columns: new[] { "CompanionPlants2Id", "CompanionPlantsId" });

            migrationBuilder.CreateTable(
                name: "PlantAvoidPlant",
                columns: table => new
                {
                    AvoidPlants2Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AvoidPlantsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantAvoidPlant", x => new { x.AvoidPlants2Id, x.AvoidPlantsId });
                    table.ForeignKey(
                        name: "FK_PlantAvoidPlant_Plants_AvoidPlants2Id",
                        column: x => x.AvoidPlants2Id,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantAvoidPlant_Plants_AvoidPlantsId",
                        column: x => x.AvoidPlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantAvoidPlant_AvoidPlantsId",
                table: "PlantAvoidPlant",
                column: "AvoidPlantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantCompanionPlant_Plants_CompanionPlants2Id",
                table: "PlantCompanionPlant",
                column: "CompanionPlants2Id",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantCompanionPlant_Plants_CompanionPlantsId",
                table: "PlantCompanionPlant",
                column: "CompanionPlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantCompanionPlant_Plants_CompanionPlants2Id",
                table: "PlantCompanionPlant");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantCompanionPlant_Plants_CompanionPlantsId",
                table: "PlantCompanionPlant");

            migrationBuilder.DropTable(
                name: "PlantAvoidPlant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantCompanionPlant",
                table: "PlantCompanionPlant");

            migrationBuilder.RenameTable(
                name: "PlantCompanionPlant",
                newName: "PlantPlant");

            migrationBuilder.RenameColumn(
                name: "CompanionPlants2Id",
                table: "PlantPlant",
                newName: "AvoidPlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantCompanionPlant_CompanionPlantsId",
                table: "PlantPlant",
                newName: "IX_PlantPlant_CompanionPlantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantPlant",
                table: "PlantPlant",
                columns: new[] { "AvoidPlantsId", "CompanionPlantsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlantPlant_Plants_AvoidPlantsId",
                table: "PlantPlant",
                column: "AvoidPlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantPlant_Plants_CompanionPlantsId",
                table: "PlantPlant",
                column: "CompanionPlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

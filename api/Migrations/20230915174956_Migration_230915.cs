using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_230915 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DirectSewing",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHybrid",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlantPlant",
                columns: table => new
                {
                    AvoidPlantsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanionPlantId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantPlant", x => new { x.AvoidPlantsId, x.CompanionPlantId });
                    table.ForeignKey(
                        name: "FK_PlantPlant_Plants_AvoidPlantsId",
                        column: x => x.AvoidPlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantPlant_Plants_CompanionPlantId",
                        column: x => x.CompanionPlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantPlant_CompanionPlantId",
                table: "PlantPlant",
                column: "CompanionPlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantPlant");

            migrationBuilder.DropColumn(
                name: "DirectSewing",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "IsHybrid",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Plants");
        }
    }
}

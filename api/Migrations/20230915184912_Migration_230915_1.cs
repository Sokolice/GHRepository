using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_230915_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantPlant_Plants_CompanionPlantId",
                table: "PlantPlant");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Plants",
                newName: "Progress");

            migrationBuilder.RenameColumn(
                name: "CompanionPlantId",
                table: "PlantPlant",
                newName: "CompanionPlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantPlant_CompanionPlantId",
                table: "PlantPlant",
                newName: "IX_PlantPlant_CompanionPlantsId");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantPlant_Plants_CompanionPlantsId",
                table: "PlantPlant",
                column: "CompanionPlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantPlant_Plants_CompanionPlantsId",
                table: "PlantPlant");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "Progress",
                table: "Plants",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CompanionPlantsId",
                table: "PlantPlant",
                newName: "CompanionPlantId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantPlant_CompanionPlantsId",
                table: "PlantPlant",
                newName: "IX_PlantPlant_CompanionPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantPlant_Plants_CompanionPlantId",
                table: "PlantPlant",
                column: "CompanionPlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

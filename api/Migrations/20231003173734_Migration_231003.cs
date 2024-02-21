using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_231003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VegetationPeriod",
                table: "Plants",
                newName: "RepeatedPlanting");

            migrationBuilder.RenameColumn(
                name: "DatePlanted",
                table: "Plants",
                newName: "ImageSrc");

            migrationBuilder.AddColumn<int>(
                name: "CropRotation",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GerminationTemp",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MonthWeeks",
                columns: table => new
                {
                    Month = table.Column<string>(type: "TEXT", nullable: false),
                    Week = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeeks", x => new { x.Month, x.Week });
                });

            migrationBuilder.CreateTable(
                name: "PlantRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatePlanted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AmountPlanted = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantRecords_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthWeekPlant",
                columns: table => new
                {
                    SewedPlantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SewingMonthsMonth = table.Column<string>(type: "TEXT", nullable: false),
                    SewingMonthsWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeekPlant", x => new { x.SewedPlantId, x.SewingMonthsMonth, x.SewingMonthsWeek });
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant_MonthWeeks_SewingMonthsMonth_SewingMonthsWeek",
                        columns: x => new { x.SewingMonthsMonth, x.SewingMonthsWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant_Plants_SewedPlantId",
                        column: x => x.SewedPlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthWeekPlant1",
                columns: table => new
                {
                    HarvestedPlantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HarvestMonthsMonth = table.Column<string>(type: "TEXT", nullable: false),
                    HarvestMonthsWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeekPlant1", x => new { x.HarvestedPlantId, x.HarvestMonthsMonth, x.HarvestMonthsWeek });
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant1_MonthWeeks_HarvestMonthsMonth_HarvestMonthsWeek",
                        columns: x => new { x.HarvestMonthsMonth, x.HarvestMonthsWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant1_Plants_HarvestedPlantId",
                        column: x => x.HarvestedPlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardeningTaskMonthWeek",
                columns: table => new
                {
                    GardeningTasksId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MonthWeeksMonth = table.Column<string>(type: "TEXT", nullable: false),
                    MonthWeeksWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardeningTaskMonthWeek", x => new { x.GardeningTasksId, x.MonthWeeksMonth, x.MonthWeeksWeek });
                    table.ForeignKey(
                        name: "FK_GardeningTaskMonthWeek_MonthWeeks_MonthWeeksMonth_MonthWeeksWeek",
                        columns: x => new { x.MonthWeeksMonth, x.MonthWeeksWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardeningTaskMonthWeek_Tasks_GardeningTasksId",
                        column: x => x.GardeningTasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardeningTaskMonthWeek_MonthWeeksMonth_MonthWeeksWeek",
                table: "GardeningTaskMonthWeek",
                columns: new[] { "MonthWeeksMonth", "MonthWeeksWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthWeekPlant_SewingMonthsMonth_SewingMonthsWeek",
                table: "MonthWeekPlant",
                columns: new[] { "SewingMonthsMonth", "SewingMonthsWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthWeekPlant1_HarvestMonthsMonth_HarvestMonthsWeek",
                table: "MonthWeekPlant1",
                columns: new[] { "HarvestMonthsMonth", "HarvestMonthsWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_PlantRecords_PlantId",
                table: "PlantRecords",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardeningTaskMonthWeek");

            migrationBuilder.DropTable(
                name: "MonthWeekPlant");

            migrationBuilder.DropTable(
                name: "MonthWeekPlant1");

            migrationBuilder.DropTable(
                name: "PlantRecords");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "MonthWeeks");

            migrationBuilder.DropColumn(
                name: "CropRotation",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "GerminationTemp",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "RepeatedPlanting",
                table: "Plants",
                newName: "VegetationPeriod");

            migrationBuilder.RenameColumn(
                name: "ImageSrc",
                table: "Plants",
                newName: "DatePlanted");
        }
    }
}

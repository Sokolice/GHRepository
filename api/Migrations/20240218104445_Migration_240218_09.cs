using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Migration_240218_09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FreezeAlert = table.Column<bool>(type: "INTEGER", nullable: false),
                    HighTemperatureAlert = table.Column<bool>(type: "INTEGER", nullable: false),
                    RainPeriodAlert = table.Column<bool>(type: "INTEGER", nullable: false),
                    MissingSowingThisWeekAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    MissingTaskThisWeekAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    CanBeSowedRepeatedlyAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    ReadyToHarvestAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    CanBeSowedThisWeek = table.Column<string>(type: "TEXT", nullable: false),
                    CanBeSowedRepeatedly = table.Column<string>(type: "TEXT", nullable: false),
                    ReadyToHarvest = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}

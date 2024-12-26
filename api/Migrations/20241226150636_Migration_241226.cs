using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_241226 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MinTemperature",
                table: "PlantTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PlantHeight",
                table: "PlantTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlantSpace",
                table: "PlantTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowSpace",
                table: "PlantTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "PlantTypes");

            migrationBuilder.DropColumn(
                name: "PlantHeight",
                table: "PlantTypes");

            migrationBuilder.DropColumn(
                name: "PlantSpace",
                table: "PlantTypes");

            migrationBuilder.DropColumn(
                name: "RowSpace",
                table: "PlantTypes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_241227 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MinTemperature",
                table: "Plants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantHeight",
                table: "Plants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantSpace",
                table: "Plants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowSpace",
                table: "Plants",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantHeight",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantSpace",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "RowSpace",
                table: "Plants");
        }
    }
}

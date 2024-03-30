using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_240330 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PlantRecords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Beds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantRecords_UserId",
                table: "PlantRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_UserId",
                table: "Beds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_AspNetUsers_UserId",
                table: "Beds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantRecords_AspNetUsers_UserId",
                table: "PlantRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_AspNetUsers_UserId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantRecords_AspNetUsers_UserId",
                table: "PlantRecords");

            migrationBuilder.DropIndex(
                name: "IX_PlantRecords_UserId",
                table: "PlantRecords");

            migrationBuilder.DropIndex(
                name: "IX_Beds_UserId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlantRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Beds");
        }
    }
}

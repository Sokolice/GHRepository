using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migration_200427 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Beds_BedId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_BedId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "Plants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BedId",
                table: "Plants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_BedId",
                table: "Plants",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Beds_BedId",
                table: "Plants",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");
        }
    }
}

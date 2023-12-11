using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Migration_231209 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Beds_BedId",
                table: "Cell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cell",
                table: "Cell");

            migrationBuilder.RenameTable(
                name: "Cell",
                newName: "Cells");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_BedId",
                table: "Cells",
                newName: "IX_Cells_BedId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Cells",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cells",
                table: "Cells",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Beds_BedId",
                table: "Cells",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Beds_BedId",
                table: "Cells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cells",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cells");

            migrationBuilder.RenameTable(
                name: "Cells",
                newName: "Cell");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_BedId",
                table: "Cell",
                newName: "IX_Cell_BedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cell",
                table: "Cell",
                columns: new[] { "X", "Y" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Beds_BedId",
                table: "Cell",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");
        }
    }
}

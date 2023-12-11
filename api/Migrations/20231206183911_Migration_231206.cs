using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Migration_231206 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfColumns = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    GridColumn = table.Column<string>(type: "TEXT", nullable: false),
                    GridRow = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundImage = table.Column<string>(type: "TEXT", nullable: false),
                    BedId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => new { x.X, x.Y });
                    table.ForeignKey(
                        name: "FK_Cell_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cell_BedId",
                table: "Cell",
                column: "BedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cell");

            migrationBuilder.DropTable(
                name: "Beds");
        }
    }
}

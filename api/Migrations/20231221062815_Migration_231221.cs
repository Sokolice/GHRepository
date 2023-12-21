using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Migration_231221 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GridColumn",
                table: "Cells");

            migrationBuilder.RenameColumn(
                name: "GridRow",
                table: "Cells",
                newName: "GridArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GridArea",
                table: "Cells",
                newName: "GridRow");

            migrationBuilder.AddColumn<string>(
                name: "GridColumn",
                table: "Cells",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkStickyNotes.Migrations
{
    /// <inheritdoc />
    public partial class AddContentFileNameToNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentFileName",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentFileName",
                table: "Notes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkStickyNotes.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteExtendedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssigneeId",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IssueTypeId",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriorityId",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Assignees",
                columns: new[] { "Id", "IsDeleted", "Name", "Order" },
                values: new object[] { 1, false, "あなた", 1 });

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "IsDeleted", "Name", "Order" },
                values: new object[,]
                {
                    { 1, false, "バグ", 1 },
                    { 2, false, "タスク", 2 },
                    { 3, false, "要望", 3 },
                    { 4, false, "その他", 4 }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "IsDeleted", "Name", "Order" },
                values: new object[,]
                {
                    { 1, false, "高", 1 },
                    { 2, false, "中", 2 },
                    { 3, false, "低", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IssueTypeId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Notes");
        }
    }
}

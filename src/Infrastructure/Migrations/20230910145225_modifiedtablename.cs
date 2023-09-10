using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifiedtablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntity",
                schema: "com",
                table: "TaskEntity");

            migrationBuilder.RenameTable(
                name: "TaskEntity",
                schema: "com",
                newName: "Tasks",
                newSchema: "com");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                schema: "com",
                table: "Tasks",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                schema: "com",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                schema: "com",
                newName: "TaskEntity",
                newSchema: "com");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntity",
                schema: "com",
                table: "TaskEntity",
                column: "TaskId");
        }
    }
}

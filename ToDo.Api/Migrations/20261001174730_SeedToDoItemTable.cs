using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedToDoItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "IsCompleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Pendiente 1" },
                    { 2, true, "Pendiente 2" },
                    { 3, false, "Pendiente 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

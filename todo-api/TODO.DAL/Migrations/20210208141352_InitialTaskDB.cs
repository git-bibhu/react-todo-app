using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TODO.DAL.Migrations
{
    public partial class InitialTaskDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "DueDate", "Name", "Priority" },
                values: new object[] { 1, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "Shopping", "Low" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "DueDate", "Name", "Priority" },
                values: new object[] { 2, new DateTime(2021, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "Meeting", "High" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "DueDate", "Name", "Priority" },
                values: new object[] { 3, new DateTime(2021, 2, 9, 0, 0, 0, 0, DateTimeKind.Local), "Health Checkup", "Medium" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}

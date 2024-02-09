using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testSibers.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssigneeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    TaskProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_TaskProjectId",
                        column: x => x.TaskProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56ad9457-b3e5-4f1a-9df3-387b17c008f8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c644f6e1-09a5-4ce7-99e5-5ef13f3f1d0e", "AQAAAAIAAYagAAAAEJaei06IMZurxuzHuwr3sofrp1vqfMmG5CMEAykdKi1pHEnFJB7e4CkjNJOO8sFtMw==", "916fc5d6-55c2-4a95-8c0d-f2a7a3f6535b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7b336654-32c4-44ef-88a1-16e3cb1c2a6e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "990e2411-78ea-4efe-9df8-9bcde29922a0", "AQAAAAIAAYagAAAAEAe9ae1xDRO7usHKGX3Ftjwz2wlcb/4kSOVsQsZUPHfDnHhGs9JC2QNP/+oj+nUbrQ==", "68e8107c-ed73-4eb7-b7aa-cbdb51bf5f73" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f51b901-3f29-40f8-9ab7-037edc99db74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efab2074-38e1-422c-87c7-47ce19ea0108", "AQAAAAIAAYagAAAAEJUfdSk60ZEb7mBv+QK/rhopowCclcuVI4zv4qQaoi9FLJkdVFuonUPmdGa/UZbRsg==", "c39e2d27-c065-45bb-b896-7cdc18684f50" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskProjectId",
                table: "Tasks",
                column: "TaskProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56ad9457-b3e5-4f1a-9df3-387b17c008f8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98831030-a776-4de5-a9bf-fc4661867315", "AQAAAAIAAYagAAAAEBHwJzKabVsmR1rEI6da3ozZ9oP4fluOOJG5zQSfqJoWwPHi9lHMzptDbjwXNw5OTQ==", "de175b6d-58bd-44a1-9298-fd6824398baa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7b336654-32c4-44ef-88a1-16e3cb1c2a6e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "043a10e3-da21-483c-82d3-68bffe1b30ae", "AQAAAAIAAYagAAAAEEwdfThCUK0qXEjHzReK0DOvOwtQYcaeEejh1+wXVeeVgkHS/sFRWmT87/maIyEvRQ==", "f25891e5-f81f-4f64-8364-c65d746193c9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f51b901-3f29-40f8-9ab7-037edc99db74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b73d8553-5605-471b-add8-b240a5605312", "AQAAAAIAAYagAAAAED1JNp7s851clFF23y/DoC15wtOKo2bN0yJxbYlHdcF0lhca+tXk5zvmJKj7VGGwyQ==", "832bcfb5-fcf3-4340-a5ad-11f72903b17a" });
        }
    }
}

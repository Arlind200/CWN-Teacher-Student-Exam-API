using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _222_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamTasks_ExamId",
                table: "ExamTasks");

            migrationBuilder.AddColumn<int>(
                name: "Actual",
                table: "ExamTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Expected",
                table: "ExamTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "ExamTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ExamTasks_ExamId_TaskId",
                table: "ExamTasks",
                columns: new[] { "ExamId", "TaskId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamId",
                table: "Exams",
                column: "ExamId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamTasks_ExamId_TaskId",
                table: "ExamTasks");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExamId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Actual",
                table: "ExamTasks");

            migrationBuilder.DropColumn(
                name: "Expected",
                table: "ExamTasks");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "ExamTasks");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTasks_ExamId",
                table: "ExamTasks",
                column: "ExamId");
        }
    }
}

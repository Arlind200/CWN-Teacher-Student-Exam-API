using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _222_Migration_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamTasks_ExamId_TaskId",
                table: "ExamTasks");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExamId",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTasks_ExamId",
                table: "ExamTasks",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamTasks_ExamId",
                table: "ExamTasks");

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
    }
}

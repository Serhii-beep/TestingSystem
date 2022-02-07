using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingSystem.DAL.Migrations
{
    public partial class RemovedQuestionFromTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Questions",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Tests");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Questions",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

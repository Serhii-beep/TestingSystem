using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingSystem.DAL.Migrations
{
    public partial class AddedDescriptionToTestSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TestSets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TestSets");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Tests");
        }
    }
}

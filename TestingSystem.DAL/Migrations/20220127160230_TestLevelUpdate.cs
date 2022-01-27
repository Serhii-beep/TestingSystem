using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingSystem.DAL.Migrations
{
    public partial class TestLevelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "TestLevels",
                newName: "DifficultyLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DifficultyLevel",
                table: "TestLevels",
                newName: "Level");
        }
    }
}

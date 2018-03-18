using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
	public partial class UpdatedTestEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfEasy",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfHard",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfMedium",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfQuestions",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tests",
                nullable: false,
                defaultValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfEasy",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CountOfHard",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CountOfMedium",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CountOfQuestions",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tests");
        }
    }
}

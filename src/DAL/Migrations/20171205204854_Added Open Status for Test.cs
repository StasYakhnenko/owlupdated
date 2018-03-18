using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
	public partial class AddedOpenStatusforTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenStatus",
                table: "Tests",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenStatus",
                table: "Tests");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
	public partial class Addedneededfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Level",
                table: "Questions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "PasswordForShow",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PasswordForShow",
                table: "AspNetUsers");
        }
    }
}

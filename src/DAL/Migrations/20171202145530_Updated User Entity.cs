using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
	public partial class UpdatedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudyEndDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudyStartDate",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudyEndDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudyStartDate",
                table: "AspNetUsers");
        }
    }
}

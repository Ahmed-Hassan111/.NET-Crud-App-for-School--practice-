using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Migrations
{
    public partial class img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Students");
        }
    }
}

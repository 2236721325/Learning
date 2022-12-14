using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTMD5.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

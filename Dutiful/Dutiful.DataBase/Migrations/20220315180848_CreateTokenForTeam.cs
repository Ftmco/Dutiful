using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dutiful.DataBase.Migrations
{
    public partial class CreateTokenForTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Team");
        }
    }
}

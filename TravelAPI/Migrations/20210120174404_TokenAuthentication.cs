using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class TokenAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Reviews");
        }
    }
}

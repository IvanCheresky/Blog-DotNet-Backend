using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_Backend.Data.Migrations
{
    public partial class EmailInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Client",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Client",
                table: "Users");
        }
    }
}

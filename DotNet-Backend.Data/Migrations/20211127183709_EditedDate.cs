using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_Backend.Data.Migrations
{
    public partial class EditedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditDate",
                schema: "Client",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditDate",
                schema: "Client",
                table: "Comments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEditDate",
                schema: "Client",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LastEditDate",
                schema: "Client",
                table: "Comments");
        }
    }
}

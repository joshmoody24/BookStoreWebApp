using Microsoft.EntityFrameworkCore.Migrations;

namespace BookstoreWebApp.Migrations
{
    public partial class zip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Orders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Orders");
        }
    }
}

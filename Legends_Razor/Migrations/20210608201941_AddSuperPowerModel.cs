using Microsoft.EntityFrameworkCore.Migrations;

namespace Legends_Razor.Migrations
{
    public partial class AddSuperPowerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuperPower",
                table: "Legends",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperPower",
                table: "Legends");
        }
    }
}

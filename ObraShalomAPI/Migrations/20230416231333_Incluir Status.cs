using Microsoft.EntityFrameworkCore.Migrations;

namespace ObraShalomAPI.Migrations
{
    public partial class IncluirStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Pessoas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pessoas");
        }
    }
}

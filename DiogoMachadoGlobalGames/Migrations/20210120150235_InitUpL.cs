using Microsoft.EntityFrameworkCore.Migrations;

namespace DiogoMachadoGlobalGames.Migrations
{
    public partial class InitUpL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Incricoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Incricoes");
        }
    }
}

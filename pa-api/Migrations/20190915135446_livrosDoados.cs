using Microsoft.EntityFrameworkCore.Migrations;

namespace pa_api.Migrations
{
    public partial class livrosDoados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "livrosDoados",
                table: "Alunos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "livrosDoados",
                table: "Alunos");
        }
    }
}

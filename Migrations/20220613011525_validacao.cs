using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteEngegraph.Migrations
{
    public partial class validacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "validacao",
                table: "Pessoa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "validacao",
                table: "Pessoa");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Alterada_AtualizacaoCliente_13062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VersaoAnteriorId",
                table: "AtualizacaoCliente",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VersaoAnteriorId",
                table: "AtualizacaoCliente",
                nullable: false);
        }
    }
}

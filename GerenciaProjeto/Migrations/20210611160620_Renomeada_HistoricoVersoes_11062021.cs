using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Renomeada_HistoricoVersoes_11062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "HistoricoVersoes",
                newName: "AtualizacoesClientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AtualizacoesClientes",
                newName: "HistoricoVersoes");
        }
    }
}

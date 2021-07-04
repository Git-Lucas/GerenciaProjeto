using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class ColunaCnpjAdicionadaEmEmpresas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cnpj",
                schema: "tarefas",
                table: "empresa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cnpj",
                schema: "tarefas",
                table: "empresa");
        }
    }
}

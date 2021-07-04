using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Alterada_Empresa_16062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                table: "AtualizacaoCliente");

            migrationBuilder.AlterColumn<int>(
                name: "VersaoAnteriorId",
                table: "AtualizacaoCliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                table: "AtualizacaoCliente",
                column: "VersaoAnteriorId",
                principalTable: "Versao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "tarefas",
                table: "empresa",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                table: "AtualizacaoCliente");

            migrationBuilder.AlterColumn<int>(
                name: "VersaoAnteriorId",
                table: "AtualizacaoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                table: "AtualizacaoCliente",
                column: "VersaoAnteriorId",
                principalTable: "Versao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "tarefas",
                table: "empresa",
                nullable: false);
        }
    }
}

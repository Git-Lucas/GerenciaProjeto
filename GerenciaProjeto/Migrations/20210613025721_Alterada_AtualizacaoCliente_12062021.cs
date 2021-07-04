using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Alterada_AtualizacaoCliente_12062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                table: "AtualizacaoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAtualizadaId",
                table: "AtualizacaoCliente");

            migrationBuilder.AlterColumn<int>(
                name: "VersaoAtualizadaId",
                table: "AtualizacaoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAtualizadaId",
                table: "AtualizacaoCliente",
                column: "VersaoAtualizadaId",
                principalTable: "Versao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                table: "AtualizacaoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAtualizadaId",
                table: "AtualizacaoCliente");

            migrationBuilder.AlterColumn<int>(
                name: "VersaoAtualizadaId",
                table: "AtualizacaoCliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtualizacaoCliente_Versao_VersaoAtualizadaId",
                table: "AtualizacaoCliente",
                column: "VersaoAtualizadaId",
                principalTable: "Versao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

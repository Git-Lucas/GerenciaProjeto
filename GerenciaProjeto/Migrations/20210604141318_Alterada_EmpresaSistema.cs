using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Alterada_EmpresaSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresaId",
                table: "EmpresaSistema");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemaId",
                table: "EmpresaSistema");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoVersoes_empresa_EmpresaId",
                table: "HistoricoVersoes");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoVersoes_Sistema_SistemaId",
                table: "HistoricoVersoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Versao_Sistema_SistemaId",
                table: "Versao");

            migrationBuilder.DropForeignKey(
                name: "tarefacliente$tarefacliente_ibfk_1",
                schema: "tarefas",
                table: "tarefacliente");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmpresaSistema",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresaId",
                table: "EmpresaSistema",
                column: "EmpresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemaId",
                table: "EmpresaSistema",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoVersoes_empresa_EmpresaId",
                table: "HistoricoVersoes",
                column: "EmpresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoVersoes_Sistema_SistemaId",
                table: "HistoricoVersoes",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Versao_Sistema_SistemaId",
                table: "Versao",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tarefacliente$tarefacliente_ibfk_1",
                schema: "tarefas",
                table: "tarefacliente",
                column: "empresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresaId",
                table: "EmpresaSistema");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemaId",
                table: "EmpresaSistema");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoVersoes_empresa_EmpresaId",
                table: "HistoricoVersoes");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoVersoes_Sistema_SistemaId",
                table: "HistoricoVersoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Versao_Sistema_SistemaId",
                table: "Versao");

            migrationBuilder.DropForeignKey(
                name: "tarefacliente$tarefacliente_ibfk_1",
                schema: "tarefas",
                table: "tarefacliente");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmpresaSistema");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresaId",
                table: "EmpresaSistema",
                column: "EmpresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemaId",
                table: "EmpresaSistema",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoVersoes_empresa_EmpresaId",
                table: "HistoricoVersoes",
                column: "EmpresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoVersoes_Sistema_SistemaId",
                table: "HistoricoVersoes",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Versao_Sistema_SistemaId",
                table: "Versao",
                column: "SistemaId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "tarefacliente$tarefacliente_ibfk_1",
                schema: "tarefas",
                table: "tarefacliente",
                column: "empresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

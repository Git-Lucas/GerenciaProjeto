using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Alterada_Empresa_Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresaId",
                table: "EmpresaSistema");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemaId",
                table: "EmpresaSistema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpresaSistema",
                table: "EmpresaSistema");

            migrationBuilder.DropIndex(
                name: "IX_EmpresaSistema_SistemaId",
                table: "EmpresaSistema");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "EmpresaSistema");

            migrationBuilder.RenameIndex(
                name: "id_status",
                schema: "tarefas",
                table: "tarefaempresa",
                newName: "IX_tarefaempresa_status");

            migrationBuilder.RenameIndex(
                name: "tarefacliente_ibfk_1",
                schema: "tarefas",
                table: "tarefacliente",
                newName: "IX_tarefacliente_empresaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmpresaSistema",
                newName: "SistemasId");

            migrationBuilder.RenameColumn(
                name: "SistemaId",
                table: "EmpresaSistema",
                newName: "EmpresasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpresaSistema",
                table: "EmpresaSistema",
                columns: new[] { "EmpresasId", "SistemasId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaSistema_SistemasId",
                table: "EmpresaSistema",
                column: "SistemasId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresasId",
                table: "EmpresaSistema",
                column: "EmpresasId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemasId",
                table: "EmpresaSistema",
                column: "SistemasId",
                principalTable: "Sistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_empresa_EmpresasId",
                table: "EmpresaSistema");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpresaSistema_Sistema_SistemasId",
                table: "EmpresaSistema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpresaSistema",
                table: "EmpresaSistema");

            migrationBuilder.DropIndex(
                name: "IX_EmpresaSistema_SistemasId",
                table: "EmpresaSistema");

            migrationBuilder.RenameIndex(
                name: "IX_tarefaempresa_status",
                schema: "tarefas",
                table: "tarefaempresa",
                newName: "id_status");

            migrationBuilder.RenameIndex(
                name: "IX_tarefacliente_empresaId",
                schema: "tarefas",
                table: "tarefacliente",
                newName: "tarefacliente_ibfk_1");

            migrationBuilder.RenameColumn(
                name: "SistemasId",
                table: "EmpresaSistema",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmpresasId",
                table: "EmpresaSistema",
                newName: "SistemaId");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "EmpresaSistema",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpresaSistema",
                table: "EmpresaSistema",
                columns: new[] { "EmpresaId", "SistemaId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaSistema_SistemaId",
                table: "EmpresaSistema",
                column: "SistemaId");

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
        }
    }
}

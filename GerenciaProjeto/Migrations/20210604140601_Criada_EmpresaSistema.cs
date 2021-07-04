using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Criada_EmpresaSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sistema_empresa_EmpresaId",
                table: "Sistema");

            migrationBuilder.DropIndex(
                name: "IX_Sistema_EmpresaId",
                table: "Sistema");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Sistema");

            migrationBuilder.CreateTable(
                name: "EmpresaSistema",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false),
                    SistemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaSistema", x => new { x.EmpresaId, x.SistemaId });
                    table.ForeignKey(
                        name: "FK_EmpresaSistema_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "tarefas",
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaSistema_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaSistema_SistemaId",
                table: "EmpresaSistema",
                column: "SistemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaSistema");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Sistema",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sistema_EmpresaId",
                table: "Sistema",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sistema_empresa_EmpresaId",
                table: "Sistema",
                column: "EmpresaId",
                principalSchema: "tarefas",
                principalTable: "empresa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

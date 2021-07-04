using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Criadas_HistoricoVersoes_Sistema_Versao_Alterada_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sistema_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "tarefas",
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Versao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<string>(nullable: true),
                    SistemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versao_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoVersoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    SistemaId = table.Column<int>(nullable: false),
                    VersaoAnteriorId = table.Column<int>(nullable: true),
                    VersaoAtualizadaId = table.Column<int>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoVersoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoVersoes_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "tarefas",
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoVersoes_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoVersoes_Versao_VersaoAnteriorId",
                        column: x => x.VersaoAnteriorId,
                        principalTable: "Versao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoVersoes_Versao_VersaoAtualizadaId",
                        column: x => x.VersaoAtualizadaId,
                        principalTable: "Versao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVersoes_EmpresaId",
                table: "HistoricoVersoes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVersoes_SistemaId",
                table: "HistoricoVersoes",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVersoes_VersaoAnteriorId",
                table: "HistoricoVersoes",
                column: "VersaoAnteriorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoVersoes_VersaoAtualizadaId",
                table: "HistoricoVersoes",
                column: "VersaoAtualizadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sistema_EmpresaId",
                table: "Sistema",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Versao_SistemaId",
                table: "Versao",
                column: "SistemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoVersoes");

            migrationBuilder.DropTable(
                name: "Versao");

            migrationBuilder.DropTable(
                name: "Sistema");
        }
    }
}

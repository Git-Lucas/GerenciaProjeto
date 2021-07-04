using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Renomeada_AtualizacoesClientes_11062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtualizacoesClientes");

            migrationBuilder.CreateTable(
                name: "AtualizacaoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    SistemaId = table.Column<int>(type: "int", nullable: false),
                    VersaoAnteriorId = table.Column<int>(type: "int", nullable: true),
                    VersaoAtualizadaId = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtualizacaoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtualizacaoCliente_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "tarefas",
                        principalTable: "empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtualizacaoCliente_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtualizacaoCliente_Versao_VersaoAnteriorId",
                        column: x => x.VersaoAnteriorId,
                        principalTable: "Versao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtualizacaoCliente_Versao_VersaoAtualizadaId",
                        column: x => x.VersaoAtualizadaId,
                        principalTable: "Versao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtualizacaoCliente_EmpresaId",
                table: "AtualizacaoCliente",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtualizacaoCliente_SistemaId",
                table: "AtualizacaoCliente",
                column: "SistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtualizacaoCliente_VersaoAnteriorId",
                table: "AtualizacaoCliente",
                column: "VersaoAnteriorId");

            migrationBuilder.CreateIndex(
                name: "IX_AtualizacaoCliente_VersaoAtualizadaId",
                table: "AtualizacaoCliente",
                column: "VersaoAtualizadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtualizacaoCliente");

            migrationBuilder.CreateTable(
                name: "AtualizacoesClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    SistemaId = table.Column<int>(type: "int", nullable: false),
                    VersaoAnteriorId = table.Column<int>(type: "int", nullable: true),
                    VersaoAtualizadaId = table.Column<int>(type: "int", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoVersoes_Sistema_SistemaId",
                        column: x => x.SistemaId,
                        principalTable: "Sistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
        }
    }
}

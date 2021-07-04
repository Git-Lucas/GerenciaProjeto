using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjeto.Migrations
{
    public partial class Alterada_EmpresaSistema_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmpresaSistema_EmpresasId",
                table: "EmpresaSistema",
                column: "SistemasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

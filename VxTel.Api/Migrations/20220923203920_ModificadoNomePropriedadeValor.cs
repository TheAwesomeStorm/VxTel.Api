using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VxTel.Api.Migrations
{
    public partial class ModificadoNomePropriedadeValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Tarifas",
                newName: "Valor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Tarifas",
                newName: "valor");
        }
    }
}

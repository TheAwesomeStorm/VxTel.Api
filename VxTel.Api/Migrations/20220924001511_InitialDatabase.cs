using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VxTel.Api.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoDdd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Minutos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCidadeOrigem = table.Column<int>(type: "int", nullable: false),
                    IdCidadeDestino = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarifas_Cidades_IdCidadeDestino",
                        column: x => x.IdCidadeDestino,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarifas_Cidades_IdCidadeOrigem",
                        column: x => x.IdCidadeOrigem,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CodigoDdd",
                table: "Cidades",
                column: "CodigoDdd",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planos_Nome",
                table: "Planos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_IdCidadeDestino",
                table: "Tarifas",
                column: "IdCidadeDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_IdCidadeOrigem_IdCidadeDestino",
                table: "Tarifas",
                columns: new[] { "IdCidadeOrigem", "IdCidadeDestino" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}

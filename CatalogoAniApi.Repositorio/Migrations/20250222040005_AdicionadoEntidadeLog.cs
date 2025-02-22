using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoAniApi.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoEntidadeLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menssagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Excecao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensagemExcecao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeLancamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}

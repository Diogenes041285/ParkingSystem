using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingSystem.Data.Migrations
{
    public partial class MelhoriasentidadeCarros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manobras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manobras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    CarroId = table.Column<Guid>(nullable: false),
                    DataAlterado = table.Column<DateTime>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(nullable: true),
                    DataHoraSaida = table.Column<DateTime>(nullable: true),
                    ManobristaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manobras_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manobras_Manobristas_ManobristaId",
                        column: x => x.ManobristaId,
                        principalTable: "Manobristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manobras_CarroId",
                table: "Manobras",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Manobras_ManobristaId",
                table: "Manobras",
                column: "ManobristaId");
        }
    }
}

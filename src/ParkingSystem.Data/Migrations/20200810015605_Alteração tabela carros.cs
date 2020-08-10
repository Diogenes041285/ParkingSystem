using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingSystem.Data.Migrations
{
    public partial class Alteraçãotabelacarros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraEntrada",
                table: "Carros",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraSaida",
                table: "Carros",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManobristaEntradaId",
                table: "Carros",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ManobristaSaidaId",
                table: "Carros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ManobristaEntradaId",
                table: "Carros",
                column: "ManobristaEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ManobristaSaidaId",
                table: "Carros",
                column: "ManobristaSaidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Manobristas_ManobristaEntradaId",
                table: "Carros",
                column: "ManobristaEntradaId",
                principalTable: "Manobristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Manobristas_ManobristaSaidaId",
                table: "Carros",
                column: "ManobristaSaidaId",
                principalTable: "Manobristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Manobristas_ManobristaEntradaId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Manobristas_ManobristaSaidaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_ManobristaEntradaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_ManobristaSaidaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "DataHoraEntrada",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "DataHoraSaida",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ManobristaEntradaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ManobristaSaidaId",
                table: "Carros");
        }
    }
}

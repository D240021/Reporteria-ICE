using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICE.Capa_Datos.Migrations
{
    /// <inheritdoc />
    public partial class NuevosAtributosReporte_Evidencia_Causa_FechaHora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReporteCausa",
                table: "ReporteCausa");

            migrationBuilder.AddColumn<string>(
                name: "Causas",
                table: "Reporte",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Evidencia",
                table: "Reporte",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHora",
                table: "Reporte",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacionesTecnicoLinea",
                table: "Reporte",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReporteCausa",
                table: "ReporteCausa",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteCausa_ReporteId",
                table: "ReporteCausa",
                column: "ReporteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReporteCausa",
                table: "ReporteCausa");

            migrationBuilder.DropIndex(
                name: "IX_ReporteCausa_ReporteId",
                table: "ReporteCausa");

            migrationBuilder.DropColumn(
                name: "Causas",
                table: "Reporte");

            migrationBuilder.DropColumn(
                name: "Evidencia",
                table: "Reporte");

            migrationBuilder.DropColumn(
                name: "FechaHora",
                table: "Reporte");

            migrationBuilder.DropColumn(
                name: "ObservacionesTecnicoLinea",
                table: "Reporte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReporteCausa",
                table: "ReporteCausa",
                columns: new[] { "ReporteId", "CausaId" });
        }
    }
}

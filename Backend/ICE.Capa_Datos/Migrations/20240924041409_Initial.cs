using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICE.Capa_Datos.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Causa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorrientesDeFalla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealIR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RealIS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RealIT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcumuladaR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcumuladaS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcumuladaT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrientesDeFalla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatosDeLinea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aviso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SAP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Distancia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Funcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosDeLinea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatosGenerales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Subestacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Equipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosGenerales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistanciaDeFalla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistanciaKM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistanciaPorcentaje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistanciaReportada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistanciaDobleTemporal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Error = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Error_Doble = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistanciaDeFalla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineaTransmision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUbicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Identificador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaTransmision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destinatario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cuerpo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subestacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUbicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Identificador = table.Column<int>(type: "int", nullable: false),
                    UnidadRegionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subestacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teleproteccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_TEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RX_TEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TiempoMPLS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teleproteccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiemposDeDisparo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    S = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    T = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reserva = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiemposDeDisparo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadRegional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUbicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Identificador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadRegional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubestacionLineaTransmision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubestacionId = table.Column<int>(type: "int", nullable: false),
                    LineaTransmisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubestacionLineaTransmision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubestacionLineaTransmision_LineaTransmision_LineaTransmisionId",
                        column: x => x.LineaTransmisionId,
                        principalTable: "LineaTransmision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubestacionLineaTransmision_Subestacion_SubestacionId",
                        column: x => x.SubestacionId,
                        principalTable: "Subestacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasenia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Identificador = table.Column<int>(type: "int", nullable: false),
                    RollId = table.Column<int>(type: "int", nullable: false),
                    SubestacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RollId",
                        column: x => x.RollId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Subestacion_SubestacionId",
                        column: x => x.SubestacionId,
                        principalTable: "Subestacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Informe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    SubestacionId = table.Column<int>(type: "int", nullable: false),
                    LineaTransmisionId = table.Column<int>(type: "int", nullable: false),
                    DatosDeLineaId = table.Column<int>(type: "int", nullable: false),
                    DatosGeneralesId = table.Column<int>(type: "int", nullable: false),
                    TeleproteccionId = table.Column<int>(type: "int", nullable: false),
                    DistanciaDeFallaId = table.Column<int>(type: "int", nullable: false),
                    TiemposDeDisparoId = table.Column<int>(type: "int", nullable: false),
                    CorrientesDeFallaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informe_CorrientesDeFalla_CorrientesDeFallaId",
                        column: x => x.CorrientesDeFallaId,
                        principalTable: "CorrientesDeFalla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informe_DatosDeLinea_DatosDeLineaId",
                        column: x => x.DatosDeLineaId,
                        principalTable: "DatosDeLinea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Informe_DatosGenerales_DatosGeneralesId",
                        column: x => x.DatosGeneralesId,
                        principalTable: "DatosGenerales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informe_DistanciaDeFalla_DistanciaDeFallaId",
                        column: x => x.DistanciaDeFallaId,
                        principalTable: "DistanciaDeFalla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informe_LineaTransmision_LineaTransmisionId",
                        column: x => x.LineaTransmisionId,
                        principalTable: "LineaTransmision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Informe_Subestacion_SubestacionId",
                        column: x => x.SubestacionId,
                        principalTable: "Subestacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Informe_Teleproteccion_TeleproteccionId",
                        column: x => x.TeleproteccionId,
                        principalTable: "Teleproteccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Informe_TiemposDeDisparo_TiemposDeDisparoId",
                        column: x => x.TiemposDeDisparoId,
                        principalTable: "TiemposDeDisparo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapaDeDescargas = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InformeV1Id = table.Column<int>(type: "int", nullable: false),
                    InformeV2Id = table.Column<int>(type: "int", nullable: false),
                    InformeV3Id = table.Column<int>(type: "int", nullable: false),
                    InformeV4Id = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioSupervisorId = table.Column<int>(type: "int", nullable: false),
                    TecnicoLineaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_Informe_InformeV1Id",
                        column: x => x.InformeV1Id,
                        principalTable: "Informe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reporte_Informe_InformeV2Id",
                        column: x => x.InformeV2Id,
                        principalTable: "Informe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reporte_Informe_InformeV3Id",
                        column: x => x.InformeV3Id,
                        principalTable: "Informe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reporte_Informe_InformeV4Id",
                        column: x => x.InformeV4Id,
                        principalTable: "Informe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reporte_Usuario_TecnicoLineaId",
                        column: x => x.TecnicoLineaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reporte_Usuario_UsuarioSupervisorId",
                        column: x => x.UsuarioSupervisorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReporteCausa",
                columns: table => new
                {
                    ReporteId = table.Column<int>(type: "int", nullable: false),
                    CausaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteCausa", x => new { x.ReporteId, x.CausaId });
                    table.ForeignKey(
                        name: "FK_ReporteCausa_Causa_CausaId",
                        column: x => x.CausaId,
                        principalTable: "Causa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporteCausa_Reporte_ReporteId",
                        column: x => x.ReporteId,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informe_CorrientesDeFallaId",
                table: "Informe",
                column: "CorrientesDeFallaId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_DatosDeLineaId",
                table: "Informe",
                column: "DatosDeLineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_DatosGeneralesId",
                table: "Informe",
                column: "DatosGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_DistanciaDeFallaId",
                table: "Informe",
                column: "DistanciaDeFallaId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_LineaTransmisionId",
                table: "Informe",
                column: "LineaTransmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_SubestacionId",
                table: "Informe",
                column: "SubestacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_TeleproteccionId",
                table: "Informe",
                column: "TeleproteccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_TiemposDeDisparoId",
                table: "Informe",
                column: "TiemposDeDisparoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_InformeV1Id",
                table: "Reporte",
                column: "InformeV1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_InformeV2Id",
                table: "Reporte",
                column: "InformeV2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_InformeV3Id",
                table: "Reporte",
                column: "InformeV3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_InformeV4Id",
                table: "Reporte",
                column: "InformeV4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_TecnicoLineaId",
                table: "Reporte",
                column: "TecnicoLineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_UsuarioSupervisorId",
                table: "Reporte",
                column: "UsuarioSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteCausa_CausaId",
                table: "ReporteCausa",
                column: "CausaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubestacionLineaTransmision_LineaTransmisionId",
                table: "SubestacionLineaTransmision",
                column: "LineaTransmisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubestacionLineaTransmision_SubestacionId",
                table: "SubestacionLineaTransmision",
                column: "SubestacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RollId",
                table: "Usuario",
                column: "RollId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_SubestacionId",
                table: "Usuario",
                column: "SubestacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DropTable(
                name: "Notificacion");

            migrationBuilder.DropTable(
                name: "ReporteCausa");

            migrationBuilder.DropTable(
                name: "SubestacionLineaTransmision");

            migrationBuilder.DropTable(
                name: "UnidadRegional");

            migrationBuilder.DropTable(
                name: "Causa");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Informe");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "CorrientesDeFalla");

            migrationBuilder.DropTable(
                name: "DatosDeLinea");

            migrationBuilder.DropTable(
                name: "DatosGenerales");

            migrationBuilder.DropTable(
                name: "DistanciaDeFalla");

            migrationBuilder.DropTable(
                name: "LineaTransmision");

            migrationBuilder.DropTable(
                name: "Teleproteccion");

            migrationBuilder.DropTable(
                name: "TiemposDeDisparo");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Subestacion");
        }
    }
}

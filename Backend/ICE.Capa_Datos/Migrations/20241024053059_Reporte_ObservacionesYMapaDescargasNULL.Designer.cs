﻿// <auto-generated />
using System;
using ICE.Capa_Datos.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ICE.Capa_Datos.Migrations
{
    [DbContext(typeof(ICE_Context))]
    [Migration("20241024053059_Reporte_ObservacionesYMapaDescargasNULL")]
    partial class Reporte_ObservacionesYMapaDescargasNULL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.BitacoraDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Bitacora");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.CausaDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Causa");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.CorrientesDeFallaDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcumuladaR")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AcumuladaS")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AcumuladaT")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RealIR")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RealIS")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RealIT")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CorrientesDeFalla");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.DatosDeLineaDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aviso")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Distancia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Funcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OT")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SAP")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Zona")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DatosDeLinea");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.DatosGeneralesDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Equipo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Evento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("Hora")
                        .HasColumnType("time");

                    b.Property<string>("LT")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Subestacion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DatosGenerales");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.DistanciaDeFallaDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DistanciaDobleTemporal")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DistanciaKM")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DistanciaPorcentaje")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DistanciaReportada")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Error")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Error_Doble")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DistanciaDeFalla");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.InformeDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CorrientesDeFallaId")
                        .HasColumnType("int");

                    b.Property<int>("DatosDeLineaId")
                        .HasColumnType("int");

                    b.Property<int>("DatosGeneralesId")
                        .HasColumnType("int");

                    b.Property<int>("DistanciaDeFallaId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("LineaTransmisionId")
                        .HasColumnType("int");

                    b.Property<int>("SubestacionId")
                        .HasColumnType("int");

                    b.Property<int>("TeleproteccionId")
                        .HasColumnType("int");

                    b.Property<int>("TiemposDeDisparoId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorrientesDeFallaId");

                    b.HasIndex("DatosDeLineaId");

                    b.HasIndex("DatosGeneralesId");

                    b.HasIndex("DistanciaDeFallaId");

                    b.HasIndex("LineaTransmisionId");

                    b.HasIndex("SubestacionId");

                    b.HasIndex("TeleproteccionId");

                    b.HasIndex("TiemposDeDisparoId");

                    b.ToTable("Informe");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.LineaTransmisionDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Identificador")
                        .HasColumnType("int");

                    b.Property<string>("NombreUbicacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LineaTransmision");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.NotificacionDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Cuerpo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Destinatario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Notificacion");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.ReporteCausaDA", b =>
                {
                    b.Property<int>("ReporteId")
                        .HasColumnType("int");

                    b.Property<int>("CausaId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("ReporteId", "CausaId");

                    b.HasIndex("CausaId");

                    b.ToTable("ReporteCausa");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.ReporteDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("InformeV1Id")
                        .HasColumnType("int");

                    b.Property<int>("InformeV2Id")
                        .HasColumnType("int");

                    b.Property<int>("InformeV3Id")
                        .HasColumnType("int");

                    b.Property<int>("InformeV4Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("MapaDeDescargas")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TecnicoLineaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioSupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InformeV1Id");

                    b.HasIndex("InformeV2Id");

                    b.HasIndex("InformeV3Id");

                    b.HasIndex("InformeV4Id");

                    b.HasIndex("TecnicoLineaId");

                    b.HasIndex("UsuarioSupervisorId");

                    b.ToTable("Reporte");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.RolDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.SubestacionDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Identificador")
                        .HasColumnType("int");

                    b.Property<string>("NombreUbicacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UnidadRegionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subestacion");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.SubestacionLineaTransmisionDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LineaTransmisionId")
                        .HasColumnType("int");

                    b.Property<int>("SubestacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LineaTransmisionId");

                    b.HasIndex("SubestacionId");

                    b.ToTable("SubestacionLineaTransmision");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.TeleproteccionDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RX_TEL")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TX_TEL")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TiempoMPLS")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Teleproteccion");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.TiemposDeDisparoDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("R")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Reserva")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("S")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("T")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TiemposDeDisparo");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.UnidadRegionalDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Identificador")
                        .HasColumnType("int");

                    b.Property<string>("NombreUbicacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UnidadRegional");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.UsuarioDA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Identificador")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RollId")
                        .HasColumnType("int");

                    b.Property<int>("SubestacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RollId");

                    b.HasIndex("SubestacionId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.InformeDA", b =>
                {
                    b.HasOne("ICE.Capa_Datos.Entidades.CorrientesDeFallaDA", "CorrientesDeFalla")
                        .WithMany()
                        .HasForeignKey("CorrientesDeFallaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.DatosDeLineaDA", "DatosDeLinea")
                        .WithMany()
                        .HasForeignKey("DatosDeLineaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.DatosGeneralesDA", "DatosGenerales")
                        .WithMany()
                        .HasForeignKey("DatosGeneralesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.DistanciaDeFallaDA", "DistanciaDeFalla")
                        .WithMany()
                        .HasForeignKey("DistanciaDeFallaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.LineaTransmisionDA", "LineaTransmision")
                        .WithMany()
                        .HasForeignKey("LineaTransmisionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.SubestacionDA", "Subestacion")
                        .WithMany()
                        .HasForeignKey("SubestacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.TeleproteccionDA", "Teleproteccion")
                        .WithMany()
                        .HasForeignKey("TeleproteccionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.TiemposDeDisparoDA", "TiemposDeDisparo")
                        .WithMany()
                        .HasForeignKey("TiemposDeDisparoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorrientesDeFalla");

                    b.Navigation("DatosDeLinea");

                    b.Navigation("DatosGenerales");

                    b.Navigation("DistanciaDeFalla");

                    b.Navigation("LineaTransmision");

                    b.Navigation("Subestacion");

                    b.Navigation("Teleproteccion");

                    b.Navigation("TiemposDeDisparo");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.ReporteCausaDA", b =>
                {
                    b.HasOne("ICE.Capa_Datos.Entidades.CausaDA", "Causa")
                        .WithMany()
                        .HasForeignKey("CausaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.ReporteDA", "Reporte")
                        .WithMany()
                        .HasForeignKey("ReporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Causa");

                    b.Navigation("Reporte");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.ReporteDA", b =>
                {
                    b.HasOne("ICE.Capa_Datos.Entidades.InformeDA", "InformeV1")
                        .WithMany()
                        .HasForeignKey("InformeV1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.InformeDA", "InformeV2")
                        .WithMany()
                        .HasForeignKey("InformeV2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.InformeDA", "InformeV3")
                        .WithMany()
                        .HasForeignKey("InformeV3Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.InformeDA", "InformeV4")
                        .WithMany()
                        .HasForeignKey("InformeV4Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.UsuarioDA", "TecnicoLinea")
                        .WithMany()
                        .HasForeignKey("TecnicoLineaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.UsuarioDA", "UsuarioSupervisor")
                        .WithMany()
                        .HasForeignKey("UsuarioSupervisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InformeV1");

                    b.Navigation("InformeV2");

                    b.Navigation("InformeV3");

                    b.Navigation("InformeV4");

                    b.Navigation("TecnicoLinea");

                    b.Navigation("UsuarioSupervisor");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.SubestacionLineaTransmisionDA", b =>
                {
                    b.HasOne("ICE.Capa_Datos.Entidades.LineaTransmisionDA", "LineaTransmision")
                        .WithMany()
                        .HasForeignKey("LineaTransmisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.SubestacionDA", "Subestacion")
                        .WithMany()
                        .HasForeignKey("SubestacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LineaTransmision");

                    b.Navigation("Subestacion");
                });

            modelBuilder.Entity("ICE.Capa_Datos.Entidades.UsuarioDA", b =>
                {
                    b.HasOne("ICE.Capa_Datos.Entidades.RolDA", "Rol")
                        .WithMany()
                        .HasForeignKey("RollId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ICE.Capa_Datos.Entidades.SubestacionDA", "Subestacion")
                        .WithMany()
                        .HasForeignKey("SubestacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Subestacion");
                });
#pragma warning restore 612, 618
        }
    }
}

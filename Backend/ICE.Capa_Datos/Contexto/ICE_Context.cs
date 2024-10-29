using ICE.Capa_Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Contexto
{
    public class ICE_Context : DbContext
    {
        public ICE_Context(DbContextOptions<ICE_Context> options) : base(options) { }

        // Definir DbSet para cada entidad
        public DbSet<UsuarioDA> Usuarios { get; set; }
        public DbSet<UnidadRegionalDA> UnidadesRegionales { get; set; }
        public DbSet<SubestacionDA> Subestaciones { get; set; }
        public DbSet<NotificacionDA> Notificaciones { get; set; }
        public DbSet<BitacoraDA> Bitacoras { get; set; }
        public DbSet<SubestacionLineaTransmisionDA> SubestacionLineaTransmisiones { get; set; }
        public DbSet<LineaTransmisionDA> LineasTransmision { get; set; }
        public DbSet<DatosDeLineaDA> DatosDeLinea { get; set; }
        public DbSet<TeleproteccionDA> Teleprotecciones { get; set; }
        public DbSet<DistanciaDeFallaDA> DistanciasDeFalla { get; set; }
        public DbSet<CorrientesDeFallaDA> CorrientesDeFalla { get; set; }
        public DbSet<TiemposDeDisparoDA> TiemposDeDisparo { get; set; }
        public DbSet<ReporteDA> Reportes { get; set; }
        public DbSet<InformeDA> Informes { get; set; }
        public DbSet<CausaDA> Causas { get; set; }
        public DbSet<ReporteCausaDA> ReporteCausas { get; set; }
        public DbSet<DatosGeneralesDA> DatosGenerales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de clave compuesta para la tabla ReporteCausaDA
            modelBuilder.Entity<ReporteCausaDA>()
                .HasKey(rc => new { rc.ReporteId, rc.CausaId });

            // Configuración para evitar múltiples rutas de cascada en la tabla `ReporteDA`
            modelBuilder.Entity<ReporteDA>()
                .HasOne(r => r.InformeV1)
                .WithMany()
                .HasForeignKey(r => r.InformeV1Id)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar cascada a Restrict

            modelBuilder.Entity<ReporteDA>()
                .HasOne(r => r.InformeV2)
                .WithMany()
                .HasForeignKey(r => r.InformeV2Id)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar cascada a Restrict

            modelBuilder.Entity<ReporteDA>()
                .HasOne(r => r.InformeV3)
                .WithMany()
                .HasForeignKey(r => r.InformeV3Id)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar cascada a Restrict

            modelBuilder.Entity<ReporteDA>()
                .HasOne(r => r.InformeV4)
                .WithMany()
                .HasForeignKey(r => r.InformeV4Id)
                .OnDelete(DeleteBehavior.Restrict); // Cambiar cascada a Restrict

            // Configuración de relaciones entre Reporte y Usuario
            modelBuilder.Entity<ReporteDA>()
                .HasOne(r => r.UsuarioSupervisor)
                .WithMany()
                .HasForeignKey(r => r.UsuarioSupervisorId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascada para UsuarioSupervisor

            modelBuilder.Entity<ReporteDA>()
                .HasOne(r => r.TecnicoLinea)
                .WithMany()
                .HasForeignKey(r => r.TecnicoLineaId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascada para TecnicoLinea

            modelBuilder.Entity<UsuarioDA>()
                .HasOne(u => u.Subestacion)
                .WithMany()
                .HasForeignKey(u => u.SubestacionId)
                .OnDelete(DeleteBehavior.Restrict); // Relación Usuario-Subestacion

            // Configuración de relaciones para InformeDA
            modelBuilder.Entity<InformeDA>()
                .HasOne(i => i.Subestacion)
                .WithMany()
                .HasForeignKey(i => i.SubestacionId)
                .OnDelete(DeleteBehavior.Restrict); // Relación Informe-Subestacion

            modelBuilder.Entity<InformeDA>()
                .HasOne(i => i.LineaTransmision)
                .WithMany()
                .HasForeignKey(i => i.LineaTransmisionId)
                .OnDelete(DeleteBehavior.Restrict); // Relación Informe-LineaTransmision

            modelBuilder.Entity<InformeDA>()
                .HasOne(i => i.DatosDeLinea)
                .WithMany()
                .HasForeignKey(i => i.DatosDeLineaId)
                .OnDelete(DeleteBehavior.Restrict); // Relación Informe-DatosDeLinea

            modelBuilder.Entity<InformeDA>()
                .HasOne(i => i.Teleproteccion)
                .WithMany()
                .HasForeignKey(i => i.TeleproteccionId)
                .OnDelete(DeleteBehavior.Restrict); // Relación Informe-Teleproteccion

        }
    }
}

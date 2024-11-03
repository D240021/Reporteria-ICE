using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarReporteDA : IGestionarReporteDA
    {
        private readonly ICE_Context _context;

        public GestionarReporteDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarReporte(Reporte reporte)
        {
            var reporteDA = new ReporteDA
            {
                MapaDeDescargas = reporte.MapaDeDescargas,
                Observaciones = reporte.Observaciones,
                InformeV1Id = reporte.InformeV1Id,
                InformeV2Id = reporte.InformeV2Id,
                InformeV3Id = reporte.InformeV3Id,
                InformeV4Id = reporte.InformeV4Id,
                Estado = reporte.Estado,
                UsuarioSupervisorId = reporte.UsuarioSupervisorId,
                TecnicoLineaId = reporte.TecnicoLineaId
            };

            _context.Reportes.Add(reporteDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarReporte(int id, Reporte reporte)
        {
            var reporteBD = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == id);
            if (reporteBD != null)
            {
                reporteBD.MapaDeDescargas = reporte.MapaDeDescargas;
                reporteBD.Observaciones = reporte.Observaciones;
                reporteBD.InformeV1Id = reporte.InformeV1Id;
                reporteBD.InformeV2Id = reporte.InformeV2Id;
                reporteBD.InformeV3Id = reporte.InformeV3Id;
                reporteBD.InformeV4Id = reporte.InformeV4Id;
                reporteBD.Estado = reporte.Estado;
                reporteBD.UsuarioSupervisorId = reporte.UsuarioSupervisorId;
                reporteBD.TecnicoLineaId = reporte.TecnicoLineaId;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarReporte(int id)
        {
            var reporteBD = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == id);
            if (reporteBD != null)
            {
                _context.Reportes.Remove(reporteBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Reporte> ObtenerReportePorId(int id)
        {
            var reporteBD = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == id);
            if (reporteBD == null)
            {
                return null;
            }

            return new Reporte
            {
                Id = reporteBD.Id,
                MapaDeDescargas = reporteBD.MapaDeDescargas,
                Observaciones = reporteBD.Observaciones,
                InformeV1Id = reporteBD.InformeV1Id,
                InformeV2Id = reporteBD.InformeV2Id,
                InformeV3Id = reporteBD.InformeV3Id,
                InformeV4Id = reporteBD.InformeV4Id,
                Estado = reporteBD.Estado,
                UsuarioSupervisorId = reporteBD.UsuarioSupervisorId,
                TecnicoLineaId = reporteBD.TecnicoLineaId
            };
        }

        public async Task<IEnumerable<Reporte>> ObtenerTodosLosReportes()
        {
            var reportesBD = await _context.Reportes.ToListAsync();

            return reportesBD.Select(reporteBD => new Reporte
            {
                Id = reporteBD.Id,
                MapaDeDescargas = reporteBD.MapaDeDescargas,
                Observaciones = reporteBD.Observaciones,
                InformeV1Id = reporteBD.InformeV1Id,
                InformeV2Id = reporteBD.InformeV2Id,
                InformeV3Id = reporteBD.InformeV3Id,
                InformeV4Id = reporteBD.InformeV4Id,
                Estado = reporteBD.Estado,
                UsuarioSupervisorId = reporteBD.UsuarioSupervisorId,
                TecnicoLineaId = reporteBD.TecnicoLineaId
            }).ToList();
        }


        public async Task<IEnumerable<int>> ObtenerIdsInformesDeReporte(int informeId)
        {
            //Se busca el reporte con el id asociado
            var reporte = await _context.Reportes
                .Where(r => r.InformeV1Id == informeId || r.InformeV2Id == informeId || r.InformeV3Id == informeId || r.InformeV4Id == informeId)
                .Select(r => new List<int> { r.InformeV1Id, r.InformeV2Id, r.InformeV3Id, r.InformeV4Id })
                .FirstOrDefaultAsync();

            //Si no se ecuentra el reporte, se obtiene una lista vacia
            return reporte ?? new List<int>();
        }


        public async Task<Reporte> ObtenerReportePorInformeId(int informeId)
        {
            // Buscar el reporte que contenga el informeId en cualquiera de los cuatro campos de informe
            var reporteBD = await _context.Reportes
                .FirstOrDefaultAsync(r => r.InformeV1Id == informeId ||
                                          r.InformeV2Id == informeId ||
                                          r.InformeV3Id == informeId ||
                                          r.InformeV4Id == informeId);
            
            if (reporteBD == null)
            {
                return null;
            }
            return new Reporte
            {
                Id = reporteBD.Id,
                MapaDeDescargas = reporteBD.MapaDeDescargas,
                Observaciones = reporteBD.Observaciones,
                InformeV1Id = reporteBD.InformeV1Id,
                InformeV2Id = reporteBD.InformeV2Id,
                InformeV3Id = reporteBD.InformeV3Id,
                InformeV4Id = reporteBD.InformeV4Id,
                Estado = reporteBD.Estado,
                UsuarioSupervisorId = reporteBD.UsuarioSupervisorId,
                TecnicoLineaId = reporteBD.TecnicoLineaId
            };
        }

    }
}

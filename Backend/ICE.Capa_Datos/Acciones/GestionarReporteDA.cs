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
            // Verificar si el reporte existe
            var reporteBD = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == id);
            if (reporteBD == null)
            {
                return false;
            }

            // Validar las referencias antes de la actualización (FK)
            var resultadoValidacion = await ValidarReporteReferencias(reporte);
            if (!resultadoValidacion)
            {
                return false;
            }
            // Actualizar el reporte existente
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

        //Metodos de Validacion

        // Validar que el ID de Informe realmente exista en la tabla Informes
        private async Task<bool> ValidarExistenciaInforme(int informeId)
        {
            return await _context.Informes.AnyAsync(i => i.Id == informeId);
        }

        // Validar que el Usuario Supervisor realmente exista en la tabla Usuarios
        private async Task<bool> ValidarExistenciaUsuarioSupervisor(int usuarioSupervisorId)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == usuarioSupervisorId);
        }

        // Validar que el Técnico de Línea realmente exista en la tabla Usuarios
        private async Task<bool> ValidarExistenciaTecnicoLinea(int tecnicoLineaId)
        {
            return await _context.Usuarios.AnyAsync(t => t.Id == tecnicoLineaId);
        }

        // Validar que los informes asociados a un reporte específico coincidan con los IDs proporcionados
        private async Task<bool> ValidarInformesEnReporte(int reporteId, int informeV1Id, int informeV2Id, int informeV3Id, int informeV4Id)
        {
            return await _context.Reportes.AnyAsync(r =>
                r.Id == reporteId &&
                r.InformeV1Id == informeV1Id &&
                r.InformeV2Id == informeV2Id &&
                r.InformeV3Id == informeV3Id &&
                r.InformeV4Id == informeV4Id);
        }

        // Método principal de validación de referencias del reporte
        private async Task<bool> ValidarReporteReferencias(Reporte reporte)
        {
            // Validar que los informes existen en la tabla Informes
            bool informeV1Existe = await ValidarExistenciaInforme(reporte.InformeV1Id);
            bool informeV2Existe = await ValidarExistenciaInforme(reporte.InformeV2Id);
            bool informeV3Existe = await ValidarExistenciaInforme(reporte.InformeV3Id);
            bool informeV4Existe = await ValidarExistenciaInforme(reporte.InformeV4Id);

            // Validar que los usuarios existen en la tabla Usuarios
            bool usuarioSupervisorExiste = await ValidarExistenciaUsuarioSupervisor(reporte.UsuarioSupervisorId);
            bool tecnicoLineaExiste = await ValidarExistenciaTecnicoLinea(reporte.TecnicoLineaId);

            // Validar que los informes coincidan con los IDs en el Reporte
            bool informesEnReporteValidos = await ValidarInformesEnReporte(reporte.Id, reporte.InformeV1Id, reporte.InformeV2Id, reporte.InformeV3Id, reporte.InformeV4Id);

            // Retornar true solo si todos los valores existen y coinciden
            return informeV1Existe && informeV2Existe && informeV3Existe && informeV4Existe &&
                   usuarioSupervisorExiste && tecnicoLineaExiste && informesEnReporteValidos;
        }


        private bool ValidarIdsSupervisorYTecnico(Reporte reporte)
        {
            return reporte.UsuarioSupervisorId > 0 && reporte.TecnicoLineaId > 0;
        }

    }
}

using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarReporteDA
    {
        Task<bool> RegistrarReporte(Reporte reporte);
        Task<bool> ActualizarReporte(int id, Reporte reporte);
        Task<bool> EliminarReporte(int id);
        Task<Reporte> ObtenerReportePorId(int id);
        Task<IEnumerable<Reporte>> ObtenerTodosLosReportes();
        Task<IEnumerable<int>> ObtenerIdsInformesDeReporte(int informeId);
        Task<Reporte> ObtenerReportePorInformeId(int informeId);
        Task<IEnumerable<int>> ObtenerIdsInformesAsociadosPorReporteId(int reporteId);
    }
}

using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarReporteCN
    {
        Task<bool> RegistrarReporte(Reporte reporte);
        Task<bool> ActualizarReporte(int id, Reporte reporte);
        Task<bool> EliminarReporte(int id);
        Task<Reporte> ObtenerReportePorId(int id);
        Task<IEnumerable<Reporte>> ObtenerTodosLosReportes();
    }
}

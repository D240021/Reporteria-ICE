using ICE.Capa_Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarReporteCausaDA
    {        
        Task<bool> RegistrarReporteCausa(int reporteId, int causaId);     
        Task<IEnumerable<Causa>> ObtenerCausasPorReporteId(int reporteId);        
        Task<IEnumerable<Reporte>> ObtenerReportesPorCausaId(int causaId);        
        Task<bool> ActualizarReporteCausa(int id, int nuevoReporteId, int nuevaCausaId);
        Task<bool> EliminarReporteCausa(int id);
    }
}

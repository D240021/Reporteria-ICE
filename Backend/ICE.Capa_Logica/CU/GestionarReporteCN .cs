using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarReporteCN : IGestionarReporteCN
    {
        private readonly IGestionarReporteDA _gestionarReporteDA;

        public GestionarReporteCN(IGestionarReporteDA gestionarReporteDA)
        {
            _gestionarReporteDA = gestionarReporteDA;
        }

        public async Task<bool> RegistrarReporte(Reporte reporte)
        {
            return await _gestionarReporteDA.RegistrarReporte(reporte);
        }

        public async Task<bool> ActualizarReporte(int id, Reporte reporte)
        {
            return await _gestionarReporteDA.ActualizarReporte(id, reporte);
        }

        public async Task<bool> EliminarReporte(int id)
        {
            return await _gestionarReporteDA.EliminarReporte(id);
        }

        public async Task<Reporte> ObtenerReportePorId(int id)
        {
            return await _gestionarReporteDA.ObtenerReportePorId(id);
        }

        public async Task<IEnumerable<Reporte>> ObtenerTodosLosReportes()
        {
            return await _gestionarReporteDA.ObtenerTodosLosReportes();
        }
    }
}

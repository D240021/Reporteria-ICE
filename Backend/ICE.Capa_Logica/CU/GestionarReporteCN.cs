using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Collections.Generic;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarReporteCN : IGestionarReporteCN
    {
        private readonly IGestionarReporteDA _gestionarReporteDA;

        //Servicio de Informes y Reportes
        private readonly IGestionarReporteConInformesService _gestionarReporteConInformesService;

        public GestionarReporteCN(IGestionarReporteDA gestionarReporteDA, IGestionarReporteConInformesService gestionarReporteConInformesService)
        {
            _gestionarReporteDA = gestionarReporteDA;
            _gestionarReporteConInformesService = gestionarReporteConInformesService;
        }

        public async Task<bool> RegistrarReporte(Reporte reporte)
        {

            var reporteActualizado = ReglasReporte.ActualizarEstadoReporte(reporte);
            if (!reporteActualizado.esValido)
            {
                return reporteActualizado.esValido;
            }
            return await _gestionarReporteDA.RegistrarReporte(reporte);
        }

        public async Task<bool> ActualizarReporte(int id, Reporte reporte)
        {

            var validacionReporte = ReglasReporte.EsReporteValido(reporte);
            if (!validacionReporte.esValido)
            {
                return validacionReporte.esValido;
            }
            //erificar si los informes del reporte estan completos
            var validacionInformesDeReporte =  await _gestionarReporteConInformesService.VerificarInformesCompletosAsociados(reporte.InformeV1Id);

            if (!validacionInformesDeReporte)
            {
                return validacionInformesDeReporte;
            }

            // Actualizar el estado del reporte según los informes asociados
            var resultadoActualizacion = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);
            return resultadoActualizacion;
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

        public async Task<IEnumerable<int>> ObtenerIdsInformesDeReporte(int informeId)
        {
            // Llamada al método de la capa de datos para obtener los IDs de los informes asociados al reporte
            return await _gestionarReporteDA.ObtenerIdsInformesDeReporte(informeId);
        }        
    }
}

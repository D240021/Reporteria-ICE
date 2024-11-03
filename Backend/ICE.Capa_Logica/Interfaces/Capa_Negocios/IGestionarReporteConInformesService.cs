using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarReporteConInformesService
    {
        Task<bool> RegistrarReporteConInformes(Reporte reporte, List<int> subestacionIds, int lineaTransmisionId);
        Task VerificarEstadoInformesAsociados(int informeId);

        /// <summary>
        /// Verifica si al menos uno de los informes asociados a un reporte está completo.
        /// </summary>
        Task<bool> VerificarInformesCompletosAsociados(int informeId);

        /// <summary>
        /// Cambia el estado de todos los informes asociados a "pendiente" si no hay informes completos.
        /// </summary>
        Task<bool> ActualizarEstadosDeInformesAPendiente(int informeId);

        Task<bool> VerificarEstadoInformesDeReporte(int reporteId);
        Task<(bool esValido, string mensaje)> ActualizarEstadoReporteSegunInformes(Reporte reporte);
        Task<Reporte> ObtenerReportePorInformeId(int informeId);
    }
}

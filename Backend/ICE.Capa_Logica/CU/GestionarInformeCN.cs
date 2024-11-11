using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarInformeCN : IGestionarInformeCN
    {
        private readonly IGestionarInformeDA _gestionarInformeDA;
        private readonly IGestionarTeleproteccionDA _gestionarTeleproteccionDA;
        private readonly IGestionarDistanciaDeFallaDA _gestionarDistanciaDeFallaDA;
        private readonly IGestionarCorrientesDeFallaDA _gestionarCorrientesDeFallaDA;
        private readonly IGestionarTiemposDeDisparoDA _gestionarTiemposDeDisparoDA;
        private readonly IGestionarLineasTransmisionDA _gestionarLineaTransmisionDA;
        private readonly IGestionarDatosDeLineaDA _gestionarDatosDeLineaDA;
        private readonly IGestionarDatosGeneralesDA _gestionarDatosGeneralesDA;
        
        private readonly IGestionarReporteConInformesService _gestionarReporteConInformesService;


        public GestionarInformeCN(
            IGestionarInformeDA gestionarInformeDA,
            IGestionarTeleproteccionDA gestionarTeleproteccionDA,
            IGestionarDistanciaDeFallaDA gestionarDistanciaDeFallaDA,
            IGestionarCorrientesDeFallaDA gestionarCorrientesDeFallaDA,
            IGestionarTiemposDeDisparoDA gestionarTiemposDeDisparoDA,
            IGestionarLineasTransmisionDA gestionarLineaTransmisionDA,
            IGestionarDatosDeLineaDA gestionarDatosDeLineaDA,
            IGestionarDatosGeneralesDA gestionarDatosGeneralesDA,
            IGestionarReporteConInformesService gestionarReporteConInformesService)
        {
            _gestionarInformeDA = gestionarInformeDA;
            _gestionarTeleproteccionDA = gestionarTeleproteccionDA;
            _gestionarDistanciaDeFallaDA = gestionarDistanciaDeFallaDA;
            _gestionarCorrientesDeFallaDA = gestionarCorrientesDeFallaDA;
            _gestionarTiemposDeDisparoDA = gestionarTiemposDeDisparoDA;
            _gestionarLineaTransmisionDA = gestionarLineaTransmisionDA;
            _gestionarDatosDeLineaDA = gestionarDatosDeLineaDA;
            _gestionarDatosGeneralesDA = gestionarDatosGeneralesDA;
            _gestionarReporteConInformesService = gestionarReporteConInformesService;
        }

        public async Task<int> RegistrarInformeCompleto(Informe informe)
        {
            //Los datos de "informe" se han generado en la clase GestionarReporteConInformeService                        
            return await _gestionarInformeDA.RegistrarInforme(informe);
        }

        public async Task<Informe> ObtenerInformePorId(int id)
        {
            return await _gestionarInformeDA.ObtenerInformePorId(id);
        }

        public async Task<bool> ActualizarInforme(Informe informe)
        {
            // Validación del informe
            var (esValido, mensaje) = ReglasInforme.EsInformeValido(informe);
            if (!esValido)
                return false;

            // Cambiar el estado del informe a "confirmado"
            ReglasInforme.CambiarEstadoAConfirmado(informe);

            // Actualizar el informe en la base de datos
            bool esInformeActualizado = await _gestionarInformeDA.ActualizarInforme(informe.Id, informe);
            if (!esInformeActualizado)
                return false;

            // Verificar si los 4 informes asociados a un reporte estan confirmados, de ser asi, revisar tambien que al menos uno de los 4 no tenga instancias anidadas con
            //datos nulos
            await _gestionarReporteConInformesService.VerificarEstadoInformesAsociados(informe.Id);

            return true;
        }

        public async Task<bool> EliminarInforme(int id)
        {
            var informe = await ObtenerInformePorId(id);
            if (informe != null)
            {
                await _gestionarTeleproteccionDA.EliminarTeleproteccion(informe.Teleproteccion.Id);
                await _gestionarDistanciaDeFallaDA.EliminarDistanciaDeFalla(informe.DistanciaDeFalla.Id);
                await _gestionarCorrientesDeFallaDA.EliminarCorrientesDeFalla(informe.CorrientesDeFalla.Id);
                await _gestionarTiemposDeDisparoDA.EliminarTiemposDeDisparo(informe.TiemposDeDisparo.Id);
                await _gestionarDatosDeLineaDA.EliminarDatosDeLinea(informe.DatosDeLinea.Id);
                await _gestionarDatosGeneralesDA.EliminarDatosGenerales(informe.DatosGenerales.Id);

                return await _gestionarInformeDA.EliminarInforme(id);
            }
            return false;
        }

        public async Task<List<Informe>> ObtenerInformesPendientesPorSubestacion(int subestacionId)
        {
            return await _gestionarInformeDA.ObtenerInformesPendientesPorSubestacion(subestacionId);
        }

        public async Task<List<Informe>> ObtenerInformesPorSubestacion(int subestacionId)
        {
            return await _gestionarInformeDA.ObtenerInformesPorSubestacion(subestacionId);
        }
    }
}

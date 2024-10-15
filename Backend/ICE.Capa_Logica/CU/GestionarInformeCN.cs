using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
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

        public GestionarInformeCN(
            IGestionarInformeDA gestionarInformeDA,
            IGestionarTeleproteccionDA gestionarTeleproteccionDA,
            IGestionarDistanciaDeFallaDA gestionarDistanciaDeFallaDA,
            IGestionarCorrientesDeFallaDA gestionarCorrientesDeFallaDA,
            IGestionarTiemposDeDisparoDA gestionarTiemposDeDisparoDA,
            IGestionarLineasTransmisionDA gestionarLineaTransmisionDA,
            IGestionarDatosDeLineaDA gestionarDatosDeLineaDA,
            IGestionarDatosGeneralesDA gestionarDatosGeneralesDA)
        {
            _gestionarInformeDA = gestionarInformeDA;
            _gestionarTeleproteccionDA = gestionarTeleproteccionDA;
            _gestionarDistanciaDeFallaDA = gestionarDistanciaDeFallaDA;
            _gestionarCorrientesDeFallaDA = gestionarCorrientesDeFallaDA;
            _gestionarTiemposDeDisparoDA = gestionarTiemposDeDisparoDA;
            _gestionarLineaTransmisionDA = gestionarLineaTransmisionDA;
            _gestionarDatosDeLineaDA = gestionarDatosDeLineaDA;
            _gestionarDatosGeneralesDA = gestionarDatosGeneralesDA;
        }

        public async Task<bool> RegistrarInformeCompleto(Informe informe)
        {
            await _gestionarTeleproteccionDA.RegistrarTeleproteccion(informe.Teleproteccion);
            await _gestionarDistanciaDeFallaDA.RegistrarDistanciaDeFalla(informe.DistanciaDeFalla);
            await _gestionarCorrientesDeFallaDA.RegistrarCorrientesDeFalla(informe.CorrientesDeFalla);
            await _gestionarTiemposDeDisparoDA.RegistrarTiemposDeDisparo(informe.TiemposDeDisparo);
            await _gestionarDatosDeLineaDA.RegistrarDatosDeLinea(informe.DatosDeLinea);
            await _gestionarDatosGeneralesDA.RegistrarDatosGenerales(informe.DatosGenerales);

            return await _gestionarInformeDA.RegistrarInforme(informe);
        }

        public async Task<Informe> ObtenerInformePorId(int id)
        {
            return await _gestionarInformeDA.ObtenerInformePorId(id);
        }

        public async Task<bool> ActualizarInforme(Informe informe)
        {
            await _gestionarTeleproteccionDA.ActualizarTeleproteccion(informe.TeleproteccionId, informe.Teleproteccion);
            await _gestionarDistanciaDeFallaDA.ActualizarDistanciaDeFalla(informe.DistanciaDeFallaId, informe.DistanciaDeFalla);
            await _gestionarCorrientesDeFallaDA.ActualizarCorrientesDeFalla(informe.CorrientesDeFallaId, informe.CorrientesDeFalla);
            await _gestionarTiemposDeDisparoDA.ActualizarTiemposDeDisparo(informe.TiemposDeDisparoId, informe.TiemposDeDisparo);
            await _gestionarDatosDeLineaDA.ActualizarDatosDeLinea(informe.DatosDeLineaId, informe.DatosDeLinea);
            await _gestionarDatosGeneralesDA.ActualizarDatosGenerales(informe.DatosGeneralesId, informe.DatosGenerales);

            return await _gestionarInformeDA.ActualizarInforme(informe.Id, informe);
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
    }
}

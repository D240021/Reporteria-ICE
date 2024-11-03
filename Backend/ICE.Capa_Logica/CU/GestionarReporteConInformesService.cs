using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{

    public class GestionarReporteConInformesService: IGestionarReporteConInformesService
    {
        //private readonly IGestionarReporteCN _gestionarReporteCN;
        //private readonly IGestionarInformeCN _gestionarInformeCN;
        
        private readonly IGestionarInformeDA _gestionarInformeDA;
        private readonly IGestionarReporteDA _gestionarReporteDA;
        private readonly IGestionarTeleproteccionDA _gestionarTeleproteccionDA;
        private readonly IGestionarDistanciaDeFallaDA _gestionarDistanciaDeFallaDA;
        private readonly IGestionarCorrientesDeFallaDA _gestionarCorrientesDeFallaDA;
        private readonly IGestionarTiemposDeDisparoDA _gestionarTiemposDeDisparoDA;
        private readonly IGestionarLineasTransmisionDA _gestionarLineaTransmisionDA;
        private readonly IGestionarDatosDeLineaDA _gestionarDatosDeLineaDA;
        private readonly IGestionarDatosGeneralesDA _gestionarDatosGeneralesDA;

        //IGestionarReporteCN gestionarReporteCN,
          //IGestionarInformeCN gestionarInformeCN,

        public GestionarReporteConInformesService(
           
            IGestionarInformeDA gestionarInformeDA,
            IGestionarReporteDA gestionarReporteDA,
            IGestionarTeleproteccionDA gestionarTeleproteccionDA,
            IGestionarDistanciaDeFallaDA gestionarDistanciaDeFallaDA,
            IGestionarCorrientesDeFallaDA gestionarCorrientesDeFallaDA,
            IGestionarTiemposDeDisparoDA gestionarTiemposDeDisparoDA,
            IGestionarLineasTransmisionDA gestionarLineaTransmisionDA,
            IGestionarDatosDeLineaDA gestionarDatosDeLineaDA,
            IGestionarDatosGeneralesDA gestionarDatosGeneralesDA)
        {
            //_gestionarReporteCN = gestionarReporteCN;
            //_gestionarInformeCN = gestionarInformeCN;

            _gestionarInformeDA = gestionarInformeDA;
            _gestionarReporteDA = gestionarReporteDA;
            _gestionarTeleproteccionDA = gestionarTeleproteccionDA;
            _gestionarDistanciaDeFallaDA = gestionarDistanciaDeFallaDA;
            _gestionarCorrientesDeFallaDA = gestionarCorrientesDeFallaDA;
            _gestionarTiemposDeDisparoDA = gestionarTiemposDeDisparoDA;
            _gestionarLineaTransmisionDA = gestionarLineaTransmisionDA;
            _gestionarDatosDeLineaDA = gestionarDatosDeLineaDA;
            _gestionarDatosGeneralesDA = gestionarDatosGeneralesDA;

        }

        //Aqui no se deben aplicar las Reglas de Informe , ya que deben crearse con valores nulos en un inicio para ser actualizados despues
        public async Task<bool> RegistrarReporteConInformes(Reporte reporte, List<int> subestacionIds, int lineaTransmisionId)
        {
            try
            {
                //lista de informes
                List<Informe> informes = new List<Informe>();

                //cada vuelta es una subestacion
                for (int i = 0; i < subestacionIds.Count; i++)
                {
                    //datos del informe impedancia (tipo 1)
                    var datosDeLinea1 = new DatosDeLinea();
                    var datosGenerales1 = new DatosGenerales();
                    var teleproteccion1 = new Teleproteccion();
                    var distanciaDeFalla1 = new DistanciaDeFalla();
                    var tiemposDeDisparo1 = new TiemposDeDisparo();
                    var corrientesDeFalla1 = new CorrientesDeFalla();


                    //cada nuevo grupo de datos se guarda en la BD                    
                    datosDeLinea1.Id = await _gestionarDatosDeLineaDA.RegistrarDatosDeLinea(datosDeLinea1);
                    datosGenerales1.Id = await _gestionarDatosGeneralesDA.RegistrarDatosGenerales(datosGenerales1);
                    teleproteccion1.Id = await _gestionarTeleproteccionDA.RegistrarTeleproteccion(teleproteccion1);
                    distanciaDeFalla1.Id = await _gestionarDistanciaDeFallaDA.RegistrarDistanciaDeFalla(distanciaDeFalla1);
                    tiemposDeDisparo1.Id = await _gestionarTiemposDeDisparoDA.RegistrarTiemposDeDisparo(tiemposDeDisparo1);
                    corrientesDeFalla1.Id = await _gestionarCorrientesDeFallaDA.RegistrarCorrientesDeFalla(corrientesDeFalla1);


                    var informeTipo1 = new Informe
                    {
                        Tipo = 1,
                        SubestacionId = subestacionIds[i],
                        LineaTransmisionId = lineaTransmisionId,
                        DatosDeLineaId = datosDeLinea1.Id,
                        DatosGeneralesId = datosGenerales1.Id,
                        TeleproteccionId = teleproteccion1.Id,
                        DistanciaDeFallaId = distanciaDeFalla1.Id,
                        TiemposDeDisparoId = tiemposDeDisparo1.Id,
                        CorrientesDeFallaId = corrientesDeFalla1.Id,
                        Estado = 0
                    };

                    Console.WriteLine("ID Autogenerado: " + corrientesDeFalla1.Id);
                    informes.Add(informeTipo1);

                    //datos del informe diferencial (tipo 2)
                    var datosDeLinea2 = new DatosDeLinea();
                    var datosGenerales2 = new DatosGenerales();
                    var teleproteccion2 = new Teleproteccion();
                    var distanciaDeFalla2 = new DistanciaDeFalla();
                    var tiemposDeDisparo2 = new TiemposDeDisparo();
                    var corrientesDeFalla2 = new CorrientesDeFalla();

                    // Guardar los datos para Informe Tipo 2 en la BD
                    datosDeLinea2.Id = await _gestionarDatosDeLineaDA.RegistrarDatosDeLinea(datosDeLinea1);
                    datosGenerales2.Id = await _gestionarDatosGeneralesDA.RegistrarDatosGenerales(datosGenerales1);
                    teleproteccion2.Id = await _gestionarTeleproteccionDA.RegistrarTeleproteccion(teleproteccion1);
                    distanciaDeFalla2.Id = await _gestionarDistanciaDeFallaDA.RegistrarDistanciaDeFalla(distanciaDeFalla1);
                    tiemposDeDisparo2.Id = await _gestionarTiemposDeDisparoDA.RegistrarTiemposDeDisparo(tiemposDeDisparo1);
                    corrientesDeFalla2.Id = await _gestionarCorrientesDeFallaDA.RegistrarCorrientesDeFalla(corrientesDeFalla1);


                    var informeTipo2 = new Informe
                    {
                        Tipo = 2,
                        SubestacionId = subestacionIds[i],
                        LineaTransmisionId = lineaTransmisionId,
                        DatosDeLineaId = datosDeLinea2.Id,
                        DatosGeneralesId = datosGenerales2.Id,
                        TeleproteccionId = teleproteccion2.Id,
                        DistanciaDeFallaId = distanciaDeFalla2.Id,
                        TiemposDeDisparoId = tiemposDeDisparo2.Id,
                        CorrientesDeFallaId = corrientesDeFalla2.Id,
                        Estado = 0
                    };

                    informes.Add(informeTipo2);
                }

                //se insertan los informes en la BD y se recupera su ID para el reporte
                for (int i = 0; i < informes.Count; i++)
                {
                    //informes[i].Id = await _gestionarInformeCN.RegistrarInformeCompleto(informes[i]);
                    informes[i].Id = await _gestionarInformeDA.RegistrarInforme(informes[i]);
                }

                // se asignan los informes al reporte
                if (informes.Count >= 4)
                {
                    reporte.InformeV1Id = informes[0].Id;
                    reporte.InformeV2Id = informes[1].Id;
                    reporte.InformeV3Id = informes[2].Id;
                    reporte.InformeV4Id = informes[3].Id;
                }

                // Registrar el reporte
                //return await _gestionarReporteCN.RegistrarReporte(reporte);
                return await _gestionarReporteDA.RegistrarReporte(reporte);

                // await transaction.CommitAsync();
                //return true;

            }
            catch (Exception ex)
            {
                //revertir todo ante cualquier insercion fallida, ya que son muchas
                //  await transaction.RollbackAsync();
                throw new Exception("Error al registrar los datos del informe y reporte: " + ex.Message);
            }
        }


        // Método privado para obtener los informes asociados de un reporte
        private async Task<List<Informe>> ObtenerInformesAsociados(int informeId)
        {
            var idsInformesAsociados = await _gestionarReporteDA.ObtenerIdsInformesDeReporte(informeId);
            var informesAsociados = new List<Informe>();

            foreach (var id in idsInformesAsociados)
            {
                var informe = await _gestionarInformeDA.ObtenerInformePorId(id);
                if (informe != null)
                {
                    informesAsociados.Add(informe);
                }
            }

            return informesAsociados;
        }

        public async Task VerificarEstadoInformesAsociados(int informeId)
        {
            var informesAsociados = await ObtenerInformesAsociados(informeId);

            bool todosConfirmados = informesAsociados.All(inf => inf.Estado == 1);

            if (todosConfirmados)
            {
                bool hayInformeCompleto = await VerificarInformesCompletosAsociados(informeId);

                if (!hayInformeCompleto)
                {
                    await ActualizarEstadosDeInformesAPendiente(informeId);
                }
            }
        }

        public async Task<bool> VerificarInformesCompletosAsociados(int informeId)
        {
            var informesAsociados = await ObtenerInformesAsociados(informeId);

            return informesAsociados.Any(inf => ReglasInforme.EsInformeCompleto(inf).esValido);
        }

        public async Task<bool> ActualizarEstadosDeInformesAPendiente(int informeId)
        {
            var informesAsociados = await ObtenerInformesAsociados(informeId);

            ReglasInforme.CambiarTodosLosInformesAPendientes(informesAsociados);

            foreach (var informe in informesAsociados)
            {
                await _gestionarInformeDA.ActualizarInforme(informe.Id, informe);
            }

            return true;
        }
    }
}

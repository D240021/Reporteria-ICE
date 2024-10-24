using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{

    public class GestionarReporteConInformesService: IGestionarReporteConInformesService
    {
        private readonly IGestionarReporteCN _gestionarReporteCN;
        private readonly IGestionarInformeCN _gestionarInformeCN;

        //Datos
        //private readonly ICE_Context _context;


        private readonly IGestionarInformeDA _gestionarInformeDA;
        private readonly IGestionarTeleproteccionDA _gestionarTeleproteccionDA;
        private readonly IGestionarDistanciaDeFallaDA _gestionarDistanciaDeFallaDA;
        private readonly IGestionarCorrientesDeFallaDA _gestionarCorrientesDeFallaDA;
        private readonly IGestionarTiemposDeDisparoDA _gestionarTiemposDeDisparoDA;
        private readonly IGestionarLineasTransmisionDA _gestionarLineaTransmisionDA;
        private readonly IGestionarDatosDeLineaDA _gestionarDatosDeLineaDA;
        private readonly IGestionarDatosGeneralesDA _gestionarDatosGeneralesDA;

        public GestionarReporteConInformesService(
            IGestionarReporteCN gestionarReporteCN, 
            IGestionarInformeCN gestionarInformeCN,
            IGestionarInformeDA gestionarInformeDA,
            IGestionarTeleproteccionDA gestionarTeleproteccionDA,
            IGestionarDistanciaDeFallaDA gestionarDistanciaDeFallaDA,
            IGestionarCorrientesDeFallaDA gestionarCorrientesDeFallaDA,
            IGestionarTiemposDeDisparoDA gestionarTiemposDeDisparoDA,
            IGestionarLineasTransmisionDA gestionarLineaTransmisionDA,
            IGestionarDatosDeLineaDA gestionarDatosDeLineaDA,
            IGestionarDatosGeneralesDA gestionarDatosGeneralesDA)
        {
            _gestionarReporteCN = gestionarReporteCN;
            _gestionarInformeCN = gestionarInformeCN;

            _gestionarInformeDA = gestionarInformeDA;
            _gestionarTeleproteccionDA = gestionarTeleproteccionDA;
            _gestionarDistanciaDeFallaDA = gestionarDistanciaDeFallaDA;
            _gestionarCorrientesDeFallaDA = gestionarCorrientesDeFallaDA;
            _gestionarTiemposDeDisparoDA = gestionarTiemposDeDisparoDA;
            _gestionarLineaTransmisionDA = gestionarLineaTransmisionDA;
            _gestionarDatosDeLineaDA = gestionarDatosDeLineaDA;
            _gestionarDatosGeneralesDA = gestionarDatosGeneralesDA;

        }

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
                    await _gestionarDatosDeLineaDA.RegistrarDatosDeLinea(datosDeLinea1);
                    await _gestionarDatosGeneralesDA.RegistrarDatosGenerales(datosGenerales1);
                    await _gestionarTeleproteccionDA.RegistrarTeleproteccion(teleproteccion1);
                    await _gestionarDistanciaDeFallaDA.RegistrarDistanciaDeFalla(distanciaDeFalla1);
                    await _gestionarTiemposDeDisparoDA.RegistrarTiemposDeDisparo(tiemposDeDisparo1);
                    await _gestionarCorrientesDeFallaDA.RegistrarCorrientesDeFalla(corrientesDeFalla1);


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

                    informes.Add(informeTipo1);

                    //datos del informe diferencial (tipo 2)
                    var datosDeLinea2 = new DatosDeLinea();
                    var datosGenerales2 = new DatosGenerales();
                    var teleproteccion2 = new Teleproteccion();
                    var distanciaDeFalla2 = new DistanciaDeFalla();
                    var tiemposDeDisparo2 = new TiemposDeDisparo();
                    var corrientesDeFalla2 = new CorrientesDeFalla();

                    // Guardar los datos para Informe Tipo 2 en la BD
                    await _gestionarDatosDeLineaDA.RegistrarDatosDeLinea(datosDeLinea2);
                    await _gestionarDatosGeneralesDA.RegistrarDatosGenerales(datosGenerales2);
                    await _gestionarTeleproteccionDA.RegistrarTeleproteccion(teleproteccion2);
                    await _gestionarDistanciaDeFallaDA.RegistrarDistanciaDeFalla(distanciaDeFalla2);
                    await _gestionarTiemposDeDisparoDA.RegistrarTiemposDeDisparo(tiemposDeDisparo2);
                    await _gestionarCorrientesDeFallaDA.RegistrarCorrientesDeFalla(corrientesDeFalla2);


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
                    informes[i].Id = await _gestionarInformeCN.RegistrarInformeCompleto(informes[i]);
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
                return await _gestionarReporteCN.RegistrarReporte(reporte);

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
    }
}

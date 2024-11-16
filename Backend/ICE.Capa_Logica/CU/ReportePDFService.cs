using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{

    public class GestionarReporteConInformesService : IGestionarReporteConInformesService
    {
        private readonly IGestionarInformeDA _gestionarInformeDA;
        private readonly IGestionarReporteDA _gestionarReporteDA;
        private readonly IGestionarTeleproteccionDA _gestionarTeleproteccionDA;
        private readonly IGestionarDistanciaDeFallaDA _gestionarDistanciaDeFallaDA;
        private readonly IGestionarCorrientesDeFallaDA _gestionarCorrientesDeFallaDA;
        private readonly IGestionarTiemposDeDisparoDA _gestionarTiemposDeDisparoDA;
        private readonly IGestionarLineasTransmisionDA _gestionarLineaTransmisionDA;
        private readonly IGestionarDatosDeLineaDA _gestionarDatosDeLineaDA;
        private readonly IGestionarDatosGeneralesDA _gestionarDatosGeneralesDA;

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
                if (!ReglasReporte.ReporteInicialValido(subestacionIds, lineaTransmisionId, reporte).esValido) return false;
                //metodo para compribar que el supervisorId exista y el tecnico tambien


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

                // Llamar a ActualizarEstadoReporte para que actualice el estado antes de registrar
                var reporteActualizado = ReglasReporte.ActualizarEstadoReporte(reporte);
                if (!reporteActualizado.esValido)
                {
                    return false;
                }

                // Registrar el reporte
                return await _gestionarReporteDA.RegistrarReporte(reporte);

            }
            catch (Exception ex)
            {
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

        //Metodo para obtener los informes de un reporte y verificar si todos estan confirmados, pero si al menos
        //1 no esta completo, se quedan pendientes los 4 otra vez
        public async Task VerificarEstadoInformesAsociados(int informeId)
        {
            var informesAsociados = await ObtenerInformesAsociados(informeId);
            var reporteAsociado = await ObtenerReportePorInformeId(informeId);

            bool todosConfirmados = informesAsociados.All(inf => inf.Estado == 1);

            if (todosConfirmados)
            {
                //A pesar de estar como confirmados, revisar que las instancias no tengan atributos nulos
                bool hayInformeCompleto = await VerificarInformesCompletosAsociados(informeId);
                if (!hayInformeCompleto)
                {
                    await ActualizarEstadosDeInformesAPendiente(informeId);
                    return;
                }
                //Como hay al menos 1 informe con datos completos, se actualiza el reporte
                ReglasReporte.ActualizarEstadoReporte(reporteAsociado);
                await _gestionarReporteDA.ActualizarReporte(reporteAsociado.Id, reporteAsociado);
            }
        }

        //Metodo para verificar que los atributos de tipo Instanciad de Informe no esten nulos
        public async Task<bool> VerificarInformesCompletosAsociados(int informeId)
        {
            var informesAsociados = await ObtenerInformesAsociados(informeId);

            return informesAsociados.Any(inf => ReglasInforme.EsInformeCompleto(inf).esValido);
        }

        //Se actualizan a pendientes todos los informes de un reporte
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




        //Para GestionarReporteCN
        public async Task<bool> VerificarEstadoInformesDeReporte(int reporteId)
        {
            // Obtener los informes asociados al reporte
            var informesAsociados = await ObtenerInformesAsociados(reporteId);

            // Verificar si todos los informes asociados están completos (Estado == 1)
            return informesAsociados.All(informe => informe.Estado == 1);
        }

        public async Task<bool> ActualizarEstadoReporteSegunInformes(Reporte reporte)
        {
            // Verificar si todos los informes asociados están completos
            bool informesCompletos = await VerificarEstadoInformesDeReporte(reporte.Id);

            if (!informesCompletos)
            {
                return false;
            }

            // Llamar a ReglasReporte para actualizar el estado del reporte según las reglas
            var resultado = ReglasReporte.ActualizarEstadoReporte(reporte);

            if (!resultado.esValido)
            {
                return false;
            }

            // Actualizar el reporte en la base de datos
            var actualizacionReporte = await _gestionarReporteDA.ActualizarReporte(reporte.Id, reporte);

            return actualizacionReporte;
        }

        public async Task<Reporte> ObtenerReportePorInformeId(int informeId)
        {
            // Intentar obtener el reporte usando cada uno de los IDs de informe
            var reporte = await _gestionarReporteDA.ObtenerReportePorInformeId(informeId);

            if (reporte != null &&
                (reporte.InformeV1Id == informeId ||
                 reporte.InformeV2Id == informeId ||
                 reporte.InformeV3Id == informeId ||
                 reporte.InformeV4Id == informeId))
            {
                return reporte;
            }

            // Si no se encuentra el reporte, retornar null
            return null;
        }



        //Metodos para reportes
        public async Task<Reporte> ObtenerReporteConInformesPorId(int reporteId)
        {
            // Obtener el reporte principal
            var reporte = await _gestionarReporteDA.ObtenerReportePorId(reporteId);

            if (reporte == null)
            {
                return null;
            }

            // Obtener los informes asociados al reporte
            var informes = await ObtenerInformesAsociados(reporteId);

            // Asignar los informes obtenidos al reporte
            if (informes.Count >= 4)
            {
                reporte.InformeV1Id = informes[0].Id;
                reporte.InformeV2Id = informes[1].Id;
                reporte.InformeV3Id = informes[2].Id;
                reporte.InformeV4Id = informes[3].Id;
            }

            return reporte;
        }

        public async Task<List<Informe>> ObtenerReporteConInformesPDF(int reporteId)
        {
            return await ObtenerInformesAsociados(reporteId);
        }
    }
}

/*using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using iText.Layout.Element;
using iText.Kernel.Colors;
using System.IO;
using ICE.Capa_Dominio.Modelos;

public class PDFGeneratorService : IPDFGeneratorService
{

    private readonly IGestionarReporteConInformesService _gestionarReporteConInformesService;
    //private readonly IGestionarLineasTransmisionDA _gestionarLineasTransmisionDA;
    //private readonly IGestionarSubestacionDA _gestionarSubestacionDA;

    public PDFGeneratorService(IGestionarReporteConInformesService gestionarReporteConInformesService)
    {
        _gestionarReporteConInformesService = gestionarReporteConInformesService;
        //_gestionarLineasTransmisionDA
        //_gestionarSubestacionDA
    }


    public async Task<byte[]> GenerarPDF(Reporte reporte)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // Título del PDF
            document.Add(new Paragraph("Reporte de Fallas")
                .SetFontSize(20)
                .SetBold()
                .SetFontColor(ColorConstants.BLUE));

            // Información del reporte
            document.Add(new Paragraph($"Reporte ID: {reporte.Id}"));
            document.Add(new Paragraph($"Observaciones: {reporte.Observaciones ?? "Sin observaciones"}"));
            document.Add(new Paragraph($"Estado: {reporte.Estado}"));

            // Mapa de Descargas
            AgregarImagenAlPDF(document, reporte.MapaDeDescargas, "Mapa de Descargas");

            // Información del Técnico de Línea
            document.Add(new Paragraph($"Fecha y Hora: {reporte.FechaHora?.ToString("yyyy-MM-dd HH:mm:ss") ?? "No especificado"}"));
            document.Add(new Paragraph("Información del Técnico de Línea").SetBold().SetFontSize(16));
            document.Add(new Paragraph($"Observaciones del Técnico de Línea: {reporte.ObservacionesTecnicoLinea ?? "Sin observaciones"}"));

            // Evidencia del Técnico de lnea
            AgregarImagenAlPDF(document, reporte.Evidencia, "Evidencia");

            // Causas del reporte
            AgregarCausasAlPDF(document, reporte.Causas);

            // Obtener la lista de informes asociados usando el servicio
            var informesDeReporte = await _gestionarReporteConInformesService.ObtenerReporteConInformesPDF(reporte.Id);
            AgregarInformesAlPDF(document,informesDeReporte);
            

            document.Close();
            return stream.ToArray();
        }
    }

    private void AgregarInformesAlPDF(Document document, List<Informe> informes)
    {
        // Agrega información de cada informe relacionado
        for (int i = 0; i < informes.Count; i++)
        {
            AgregarInforme(document, $"Informe V{i + 1}", informes[i]);
        }
    }


    private void AgregarInforme(Document document, string tituloInforme, Informe informe)
    {
        if (informe == null)
        {
            document.Add(new Paragraph($"{tituloInforme}: No disponible").SetItalic());
            return;
        }

        document.Add(new Paragraph(tituloInforme).SetBold().SetFontSize(16));
        document.Add(new Paragraph($"Informe ID: {informe.Id}"));
        document.Add(new Paragraph($"Subestación ID: {informe.SubestacionId}"));
        document.Add(new Paragraph($"Línea de Transmisión ID: {informe.LineaTransmisionId}"));
        document.Add(new Paragraph($"Estado: {informe.Estado}"));

        // Información de Corrientes de Falla
        if (informe.CorrientesDeFalla != null)
        {
            document.Add(new Paragraph("Corrientes de Falla").SetUnderline());
            document.Add(new Paragraph($"Real IR: {informe.CorrientesDeFalla.RealIR ?? "No disponible"}"));
            document.Add(new Paragraph($"Real IS: {informe.CorrientesDeFalla.RealIS ?? "No disponible"}"));
            document.Add(new Paragraph($"Real IT: {informe.CorrientesDeFalla.RealIT ?? "No disponible"}"));
            document.Add(new Paragraph($"Acumulada R: {informe.CorrientesDeFalla.AcumuladaR ?? "No disponible"}"));
            document.Add(new Paragraph($"Acumulada S: {informe.CorrientesDeFalla.AcumuladaS ?? "No disponible"}"));
            document.Add(new Paragraph($"Acumulada T: {informe.CorrientesDeFalla.AcumuladaT ?? "No disponible"}"));
        }

        // Información de Datos de Línea
        if (informe.DatosDeLinea != null)
        {
            document.Add(new Paragraph("Datos de Línea").SetUnderline());
            document.Add(new Paragraph($"OT: {informe.DatosDeLinea.OT ?? "No disponible"}"));
            document.Add(new Paragraph($"Aviso: {informe.DatosDeLinea.Aviso ?? "No disponible"}"));
            document.Add(new Paragraph($"SAP: {informe.DatosDeLinea.SAP ?? "No disponible"}"));
            document.Add(new Paragraph($"Distancia: {informe.DatosDeLinea.Distancia ?? "No disponible"}"));
            document.Add(new Paragraph($"Función: {informe.DatosDeLinea.Funcion ?? "No disponible"}"));
            document.Add(new Paragraph($"Zona: {informe.DatosDeLinea.Zona ?? "No disponible"}"));
        }

        // Información de Datos Generales
        if (informe.DatosGenerales != null)
        {
            document.Add(new Paragraph("Datos Generales").SetUnderline());
            document.Add(new Paragraph($"Evento: {informe.DatosGenerales.Evento ?? "No disponible"}"));
            document.Add(new Paragraph($"Fecha: {informe.DatosGenerales.Fecha?.ToString("dd/MM/yyyy") ?? "No disponible"}"));
            document.Add(new Paragraph($"Hora: {informe.DatosGenerales.Hora?.ToString() ?? "No disponible"}"));
            document.Add(new Paragraph($"Subestación: {informe.DatosGenerales.Subestacion ?? "No disponible"}"));
            document.Add(new Paragraph($"LT: {informe.DatosGenerales.LT ?? "No disponible"}"));
            document.Add(new Paragraph($"Equipo: {informe.DatosGenerales.Equipo ?? "No disponible"}"));
        }

        // Información de Distancia de Falla
        if (informe.DistanciaDeFalla != null)
        {
            document.Add(new Paragraph("Distancia de Falla").SetUnderline());
            document.Add(new Paragraph($"Distancia KM: {informe.DistanciaDeFalla.DistanciaKM ?? "No disponible"}"));
            document.Add(new Paragraph($"Distancia %: {informe.DistanciaDeFalla.DistanciaPorcentaje ?? "No disponible"}"));
            document.Add(new Paragraph($"Distancia Reportada: {informe.DistanciaDeFalla.DistanciaReportada ?? "No disponible"}"));
            document.Add(new Paragraph($"Distancia Doble Temporal: {informe.DistanciaDeFalla.DistanciaDobleTemporal ?? "No disponible"}"));
            document.Add(new Paragraph($"Error: {informe.DistanciaDeFalla.Error ?? "No disponible"}"));
            document.Add(new Paragraph($"Error Doble: {informe.DistanciaDeFalla.Error_Doble ?? "No disponible"}"));
        }

        // Información de Tiempos de Disparo
        if (informe.TiemposDeDisparo != null)
        {
            document.Add(new Paragraph("Tiempos de Disparo").SetUnderline());
            document.Add(new Paragraph($"R: {informe.TiemposDeDisparo.R ?? "No disponible"}"));
            document.Add(new Paragraph($"S: {informe.TiemposDeDisparo.S ?? "No disponible"}"));
            document.Add(new Paragraph($"T: {informe.TiemposDeDisparo.T ?? "No disponible"}"));
            document.Add(new Paragraph($"Reserva: {informe.TiemposDeDisparo.Reserva ?? "No disponible"}"));
        }

        // Información de Teleprotección
        if (informe.Teleproteccion != null)
        {
            document.Add(new Paragraph("Teleprotección").SetUnderline());
            document.Add(new Paragraph($"TX TEL: {informe.Teleproteccion.TX_TEL ?? "No disponible"}"));
            document.Add(new Paragraph($"RX TEL: {informe.Teleproteccion.RX_TEL ?? "No disponible"}"));
            document.Add(new Paragraph($"Tiempo MPLS: {informe.Teleproteccion.TiempoMPLS ?? "No disponible"}"));
        }
    }

    private void AgregarImagenAlPDF(Document document, byte[] imagenData, string titulo)
    {
        if (imagenData != null)
        {
            ImageData imageData = ImageDataFactory.Create(imagenData);
            Image pdfImage = new Image(imageData).SetAutoScale(true);
            document.Add(new Paragraph(titulo).SetBold());
            document.Add(pdfImage);
        }
    }
    
    private void AgregarCausasAlPDF(Document document, string causas)
    {
        if (!string.IsNullOrEmpty(causas))
        {
            document.Add(new Paragraph("Causas:").SetBold());
            var listaCausas = causas.Split(',');
            foreach (var causa in listaCausas)
            {
                document.Add(new Paragraph($"- {causa.Trim()}"));
            }
        }
    }
}
*/
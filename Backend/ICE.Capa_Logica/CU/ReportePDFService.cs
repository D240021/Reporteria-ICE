using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using iText.Layout.Element;
using iText.Kernel.Colors;
using System.IO;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;

public class PDFGeneratorService : IPDFGeneratorService
{

    private readonly IGestionarReporteConInformesService _gestionarReporteConInformesService;
    private readonly IGestionarLineasTransmisionDA _gestionarLineasTransmisionDA;
    private readonly IGestionarSubestacionDA _gestionarSubestacionDA;

    public PDFGeneratorService(
        IGestionarReporteConInformesService gestionarReporteConInformesService,
        IGestionarLineasTransmisionDA gestionarLineasTransmisionDA,
        IGestionarSubestacionDA gestionarSubestacionDA
        )
    {
        _gestionarReporteConInformesService = gestionarReporteConInformesService;
        _gestionarLineasTransmisionDA = gestionarLineasTransmisionDA;
        _gestionarSubestacionDA = gestionarSubestacionDA;
    }


    public async Task<byte[]> GenerarPDF(Reporte reporte)
    {
        using (var stream = new MemoryStream())
        {
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // T�tulo del PDF
            document.Add(new Paragraph("Reporte de Fallas")
                .SetFontSize(20)
                .SetBold()
                .SetFontColor(ColorConstants.BLUE));

            // Informaci�n del reporte
            document.Add(new Paragraph($"Reporte ID: {reporte.Id}"));
            document.Add(new Paragraph($"Observaciones: {reporte.Observaciones ?? "Sin observaciones"}"));


            // Obtener descripci�n del estado del reporte
            string descripcionEstado = ObtenerDescripcionEstadoReporte(reporte.Estado);
            document.Add(new Paragraph($"Estado: {descripcionEstado}"));

            // Mapa de Descargas
            //AgregarImagenAlPDF(document, reporte.MapaDeDescargas, "Mapa de Descargas");

            // Informaci�n del T�cnico de L�nea
            document.Add(new Paragraph($"Fecha y Hora: {reporte.FechaHora?.ToString("yyyy-MM-dd HH:mm:ss") ?? "No especificado"}"));
            document.Add(new Paragraph("Informaci�n del T�cnico de L�nea").SetBold().SetFontSize(16));
            document.Add(new Paragraph($"Observaciones del T�cnico de L�nea: {reporte.ObservacionesTecnicoLinea ?? "Sin observaciones"}"));

            // Evidencia del T�cnico de lnea
            //AgregarImagenAlPDF(document, reporte.Evidencia, "Evidencia");

            // Causas del reporte
            AgregarCausasAlPDF(document, reporte.Causas);

            // Obtener la lista de informes asociados usando el servicio
            var informesDeReporte = await _gestionarReporteConInformesService.ObtenerReporteConInformesPDF(reporte.Id);
            await AgregarInformesAlPDF(document, informesDeReporte);


            document.Close();
            return stream.ToArray();
        }
    }

    private async Task AgregarInformesAlPDF(Document document, List<Informe> informes)
    {
        // Agrega informaci�n de cada informe relacionado
        for (int i = 0; i < informes.Count; i++)
        {
            await AgregarInforme(document, $"Informe V{i + 1}", informes[i]);
        }
    }


    private async Task AgregarInforme(Document document, string tituloInforme, Informe informe)
    {
        if (informe == null)
        {
            document.Add(new Paragraph($"{tituloInforme}: No disponible").SetItalic());
            return;
        }

        // Obtener nombres de la Subestaci�n y L�nea de Transmisi�n
        string nombreSubestacion = "No disponible";
        string nombreLineaTransmision = "No disponible";
        var identificadorSubestacion = "No disponible";

        try
        {
            // Llamar a la base de datos para obtener los nombres
            var subestacion = await _gestionarSubestacionDA.ObtenerSubestacion(informe.SubestacionId);
            nombreSubestacion = subestacion.NombreUbicacion;
            identificadorSubestacion = subestacion.Identificador;

            var lineaTransmision = await _gestionarLineasTransmisionDA.ObtenerLineaTransmision(informe.LineaTransmisionId);
            nombreLineaTransmision = lineaTransmision.NombreUbicacion;
        }
        catch (Exception ex)
        {
            // Manejar errores al obtener datos
            document.Add(new Paragraph($"Error al obtener datos: {ex.Message}").SetFontColor(ColorConstants.RED));
        }

        // Agregar datos al PDF
        document.Add(new Paragraph(tituloInforme).SetBold().SetFontSize(16));
        document.Add(new Paragraph($"Informe ID: {informe.Id}"));
        document.Add(new Paragraph($"Subestaci�n: {nombreSubestacion} (Identificador: {identificadorSubestacion})"));
        document.Add(new Paragraph($"L�nea de Transmisi�n: {nombreLineaTransmision}"));
        string descripcionEstadoInforme = ObtenerDescripcionEstadoReporte(informe.Estado);
        document.Add(new Paragraph($"Estado: {descripcionEstadoInforme}"));

        // Informaci�n de Corrientes de Falla
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

        // Informaci�n de Datos de L�nea
        if (informe.DatosDeLinea != null)
        {
            document.Add(new Paragraph("Datos de L�nea").SetUnderline());
            document.Add(new Paragraph($"OT: {informe.DatosDeLinea.OT ?? "No disponible"}"));
            document.Add(new Paragraph($"Aviso: {informe.DatosDeLinea.Aviso ?? "No disponible"}"));
            document.Add(new Paragraph($"SAP: {informe.DatosDeLinea.SAP ?? "No disponible"}"));
            document.Add(new Paragraph($"Distancia: {informe.DatosDeLinea.Distancia ?? "No disponible"}"));
            document.Add(new Paragraph($"Funci�n: {informe.DatosDeLinea.Funcion ?? "No disponible"}"));
            document.Add(new Paragraph($"Zona: {informe.DatosDeLinea.Zona ?? "No disponible"}"));
        }

        // Informaci�n de Datos Generales
        if (informe.DatosGenerales != null)
        {
            document.Add(new Paragraph("Datos Generales").SetUnderline());
            document.Add(new Paragraph($"Evento: {informe.DatosGenerales.Evento ?? "No disponible"}"));
            document.Add(new Paragraph($"Fecha: {informe.DatosGenerales.Fecha?.ToString("dd/MM/yyyy") ?? "No disponible"}"));
            document.Add(new Paragraph($"Hora: {informe.DatosGenerales.Hora?.ToString() ?? "No disponible"}"));
            document.Add(new Paragraph($"Subestaci�n: {informe.DatosGenerales.Subestacion ?? "No disponible"}"));
            document.Add(new Paragraph($"LT: {informe.DatosGenerales.LT ?? "No disponible"}"));
            document.Add(new Paragraph($"Equipo: {informe.DatosGenerales.Equipo ?? "No disponible"}"));
        }

        // Informaci�n de Distancia de Falla
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

        // Informaci�n de Tiempos de Disparo
        if (informe.TiemposDeDisparo != null)
        {
            document.Add(new Paragraph("Tiempos de Disparo").SetUnderline());
            document.Add(new Paragraph($"R: {informe.TiemposDeDisparo.R ?? "No disponible"}"));
            document.Add(new Paragraph($"S: {informe.TiemposDeDisparo.S ?? "No disponible"}"));
            document.Add(new Paragraph($"T: {informe.TiemposDeDisparo.T ?? "No disponible"}"));
            document.Add(new Paragraph($"Reserva: {informe.TiemposDeDisparo.Reserva ?? "No disponible"}"));
        }

        // Informaci�n de Teleprotecci�n
        if (informe.Teleproteccion != null)
        {
            document.Add(new Paragraph("Teleprotecci�n").SetUnderline());
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

    private string ObtenerDescripcionEstadoReporte(int estado)
    {
        switch (estado)
        {
            case 0:
                return "Recien creado";
            case 1:
                return "Informes en proceso";
            case 2:
                return "Supervisor editando";
            case 3:
                return "T�cnico de campo editando";
            case 4:
                return "Finalizado";
            default:
                return "Estado desconocido";
        }
    }

    private string ObtenerDescripcionEstadoInforme(int estado)
    {
        switch (estado)
        {
            case 0:
                return "Pendiente";
            case 1:
                return "Finalizado";
            default:
                return "Estado desconocido";
        }
    }
}
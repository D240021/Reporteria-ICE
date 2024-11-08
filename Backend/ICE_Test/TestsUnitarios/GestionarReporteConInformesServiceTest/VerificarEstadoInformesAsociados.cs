using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

[TestFixture]
public class GestionarReporteConInformesServiceTests
{
    private Mock<IGestionarInformeDA> _mockInformeDA;
    private Mock<IGestionarReporteDA> _mockReporteDA;
    private GestionarReporteConInformesService _gestionarReporteConInformesService;

    [SetUp]
    public void Setup()
    {
        _mockInformeDA = new Mock<IGestionarInformeDA>();
        _mockReporteDA = new Mock<IGestionarReporteDA>();

        _gestionarReporteConInformesService = new GestionarReporteConInformesService(
            _mockInformeDA.Object,
            _mockReporteDA.Object,
            new Mock<IGestionarTeleproteccionDA>().Object,
            new Mock<IGestionarDistanciaDeFallaDA>().Object,
            new Mock<IGestionarCorrientesDeFallaDA>().Object,
            new Mock<IGestionarTiemposDeDisparoDA>().Object,
            new Mock<IGestionarLineasTransmisionDA>().Object,
            new Mock<IGestionarDatosDeLineaDA>().Object,
            new Mock<IGestionarDatosGeneralesDA>().Object
        );
    }

    [Test]
    public async Task VerificarEstadoInformesAsociados_TodosInformesConfirmadosYCompletos_ActualizaReporte()
    {
        // Arrange
        int informeId = 10;
        var informesAsociados = new List<Informe>
        {
            CrearInformeCompleto(10, estado: 1),
            CrearInformeCompleto(11, estado: 1),
            CrearInformeCompleto(12, estado: 1),
            CrearInformeCompleto(13, estado: 1)
        };
        var reporte = CrearReporteCompleto(estado: 1, fechaHora: DateTime.Now, causas: "Causas mínimas", observacionesSupervisor: "Observación mínima");

        // Configuración del mock para obtener los informes asociados
        _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.IsAny<int>()))
            .ReturnsAsync((int id) => informesAsociados.FirstOrDefault(i => i.Id == id));
        _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(informeId))
            .ReturnsAsync(informesAsociados.Select(i => i.Id).ToList());
        _mockReporteDA.Setup(da => da.ObtenerReportePorInformeId(informeId)).ReturnsAsync(reporte);

        // Verificar que `ActualizarReporte` se llamó con el reporte actualizado
        Reporte reporteActualizado = reporte;
        _mockReporteDA.Setup(da => da.ActualizarReporte(It.IsAny<int>(), It.IsAny<Reporte>()))
            .Callback<int, Reporte>((id, updatedReporte) => reporteActualizado = updatedReporte)
            .ReturnsAsync(true);

        // Act
        await _gestionarReporteConInformesService.VerificarEstadoInformesAsociados(informeId);
        
        // Assert final
        Assert.AreEqual(2, reporteActualizado.Estado, "El estado del reporte debería haberse actualizado a 2");
        _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Once);
    }


    [Test]
    public async Task VerificarEstadoInformesAsociados_TodosInformesConfirmadosPeroNoCompletos_RegresaPendiente()
    {
        // Arrange
        int informeId = 1;
        var informesAsociados = new List<Informe>
        {
            CrearInformeIncompleto(10, estado: 1),
            CrearInformeIncompleto(11, estado: 1),
            CrearInformeIncompleto(12, estado: 1),
            CrearInformeIncompleto(13, estado: 1)
        };
        var reporte = CrearReporteCompleto(estado: 1, fechaHora: DateTime.Now, causas: "Causas", observacionesSupervisor: "Observaciones");

        //Simulamos llamar a los metodos de BD

        _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.IsAny<int>()))
            .ReturnsAsync((int id) => informesAsociados.FirstOrDefault(i => i.Id == id));
        _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(informeId))
            .ReturnsAsync(informesAsociados.Select(i => i.Id).ToList());
        _mockReporteDA.Setup(da => da.ObtenerReportePorInformeId(informeId)).ReturnsAsync(reporte);
        
        // Callback para verificar que los informes vuelvan a estado pendiente
        _mockInformeDA.Setup(da => da.ActualizarInforme(It.IsAny<int>(), It.IsAny<Informe>()))
            .Callback<int, Informe>((id, informe) => informe.Estado = 0);

        // Act
        await _gestionarReporteConInformesService.VerificarEstadoInformesAsociados(informeId);

        // Assert
        Assert.IsTrue(informesAsociados.All(inf => inf.Estado == 0), "Todos los informes deberían estar en estado pendiente.");
        Assert.AreEqual(1, reporte.Estado, "El estado del reporte se mantiene en 1");
        _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Never);
    }

    private Informe CrearInformeCompleto(int id, int estado)
    {
        return new Informe
        {
            Id = id,
            Estado = estado,
            Tipo = 2,
            SubestacionId = 1,
            LineaTransmisionId = 1,
            DatosDeLineaId = id,
            DatosDeLinea = new DatosDeLinea
            {
                Id = id,
                OT = "OT-12345",
                Aviso = "Aviso-001",
                SAP = "SAP-56789",
                Distancia = "20 km",
                Funcion = "Función de protección",
                Zona = "Zona Norte"
            },
            DatosGeneralesId = id,
            DatosGenerales = new DatosGenerales
            {
                Id = id,
                Evento = "Falla en línea de transmisión",
                Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                Hora = TimeSpan.Parse("08:30:00"),
                Subestacion = "Subestación Norte",
                LT = "LT-456",
                Equipo = "Equipo A"
            },
            TeleproteccionId = id,
            Teleproteccion = new Teleproteccion
            {
                Id = id,
                TX_TEL = "TX-100",
                RX_TEL = "RX-100",
                TiempoMPLS = "200 ms"
            },
            DistanciaDeFallaId = id,
            DistanciaDeFalla = new DistanciaDeFalla
            {
                Id = id,
                DistanciaKM = "15 km",
                DistanciaPorcentaje = "75%",
                DistanciaReportada = "Distancia Reportada - 14 km",
                DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                Error = "0.5%",
                Error_Doble = "1%"
            },
            TiemposDeDisparoId = id,
            TiemposDeDisparo = new TiemposDeDisparo
            {
                Id = id,
                R = "30 ms",
                S = "40 ms",
                T = "50 ms",
                Reserva = "10 ms"
            },
            CorrientesDeFallaId = id,
            CorrientesDeFalla = new CorrientesDeFalla
            {
                Id = id,
                RealIR = "500 A",
                RealIS = "600 A",
                RealIT = "700 A",
                AcumuladaR = "1500 A",
                AcumuladaS = "1600 A",
                AcumuladaT = "1700 A"
            }
        };
    }

    private Informe CrearInformeIncompleto(int id, int estado)
    {
        return new Informe
        {
            Id = id,
            Estado = estado,
            Tipo = 2,
            SubestacionId = 1,
            LineaTransmisionId = 1,
            DatosDeLineaId = id,
            DatosDeLinea = new DatosDeLinea
            {
                Id = id,
                OT = null,
                Aviso = null,
                SAP = null,
                Distancia = null,
                Funcion = null,
                Zona = null
            },
            DatosGeneralesId = id,
            DatosGenerales = new DatosGenerales
            {
                Id = id,
                Evento = null,
                Fecha = null,
                Hora = null,
                Subestacion = null,
                LT = null,
                Equipo = null
            },
            TeleproteccionId = id,
            Teleproteccion = new Teleproteccion
            {
                Id = id,
                TX_TEL = null,
                RX_TEL = null,
                TiempoMPLS = null
            },
            DistanciaDeFallaId = id,
            DistanciaDeFalla = new DistanciaDeFalla
            {
                Id = id,
                DistanciaKM = null,
                DistanciaPorcentaje = null,
                DistanciaReportada = null,
                DistanciaDobleTemporal = null,
                Error = null,
                Error_Doble = null
            },
            TiemposDeDisparoId = id,
            TiemposDeDisparo = new TiemposDeDisparo
            {
                Id = id,
                R = null,
                S = null,
                T = null,
                Reserva = null
            },
            CorrientesDeFallaId = id,
            CorrientesDeFalla = new CorrientesDeFalla
            {
                Id = id,
                RealIR = null,
                RealIS = null,
                RealIT = null,
                AcumuladaR = null,
                AcumuladaS = null,
                AcumuladaT = null
            }
        };
    }

    private Reporte CrearReporteCompleto(int estado, DateTime? fechaHora, string? causas, string? observacionesSupervisor)
    {
        return new Reporte
        {
            Id = 1,
            Estado = estado,
            MapaDeDescargas = null,
            Observaciones = observacionesSupervisor,
            Evidencia = null,
            ObservacionesTecnicoLinea = "Observaciones",
            Causas = causas,
            FechaHora = fechaHora,
            InformeV1Id = 10,
            InformeV2Id = 11,
            InformeV3Id = 12,
            InformeV4Id = 13,
            UsuarioSupervisorId = 1,
            TecnicoLineaId = 2
        };
    }
}

using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

[TestFixture]
public class GestionarInformeCN_ValidacionEstadoTest
{
    private Mock<IGestionarInformeDA> _mockInformeDA;
    private Mock<IGestionarTeleproteccionDA> _mockTeleproteccionDA;
    private Mock<IGestionarDistanciaDeFallaDA> _mockDistanciaDeFallaDA;
    private Mock<IGestionarCorrientesDeFallaDA> _mockCorrientesDeFallaDA;
    private Mock<IGestionarTiemposDeDisparoDA> _mockTiemposDeDisparoDA;
    private Mock<IGestionarLineasTransmisionDA> _mockLineaTransmisionDA;
    private Mock<IGestionarDatosDeLineaDA> _mockDatosDeLineaDA;
    private Mock<IGestionarDatosGeneralesDA> _mockDatosGeneralesDA;
    private Mock<IGestionarReporteConInformesService> _mockGestionarReporteConInformesService;
    private GestionarInformeCN _gestionarInformeCN;

    [SetUp]
    public void Setup()
    {
        _mockInformeDA = new Mock<IGestionarInformeDA>();
        _mockTeleproteccionDA = new Mock<IGestionarTeleproteccionDA>();
        _mockDistanciaDeFallaDA = new Mock<IGestionarDistanciaDeFallaDA>();
        _mockCorrientesDeFallaDA = new Mock<IGestionarCorrientesDeFallaDA>();
        _mockTiemposDeDisparoDA = new Mock<IGestionarTiemposDeDisparoDA>();
        _mockLineaTransmisionDA = new Mock<IGestionarLineasTransmisionDA>();
        _mockDatosDeLineaDA = new Mock<IGestionarDatosDeLineaDA>();
        _mockDatosGeneralesDA = new Mock<IGestionarDatosGeneralesDA>();
        _mockGestionarReporteConInformesService = new Mock<IGestionarReporteConInformesService>();

        _gestionarInformeCN = new GestionarInformeCN(
            _mockInformeDA.Object,
            _mockTeleproteccionDA.Object,
            _mockDistanciaDeFallaDA.Object,
            _mockCorrientesDeFallaDA.Object,
            _mockTiemposDeDisparoDA.Object,
            _mockLineaTransmisionDA.Object,
            _mockDatosDeLineaDA.Object,
            _mockDatosGeneralesDA.Object,
            _mockGestionarReporteConInformesService.Object
        );
    }

    [Test]
    public async Task ActualizarInformeValido_CambiaEstadoAConfirmado()
    {
        // Arrange: crear un informe válido y completo
        var informeValido = CrearInformeCompleto(id: 1, estado: 0, tipo: 1, idInstancias: 1);
        //MockReglasInforme.EsInformeValidoResult = (true, string.Empty);

        _mockInformeDA.Setup(da => da.ActualizarInforme(informeValido.Id, informeValido)).ReturnsAsync(true);

        // Act
        var resultado = await _gestionarInformeCN.ActualizarInforme(informeValido);

        // Assert
        Assert.IsTrue(resultado);
        Assert.AreEqual(1, informeValido.Estado);
        _mockInformeDA.Verify(da => da.ActualizarInforme(informeValido.Id, informeValido), Times.Once);
    }

    [Test]
    public async Task ActualizarInformeInvalido_EstadoNoPermitido()
    {
        // Arrange: crear un informe inválido
        var informeInvalido = CrearInformeCompleto(id:1, estado: 5, tipo: 2, idInstancias: 1);        

        // Act
        var resultado = await _gestionarInformeCN.ActualizarInforme(informeInvalido);

        // Assert
        Assert.IsFalse(resultado);
        _mockInformeDA.Verify(da => da.ActualizarInforme(It.IsAny<int>(), It.IsAny<Informe>()), Times.Never);
    }

    [Test]
    public async Task ActualizarInformeInvalido_TipoNoPermitido()
    {
        // Arrange: crear un informe inválido
        var informeInvalido = CrearInformeCompleto(id:1, estado: 0, tipo: 7, idInstancias: 1);

        // Act
        var resultado = await _gestionarInformeCN.ActualizarInforme(informeInvalido);

        // Assert
        Assert.IsFalse(resultado);
        _mockInformeDA.Verify(da => da.ActualizarInforme(It.IsAny<int>(), It.IsAny<Informe>()), Times.Never);
    }

    [Test]
    public async Task ActualizarInformeInvalido_IdInstanciasNoPermitido()
    {
        // Arrange: crear un informe inválido
        var informeInvalido = CrearInformeCompleto(id: 1, estado: 0, tipo: 2, idInstancias: 0);

        // Act
        var resultado = await _gestionarInformeCN.ActualizarInforme(informeInvalido);

        // Assert
        Assert.IsFalse(resultado);
        _mockInformeDA.Verify(da => da.ActualizarInforme(It.IsAny<int>(), It.IsAny<Informe>()), Times.Never);
    }

    [Test]
    public void ActualizarInformeInvalido_InformeNulo()
    {
        Informe informeNulo = null;
        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _gestionarInformeCN.ActualizarInforme(informeNulo));
    }




    private Informe CrearInformeCompleto(int id, int estado, int tipo, int idInstancias)
    {
        return new Informe
        {
            Id = id,
            Estado = estado,
            Tipo = tipo,
            SubestacionId = 1,
            LineaTransmisionId = 1,
            DatosDeLineaId = idInstancias,
            DatosDeLinea = new DatosDeLinea
            {
                Id = idInstancias,
                OT = "OT-12345",
                Aviso = "Aviso-001",
                SAP = "SAP-56789",
                Distancia = "20 km",
                Funcion = "Función de protección",
                Zona = "Zona Norte"
            },
            DatosGeneralesId = idInstancias,
            DatosGenerales = new DatosGenerales
            {
                Id = idInstancias,
                Evento = "Falla en línea de transmisión",
                Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                Hora = TimeSpan.Parse("08:30:00"),
                Subestacion = "Subestación Norte",
                LT = "LT-456",
                Equipo = "Equipo A"
            },
            TeleproteccionId = idInstancias,
            Teleproteccion = new Teleproteccion
            {
                Id = idInstancias,
                TX_TEL = "TX-100",
                RX_TEL = "RX-100",
                TiempoMPLS = "200 ms"
            },
            DistanciaDeFallaId = idInstancias,
            DistanciaDeFalla = new DistanciaDeFalla
            {
                Id = idInstancias,
                DistanciaKM = "15 km",
                DistanciaPorcentaje = "75%",
                DistanciaReportada = "Distancia Reportada - 14 km",
                DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                Error = "0.5%",
                Error_Doble = "1%"
            },
            TiemposDeDisparoId = idInstancias,
            TiemposDeDisparo = new TiemposDeDisparo
            {
                Id = idInstancias,
                R = "30 ms",
                S = "40 ms",
                T = "50 ms",
                Reserva = "10 ms"
            },
            CorrientesDeFallaId = idInstancias,
            CorrientesDeFalla = new CorrientesDeFalla
            {
                Id = idInstancias,
                RealIR = "500 A",
                RealIS = "600 A",
                RealIT = "700 A",
                AcumuladaR = "1500 A",
                AcumuladaS = "1600 A",
                AcumuladaT = "1700 A"
            }
        };
    }
}
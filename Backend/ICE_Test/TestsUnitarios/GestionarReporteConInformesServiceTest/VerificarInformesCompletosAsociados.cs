using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE_Test.TestsUnitarios
{
    [TestFixture]
    public class VerificarInformesCompletosAsociadosTest
    {
        private Mock<IGestionarReporteDA> _mockReporteDA;
        private Mock<IGestionarInformeDA> _mockInformeDA;
        private GestionarReporteConInformesService _gestionarReporteConInformesService;

        [SetUp]
        public void Setup()
        {
            _mockReporteDA = new Mock<IGestionarReporteDA>();
            _mockInformeDA = new Mock<IGestionarInformeDA>();
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
        public async Task ActualizarReporteValido_InformesConDatosCompletos()
        {
            //Datos que usaran los metodos DA dentro de GestionarReporteConIformesService
            int informe1Id = 10;
            int informe2Id = 11;
            var idsInformesAsociados = new List<int> { informe1Id, informe2Id };


            //Informes
            var informe1Completo = new Informe
            {
                Id = 10,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = 10,
                    OT = "OT-12345",
                    Aviso = "Aviso-001",
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
                DatosGenerales = new DatosGenerales
                {
                    Id = 10,
                    Evento = "Falla en línea de transmisión",
                    Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                    Hora = TimeSpan.Parse("08:30:00"),
                    Subestacion = "Subestación Norte",
                    LT = "LT-456",
                    Equipo = "Equipo A"
                },
                Teleproteccion = new Teleproteccion
                {
                    Id = 10,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
                DistanciaDeFalla = new DistanciaDeFalla
                {
                    Id = 10,
                    DistanciaKM = "15 km",
                    DistanciaPorcentaje = "75%",
                    DistanciaReportada = "Distancia Reportada - 14 km",
                    DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                    Error = "0.5%",
                    Error_Doble = "1%"
                },
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = 10,
                    R = "30 ms",
                    S = "40 ms",
                    T = "50 ms",
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = 10,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };

            //Informes
            var informe2Completo = new Informe
            {
                Id = 10,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = 10,
                    OT = "OT-12345",
                    Aviso = "Aviso-001",
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
                DatosGenerales = new DatosGenerales
                {
                    Id = 10,
                    Evento = "Falla en línea de transmisión",
                    Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                    Hora = TimeSpan.Parse("08:30:00"),
                    Subestacion = "Subestación Norte",
                    LT = "LT-456",
                    Equipo = "Equipo A"
                },
                Teleproteccion = new Teleproteccion
                {
                    Id = 10,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
                DistanciaDeFalla = new DistanciaDeFalla
                {
                    Id = 10,
                    DistanciaKM = "15 km",
                    DistanciaPorcentaje = "75%",
                    DistanciaReportada = "Distancia Reportada - 14 km",
                    DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                    Error = "0.5%",
                    Error_Doble = "1%"
                },
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = 10,
                    R = "30 ms",
                    S = "40 ms",
                    T = "50 ms",
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = 10,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };

            //Controlamos el retorno de los metodos privados que invoca VerificarInformesCompletosAsociados()
            //en GestionarReporteConInformesService
            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(It.IsAny<int>()))
                          .ReturnsAsync(idsInformesAsociados);
            
            _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.Is<int>(id => id == informe1Id)))
                          .ReturnsAsync(informe1Completo);
            _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.Is<int>(id => id == informe2Id)))
                          .ReturnsAsync(informe2Completo);

            var resultado = await _gestionarReporteConInformesService.VerificarInformesCompletosAsociados(informe1Id);

            Assert.IsTrue(resultado, "Se esperaba que todos los informes estuvieran completos con todos los datos instanciados y válidos.");
        }


        [Test]
        public async Task ActualizarReporteValido_InformesConDatosCompletos_UnInformeCoNulos()
        {
            //Datos que usaran los metodos DA dentro de GestionarReporteConIformesService
            int informe1Id = 10;
            int informe2Id = 11;
            var idsInformesAsociados = new List<int> { informe1Id, informe2Id };


            //Informes
            var informe1Completo = new Informe
            {
                Id = 10,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = 10,
                    OT = null,
                    Aviso = "Aviso-001",
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
                DatosGenerales = new DatosGenerales
                {
                    Id = 10,
                    Evento = "Falla en línea de transmisión",
                    Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                    Hora = TimeSpan.Parse("08:30:00"),
                    Subestacion = "Subestación Norte",
                    LT = "LT-456",
                    Equipo = "Equipo A"
                },
                Teleproteccion = new Teleproteccion
                {
                    Id = 10,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
                DistanciaDeFalla = new DistanciaDeFalla
                {
                    Id = 10,
                    DistanciaKM = "15 km",
                    DistanciaPorcentaje = "75%",
                    DistanciaReportada = "Distancia Reportada - 14 km",
                    DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                    Error = "0.5%",
                    Error_Doble = "1%"
                },
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = 10,
                    R = "30 ms",
                    S = "40 ms",
                    T = "50 ms",
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = 10,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };

            //Informes
            var informe2Completo = new Informe
            {
                Id = 10,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = 10,
                    OT = "OT-12345",
                    Aviso = "Aviso-001",
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
                DatosGenerales = new DatosGenerales
                {
                    Id = 10,
                    Evento = "Falla en línea de transmisión",
                    Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                    Hora = TimeSpan.Parse("08:30:00"),
                    Subestacion = "Subestación Norte",
                    LT = "LT-456",
                    Equipo = "Equipo A"
                },
                Teleproteccion = new Teleproteccion
                {
                    Id = 10,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
                DistanciaDeFalla = new DistanciaDeFalla
                {
                    Id = 10,
                    DistanciaKM = "15 km",
                    DistanciaPorcentaje = "75%",
                    DistanciaReportada = "Distancia Reportada - 14 km",
                    DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                    Error = "0.5%",
                    Error_Doble = "1%"
                },
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = 10,
                    R = "30 ms",
                    S = "40 ms",
                    T = "50 ms",
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = 10,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };

            //Controlamos el retorno de los metodos privados que invoca VerificarInformesCompletosAsociados()
            //en GestionarReporteConInformesService
            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(It.IsAny<int>()))
                          .ReturnsAsync(idsInformesAsociados);

            _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.Is<int>(id => id == informe1Id)))
                          .ReturnsAsync(informe1Completo);
            _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.Is<int>(id => id == informe2Id)))
                          .ReturnsAsync(informe2Completo);

            var resultado = await _gestionarReporteConInformesService.VerificarInformesCompletosAsociados(informe1Id);

            Assert.IsTrue(resultado, "Se esperaba que todos los informes estuvieran completos con todos los datos instanciados y válidos.");
        }


        [Test]
        public async Task ActualizarReporteInvalido_InformesConDatosCompletos_InformesCoNulos()
        {
            //Datos que usaran los metodos DA dentro de GestionarReporteConIformesService
            int informe1Id = 10;
            int informe2Id = 11;
            var idsInformesAsociados = new List<int> { informe1Id, informe2Id };


            //Informes
            var informe1Completo = new Informe
            {
                Id = 10,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = 10,
                    OT = "OT-12345",
                    Aviso = "Aviso-001",
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
                DatosGenerales = new DatosGenerales
                {
                    Id = 10,
                    Evento = "Falla en línea de transmisión",
                    Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                    Hora = TimeSpan.Parse("08:30:00"),
                    Subestacion = "Subestación Norte",
                    LT = "LT-456",
                    Equipo = "Equipo A"
                },
                Teleproteccion = new Teleproteccion
                {
                    Id = 10,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
                DistanciaDeFalla = new DistanciaDeFalla
                {
                    Id = 10,
                    DistanciaKM = "15 km",
                    DistanciaPorcentaje = "75%",
                    DistanciaReportada = "Distancia Reportada - 14 km",
                    DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                    Error = "0.5%",
                    Error_Doble = "1%"
                },
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = 10,
                    R = "30 ms",
                    S = "40 ms",
                    T = null,
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = 10,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };

            //Informes
            var informe2Completo = new Informe
            {
                Id = 10,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = 10,
                    OT = "OT-12345",
                    Aviso = "Aviso-001",
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
                DatosGenerales = new DatosGenerales
                {
                    Id = 10,
                    Evento = "Falla en línea de transmisión",
                    Fecha = DateTime.Parse("2024-10-31T18:13:57.837"),
                    Hora = TimeSpan.Parse("08:30:00"),
                    Subestacion = "Subestación Norte",
                    LT = "LT-456",
                    Equipo = "Equipo A"
                },
                Teleproteccion = new Teleproteccion
                {
                    Id = 10,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
                DistanciaDeFalla = new DistanciaDeFalla
                {
                    Id = 10,
                    DistanciaKM = "15 km",
                    DistanciaPorcentaje = "75%",
                    DistanciaReportada = "Distancia Reportada - 14 km",
                    DistanciaDobleTemporal = "Distancia doble temporal - 10 km",
                    Error = "0.5%",
                    Error_Doble = null
                },
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = 10,
                    R = "30 ms",
                    S = "40 ms",
                    T = "50 ms",
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = 10,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };

            //Controlamos el retorno de los metodos privados que invoca VerificarInformesCompletosAsociados()
            //en GestionarReporteConInformesService
            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(It.IsAny<int>()))
                          .ReturnsAsync(idsInformesAsociados);

            _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.Is<int>(id => id == informe1Id)))
                          .ReturnsAsync(informe1Completo);
            _mockInformeDA.Setup(da => da.ObtenerInformePorId(It.Is<int>(id => id == informe2Id)))
                          .ReturnsAsync(informe2Completo);

            var resultado = await _gestionarReporteConInformesService.VerificarInformesCompletosAsociados(informe1Id);

            Assert.IsFalse(resultado, "Se esperaba que todos los informes estuvieran completos con todos los datos instanciados y válidos.");
        }

        private Informe CrearInformePersonalizado(int id, string ot = "OT-12345", string aviso = "Aviso-001", bool incluirNulos = false)
        {
            return new Informe
            {
                Id = id,
                Tipo = 2,
                SubestacionId = 1,
                LineaTransmisionId = 1,
                DatosDeLinea = new DatosDeLinea
                {
                    Id = id,
                    OT = incluirNulos ? null : ot,
                    Aviso = aviso,
                    SAP = "SAP-56789",
                    Distancia = "20 km",
                    Funcion = "Función de protección",
                    Zona = "Zona Norte"
                },
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
                Teleproteccion = new Teleproteccion
                {
                    Id = id,
                    TX_TEL = "TX-100",
                    RX_TEL = "RX-100",
                    TiempoMPLS = "200 ms"
                },
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
                TiemposDeDisparo = new TiemposDeDisparo
                {
                    Id = id,
                    R = "30 ms",
                    S = "40 ms",
                    T = "50 ms",
                    Reserva = "10 ms"
                },
                CorrientesDeFalla = new CorrientesDeFalla
                {
                    Id = id,
                    RealIR = "500 A",
                    RealIS = "600 A",
                    RealIT = "700 A",
                    AcumuladaR = "1500 A",
                    AcumuladaS = "1600 A",
                    AcumuladaT = "1700 A"
                },
                Estado = 1
            };
        }

    }
}

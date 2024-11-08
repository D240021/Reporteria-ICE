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
    public class ActualizarEstadoReporteSegunInformesTest
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
        public async Task ActualizarEstadoReporteValidoDeSupervisor_TodosInformesConfirmadosEstado1ConDatosRequeridos()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 2,
                fechaHora: DateTime.Parse("2024-10-31T18:13:57"),
                causas: "Falla eléctrica, Derrumbe",
                observacionesSupervisor: "Revisión completa"
            );  
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 1),
                    CrearInformeCompleto(11, estado: 1),
                    CrearInformeCompleto(12, estado: 1),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);
            
            Assert.IsTrue(resultado);
            Assert.AreEqual(3, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Once);
        }

        
        [Test]
        public async Task ActualizarEstadoReporteValidoDeTecnicoLinea_TodosInformesConfirmadosEstado1ConDatosRequeridos()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 3,
                fechaHora: DateTime.Parse("2024-10-31T18:13:57"),
                causas: "Falla eléctrica, Derrumbe",
                observacionesSupervisor: "Revisión completa"
            );
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 1),
                    CrearInformeCompleto(11, estado: 1),
                    CrearInformeCompleto(12, estado: 1),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);

            Assert.IsTrue(resultado);
            Assert.AreEqual(4, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Once);
        }
        
        
        [Test]
        public async Task ActualizarEstadoReporteInvalidoDeSupervisor_InformesConEstado0ConDatosRequeridos()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 2,
                fechaHora: DateTime.Parse("2024-10-31T18:13:57"),
                causas: "Falla eléctrica, Derrumbe",
                observacionesSupervisor: "Revisión completa"
            );
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 0),
                    CrearInformeCompleto(11, estado: 1),
                    CrearInformeCompleto(12, estado: 0),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);

            Assert.IsFalse(resultado);
            //No cambia de estado, ya que sus informes no estan confirmados
            Assert.AreEqual(2, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Never);
        }
        
        [Test]
        public async Task ActualizarEstadoReporteInvalidoDeTecnicoLinea_InformesConEstado0ConDatosRequeridos()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 3,
                fechaHora: DateTime.Parse("2024-10-31T18:13:57"),
                causas: "Falla eléctrica, Derrumbe",
                observacionesSupervisor: "Revisión completa"
            );
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 0),
                    CrearInformeCompleto(11, estado: 0),
                    CrearInformeCompleto(12, estado: 0),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);

            Assert.IsFalse(resultado);
            //No cambia de estado, ya que sus informes no estan confirmados
            Assert.AreEqual(3, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Never);
        }


        [Test]
        public async Task ActualizarEstadoReporteInvalidoDeSupervisor_InformesConEstado1SinDatosRequeridos()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 2,
                fechaHora: DateTime.Parse("2024-10-31T18:13:57"),
                causas: "Falla eléctrica, Derrumbe",
                observacionesSupervisor: null
            );
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 1),
                    CrearInformeCompleto(11, estado: 1),
                    CrearInformeCompleto(12, estado: 1),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);

            Assert.IsFalse(resultado);
            //No cambia de estado, ya que le faltan los datos obligatorios
            Assert.AreEqual(2, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Never);
        }


        [Test]
        public async Task ActualizarEstadoReporteInvalidoDeTecnicoLinea_InformesConEstado1SinDatosRequeridos()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 3,
                fechaHora: null,
                causas: null,
                observacionesSupervisor: "Revisión completa"
            );
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 1),
                    CrearInformeCompleto(11, estado: 1),
                    CrearInformeCompleto(12, estado: 1),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);

            Assert.IsFalse(resultado);
            //No cambia de estado, ya que sus informes no estan confirmados
            Assert.AreEqual(3, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Never);
        }


        [Test]
        public async Task ActualizarEstadoReporteValidoDeTecnicoProteccion_InformesConEstado1()
        {
            //Crear reporte completo y configurar mocks
            var reporte = CrearReporteCompleto(
                estado: 1,
                fechaHora: null,
                causas: null,
                observacionesSupervisor: null
            );
            var idsInformesAsociados = new List<int> { 10, 11, 12, 13 };
            var informesMixtos = new List<Informe>
                {
                    CrearInformeCompleto(10, estado: 1),
                    CrearInformeCompleto(11, estado: 1),
                    CrearInformeCompleto(12, estado: 1),
                    CrearInformeCompleto(13, estado: 1)
                };

            _mockReporteDA.Setup(da => da.ObtenerIdsInformesDeReporte(reporte.Id))
                          .ReturnsAsync(idsInformesAsociados);

            foreach (var informe in informesMixtos)
            {
                _mockInformeDA.Setup(da => da.ObtenerInformePorId(informe.Id)).ReturnsAsync(informe);
            }

            // Configurar el mock para `ActualizarReporte` para nunca llamarlo a la bd
            _mockReporteDA.Setup(da => da.ActualizarReporte(reporte.Id, reporte)).ReturnsAsync(true);

            //Prueba
            var resultado = await _gestionarReporteConInformesService.ActualizarEstadoReporteSegunInformes(reporte);

            Assert.IsTrue(resultado);
            //No cambia de estado, ya que sus informes no estan confirmados
            Assert.AreEqual(2, reporte.Estado);
            _mockReporteDA.Verify(da => da.ActualizarReporte(reporte.Id, reporte), Times.Once);
        }

        // Método auxiliar para crear un informe con estado y datos específicos
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



        // Método auxiliar para crear un reporte con estado específico
        private Reporte CrearReporteCompleto(int estado, DateTime? fechaHora, string causas, string observacionesSupervisor)
        {
            return new Reporte
            {
                Id = 1,
                Estado = estado,
                MapaDeDescargas = null,
                Observaciones = observacionesSupervisor,
                Evidencia = null,
                ObservacionesTecnicoLinea = "Observación del técnico de línea",
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
}

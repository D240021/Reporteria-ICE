using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE_Test.TestsUnitarios
{
    [TestFixture]
    public class RegistrarReporteTest
    {
        private Mock<IGestionarReporteDA> _mockReporteDA;
        private GestionarReporteConInformesService _gestionarReporteConInformesService;

        [SetUp]
        public void Setup()
        {
            _mockReporteDA = new Mock<IGestionarReporteDA>();

            _gestionarReporteConInformesService = new GestionarReporteConInformesService(
                new Mock<IGestionarInformeDA>().Object,
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
        public async Task RegistrarReporteValido()
        {            
            var reporte = new Reporte
            {
                Id = 0,
                MapaDeDescargas = null,
                Observaciones = null,
                Evidencia = null,
                ObservacionesTecnicoLinea = null,
                Causas = null,
                FechaHora = null,
                InformeV1Id = 0,
                InformeV2Id = 0,
                InformeV3Id = 0,
                InformeV4Id = 0,
                UsuarioSupervisorId = 1,
                TecnicoLineaId = 2,
                Estado = 0
            };
            var subestacionIds = new List<int> { 1, 2};
            int lineaTransmisionId = 1;

            // Configurar mock para simular la llamada exitosa
            _mockReporteDA.Setup(da => da.RegistrarReporte(It.IsAny<Reporte>())).ReturnsAsync(true);

            // Act
            var resultado = await _gestionarReporteConInformesService.RegistrarReporteConInformes(reporte, subestacionIds, lineaTransmisionId);

            // Assert
            Assert.IsTrue(resultado, "Se esperaba que el reporte fuera registrado con éxito con IDs válidos.");
            _mockReporteDA.Verify(da => da.RegistrarReporte(It.IsAny<Reporte>()), Times.Once);
        }

        [Test]
        public async Task RegistrarReporteInvalido_SubestacionesIdInvalidas()
        {
            var reporte = new Reporte
            {
                Id = 0,
                MapaDeDescargas = null,
                Observaciones = null,
                Evidencia = null,
                ObservacionesTecnicoLinea = null,
                Causas = null,
                FechaHora = null,
                InformeV1Id = 0,
                InformeV2Id = 0,
                InformeV3Id = 0,
                InformeV4Id = 0,
                UsuarioSupervisorId = 1,
                TecnicoLineaId = 2,
                Estado = 0
            };
            var subestacionIds = new List<int> { 1, -2};
            int lineaTransmisionId = 1;

            // Act
            var resultado = await _gestionarReporteConInformesService.RegistrarReporteConInformes(reporte, subestacionIds, lineaTransmisionId);

            // Assert
            Assert.IsFalse(resultado, "Se esperaba que la validación fallara con un ID de subestación inválido.");
            _mockReporteDA.Verify(da => da.RegistrarReporte(It.IsAny<Reporte>()), Times.Never);
        }

        [Test]
        public async Task RegistrarReporteInvalido_LineaTransmisionIdInvalido()
        {
            var reporte = new Reporte
            {
                Id = 0,
                MapaDeDescargas = null,
                Observaciones = null,
                Evidencia = null,
                ObservacionesTecnicoLinea = null,
                Causas = null,
                FechaHora = null,
                InformeV1Id = 0,
                InformeV2Id = 0,
                InformeV3Id = 0,
                InformeV4Id = 0,
                UsuarioSupervisorId = 1,
                TecnicoLineaId = 2,
                Estado = 0
            };
            var subestacionIds = new List<int> { 1, 2};
            int lineaTransmisionId = -1;

            // Act
            var resultado = await _gestionarReporteConInformesService.RegistrarReporteConInformes(reporte, subestacionIds, lineaTransmisionId);

            // Assert
            Assert.IsFalse(resultado, "Se esperaba que la validación fallara con un ID de línea de transmisión inválido.");
            _mockReporteDA.Verify(da => da.RegistrarReporte(It.IsAny<Reporte>()), Times.Never);
        }

        [Test]
        public async Task RegistrarReporteInvalido_UsuarioSupervisorIdInvalido()
        {            
            var reporte = new Reporte
            {
                UsuarioSupervisorId = 0,
                TecnicoLineaId = 2
            };
            var subestacionIds = new List<int> { 1, 2};
            int lineaTransmisionId = 1;

            // Act
            var resultado = await _gestionarReporteConInformesService.RegistrarReporteConInformes(reporte, subestacionIds, lineaTransmisionId);

            // Assert
            Assert.IsFalse(resultado, "Se esperaba que la validación fallara con un ID de supervisor inválido.");
            _mockReporteDA.Verify(da => da.RegistrarReporte(It.IsAny<Reporte>()), Times.Never);
        }

        [Test]
        public async Task RegistrarReporteInvalido_TecnicoLineaIdInvalido()
        {            
            var reporte = new Reporte
            {
                UsuarioSupervisorId = 1,
                TecnicoLineaId = 0
            };
            var subestacionIds = new List<int> { 1, 2};
            int lineaTransmisionId = 1;
         
            var resultado = await _gestionarReporteConInformesService.RegistrarReporteConInformes(reporte, subestacionIds, lineaTransmisionId);

            Assert.IsFalse(resultado, "Se esperaba que la validación fallara con un ID de técnico de línea inválido.");
            _mockReporteDA.Verify(da => da.RegistrarReporte(It.IsAny<Reporte>()), Times.Never);
        }
    }
}
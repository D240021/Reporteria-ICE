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
    public class ActualizarReporteTest
    {
        private Mock<IGestionarReporteDA> _mockReporteDA;
        private Mock<IGestionarReporteConInformesService> _mockGestionarReporteConInformesService;
        private GestionarReporteCN _gestionarReporteCN;

        [SetUp]
        public void Setup()
        {
            _mockReporteDA = new Mock<IGestionarReporteDA>();            
            _mockGestionarReporteConInformesService = new Mock<IGestionarReporteConInformesService>();
            _gestionarReporteCN = new GestionarReporteCN(_mockReporteDA.Object, _mockGestionarReporteConInformesService.Object);
        }
        
        //Metodo que valida que las FK del reporte recibido para actualizar sean validas
        [Test]
        public async Task ActualizarReporteValido()
        {
            var reporte = new Reporte
            {
                Id = 1,
                MapaDeDescargas = null,
                Observaciones = null,
                Evidencia = null,
                ObservacionesTecnicoLinea = null,
                Causas = null,
                FechaHora = null,
                InformeV1Id = 1,
                InformeV2Id = 2,
                InformeV3Id = 3,
                InformeV4Id = 4,
                UsuarioSupervisorId = 1,
                TecnicoLineaId = 2,
                Estado = 1
            };

            // Configurar el mock para simular la llamada exitosa

            _mockGestionarReporteConInformesService
                .Setup(service => service.VerificarInformesCompletosAsociados(reporte.InformeV1Id))
                .ReturnsAsync(true);

            _mockGestionarReporteConInformesService
                .Setup(service => service.ActualizarEstadoReporteSegunInformes(reporte))
                .ReturnsAsync(true);


            // Act
            var resultado = await _gestionarReporteCN.ActualizarReporte(reporte.Id,reporte);

            // Assert
            Assert.IsTrue(resultado, "Se esperaba que el reporte fuera registrado con éxito con IDs válidos.");
            _mockGestionarReporteConInformesService.Verify(service => service.ActualizarEstadoReporteSegunInformes(reporte), Times.Once);

        }


        [Test]
        public async Task ActualizarReporteInvalido_EstadoInvalido()
        {
            var reporte = new Reporte
            {
                Estado = 0,
                UsuarioSupervisorId = 1,
                TecnicoLineaId = 1,
                InformeV1Id = 1,
                InformeV2Id = 2,
                InformeV3Id = 3,
                InformeV4Id = 4
            };

            // Act
            var validacionReporte = await _gestionarReporteCN.ActualizarReporte(reporte.Id,reporte);

            // Assert
            Assert.IsFalse(validacionReporte, "El reporte debería ser inválido debido al estado fuera de rango.");
            _mockGestionarReporteConInformesService.Verify(service => service.ActualizarEstadoReporteSegunInformes(It.IsAny<Reporte>()), Times.Never);

        }

        [Test]
        public async Task ActualizarReporteInvalido_UsuarioSupervisorInvalido()
        {
            var reporte = new Reporte
            {
                Estado = 1,
                UsuarioSupervisorId = -1,
                TecnicoLineaId = 1,
                InformeV1Id = 1,
                InformeV2Id = 2,
                InformeV3Id = 3,
                InformeV4Id = 4
            };

            // Act
            var validacionReporte = await _gestionarReporteCN.ActualizarReporte(reporte.Id, reporte);

            // Assert
            Assert.IsFalse(validacionReporte, "El reporte debería ser inválido debido al id del supervisor fuera de rango.");
            _mockGestionarReporteConInformesService.Verify(service => service.ActualizarEstadoReporteSegunInformes(It.IsAny<Reporte>()), Times.Never);

        }

        [Test]
        public async Task ActualizarReporteInvalido_UsuarioTecnicoInvalido()
        {
            var reporte = new Reporte
            {
                Estado = 1,
                UsuarioSupervisorId = 1,
                TecnicoLineaId = -1,
                InformeV1Id = 1,
                InformeV2Id = 2,
                InformeV3Id = 3,
                InformeV4Id = 4
            };

            // Act
            var validacionReporte = await _gestionarReporteCN.ActualizarReporte(reporte.Id, reporte);

            // Assert
            Assert.IsFalse(validacionReporte, "El reporte debería ser inválido debido al id del técnico fuera de rango.");
            _mockGestionarReporteConInformesService.Verify(service => service.ActualizarEstadoReporteSegunInformes(It.IsAny<Reporte>()), Times.Never);

        }

        [Test]
        public async Task ActualizarReporteInvalido_InformesIdInvalidos()
        {            
            var idsInvalidos = new List<int> { -1, 0, -5, -3 };
            foreach (var idInvalido in idsInvalidos)
            {
                var reporte = new Reporte
                {
                    Id = 1,
                    Estado = 1,
                    UsuarioSupervisorId = 1,
                    TecnicoLineaId = 2,
                    InformeV1Id = idInvalido,
                    InformeV2Id = idInvalido,
                    InformeV3Id = idInvalido,
                    InformeV4Id = idInvalido
                };
                
                var validacionReporte = await _gestionarReporteCN.ActualizarReporte(reporte.Id, reporte);
                Assert.IsFalse(validacionReporte, $"El reporte debería ser inválido debido al ID inválido {idInvalido} en uno o más informes.");
            }
            _mockGestionarReporteConInformesService.Verify(service => service.ActualizarEstadoReporteSegunInformes(It.IsAny<Reporte>()), Times.Never);

        }

    }
}
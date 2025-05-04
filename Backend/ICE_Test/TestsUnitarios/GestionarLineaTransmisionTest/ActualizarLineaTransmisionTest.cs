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
    public class ActualizarLineaTransmisionTest
    {
        private Mock<IGestionarLineasTransmisionDA> _mockLineaTransmisionDA;
        private GestionarLineasTransmisionCN _gestionarLineaTransmisionCN;

        [SetUp]
        public void Setup()
        {
            // Se instancia la clase de base de datos asociada para manipular sus resultados
            _mockLineaTransmisionDA = new Mock<IGestionarLineasTransmisionDA>();
            // Clase de la cual se probarán los métodos
            _gestionarLineaTransmisionCN = new GestionarLineasTransmisionCN(_mockLineaTransmisionDA.Object);
        }

        [Test]
        public async Task ActualizarLineaTransmisionValida()
        {
            // Arrange
            var lineaTransmision = new LineaTransmision
            {
                NombreUbicacion = "Ubicacion Actualizada",
                Identificador = "LT-001"
            };
            _mockLineaTransmisionDA.Setup(da => da.ActualizarLineaTransmision(1, lineaTransmision)).ReturnsAsync(true);

            // Act
            var resultado = await _gestionarLineaTransmisionCN.ActualizarLineaTransmision(1, lineaTransmision);

            // Assert
            Assert.IsTrue(resultado, "La actualización debería ser exitosa para una línea de transmisión válida.");
            _mockLineaTransmisionDA.Verify(da => da.ActualizarLineaTransmision(1, lineaTransmision), Times.Once);
        }

        [Test]
        public async Task ActualizarLineaTransmisionInvalida_NombreUbicacionInvalido()
        {
            var lineasInvalidas = new List<LineaTransmision>
            {
                new LineaTransmision { NombreUbicacion = "", Identificador = "LT-001" },
                new LineaTransmision { NombreUbicacion = " ", Identificador = "LT-123" },
                new LineaTransmision { NombreUbicacion = "   ", Identificador = "LT-001" },
                new LineaTransmision { NombreUbicacion = new string('a', 101), Identificador = "LT-001" }
            };

            foreach (var linea in lineasInvalidas)
            {
                var resultado = await _gestionarLineaTransmisionCN.ActualizarLineaTransmision(1, linea);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {linea}");
                _mockLineaTransmisionDA.Verify(da => da.ActualizarLineaTransmision(It.IsAny<int>(), It.IsAny<LineaTransmision>()), Times.Never);
            }
        }

        [Test]
        public async Task ActualizarLineaTransmisionInvalida_IdentificadorInvalido()
        {
            var lineasInvalidas = new List<LineaTransmision>
            {
                new LineaTransmision { NombreUbicacion = "Orosi", Identificador = "" },
                new LineaTransmision { NombreUbicacion = "Tapanti", Identificador = " " },
                new LineaTransmision { NombreUbicacion = "Rio Macho", Identificador = "   " },
                new LineaTransmision { NombreUbicacion = "Rio Macho", Identificador = "Ca" },
                new LineaTransmision { NombreUbicacion = "Quetzal", Identificador = new string('a', 21) }
            };

            foreach (var linea in lineasInvalidas)
            {
                var resultado = await _gestionarLineaTransmisionCN.ActualizarLineaTransmision(1, linea);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {linea}");
                _mockLineaTransmisionDA.Verify(da => da.ActualizarLineaTransmision(It.IsAny<int>(), It.IsAny<LineaTransmision>()), Times.Never);
            }
        }
    }
}

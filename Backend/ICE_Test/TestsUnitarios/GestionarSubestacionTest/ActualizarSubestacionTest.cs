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
    public class ActualizarSubestacionTest
    {
        private Mock<IGestionarSubestacionDA> _mockSubestacionDA;
        private GestionarSubestacionCN _gestionarSubestacionCN;

        [SetUp]
        public void Setup()
        {
            // Se instancia la clase de bd asociada para manipular sus resultados
            _mockSubestacionDA = new Mock<IGestionarSubestacionDA>();
            // Clase de la cual se probarán los métodos
            _gestionarSubestacionCN = new GestionarSubestacionCN(_mockSubestacionDA.Object);
        }

        [Test]
        public async Task ActualizarSubestacionValida()
        {
            // Arrange
            var subestacion = new Subestacion
            {
                NombreUbicacion = "Ubicacion 1",
                Identificador = "ID-001",
                UnidadRegionalId = 1
            };
            _mockSubestacionDA.Setup(da => da.ActualizarSubestacion(1, subestacion)).ReturnsAsync(true);

            // Act
            var resultado = await _gestionarSubestacionCN.ActualizarSubestacion(1, subestacion);

            // Assert
            Assert.IsTrue(resultado, "La actualización debería ser exitosa para una subestación válida.");
            _mockSubestacionDA.Verify(da => da.ActualizarSubestacion(1, subestacion), Times.Once);
        }

        [Test]
        public async Task ActualizarSubestacionInvalida_NombreUbicacionInvalido()
        {
            var subestacionesInvalidas = new List<Subestacion>
            {
                new Subestacion { NombreUbicacion = "", Identificador = "ID-001", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "    ", Identificador = "ID-123", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "   ", Identificador = "ID-001", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = new string('a', 101), Identificador = "ID-001", UnidadRegionalId = 1 }
            };

            foreach (var subestacion in subestacionesInvalidas)
            {
                var resultado = await _gestionarSubestacionCN.ActualizarSubestacion(1, subestacion);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {subestacion}");
                _mockSubestacionDA.Verify(da => da.ActualizarSubestacion(It.IsAny<int>(), It.IsAny<Subestacion>()), Times.Never);
            }
        }

        [Test]
        public async Task ActualizarSubestacionInvalida_IdentificadorInvalido()
        {
            var subestacionesInvalidas = new List<Subestacion>
            {
                new Subestacion { NombreUbicacion = "Orosi", Identificador = "", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "Tapanti", Identificador = " ", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "Rio Macho", Identificador = "   ", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "Rio Macho", Identificador = "Ca", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "Quetzal", Identificador = new string('a', 21), UnidadRegionalId = 1 }
            };

            foreach (var subestacion in subestacionesInvalidas)
            {
                var resultado = await _gestionarSubestacionCN.ActualizarSubestacion(1, subestacion);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {subestacion}");
                _mockSubestacionDA.Verify(da => da.ActualizarSubestacion(It.IsAny<int>(), It.IsAny<Subestacion>()), Times.Never);
            }
        }

        [Test]
        public async Task ActualizarSubestacionInvalida_UnidadRegionalInvalida()
        {
            var subestacionesInvalidas = new List<Subestacion>
            {
                new Subestacion { NombreUbicacion = "Rio Macho", Identificador = "Sub_111", UnidadRegionalId = -12 },
                new Subestacion { NombreUbicacion = "Quetzal", Identificador = "Subestacion_RioMachoOrosi", UnidadRegionalId = 0 }
            };

            foreach (var subestacion in subestacionesInvalidas)
            {
                var resultado = await _gestionarSubestacionCN.ActualizarSubestacion(1, subestacion);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {subestacion}");
                _mockSubestacionDA.Verify(da => da.ActualizarSubestacion(It.IsAny<int>(), It.IsAny<Subestacion>()), Times.Never);
            }
        }
    }
}

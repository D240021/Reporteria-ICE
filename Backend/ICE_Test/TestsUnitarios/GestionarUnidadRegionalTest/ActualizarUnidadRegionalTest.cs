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
    public class ActualizarUnidadRegionalTest
    {
        private Mock<IGestionarUnidadRegionalDA> _mockUnidadRegionalDA;
        private GestionarUnidadRegionalCN _gestionarUnidadRegionalCN;

        [SetUp]
        public void Setup()
        {
            // Se instancia la clase de base de datos asociada para manipular sus resultados
            _mockUnidadRegionalDA = new Mock<IGestionarUnidadRegionalDA>();
            // Clase de la cual se probarán los métodos
            _gestionarUnidadRegionalCN = new GestionarUnidadRegionalCN(_mockUnidadRegionalDA.Object);
        }

        [Test]
        public async Task ActualizarUnidadRegionalValida()
        {
            // Arrange
            var unidadRegional = new UnidadRegional
            {
                NombreUbicacion = "Ubicacion Actualizada",
                Identificador = "UR-001"
            };
            _mockUnidadRegionalDA.Setup(da => da.ActualizarUnidadRegional(1, unidadRegional)).ReturnsAsync(true);

            // Act
            var resultado = await _gestionarUnidadRegionalCN.ActualizarUnidadRegional(1, unidadRegional);

            // Assert
            Assert.IsTrue(resultado, "La actualización debería ser exitosa para una unidad regional válida.");
            _mockUnidadRegionalDA.Verify(da => da.ActualizarUnidadRegional(1, unidadRegional), Times.Once);
        }

        [Test]
        public async Task ActualizarUnidadRegionalInvalida_NombreUbicacionInvalido()
        {
            var unidadesInvalidas = new List<UnidadRegional>
            {
                new UnidadRegional { NombreUbicacion = "", Identificador = "UR-001" },
                new UnidadRegional { NombreUbicacion = " ", Identificador = "UR-123" },
                new UnidadRegional { NombreUbicacion = "   ", Identificador = "UR-001" },
                new UnidadRegional { NombreUbicacion = new string('a', 101), Identificador = "UR-001" }
            };

            foreach (var unidad in unidadesInvalidas)
            {
                var resultado = await _gestionarUnidadRegionalCN.ActualizarUnidadRegional(1, unidad);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {unidad}");
                _mockUnidadRegionalDA.Verify(da => da.ActualizarUnidadRegional(It.IsAny<int>(), It.IsAny<UnidadRegional>()), Times.Never);
            }
        }

        [Test]
        public async Task ActualizarUnidadRegionalInvalida_IdentificadorInvalido()
        {
            var unidadesInvalidas = new List<UnidadRegional>
            {
                new UnidadRegional { NombreUbicacion = "Orosi", Identificador = "" },
                new UnidadRegional { NombreUbicacion = "Tapanti", Identificador = " " },
                new UnidadRegional { NombreUbicacion = "Rio Macho", Identificador = "   " },
                new UnidadRegional { NombreUbicacion = "Rio Macho", Identificador = "Ca" },
                new UnidadRegional { NombreUbicacion = "Quetzal", Identificador = new string('a', 21) }
            };

            foreach (var unidad in unidadesInvalidas)
            {
                var resultado = await _gestionarUnidadRegionalCN.ActualizarUnidadRegional(1, unidad);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {unidad}");
                _mockUnidadRegionalDA.Verify(da => da.ActualizarUnidadRegional(It.IsAny<int>(), It.IsAny<UnidadRegional>()), Times.Never);
            }
        }
    }
}

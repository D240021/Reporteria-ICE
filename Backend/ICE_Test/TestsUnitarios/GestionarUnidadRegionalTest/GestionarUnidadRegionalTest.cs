using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Dominio.ReglasDeNegocio;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE_Test.TestsUnitarios
{
    [TestFixture]
    public class RegistrarUnidadRegionalTest
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
        public async Task RegistrarUnidadRegionalValida()
        {
            // Arrange
            var unidadRegional = new UnidadRegional
            {
                NombreUbicacion = "Ubicacion Principal",
                Identificador = "UR-001"
            };
            _mockUnidadRegionalDA.Setup(da => da.RegistrarUnidadRegional(unidadRegional)).ReturnsAsync(true);

            // Act
            var resultado = await _gestionarUnidadRegionalCN.RegistrarUnidadRegional(unidadRegional);

            // Assert
            Assert.IsTrue(resultado);
            _mockUnidadRegionalDA.Verify(da => da.RegistrarUnidadRegional(unidadRegional), Times.Once);
        }

        [Test]
        public async Task RegistrarUnidadRegionalInvalida_NombreUbicacionInvalido()
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
                var resultado = await _gestionarUnidadRegionalCN.RegistrarUnidadRegional(unidad);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {unidad}");
                _mockUnidadRegionalDA.Verify(da => da.RegistrarUnidadRegional(It.IsAny<UnidadRegional>()), Times.Never);
            }
        }

        [Test]
        public async Task RegistrarUnidadRegionalInvalida_IdentificadorInvalido()
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
                var resultado = await _gestionarUnidadRegionalCN.RegistrarUnidadRegional(unidad);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {unidad}");
                _mockUnidadRegionalDA.Verify(da => da.RegistrarUnidadRegional(It.IsAny<UnidadRegional>()), Times.Never);
            }
        }

        //Falta Agregar el Metodo sobre Identificador que coincide con uno de la BD
    }
}

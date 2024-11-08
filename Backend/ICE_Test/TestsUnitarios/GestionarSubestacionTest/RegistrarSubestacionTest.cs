using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ICE_Test.TestsUnitarios
{
    [TestFixture]
    public class RegistrarSubestacionTest
    {
        private Mock<IGestionarSubestacionDA> _mockSubestacionDA;
        private GestionarSubestacionCN _gestionarSubestacionCN;

        [SetUp]
        public void Setup()
        {
            //Se instancia la clase de bd asociada para manipular sus resultados
            _mockSubestacionDA = new Mock<IGestionarSubestacionDA>();
            //Clase de la cual se probaran los metodos
            _gestionarSubestacionCN = new GestionarSubestacionCN(_mockSubestacionDA.Object);
        }

        [Test]
        public async Task RegistrarSubestacionValida()
        {
            // Arrange
            var subestacion = new Subestacion
            {
                NombreUbicacion = "Ubicacion 1",
                Identificador = "ID-001",
                UnidadRegionalId = 1
            };
            _mockSubestacionDA.Setup(da => da.RegistrarSubestacion(subestacion)).ReturnsAsync(true);

            // Act
            var resultado = await _gestionarSubestacionCN.RegistrarSubestacion(subestacion);

            // Assert
            Assert.IsTrue(resultado);
            _mockSubestacionDA.Verify(da => da.RegistrarSubestacion(subestacion), Times.Once);
        }

        [Test]
        public async Task RegistrarSubestacionInvalida_NombreUbicacionInvalido()
        {            
            var subestacionesInvalidas = new List<Subestacion>
            {
                new Subestacion { NombreUbicacion = "", Identificador = "ID-001", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = " ", Identificador = "ID-123", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = "   ", Identificador = "ID-001", UnidadRegionalId = 1 },
                new Subestacion { NombreUbicacion = new string('a', 101), Identificador = "ID-001", UnidadRegionalId = 1 }
            };

            foreach (var subestacion in subestacionesInvalidas)
            {
                var resultado = await _gestionarSubestacionCN.RegistrarSubestacion(subestacion);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {subestacion}");
                _mockSubestacionDA.Verify(da => da.RegistrarSubestacion(It.IsAny<Subestacion>()), Times.Never);
            }
        }

        [Test]
        public async Task RegistrarSubestacionInvalida_IdentificadorInvalido()
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
                var resultado = await _gestionarSubestacionCN.RegistrarSubestacion(subestacion);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {subestacion}");
                _mockSubestacionDA.Verify(da => da.RegistrarSubestacion(It.IsAny<Subestacion>()), Times.Never);
            }
        }

        [Test]
        public async Task RegistrarSubestacionInvalida_UnidadRegionalInvalida()
        {
            var subestacionesInvalidas = new List<Subestacion>
            {                
                new Subestacion { NombreUbicacion = "Rio Macho", Identificador = "Sub_111", UnidadRegionalId = -12 },
                new Subestacion { NombreUbicacion = "Quetzal", Identificador = "Subestacion_RioMachoOrosi", UnidadRegionalId = 0 }
            };

            foreach (var subestacion in subestacionesInvalidas)
            {
                var resultado = await _gestionarSubestacionCN.RegistrarSubestacion(subestacion);
                Assert.IsFalse(resultado, $"La validación falló para el caso: {subestacion}");
                _mockSubestacionDA.Verify(da => da.RegistrarSubestacion(It.IsAny<Subestacion>()), Times.Never);
            }
        }


        //Falta Agregar el Metodo sobre Identificador que coincide con uno de la BD
    }
}
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
    public class RegistrarUsuarioTest
    {
        private Mock<IGestionarUsuarioDA> _mockUsuarioDA;
        private GestionarUsuarioCN _gestionarUsuarioCN;

        [SetUp]
        public void Setup()
        {
            // Instancia la clase de base de datos para manipular sus resultados
            _mockUsuarioDA = new Mock<IGestionarUsuarioDA>();
            // Clase de la cual se probarán los métodos
            _gestionarUsuarioCN = new GestionarUsuarioCN(_mockUsuarioDA.Object);
        }

        [Test]
        public async Task RegistrarUsuarioValido()
        {
            // Arrange
            var usuario = new Usuario
            {
                NombreUsuario = "usuario_valido",
                Contrasenia = "Contrasenia123",
                Identificador = "ID-001",
                Rol = "Admin",
                SubestacionId = 1,
                UnidadRegionalId = 1,
                Nombre = "Nombre",
                Apellido = "Apellido",
                Correo = "correo@ejemplo.com"
            };
            _mockUsuarioDA.Setup(da => da.RegistrarUsuario(usuario)).ReturnsAsync(1);

            // Act
            var resultado = await _gestionarUsuarioCN.RegistrarUsuario(usuario);

            // Assert
            Assert.Greater(resultado, 0, "El ID del usuario debería ser mayor que 0 para indicar éxito.");
            _mockUsuarioDA.Verify(da => da.RegistrarUsuario(usuario), Times.Once);
        }

        [Test]
        public async Task RegistrarUsuarioInvalido_NombreUsuarioInvalido()
        {
            var usuariosInvalidos = new List<Usuario>
            {
                new Usuario { NombreUsuario = "", Contrasenia = "Contrasenia123", Identificador = "ID-001", Rol = "Admin", SubestacionId = 1 },
                new Usuario { NombreUsuario = new string('a', 101), Contrasenia = "Contrasenia123", Identificador = "ID-002", Rol = "User", SubestacionId = 2 }
            };

            foreach (var usuario in usuariosInvalidos)
            {
                var resultado = await _gestionarUsuarioCN.RegistrarUsuario(usuario);
                Assert.AreEqual(0, resultado, $"La validación falló para el caso: {usuario}");
                _mockUsuarioDA.Verify(da => da.RegistrarUsuario(It.IsAny<Usuario>()), Times.Never);
            }
        }

        [Test]
        public async Task RegistrarUsuarioInvalido_ContraseniaInvalida()
        {
            var usuariosInvalidos = new List<Usuario>
            {
                new Usuario { NombreUsuario = "usuario1", Contrasenia = "", Identificador = "ID-001", Rol = "Admin", SubestacionId = 1 },
                new Usuario { NombreUsuario = "usuario2", Contrasenia = "12345", Identificador = "ID-002", Rol = "User", SubestacionId = 2 }
            };

            foreach (var usuario in usuariosInvalidos)
            {             
                var resultado = await _gestionarUsuarioCN.RegistrarUsuario(usuario);
                Assert.AreEqual(0, resultado, $"La validación falló para el caso: {usuario}");
                _mockUsuarioDA.Verify(da => da.RegistrarUsuario(It.IsAny<Usuario>()), Times.Never);
            }
        }

        [Test]
        public async Task RegistrarUsuarioInvalido_IdentificadorInvalido()
        {
            var usuariosInvalidos = new List<Usuario>
            {
                new Usuario { NombreUsuario = "usuario1", Contrasenia = "Contrasenia123", Identificador = "", Rol = "Admin", SubestacionId = 1 },
                new Usuario { NombreUsuario = "usuario2", Contrasenia = "Contrasenia456", Identificador = "   ", Rol = "User", SubestacionId = 2 }
            };

            foreach (var usuario in usuariosInvalidos)
            {                
                var resultado = await _gestionarUsuarioCN.RegistrarUsuario(usuario);
                Assert.AreEqual(0, resultado, $"La validación falló para el caso: {usuario}");
                _mockUsuarioDA.Verify(da => da.RegistrarUsuario(It.IsAny<Usuario>()), Times.Never);
            }
        }

        [Test]
        public async Task RegistrarUsuarioInvalido_CorreoInvalido()
        {
            var usuariosInvalidos = new List<Usuario>
            {
                new Usuario { NombreUsuario = "usuario1", Contrasenia = "Contrasenia123", Identificador = "ID-001", Rol = "Admin", SubestacionId = 1, Correo = "correosinarroba.com" },
                new Usuario { NombreUsuario = "usuario2", Contrasenia = "Contrasenia456", Identificador = "ID-002", Rol = "User", SubestacionId = 2, Correo = "correo@sinpunto" }
            };

            foreach (var usuario in usuariosInvalidos)
            {                
                var resultado = await _gestionarUsuarioCN.RegistrarUsuario(usuario);
                Assert.AreEqual(0, resultado, $"La validación falló para el caso: {usuario}");
                _mockUsuarioDA.Verify(da => da.RegistrarUsuario(It.IsAny<Usuario>()), Times.Never);
            }
        }

        //Falta Agregar el Metodo sobre Identificador que coincide con uno de la BD
    }
}

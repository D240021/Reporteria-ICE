using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Contexto;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using reporteria_ice_api.Controllers;
using reporteria_ice_api.DTOs;
using ICE.Capa_Datos.Entidades;
using reporteria_ice_api.Utilitarios;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ICE_Test.TestsIntegracion
{
    [TestFixture]
    public class IniciarSesionTest : IntegrationTestBase
    {
        private UsuarioController _usuarioController;
        private IDbContextTransaction _transaction;

        [SetUp]
        public void Setup()
        {
            var gestionarUsuarioCN = Services.GetRequiredService<IGestionarUsuarioCN>();
            _usuarioController = new UsuarioController(gestionarUsuarioCN);

            // Iniciar transacción
            var scope = Services.CreateScope();
            var contexto = scope.ServiceProvider.GetRequiredService<ICE_Context>();
            _transaction = contexto.Database.BeginTransaction();            
        }

        [TearDown]
        public void TearDown()
        {
            // Revertir la transacción para limpiar la base de datos
            _transaction.Rollback();
            _transaction.Dispose();
        }

        [Test]
        public async Task IniciarSesionValida()
        {
            // Arrange - Crear el usuario de prueba con la función RegistrarUsuario
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario_trans",
                Contrasenia = EncriptarAES("contraseniaSegura123"),
                Correo = "usuario1@test.com",
                Nombre = "Usuario",
                Apellido = "Prueba",
                Identificador = "UZ00",
                Rol = "Técnico",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };
            await _usuarioController.RegistrarUsuario(usuarioDTO);

            // Credenciales correctas
            var credencialesDTO = new CredencialesDTO
            {
                NombreUsuario = "usuario_trans",
                Contrasenia = EncriptarAES("contraseniaSegura123")
            };

            // Act - Llama al método del controlador para iniciar sesión
            var resultado = await _usuarioController.IniciarSesion(credencialesDTO);

            // Assert - Verifica que el resultado sea un OkObjectResult con el usuario autenticado
            Assert.IsInstanceOf<OkObjectResult>(resultado.Result);
            var okResult = resultado.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var usuarioAutenticado = okResult.Value as UsuarioDTO;
            Assert.IsNotNull(usuarioAutenticado);
            Assert.AreEqual(credencialesDTO.NombreUsuario, usuarioAutenticado.NombreUsuario);
        }

        [Test]
        public async Task IniciarSesionInvalido_CredencialesInvalidas()
        {
            // Arrange - Crear el usuario de prueba con la función RegistrarUsuario
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario_trans",
                Contrasenia = EncriptarAES("contraseniaSegura123"),
                Correo = "usuario1@test.com",
                Nombre = "Usuario",
                Apellido = "Prueba",
                Identificador = "UZ00",
                Rol = "Técnico",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };
            await _usuarioController.RegistrarUsuario(usuarioDTO);

            // Credenciales incorrectas
            var credencialesDTO = new CredencialesDTO
            {
                NombreUsuario = "usuario_trans",
                Contrasenia = EncriptarAES("contraseniaIncorrecta")
            };

            // Act - Llama al método del controlador para iniciar sesión
            var resultado = await _usuarioController.IniciarSesion(credencialesDTO);

            // Assert - Verifica que el resultado sea Unauthorized indicando credenciales inválidas
            Assert.IsInstanceOf<UnauthorizedObjectResult>(resultado.Result);
            var unauthorizedResult = resultado.Result as UnauthorizedObjectResult;
            Assert.IsNotNull(unauthorizedResult);
            Assert.AreEqual("Credenciales inválidas.", unauthorizedResult.Value);
        }

        private string EncriptarAES(string textoPlano)
        {
            byte[] claveBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");

            using (Aes aes = Aes.Create())
            {
                aes.Key = claveBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(textoPlano);
                    }

                    byte[] datosCifrados = ms.ToArray();

                    string textoCifrado = Convert.ToBase64String(iv) + ":" + Convert.ToBase64String(datosCifrados);
                    return textoCifrado;
                }
            }            
        }        
    }
}

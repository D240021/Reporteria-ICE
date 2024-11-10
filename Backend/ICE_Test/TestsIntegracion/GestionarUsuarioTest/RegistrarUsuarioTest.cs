using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Contexto;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using reporteria_ice_api.Controllers;
using reporteria_ice_api.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage; //para las transacciones

namespace ICE_Test.TestsIntegracion
{
    [TestFixture]
    public class RegistrarUsuarioTest : IntegrationTestBase
    {
        private UsuarioController _usuarioController;
        private IDbContextTransaction _transaction;


        [SetUp]
        public void Setup()
        {
            // Obtiene el servicio de IGestionarUsuarioCN desde el proveedor de servicios configurado
            var gestionarUsuarioCN = Services.GetRequiredService<IGestionarUsuarioCN>();

            // Crea una instancia de UsuarioController con la dependencia inyectada
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

        /*
        [Test]
        public async Task RegistrarUsuario_DeberiaRegistrarUsuarioExitosamente()
        {
            // Arrange - Configuración de los datos de prueba
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario_unico_prueba",
                Contrasenia = "contraseniaSegura123",
                Correo = "nuevo_usuario_prueba@test.com",
                Nombre = "NombreNuevoPrueba",
                Apellido = "ApellidoNuevoPrueba",
                Identificador = "ID98765",
                Rol = "Administrador",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };

            // Act - Llama al método del controlador
            var resultado = await _usuarioController.RegistrarUsuario(usuarioDTO);

            // Verifica si el resultado es BadRequest y obtiene el mensaje de error
            if (resultado.Result is BadRequestObjectResult badRequest)
            {
                Console.WriteLine("Mensaje de error: " + badRequest.Value);
            }

            Assert.IsInstanceOf<OkObjectResult>(resultado.Result);
        }*/

        [Test]
        public async Task RegistrarUsuarioInvalido_NombreUsuarioRepetido()
        {
            // Arrange - Configuración de los datos de prueba con un NombreUsuario repetido
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario5",
                Contrasenia = EncriptarAES("contraseniaSegura123"),
                Correo = "nuevo_usuario_prueba@test.com",
                Nombre = "NombreNuevoPrueba",
                Apellido = "ApellidoNuevoPrueba",
                Identificador = "U00100",
                Rol = "Administrador",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };

            // Act - Llama al método del controlador
            var resultado = await _usuarioController.RegistrarUsuario(usuarioDTO);

            // Assert - Verifica que el resultado sea un BadRequestObjectResult debido a la excepción
            Assert.IsInstanceOf<BadRequestObjectResult>(resultado.Result);

            // Captura el mensaje de error en BadRequest y valida el contenido del error de Entity Framework
            var badRequestResult = resultado.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual("El nombre de usuario o el identificador ya están en uso.", badRequestResult.Value.ToString());
        }


        [Test]
        public async Task RegistrarUsuarioInvalido_IdentificadorRepetido()
        {
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario_nuevo",
                Contrasenia = EncriptarAES("contraseniaSegura123"),
                Correo = "nuevo_usuario_prueba@test.com",
                Nombre = "NombreNuevoPrueba",
                Apellido = "ApellidoNuevoPrueba",
                Identificador = "U005",
                Rol = "Administrador",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };
            
            var resultado = await _usuarioController.RegistrarUsuario(usuarioDTO);

            Assert.IsInstanceOf<BadRequestObjectResult>(resultado.Result);

            var badRequestResult = resultado.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual("El nombre de usuario o el identificador ya están en uso.", badRequestResult.Value.ToString());
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
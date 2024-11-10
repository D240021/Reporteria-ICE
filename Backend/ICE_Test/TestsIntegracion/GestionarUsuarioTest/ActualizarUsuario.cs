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
    public class ActualizarUsuarioTest : IntegrationTestBase
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
        public async Task EditarUsuario_DeberiaActualizarUsuarioExitosamente()
        {            
            int usuarioId = 1;
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario_actualizado",
                Contrasenia = EncriptarAES("contraseniaNueva123"),
                Correo = "usuario_actualizado@test.com",
                Nombre = "NombreActualizado",
                Apellido = "ApellidoActualizado",
                Identificador = "ID12345",
                Rol = "Administrador",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };

            // Act - Llama al método del controlador
            var resultado = await _usuarioController.EditarUsuario(usuarioId, usuarioDTO);

            // Assert - Verifica que el resultado sea un OkObjectResult indicando éxito
            Assert.IsInstanceOf<OkObjectResult>(resultado);
            var okResult = resultado as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue((bool)okResult.Value);
        }


        [Test]
        public async Task EditarUsuario_DeberiaRetornarBadRequest_NombreUsuarioDuplicado()
        {
            int usuarioId = 1;
            var usuarioDTO = new UsuarioDTO
            {
                NombreUsuario = "usuario5",
                Contrasenia = EncriptarAES("contraseniaNueva123"),
                Correo = "usuario_duplicado@test.com",
                Nombre = "NombreDuplicado",
                Apellido = "ApellidoDuplicado",
                Identificador = "U00100",
                Rol = "Administrador",
                SubestacionId = 1,
                UnidadRegionalId = 1
            };

            // Act - Llama al método del controlador
            var resultado = await _usuarioController.EditarUsuario(usuarioId, usuarioDTO);

            // Assert - Verifica que el resultado sea un BadRequestObjectResult debido a duplicación
            Assert.IsInstanceOf<BadRequestObjectResult>(resultado);

            // Validar que el mensaje de error esté presente (opcional)
            var badRequestResult = resultado as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            StringAssert.Contains("identificador ya están en uso", badRequestResult.Value.ToString());
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
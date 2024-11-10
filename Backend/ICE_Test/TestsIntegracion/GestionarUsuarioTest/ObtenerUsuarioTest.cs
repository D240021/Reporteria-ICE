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
    public class UsuarioControllerTests : IntegrationTestBase
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

        [Test]
        public async Task ObtenerTodosLosUsuarios_DeberiaRetornarListaDeUsuarios()
        {
            // Act - Llama al método del controlador
            var resultado = await _usuarioController.ObtenerTodosLosUsuarios();

            // Assert - Verifica que el resultado sea un OkObjectResult
            Assert.IsInstanceOf<OkObjectResult>(resultado.Result);

            // Verifica que la lista de usuarios devuelta no sea nula y tenga elementos
            var okResult = resultado.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var usuarios = okResult.Value as IEnumerable<UsuarioDTO>;
            Assert.IsNotNull(usuarios);
            Assert.IsTrue(usuarios.Any());
        }

        [Test]
        public async Task ObtenerUsuarioPorId_DeberiaRetornarUsuario_Existente()
        {
            // Arrange - Definir un ID de usuario que exista en la base de datos de prueba
            int usuarioId = 1;

            // Act - Llama al método del controlador
            var resultado = await _usuarioController.ObtenerUsuario(usuarioId);

            // Assert - Verifica que el resultado sea un OkObjectResult
            Assert.IsInstanceOf<OkObjectResult>(resultado.Result);

            // Verifica que el usuario devuelto no sea nulo y tenga el ID correcto
            var okResult = resultado.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var usuario = okResult.Value as UsuarioDTO;
            Assert.IsNotNull(usuario);
            Assert.AreEqual(usuarioId, usuario.Id);
        }

        [Test]
        public async Task ObtenerUsuarioPorId_DeberiaRetornarNotFound_UsuarioNoExistente()
        {
            // Arrange - Definir un ID de usuario que no exista en la base de datos de prueba
            int usuarioId = 9999;

            // Act - Llama al método del controlador
            var resultado = await _usuarioController.ObtenerUsuario(usuarioId);

            // Assert - Verifica que el resultado sea un NotFoundResult
            Assert.IsInstanceOf<NotFoundObjectResult>(resultado.Result);

            // Verifica el mensaje de error devuelto
            var notFoundResult = resultado.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual("Usuario no encontrado.", notFoundResult.Value);
        }
    }
}

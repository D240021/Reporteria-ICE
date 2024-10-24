using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reporteria_ice_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IGestionarRolCN _gestionarRolCN;

        public RolController(IGestionarRolCN gestionarRolCN)
        {
            _gestionarRolCN = gestionarRolCN;
        }

        // Registrar un nuevo rol
        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarRol([FromBody] Rol rol)
        {
            var respuesta = await _gestionarRolCN.RegistrarRol(rol);
            if (!respuesta)
            {
                return BadRequest("Error al registrar el rol.");
            }
            return Ok(respuesta);
        }

        // Obtener todos los roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> ObtenerTodosLosRoles()
        {
            var roles = await _gestionarRolCN.ObtenerTodosLosRoles();
            return Ok(roles);
        }

        // Obtener un rol por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> ObtenerRol(int id)
        {
            var rol = await _gestionarRolCN.ObtenerRolPorId(id);
            if (rol == null)
            {
                return NotFound("Rol no encontrado.");
            }
            return Ok(rol);
        }

        // Actualizar un rol
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarRol(int id, [FromBody] Rol rol)
        {
            var respuesta = await _gestionarRolCN.ActualizarRol(id, rol);
            if (!respuesta)
            {
                return BadRequest("Error al actualizar el rol.");
            }
            return Ok(respuesta);
        }

        // Eliminar un rol
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            var respuesta = await _gestionarRolCN.EliminarRol(id);
            if (!respuesta)
            {
                return BadRequest("Error al eliminar el rol.");
            }
            return Ok(respuesta);
        }
    }
}

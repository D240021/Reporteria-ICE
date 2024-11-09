using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using reporteria_ice_api.DTOs;
using reporteria_ice_api.Utilitarios;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using static ICE.Capa_Datos.Acciones.GestionarUsuarioDA;

namespace reporteria_ice_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGestionarUsuarioCN gestionarUsuarioCN;

        public UsuarioController(IGestionarUsuarioCN gestionarUsuarioCN)
        {
            this.gestionarUsuarioCN = gestionarUsuarioCN;
        }

        // Método para registrar un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = UsuarioDTOMapper.ConvertirDTOAUsuario(usuarioDTO);
                var respuesta = await gestionarUsuarioCN.RegistrarUsuario(usuario);

                if (respuesta <= 0)
                {
                    return BadRequest(new { message = "Error al registrar el usuario." });
                }

                return Ok(new { success = true, userId = respuesta });
            }
            catch (ConflictException ex) // Captura la excepción de conflicto si el usuario ya existe
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        // Método para obtener todos los usuarios, usando UsuarioViewDTO para visualización
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewDTO>>> ObtenerTodosLosUsuarios()
        {
            try
            {
                var usuarios = await gestionarUsuarioCN.ObtenerTodosLosUsuarios();
                var usuariosViewDTO = UsuarioDTOMapper.ConvertirListaDeUsuariosAViewDTO(usuarios);

                return Ok(usuariosViewDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("UnidadRegional/SPRV/{idUnidadRegional}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> obtenerSupervisorPorUnidadRegional(int idUnidadRegional)
        {
            try
            {
                var usuarios = await gestionarUsuarioCN.obtenerSupervisorPorUnidadRegional(idUnidadRegional);
                var usuariosViewDTO = UsuarioDTOMapper.ConvertirListaDeUsuariosAViewDTO(usuarios);

                return Ok(usuariosViewDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("UnidadRegional/TPM/{idUnidadRegional}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> obtenerTecnicoTPMPorUnidadRegional(int idUnidadRegional)
        {
            try
            {
                var usuarios = await gestionarUsuarioCN.obtenerTecnicoTPMPorUnidadRegional(idUnidadRegional);
                var usuariosViewDTO = UsuarioDTOMapper.ConvertirListaDeUsuariosAViewDTO(usuarios);

                return Ok(usuariosViewDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("UnidadRegional/TLT/{idUnidadRegional}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> obtenerTecnicoTLTPorUnidadRegional(int idUnidadRegional)
        {
            try
            {
                var usuarios = await gestionarUsuarioCN.obtenerTecnicoTLTPorUnidadRegional(idUnidadRegional);
                var usuariosViewDTO = UsuarioDTOMapper.ConvertirListaDeUsuariosAViewDTO(usuarios);

                return Ok(usuariosViewDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Método para obtener un usuario específico por ID, usando UsuarioViewDTO para visualización
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewDTO>> ObtenerUsuario(int id)
        {
            try
            {
                var usuario = await gestionarUsuarioCN.ObtenerUsuarioPorId(id);

                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                return Ok(UsuarioDTOMapper.ConvertirUsuarioAViewDTO(usuario));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Método para editar un usuario existente
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = UsuarioDTOMapper.ConvertirDTOAUsuario(usuarioDTO);
                var respuesta = await gestionarUsuarioCN.ActualizarUsuario(id, usuario);

                if (!respuesta)
                {
                    return BadRequest("Error al actualizar el usuario.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Método para eliminar un usuario por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                var respuesta = await gestionarUsuarioCN.EliminarUsuario(id);

                if (!respuesta)
                {
                    return BadRequest("Error al eliminar el usuario.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Método para iniciar sesión, validando las credenciales del usuario
        [HttpPost("IniciarSesion")]
        public async Task<ActionResult<UsuarioViewDTO>> IniciarSesion([FromBody] CredencialesDTO credencialesDTO)
        {
            try
            {
                var credenciales = CredencialesDTOMapper.ConvertirDTOACredenciales(credencialesDTO);
                var usuario = await gestionarUsuarioCN.AutenticarUsuario(credenciales.NombreUsuario, credenciales.Contrasenia);

                if (usuario == null)
                {
                    return Unauthorized("Credenciales inválidas.");
                }

                var usuarioViewDTOAutenticado = UsuarioDTOMapper.ConvertirUsuarioAViewDTO(usuario);

                return Ok(usuarioViewDTOAutenticado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using reporteria_ice_api.DTOs;
using reporteria_ice_api.Utilitarios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reporteria_ice_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly IGestionarTecnicoCN _gestionarTecnicoCN;

        public TecnicoController(IGestionarTecnicoCN gestionarTecnicoCN)
        {
            _gestionarTecnicoCN = gestionarTecnicoCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarTecnico(TecnicoDTO tecnicoDTO)
        {
            Usuario tecnico = TecnicoDTOMapper.ConvertirDTOATecnico(tecnicoDTO);
            var resultado = await _gestionarTecnicoCN.RegistrarTecnico(tecnico);
            if (!resultado)
                return BadRequest("Error al registrar el técnico.");

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> ActualizarTecnico(int id, TecnicoDTO tecnicoDTO)
        {
            Usuario tecnico = TecnicoDTOMapper.ConvertirDTOATecnico(tecnicoDTO);
            var resultado = await _gestionarTecnicoCN.ActualizarTecnico(id, tecnico);
            if (!resultado)
                return BadRequest("Error al actualizar el técnico.");

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> EliminarTecnico(int id)
        {
            var resultado = await _gestionarTecnicoCN.EliminarTecnico(id);
            if (!resultado)
                return BadRequest("Error al eliminar el técnico.");

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TecnicoDTO>> ObtenerTecnico(int id)
        {
            var tecnico = await _gestionarTecnicoCN.ObtenerTecnico(id);
            if (tecnico == null)
                return NotFound("Técnico no encontrado.");

            var tecnicoDTO = TecnicoDTOMapper.ConvertirTecnicoADTO(tecnico);
            return Ok(tecnicoDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TecnicoDTO>>> ObtenerTodosLosTecnicos()
        {
            var tecnicos = await _gestionarTecnicoCN.ObtenerTodosLosTecnicos();
            var tecnicosDTO = TecnicoDTOMapper.ConvertirListaDeTecnicosADTO(tecnicos);
            return Ok(tecnicosDTO);
        }
    }
}

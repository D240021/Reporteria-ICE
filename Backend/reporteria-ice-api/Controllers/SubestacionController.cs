using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using reporteria_ice_api.DTOs;
using reporteria_ice_api.Utilitarios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reporteria_ice_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubestacionController : ControllerBase
    {
        private readonly IGestionarSubestacionCN _gestionarSubestacionCN;

        public SubestacionController(IGestionarSubestacionCN gestionarSubestacionCN)
        {
            _gestionarSubestacionCN = gestionarSubestacionCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarSubestacion(SubestacionDTO subestacionDTO)
        {
            try
            {
                Subestacion subestacion = SubestacionDTOMapper.ConvertirDTOASubestacion(subestacionDTO);
                var respuesta = await _gestionarSubestacionCN.RegistrarSubestacion(subestacion);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubestacionDTO>>> ObtenerTodasLasSubestaciones()
        {
            try
            {
                var subestaciones = await _gestionarSubestacionCN.ObtenerTodasLasSubestaciones();
                var subestacionesDTO = SubestacionDTOMapper.ConvertirListaDeSubestacionesADTO(subestaciones);
                return Ok(subestacionesDTO.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubestacionDTO>> ObtenerSubestacion(int id)
        {
            try
            {
                var subestacion = await _gestionarSubestacionCN.ObtenerSubestacion(id);
                if (subestacion == null)
                {
                    return NotFound("Subestación no encontrada.");
                }
                return Ok(SubestacionDTOMapper.ConvertirSubestacionADTO(subestacion));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarSubestacion(int id, SubestacionDTO subestacionDTO)
        {
            try
            {
                Subestacion subestacion = SubestacionDTOMapper.ConvertirDTOASubestacion(subestacionDTO);
                var respuesta = await _gestionarSubestacionCN.ActualizarSubestacion(id, subestacion);

                if (!respuesta)
                {
                    return BadRequest("Error al actualizar la subestación.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSubestacion(int id)
        {
            try
            {
                var respuesta = await _gestionarSubestacionCN.EliminarSubestacion(id);

                if (!respuesta)
                {
                    return BadRequest("Error al eliminar la subestación.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

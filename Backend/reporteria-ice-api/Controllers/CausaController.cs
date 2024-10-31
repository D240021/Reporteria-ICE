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
    public class CausaController : ControllerBase
    {
        private readonly IGestionarCausaCN _gestionarCausaCN;

        public CausaController(IGestionarCausaCN gestionarCausaCN)
        {
            _gestionarCausaCN = gestionarCausaCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarCausa(CausaDTO causaDTO)
        {
            try
            {
                var causa = CausaDTOMapper.ConvertirDTOACausa(causaDTO);
                var respuesta = await _gestionarCausaCN.RegistrarCausa(causa);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CausaDTO>>> ObtenerTodasLasCausas()
        {
            try
            {
                var causas = await _gestionarCausaCN.ObtenerTodasLasCausas();
                var causasDTO = CausaDTOMapper.ConvertirListaDeCausasADTO(causas);
                return Ok(causasDTO.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CausaDTO>> ObtenerCausa(int id)
        {
            try
            {
                var causa = await _gestionarCausaCN.ObtenerCausaPorId(id);
                if (causa == null)
                {
                    return NotFound("Causa no encontrada.");
                }
                return Ok(CausaDTOMapper.ConvertirCausaADTO(causa));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarCausa(int id, CausaDTO causaDTO)
        {
            try
            {
                var causa = CausaDTOMapper.ConvertirDTOACausa(causaDTO);
                var respuesta = await _gestionarCausaCN.ActualizarCausa(id, causa);

                if (!respuesta)
                {
                    return BadRequest("Error al actualizar la causa.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCausa(int id)
        {
            try
            {
                var respuesta = await _gestionarCausaCN.EliminarCausa(id);

                if (!respuesta)
                {
                    return BadRequest("Error al eliminar la causa.");
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

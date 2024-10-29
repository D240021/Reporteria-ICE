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
    public class LineaTransmisionController : ControllerBase
    {
        private readonly IGestionarLineasTransmisionCN _gestionarLineasTransmisionCN;

        public LineaTransmisionController(IGestionarLineasTransmisionCN gestionarLineasTransmisionCN)
        {
            _gestionarLineasTransmisionCN = gestionarLineasTransmisionCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarLineaTransmision(LineaTransmisionDTO lineaTransmisionDTO)
        {
            try
            {
                var lineaTransmision = LineaTransmisionDTOMapper.ConvertirDTOALineaTransmision(lineaTransmisionDTO);
                var respuesta = await _gestionarLineasTransmisionCN.RegistrarLineaTransmision(lineaTransmision);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineaTransmisionDTO>>> ObtenerTodasLasLineasTransmision()
        {
            try
            {
                var lineas = await _gestionarLineasTransmisionCN.ObtenerTodasLasLineasTransmision();
                var lineasDTO = LineaTransmisionDTOMapper.ConvertirListaDeLineasTransmisionADTO(lineas);
                return Ok(lineasDTO.ToList());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LineaTransmisionDTO>> ObtenerLineaTransmision(int id)
        {
            try
            {
                var linea = await _gestionarLineasTransmisionCN.ObtenerLineaTransmision(id);
                if (linea == null)
                {
                    return NotFound("Línea de transmisión no encontrada.");
                }
                return Ok(LineaTransmisionDTOMapper.ConvertirLineaTransmisionADTO(linea));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarLineaTransmision(int id, LineaTransmisionDTO lineaTransmisionDTO)
        {
            try
            {
                var lineaTransmision = LineaTransmisionDTOMapper.ConvertirDTOALineaTransmision(lineaTransmisionDTO);
                var respuesta = await _gestionarLineasTransmisionCN.ActualizarLineaTransmision(id, lineaTransmision);

                if (!respuesta)
                {
                    return BadRequest("Error al actualizar la línea de transmisión.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLineaTransmision(int id)
        {
            try
            {
                var respuesta = await _gestionarLineasTransmisionCN.EliminarLineaTransmision(id);

                if (!respuesta)
                {
                    return BadRequest("Error al eliminar la línea de transmisión.");
                }

                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

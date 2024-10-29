using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using reporteria_ice_api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reporteria_ice_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadRegionalController : ControllerBase
    {
        private readonly IGestionarUnidadRegionalCN gestionarUnidadRegionalCN;

        public UnidadRegionalController(IGestionarUnidadRegionalCN gestionarUnidadRegionalCN)
        {
            this.gestionarUnidadRegionalCN = gestionarUnidadRegionalCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarUnidadRegional(UnidadRegionalDTO unidadRegionalDTO)
        {
            try
            {
                UnidadRegional unidadRegional = UnidadRegionalDTOMapper.ConvertirDTOAUnidadRegional(unidadRegionalDTO);
                var respuesta = await gestionarUnidadRegionalCN.RegistrarUnidadRegional(unidadRegional);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadRegionalDTO>>> ObtenerTodasLasUnidadesRegionales()
        {
            try
            {
                var unidades = await gestionarUnidadRegionalCN.ObtenerTodasLasUnidadesRegionales();
                var unidadesDTO = UnidadRegionalDTOMapper.ConvertirListaDeUnidadesRegionalesADTO(unidades);
                return Ok(unidadesDTO.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadRegionalDTO>> ObtenerUnidadRegional(int id)
        {
            try
            {
                var unidad = await gestionarUnidadRegionalCN.ObtenerUnidadRegional(id);
                if (unidad == null)
                {
                    return NotFound("Unidad regional no encontrada.");
                }
                return Ok(UnidadRegionalDTOMapper.ConvertirUnidadRegionalADTO(unidad));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarUnidadRegional(int id, UnidadRegionalDTO unidadRegionalDTO)
        {
            try
            {
                UnidadRegional unidadRegional = UnidadRegionalDTOMapper.ConvertirDTOAUnidadRegional(unidadRegionalDTO);
                var respuesta = await gestionarUnidadRegionalCN.ActualizarUnidadRegional(id, unidadRegional);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUnidadRegional(int id)
        {
            try
            {
                var respuesta = await gestionarUnidadRegionalCN.EliminarUnidadRegional(id);

                if (!respuesta)
                {
                    return BadRequest("Error al eliminar la unidad regional.");
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

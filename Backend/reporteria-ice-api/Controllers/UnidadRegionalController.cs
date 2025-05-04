using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using reporteria_ice_api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using static ICE.Capa_Datos.Acciones.GestionarUnidadRegionalDA;

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

                if (!respuesta)
                {
                    return BadRequest(new { message = "Error al registrar la unidad regional." });
                }

                return Ok(new { success = true });
            }
            catch (ConflictException ex) // Captura la excepción de conflicto si el identificador ya existe
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadRegionalDTO>>> ObtenerTodasLasUnidadesRegionales()
        {
            try
            {
                var unidades = await gestionarUnidadRegionalCN.ObtenerTodasLasUnidadesRegionales();
                var unidadesDTO = UnidadRegionalDTOMapper.ConvertirListaDeUnidadesRegionalesADTO(unidades);
                return Ok(unidadesDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
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
                    return NotFound(new { message = "Unidad regional no encontrada." });
                }

                return Ok(UnidadRegionalDTOMapper.ConvertirUnidadRegionalADTO(unidad));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarUnidadRegional(int id, UnidadRegionalDTO unidadRegionalDTO)
        {
            try
            {
                UnidadRegional unidadRegional = UnidadRegionalDTOMapper.ConvertirDTOAUnidadRegional(unidadRegionalDTO);
                var respuesta = await gestionarUnidadRegionalCN.ActualizarUnidadRegional(id, unidadRegional);

                if (!respuesta)
                {
                    return BadRequest(new { message = "Error al actualizar la unidad regional." });
                }

                return Ok(new { success = true });
            }
            catch (ConflictException ex) // Captura la excepción de conflicto si el identificador ya existe
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
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
                    return BadRequest(new { message = "Error al eliminar la unidad regional." });
                }

                return Ok(new { success = true });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}

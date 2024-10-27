using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.AspNetCore.Mvc;
using reporteria_ice_api.DTOs;
using reporteria_ice_api.Utilitarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reporteria_ice_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeController : ControllerBase
    {
        private readonly IGestionarInformeCN _gestionarInformeCN;

        public InformeController(IGestionarInformeCN gestionarInformeCN)
        {
            _gestionarInformeCN = gestionarInformeCN;
        }
        
        // Método para obtener un informe por id
        [HttpGet("{id}")]
        public async Task<ActionResult<InformeDTO>> ObtenerInformePorId(int id)
        {
            try
            {
                var informe = await _gestionarInformeCN.ObtenerInformePorId(id);
                if (informe == null)
                {
                    return NotFound("Informe no encontrado.");
                }
                var informeDTO = InformeDTOMapper.ConvertirInformeADTO(informe);
                return Ok(informeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Método para actualizar un informe completo
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarInforme(int id, InformeDTO informeDTO)
        {
            try
            {
                var informe = InformeDTOMapper.ConvertirDTOAInforme(informeDTO);

                var resultado = await _gestionarInformeCN.ActualizarInforme(informe);
                if (!resultado)
                {
                    return BadRequest("Error al actualizar el informe.");
                }
                return Ok(resultado);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Método para eliminar un informe por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarInforme(int id)
        {
            try
            {
                var resultado = await _gestionarInformeCN.EliminarInforme(id);
                if (!resultado)
                {
                    return BadRequest("Error al eliminar el informe.");
                }
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

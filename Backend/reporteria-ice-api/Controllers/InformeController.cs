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
        //Para que use la clase servicio entre Informes y Reportes
        private readonly IGestionarReporteConInformesService _gestionarReporteConInformesServiceCN;

        public InformeController(IGestionarInformeCN gestionarInformeCN, IGestionarReporteConInformesService gestionarReporteConInformesServiceCN)
        {
            _gestionarInformeCN = gestionarInformeCN;
            _gestionarReporteConInformesServiceCN = gestionarReporteConInformesServiceCN;
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

        //metodo para obtener informes pendientes de una subestacion
        [HttpGet("pendientes/{subestacionId}")]
        public async Task<ActionResult<List<InformeDTO>>> ObtenerInformePendientesPorSubestacion(int subestacionId)
        {
            try
            {
                var informesPendientes = await _gestionarInformeCN.ObtenerInformesPendientesPorSubestacion(subestacionId);
                if (informesPendientes == null || !informesPendientes.Any())
                {
                    return NotFound("No hay informes pendientes para esta subestación.");
                }
                var informesDTO = informesPendientes.Select(informe => InformeDTOMapper.ConvertirInformeADTO(informe)).ToList();
                return Ok(informesDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //metodo para obtener todos los informes de una subestacion
        [HttpGet("todos/{subestacionId}")]
        public async Task<ActionResult<List<InformeDTO>>> ObtenerInformePorSubestacion(int subestacionId)
        {
            try
            {
                var informesPendientes = await _gestionarInformeCN.ObtenerInformesPorSubestacion(subestacionId);
                if (informesPendientes == null || !informesPendientes.Any())
                {
                    return NotFound("No hay informes para esta subestación.");
                }
                var informesDTO = informesPendientes.Select(informe => InformeDTOMapper.ConvertirInformeADTO(informe)).ToList();
                return Ok(informesDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("reportePorInforme/{informeId}")]
        public async Task<ActionResult<ReporteDTO>> ObtenerReportePorInformeId(int informeId)
        {
            try
            {
                var reporte = await _gestionarReporteConInformesServiceCN.ObtenerReportePorInformeId(informeId);
                if (reporte == null)
                {
                    return NotFound("No se encontró un reporte asociado a este informe.");
                }
                
                var reporteDTO = ReporteDTOMapper.ConvertirReporteADTO(reporte);
                return Ok(reporteDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}

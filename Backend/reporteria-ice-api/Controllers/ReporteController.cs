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
    public class ReporteController : ControllerBase
    {
        private readonly IGestionarReporteCN _gestionarReporteCN;

        private readonly IGestionarReporteConInformesService _gestionarReporteConInformesServiceCN;

        public ReporteController(IGestionarReporteCN gestionarReporteCN, IGestionarReporteConInformesService gestionarReporteConInformesServiceCN)
        {
            _gestionarReporteCN = gestionarReporteCN;
            _gestionarReporteConInformesServiceCN = gestionarReporteConInformesServiceCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarReporte([FromBody] ReporteDTO reporteDTO, [FromQuery] List<int> subestacionIds, int lineaTransmisionId)
        {
            try
            {
                Reporte reporte = ReporteDTOMapper.ConvertirDTOAReporte(reporteDTO);
                
                var respuesta = await _gestionarReporteConInformesService.RegistrarReporteConInformes(reporte, subestacionIds, lineaTransmisionId);

                if (!respuesta)
                {
                    return BadRequest("Error al registrar el reporte y sus informes asociados");
                }
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteDTO>>> ObtenerTodosLosReportes()
        {
            try
            {
                var reportes = await _gestionarReporteCN.ObtenerTodosLosReportes();
                var reportesDTO = ReporteDTOMapper.ConvertirListaDeReportesADTO(reportes);
                return Ok(reportesDTO.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteDTO>> ObtenerReporte(int id)
        {
            try
            {
                var reporte = await _gestionarReporteCN.ObtenerReportePorId(id);
                if (reporte == null)
                {
                    return NotFound("Reporte no encontrado.");
                }
                return Ok(ReporteDTOMapper.ConvertirReporteADTO(reporte));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarReporte(int id, ReporteDTO reporteDTO)
        {
            try
            {
                Reporte reporte = ReporteDTOMapper.ConvertirDTOAReporte(reporteDTO);

                var respuesta = await _gestionarReporteCN.ActualizarReporte(id, reporte);

                if (!respuesta)
                {
                    return BadRequest("Error al actualizar el reporte.");
                }

                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReporte(int id)
        {
            try
            {
                var respuesta = await _gestionarReporteCN.EliminarReporte(id);

                if (!respuesta)
                {
                    return BadRequest("Error al eliminar el reporte.");
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

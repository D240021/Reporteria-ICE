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
    public class SupervisorController : ControllerBase
    {
        private readonly IGestionarSupervisorCN _gestionarSupervisorCN;

        public SupervisorController(IGestionarSupervisorCN gestionarSupervisorCN)
        {
            _gestionarSupervisorCN = gestionarSupervisorCN;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarSupervisor(SupervisorDTO supervisorDTO)
        {
            Usuario supervisor = SupervisorDTOMapper.ConvertirDTOASupervisor(supervisorDTO);
            var resultado = await _gestionarSupervisorCN.RegistrarSupervisor(supervisor);
            if (!resultado)
                return BadRequest("Error al registrar el supervisor.");

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> ActualizarSupervisor(int id, SupervisorDTO supervisorDTO)
        {
            Usuario supervisor = SupervisorDTOMapper.ConvertirDTOASupervisor(supervisorDTO);
            var resultado = await _gestionarSupervisorCN.ActualizarSupervisor(id, supervisor);
            if (!resultado)
                return BadRequest("Error al actualizar el supervisor.");

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> EliminarSupervisor(int id)
        {
            var resultado = await _gestionarSupervisorCN.EliminarSupervisor(id);
            if (!resultado)
                return BadRequest("Error al eliminar el supervisor.");

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupervisorDTO>> ObtenerSupervisor(int id)
        {
            var supervisor = await _gestionarSupervisorCN.ObtenerSupervisor(id);
            if (supervisor == null)
                return NotFound("Supervisor no encontrado.");

            var supervisorDTO = SupervisorDTOMapper.ConvertirSupervisorADTO(supervisor);
            return Ok(supervisorDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupervisorDTO>>> ObtenerTodosLosSupervisores()
        {
            var supervisores = await _gestionarSupervisorCN.ObtenerTodosLosSupervisores();
            var supervisoresDTO = SupervisorDTOMapper.ConvertirListaDeSupervisoresADTO(supervisores);
            return Ok(supervisoresDTO);
        }
    }
}

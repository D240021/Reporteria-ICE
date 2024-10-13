using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarSupervisorCN : IGestionarSupervisorCN
    {
        private readonly IGestionarSupervisorDA _gestionarSupervisorDA;

        public GestionarSupervisorCN(IGestionarSupervisorDA gestionarSupervisorDA)
        {
            _gestionarSupervisorDA = gestionarSupervisorDA;
        }

        public async Task<bool> RegistrarSupervisor(Usuario supervisor)
        {
            var validacion = ReglasUsuario.EsUsuarioValido(supervisor);

            if (!validacion.esValido)
                return false;

            return await _gestionarSupervisorDA.RegistrarSupervisor(supervisor);
        }

        public async Task<bool> ActualizarSupervisor(int id, Usuario supervisor)
        {
            var validacion = ReglasUsuario.EsUsuarioValido(supervisor);
            var validacionID = ReglasUsuario.EsIdValido(id);

            if (!validacion.esValido || !validacionID.esValido)
                return false;

            return await _gestionarSupervisorDA.ActualizarSupervisor(id, supervisor);
        }

        public async Task<bool> EliminarSupervisor(int id)
        {
            var validacionID = ReglasUsuario.EsIdValido(id);

            if (!validacionID.esValido)
                return false;

            return await _gestionarSupervisorDA.EliminarSupervisor(id);
        }

        public async Task<Usuario> ObtenerSupervisor(int id)
        {
            var validacionID = ReglasUsuario.EsIdValido(id);

            if (!validacionID.esValido)
                return null;

            return await _gestionarSupervisorDA.ObtenerSupervisor(id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosSupervisores()
        {
            return await _gestionarSupervisorDA.ObtenerTodosLosSupervisores();
        }
    }
}

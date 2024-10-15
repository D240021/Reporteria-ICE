using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarTecnicoCN : IGestionarTecnicoCN
    {
        private readonly IGestionarTecnicoDA _gestionarTecnicoDA;

        public GestionarTecnicoCN(IGestionarTecnicoDA gestionarTecnicoDA)
        {
            _gestionarTecnicoDA = gestionarTecnicoDA;
        }

        public async Task<bool> RegistrarTecnico(Usuario tecnico)
        {
            var validacion = ReglasUsuario.EsUsuarioValido(tecnico);

            if (!validacion.esValido)
                return false;

            return await _gestionarTecnicoDA.RegistrarTecnico(tecnico);
        }

        public async Task<bool> ActualizarTecnico(int id, Usuario tecnico)
        {
            var validacion = ReglasUsuario.EsUsuarioValido(tecnico);
            var validacionID = ReglasUsuario.EsIdValido(id);

            if (!validacion.esValido || !validacionID.esValido)
                return false;

            return await _gestionarTecnicoDA.ActualizarTecnico(id, tecnico);
        }

        public async Task<bool> EliminarTecnico(int id)
        {
            var validacionID = ReglasUsuario.EsIdValido(id);

            if (!validacionID.esValido)
                return false;

            return await _gestionarTecnicoDA.EliminarTecnico(id);
        }

        public async Task<Usuario> ObtenerTecnico(int id)
        {
            var validacionID = ReglasUsuario.EsIdValido(id);

            if (!validacionID.esValido)
                return null;

            return await _gestionarTecnicoDA.ObtenerTecnico(id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosTecnicos()
        {
            return await _gestionarTecnicoDA.ObtenerTodosLosTecnicos();
        }
    }
}

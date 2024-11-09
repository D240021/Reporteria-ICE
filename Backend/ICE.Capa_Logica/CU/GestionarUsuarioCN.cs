using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarUsuarioCN : IGestionarUsuarioCN
    {
        private readonly IGestionarUsuarioDA _gestionarUsuarioDA;

        public GestionarUsuarioCN(IGestionarUsuarioDA gestionarUsuarioDA)
        {
            _gestionarUsuarioDA = gestionarUsuarioDA;
        }

        public class ConflictException : Exception
        {
            public ConflictException(string message) : base(message)
            {
            }
        }

        public async Task<int> RegistrarUsuario(Usuario usuario)
        {
            var validacionUsuario = ReglasUsuario.EsUsuarioValido(usuario);
            if (!validacionUsuario.esValido)
            {
                return 0; // Si no es válido, retorna 0 (error de validación)
            }

            try
            {
                return await _gestionarUsuarioDA.RegistrarUsuario(usuario);
            }
            catch (ConflictException ex)
            {
                throw;
            }
        }


        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _gestionarUsuarioDA.ObtenerUsuarioPorId(id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios()
        {
            return await _gestionarUsuarioDA.ObtenerTodosLosUsuarios();
        }

        public async Task<IEnumerable<Usuario>> obtenerSupervisorPorUnidadRegional(int idUnidadRegional)
        {
            return await _gestionarUsuarioDA.obtenerSupervisorPorUnidadRegional(idUnidadRegional);
        }

        public async Task<IEnumerable<Usuario>> obtenerTecnicoTPMPorUnidadRegional(int idUnidadRegional)
        {
            return await _gestionarUsuarioDA.obtenerTecnicoTPMPorUnidadRegional(idUnidadRegional);
        }

        public async Task<IEnumerable<Usuario>> obtenerTecnicoTLTPorUnidadRegional(int idUnidadRegional)
        {
            return await _gestionarUsuarioDA.obtenerTecnicoTLTPorUnidadRegional(idUnidadRegional);
        }

        public async Task<bool> ActualizarUsuario(int id, Usuario usuario)
        {
            var validacionUsuario = ReglasUsuario.EsUsuarioValido(usuario);
            if (!validacionUsuario.esValido)
            {
                return false;
            }
            return await _gestionarUsuarioDA.ActualizarUsuario(id, usuario);
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            return await _gestionarUsuarioDA.EliminarUsuario(id);
        }

        public async Task<Usuario> AutenticarUsuario(string nombreUsuario, string contraseniaCifrada)
        {
            return await _gestionarUsuarioDA.AutenticarUsuario(nombreUsuario, contraseniaCifrada);
        }

       
    }
}

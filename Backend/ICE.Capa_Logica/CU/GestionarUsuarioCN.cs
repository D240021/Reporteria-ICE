using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
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

        public async Task<int> RegistrarUsuario(Usuario usuario)
        {
            return await _gestionarUsuarioDA.RegistrarUsuario(usuario);
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _gestionarUsuarioDA.ObtenerUsuarioPorId(id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios()
        {
            return await _gestionarUsuarioDA.ObtenerTodosLosUsuarios();
        }

        public async Task<bool> ActualizarUsuario(int id, Usuario usuario)
        {
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

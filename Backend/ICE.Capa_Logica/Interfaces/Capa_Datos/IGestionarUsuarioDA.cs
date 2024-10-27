using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarUsuarioDA
    {
        Task<int> RegistrarUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosLosUsuarios();
        Task<bool> ActualizarUsuario(int id, Usuario usuario);
        Task<bool> EliminarUsuario(int id);
    }
}

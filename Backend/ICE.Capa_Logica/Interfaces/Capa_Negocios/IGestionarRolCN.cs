using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarRolCN
    {
        Task<bool> RegistrarRol(Rol rol);
        Task<Rol> ObtenerRolPorId(int id);
        Task<bool> ActualizarRol(int id, Rol rol);
        Task<bool> EliminarRol(int id);
        Task<IEnumerable<Rol>> ObtenerTodosLosRoles();
    }
}

using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarRolDA
    {
        Task<bool> RegistrarRol(Rol rol);
        Task<bool> ActualizarRol(int id, Rol rol);
        Task<bool> EliminarRol(int id);
        Task<Rol> ObtenerRolPorId(int id);
        Task<IEnumerable<Rol>> ObtenerTodosLosRoles();
    }
}
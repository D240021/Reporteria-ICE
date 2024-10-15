using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarSupervisorCN
    {
        Task<bool> RegistrarSupervisor(Usuario supervisor);
        Task<bool> ActualizarSupervisor(int id, Usuario supervisor);
        Task<bool> EliminarSupervisor(int id);
        Task<Usuario> ObtenerSupervisor(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosLosSupervisores();
    }
}

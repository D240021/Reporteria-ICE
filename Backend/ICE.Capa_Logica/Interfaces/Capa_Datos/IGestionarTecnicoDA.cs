using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarTecnicoDA
    {
        Task<bool> RegistrarTecnico(Usuario tecnico);
        Task<bool> ActualizarTecnico(int id, Usuario tecnico);
        Task<bool> EliminarTecnico(int id);
        Task<Usuario> ObtenerTecnico(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosLosTecnicos();
    }
}

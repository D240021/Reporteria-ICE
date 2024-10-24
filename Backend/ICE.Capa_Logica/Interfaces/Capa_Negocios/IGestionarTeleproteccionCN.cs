using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarTeleproteccionCN
    {
        Task<int> RegistrarTeleproteccion(Teleproteccion teleproteccion);
        Task<Teleproteccion> ObtenerTeleproteccionPorId(int id);
        Task<bool> ActualizarTeleproteccion(int id, Teleproteccion teleproteccion);
        Task<bool> EliminarTeleproteccion(int id);
    }
}

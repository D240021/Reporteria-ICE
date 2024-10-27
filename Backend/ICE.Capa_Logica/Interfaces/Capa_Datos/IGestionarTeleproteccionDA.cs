using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarTeleproteccionDA
    {
        Task<int> RegistrarTeleproteccion(Teleproteccion teleproteccion);
        Task<bool> ActualizarTeleproteccion(int id, Teleproteccion teleproteccion);
        Task<bool> EliminarTeleproteccion(int id);
        Task<Teleproteccion> ObtenerTeleproteccionPorId(int id);
    }
}

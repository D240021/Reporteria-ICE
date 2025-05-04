using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarTiemposDeDisparoCN
    {
        Task<int> RegistrarTiemposDeDisparo(TiemposDeDisparo tiemposDeDisparo);
        Task<TiemposDeDisparo> ObtenerTiemposDeDisparoPorId(int id);
        Task<bool> ActualizarTiemposDeDisparo(int id, TiemposDeDisparo tiemposDeDisparo);
        Task<bool> EliminarTiemposDeDisparo(int id);
    }
}

using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarTiemposDeDisparoDA
    {
        Task<int> RegistrarTiemposDeDisparo(TiemposDeDisparo tiemposDeDisparo);
        Task<bool> ActualizarTiemposDeDisparo(int id, TiemposDeDisparo tiemposDeDisparo);
        Task<bool> EliminarTiemposDeDisparo(int id);
        Task<TiemposDeDisparo> ObtenerTiemposDeDisparoPorId(int id);
    }
}

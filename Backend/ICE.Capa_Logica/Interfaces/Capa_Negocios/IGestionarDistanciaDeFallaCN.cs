using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarDistanciaDeFallaCN
    {
        Task<int> RegistrarDistanciaDeFalla(DistanciaDeFalla distanciaDeFalla);
        Task<DistanciaDeFalla> ObtenerDistanciaDeFallaPorId(int id);
        Task<bool> ActualizarDistanciaDeFalla(int id, DistanciaDeFalla distanciaDeFalla);
        Task<bool> EliminarDistanciaDeFalla(int id);
    }
}

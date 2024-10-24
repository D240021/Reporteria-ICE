using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarDistanciaDeFallaDA
    {
        Task<int> RegistrarDistanciaDeFalla(DistanciaDeFalla distanciaDeFalla);
        Task<bool> ActualizarDistanciaDeFalla(int id, DistanciaDeFalla distanciaDeFalla);
        Task<bool> EliminarDistanciaDeFalla(int id);
        Task<DistanciaDeFalla> ObtenerDistanciaDeFallaPorId(int id);
    }
}

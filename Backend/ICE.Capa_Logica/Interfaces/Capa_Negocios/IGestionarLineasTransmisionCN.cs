using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarLineasTransmisionCN
    {
        Task<bool> ActualizarLineaTransmision(int id, LineaTransmision lineaTransmision);
        Task<bool> EliminarLineaTransmision(int id);
        Task<LineaTransmision> ObtenerLineaTransmision(int id);
        Task<IEnumerable<LineaTransmision>> ObtenerTodasLasLineasTransmision();
        Task<bool> RegistrarLineaTransmision(LineaTransmision lineaTransmision);
    }
}

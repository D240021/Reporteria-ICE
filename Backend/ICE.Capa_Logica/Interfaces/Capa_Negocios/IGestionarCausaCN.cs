using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarCausaCN
    {
        Task<bool> ActualizarCausa(int id, Causa causa);
        Task<bool> EliminarCausa(int id);        
        Task<Causa> ObtenerCausaPorId(int id);
        Task<IEnumerable<Causa>> ObtenerTodasLasCausas();
        Task<bool> RegistrarCausa(Causa causa);
    }
}

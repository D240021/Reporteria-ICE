using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarUnidadRegionalCN
    {
        Task<bool> RegistrarUnidadRegional(UnidadRegional unidadRegional);
        Task<bool> ActualizarUnidadRegional(int id, UnidadRegional unidadRegional);
        Task<bool> EliminarUnidadRegional(int id);
        Task<IEnumerable<UnidadRegional>> ObtenerTodasLasUnidadesRegionales();
        Task<UnidadRegional> ObtenerUnidadRegional(int id);
    }
}

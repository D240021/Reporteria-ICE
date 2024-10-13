using ICE.Capa_Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarUnidadRegionalDA
    {
        Task<bool> RegistrarUnidadRegional(UnidadRegional unidadRegional);
        Task<bool> ActualizarUnidadRegional(int id, UnidadRegional unidadRegional);
        Task<bool> EliminarUnidadRegional(int id);
        Task<IEnumerable<UnidadRegional>> ObtenerTodasLasUnidadesRegionales();
        Task<UnidadRegional> ObtenerUnidadRegional(int id);
    }
}

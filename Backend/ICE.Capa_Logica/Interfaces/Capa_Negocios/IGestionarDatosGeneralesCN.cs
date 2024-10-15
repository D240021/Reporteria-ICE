using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarDatosGeneralesCN
    {
        Task<bool> RegistrarDatosGenerales(DatosGenerales datosGenerales);
        Task<DatosGenerales> ObtenerDatosGeneralesPorId(int id);
        Task<bool> ActualizarDatosGenerales(int id, DatosGenerales datosGenerales);
        Task<bool> EliminarDatosGenerales(int id);
    }
}

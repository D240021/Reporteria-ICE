using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarDatosGeneralesDA
    {
        Task<int> RegistrarDatosGenerales(DatosGenerales datosGenerales);
        Task<bool> ActualizarDatosGenerales(int id, DatosGenerales datosGenerales);
        Task<bool> EliminarDatosGenerales(int id);
        Task<DatosGenerales> ObtenerDatosGeneralesPorId(int id);
    }
}

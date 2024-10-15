using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarDatosDeLineaDA
    {
        Task<bool> RegistrarDatosDeLinea(DatosDeLinea datosDeLinea);
        Task<bool> ActualizarDatosDeLinea(int id, DatosDeLinea datosDeLinea);
        Task<bool> EliminarDatosDeLinea(int id);
        Task<DatosDeLinea> ObtenerDatosDeLineaPorId(int id);
    }
}

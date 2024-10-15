using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarDatosDeLineaCN
    {
        Task<bool> RegistrarDatosDeLinea(DatosDeLinea datosDeLinea);
        Task<DatosDeLinea> ObtenerDatosDeLineaPorId(int id);
        Task<bool> ActualizarDatosDeLinea(int id, DatosDeLinea datosDeLinea);
        Task<bool> EliminarDatosDeLinea(int id);
    }
}

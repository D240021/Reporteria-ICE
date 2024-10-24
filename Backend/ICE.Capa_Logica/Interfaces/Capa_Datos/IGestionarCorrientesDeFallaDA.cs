using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarCorrientesDeFallaDA
    {
        Task<int> RegistrarCorrientesDeFalla(CorrientesDeFalla corrientesDeFalla);
        Task<bool> ActualizarCorrientesDeFalla(int id, CorrientesDeFalla corrientesDeFalla);
        Task<bool> EliminarCorrientesDeFalla(int id);
        Task<CorrientesDeFalla> ObtenerCorrientesDeFallaPorId(int id);
    }
}

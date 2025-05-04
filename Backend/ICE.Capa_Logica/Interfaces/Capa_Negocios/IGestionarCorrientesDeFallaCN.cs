using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarCorrientesDeFallaCN
    {
        Task<int> RegistrarCorrientesDeFalla(CorrientesDeFalla corrientesDeFalla);
        Task<CorrientesDeFalla> ObtenerCorrientesDeFallaPorId(int id);
        Task<bool> ActualizarCorrientesDeFalla(int id, CorrientesDeFalla corrientesDeFalla);
        Task<bool> EliminarCorrientesDeFalla(int id);
    }
}

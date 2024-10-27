using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarReporteConInformesService
    {
        Task<bool> RegistrarReporteConInformes(Reporte reporte, List<int> subestacionIds, int lineaTransmisionId);
    }
}

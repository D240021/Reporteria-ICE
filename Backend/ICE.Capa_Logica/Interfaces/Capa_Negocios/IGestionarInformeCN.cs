using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarInformeCN
    {
        Task<int> RegistrarInformeCompleto(Informe informe);
        Task<Informe> ObtenerInformePorId(int id);
        Task<bool> ActualizarInforme(Informe informe);
        Task<bool> EliminarInforme(int id);
    }
}

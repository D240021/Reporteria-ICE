using ICE.Capa_Dominio.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Datos
{
    public interface IGestionarInformeDA
    {
        Task<int> RegistrarInforme(Informe informe);
        Task<bool> ActualizarInforme(int id, Informe informe);
        Task<bool> EliminarInforme(int id);
        Task<Informe> ObtenerInformePorId(int id);
    }
}

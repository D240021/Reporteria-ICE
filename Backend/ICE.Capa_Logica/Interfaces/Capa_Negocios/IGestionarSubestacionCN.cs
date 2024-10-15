using ICE.Capa_Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.Interfaces.Capa_Negocios
{
    public interface IGestionarSubestacionCN
    {
        Task<bool> ActualizarSubestacion(int id, Subestacion subestacion);
        Task<bool> EliminarSubestacion(int id);
        Task<Subestacion> ObtenerSubestacion(int id);
        Task<IEnumerable<Subestacion>> ObtenerTodasLasSubestaciones();
        Task<bool> RegistrarSubestacion(Subestacion subestacion);
    }
}

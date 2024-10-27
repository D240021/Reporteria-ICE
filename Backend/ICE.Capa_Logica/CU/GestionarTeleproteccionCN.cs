using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarTeleproteccionCN : IGestionarTeleproteccionCN
    {
        private readonly IGestionarTeleproteccionDA _gestionarTeleproteccionDA;

        public GestionarTeleproteccionCN(IGestionarTeleproteccionDA gestionarTeleproteccionDA)
        {
            _gestionarTeleproteccionDA = gestionarTeleproteccionDA;
        }

        public async Task<int> RegistrarTeleproteccion(Teleproteccion teleproteccion)
        {
            return await _gestionarTeleproteccionDA.RegistrarTeleproteccion(teleproteccion);
        }

        public async Task<Teleproteccion> ObtenerTeleproteccionPorId(int id)
        {
            return await _gestionarTeleproteccionDA.ObtenerTeleproteccionPorId(id);
        }

        public async Task<bool> ActualizarTeleproteccion(int id, Teleproteccion teleproteccion)
        {
            return await _gestionarTeleproteccionDA.ActualizarTeleproteccion(id, teleproteccion);
        }

        public async Task<bool> EliminarTeleproteccion(int id)
        {
            return await _gestionarTeleproteccionDA.EliminarTeleproteccion(id);
        }
    }
}

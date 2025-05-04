using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarDistanciaDeFallaCN : IGestionarDistanciaDeFallaCN
    {
        private readonly IGestionarDistanciaDeFallaDA _gestionarDistanciaDeFallaDA;

        public GestionarDistanciaDeFallaCN(IGestionarDistanciaDeFallaDA gestionarDistanciaDeFallaDA)
        {
            _gestionarDistanciaDeFallaDA = gestionarDistanciaDeFallaDA;
        }

        public async Task<int> RegistrarDistanciaDeFalla(DistanciaDeFalla distanciaDeFalla)
        {
            return await _gestionarDistanciaDeFallaDA.RegistrarDistanciaDeFalla(distanciaDeFalla);
        }

        public async Task<DistanciaDeFalla> ObtenerDistanciaDeFallaPorId(int id)
        {
            return await _gestionarDistanciaDeFallaDA.ObtenerDistanciaDeFallaPorId(id);
        }

        public async Task<bool> ActualizarDistanciaDeFalla(int id, DistanciaDeFalla distanciaDeFalla)
        {
            return await _gestionarDistanciaDeFallaDA.ActualizarDistanciaDeFalla(id, distanciaDeFalla);
        }

        public async Task<bool> EliminarDistanciaDeFalla(int id)
        {
            return await _gestionarDistanciaDeFallaDA.EliminarDistanciaDeFalla(id);
        }
    }
}

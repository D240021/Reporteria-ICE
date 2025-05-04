using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarTiemposDeDisparoCN : IGestionarTiemposDeDisparoCN
    {
        private readonly IGestionarTiemposDeDisparoDA _gestionarTiemposDeDisparoDA;

        public GestionarTiemposDeDisparoCN(IGestionarTiemposDeDisparoDA gestionarTiemposDeDisparoDA)
        {
            _gestionarTiemposDeDisparoDA = gestionarTiemposDeDisparoDA;
        }

        public async Task<int> RegistrarTiemposDeDisparo(TiemposDeDisparo tiemposDeDisparo)
        {
            return await _gestionarTiemposDeDisparoDA.RegistrarTiemposDeDisparo(tiemposDeDisparo);
        }

        public async Task<TiemposDeDisparo> ObtenerTiemposDeDisparoPorId(int id)
        {
            return await _gestionarTiemposDeDisparoDA.ObtenerTiemposDeDisparoPorId(id);
        }

        public async Task<bool> ActualizarTiemposDeDisparo(int id, TiemposDeDisparo tiemposDeDisparo)
        {
            return await _gestionarTiemposDeDisparoDA.ActualizarTiemposDeDisparo(id, tiemposDeDisparo);
        }

        public async Task<bool> EliminarTiemposDeDisparo(int id)
        {
            return await _gestionarTiemposDeDisparoDA.EliminarTiemposDeDisparo(id);
        }
    }
}

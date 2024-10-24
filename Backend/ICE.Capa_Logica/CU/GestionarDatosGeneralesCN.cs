using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarDatosGeneralesCN : IGestionarDatosGeneralesCN
    {
        private readonly IGestionarDatosGeneralesDA _gestionarDatosGeneralesDA;

        public GestionarDatosGeneralesCN(IGestionarDatosGeneralesDA gestionarDatosGeneralesDA)
        {
            _gestionarDatosGeneralesDA = gestionarDatosGeneralesDA;
        }

        public async Task<int> RegistrarDatosGenerales(DatosGenerales datosGenerales)
        {
            return await _gestionarDatosGeneralesDA.RegistrarDatosGenerales(datosGenerales);
        }

        public async Task<DatosGenerales> ObtenerDatosGeneralesPorId(int id)
        {
            return await _gestionarDatosGeneralesDA.ObtenerDatosGeneralesPorId(id);
        }

        public async Task<bool> ActualizarDatosGenerales(int id, DatosGenerales datosGenerales)
        {
            return await _gestionarDatosGeneralesDA.ActualizarDatosGenerales(id, datosGenerales);
        }

        public async Task<bool> EliminarDatosGenerales(int id)
        {
            return await _gestionarDatosGeneralesDA.EliminarDatosGenerales(id);
        }
    }
}

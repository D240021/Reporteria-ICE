using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarDatosDeLineaCN : IGestionarDatosDeLineaCN
    {
        private readonly IGestionarDatosDeLineaDA _gestionarDatosDeLineaDA;

        public GestionarDatosDeLineaCN(IGestionarDatosDeLineaDA gestionarDatosDeLineaDA)
        {
            _gestionarDatosDeLineaDA = gestionarDatosDeLineaDA;
        }

        public async Task<bool> RegistrarDatosDeLinea(DatosDeLinea datosDeLinea)
        {
            return await _gestionarDatosDeLineaDA.RegistrarDatosDeLinea(datosDeLinea);
        }

        public async Task<DatosDeLinea> ObtenerDatosDeLineaPorId(int id)
        {
            return await _gestionarDatosDeLineaDA.ObtenerDatosDeLineaPorId(id);
        }

        public async Task<bool> ActualizarDatosDeLinea(int id, DatosDeLinea datosDeLinea)
        {
            return await _gestionarDatosDeLineaDA.ActualizarDatosDeLinea(id, datosDeLinea);
        }

        public async Task<bool> EliminarDatosDeLinea(int id)
        {
            return await _gestionarDatosDeLineaDA.EliminarDatosDeLinea(id);
        }
    }
}

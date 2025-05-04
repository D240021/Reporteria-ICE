using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using System.Threading.Tasks;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarCorrientesDeFallaCN : IGestionarCorrientesDeFallaCN
    {
        private readonly IGestionarCorrientesDeFallaDA _gestionarCorrientesDeFallaDA;

        public GestionarCorrientesDeFallaCN(IGestionarCorrientesDeFallaDA gestionarCorrientesDeFallaDA)
        {
            _gestionarCorrientesDeFallaDA = gestionarCorrientesDeFallaDA;
        }

        public async Task<int> RegistrarCorrientesDeFalla(CorrientesDeFalla corrientesDeFalla)
        {
            return await _gestionarCorrientesDeFallaDA.RegistrarCorrientesDeFalla(corrientesDeFalla);
        }

        public async Task<CorrientesDeFalla> ObtenerCorrientesDeFallaPorId(int id)
        {
            return await _gestionarCorrientesDeFallaDA.ObtenerCorrientesDeFallaPorId(id);
        }

        public async Task<bool> ActualizarCorrientesDeFalla(int id, CorrientesDeFalla corrientesDeFalla)
        {
            return await _gestionarCorrientesDeFallaDA.ActualizarCorrientesDeFalla(id, corrientesDeFalla);
        }

        public async Task<bool> EliminarCorrientesDeFalla(int id)
        {
            return await _gestionarCorrientesDeFallaDA.EliminarCorrientesDeFalla(id);
        }
    }
}

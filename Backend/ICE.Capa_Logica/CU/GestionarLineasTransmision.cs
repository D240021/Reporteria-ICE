using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using static ICE.Capa_Negocios.CU.GestionarUsuarioCN;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarLineasTransmisionCN : IGestionarLineasTransmisionCN
    {
        private readonly IGestionarLineasTransmisionDA _gestionarLineasTransmisionDA;

        public GestionarLineasTransmisionCN(IGestionarLineasTransmisionDA gestionarLineasTransmisionDA)
        {
            _gestionarLineasTransmisionDA = gestionarLineasTransmisionDA;
        }

        public async Task<bool> ActualizarLineaTransmision(int id, LineaTransmision lineaTransmision)
        {
            var validacion = ReglasLineaTransmision.EsLineaTransmisionValida(lineaTransmision);
            var validacionID = ReglasLineaTransmision.EsIdValido(id);

            if (!validacion.esValido || !validacionID.esValido)
                return false;

            try
            {
                return await _gestionarLineasTransmisionDA.ActualizarLineaTransmision(id, lineaTransmision);
            }
            catch (ConflictException ex)
            {
                throw; 
            }
        }

        public async Task<bool> EliminarLineaTransmision(int id)
        {
            var validacionID = ReglasLineaTransmision.EsIdValido(id);

            if (!validacionID.esValido)
                return false;

            return await _gestionarLineasTransmisionDA.EliminarLineaTransmision(id);
        }

        public async Task<LineaTransmision> ObtenerLineaTransmision(int id)
        {
            var validacionID = ReglasLineaTransmision.EsIdValido(id);

            if (!validacionID.esValido)
                return null;

            return await _gestionarLineasTransmisionDA.ObtenerLineaTransmision(id);
        }

        public async Task<IEnumerable<LineaTransmision>> ObtenerTodasLasLineasTransmision()
        {
            return await _gestionarLineasTransmisionDA.ObtenerTodasLasLineasTransmision();
        }

        public async Task<bool> RegistrarLineaTransmision(LineaTransmision lineaTransmision)
        {
            var validacion = ReglasLineaTransmision.EsLineaTransmisionValida(lineaTransmision);

            if (!validacion.esValido)
                return false;

            try
            {
                return await _gestionarLineasTransmisionDA.RegistrarLineaTransmision(lineaTransmision);
            }
            catch (ConflictException ex)
            {
                throw;
            }
        }
    }
}

using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarCausaCN : IGestionarCausaCN
    {
        private readonly IGestionarCausaDA _gestionarCausaDA;

        public GestionarCausaCN(IGestionarCausaDA gestionarCausaDA)
        {
            _gestionarCausaDA = gestionarCausaDA;
        }

        public async Task<bool> ActualizarCausa(int id, Causa causa)
        {
            var validacion = ReglasCausa.EsCausaValida(causa);
            var validacionID = ReglasCausa.EsIdValido(id);

            if (!validacion.esValido || !validacionID.esValido)
                return false;

            return await _gestionarCausaDA.ActualizarCausa(id, causa);
        }

        public async Task<bool> EliminarCausa(int id)
        {
            var validacionID = ReglasCausa.EsIdValido(id);

            if (!validacionID.esValido)
                return false;

            return await _gestionarCausaDA.EliminarCausa(id);
        }

        public async Task<Causa> ObtenerCausaPorId(int id)
        {
            var validacionID = ReglasCausa.EsIdValido(id);

            if (!validacionID.esValido)
                return null;

            return await _gestionarCausaDA.ObtenerCausaPorId(id);
        }

        public async Task<IEnumerable<Causa>> ObtenerTodasLasCausas()
        {
            return await _gestionarCausaDA.ObtenerTodasLasCausas();
        }

        public async Task<bool> RegistrarCausa(Causa causa)
        {
            var validacion = ReglasCausa.EsCausaValidaParaRegistro(causa);
            if (!validacion.esValido)
                return false;

            return await _gestionarCausaDA.RegistrarCausa(causa);
        }
    }
}

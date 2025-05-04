using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using static ICE.Capa_Negocios.CU.GestionarUsuarioCN;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarUnidadRegionalCN : IGestionarUnidadRegionalCN
    {
        private readonly IGestionarUnidadRegionalDA _gestionarUnidadRegionalDA;

        public GestionarUnidadRegionalCN(IGestionarUnidadRegionalDA gestionarUnidadRegionalDA)
        {
            _gestionarUnidadRegionalDA = gestionarUnidadRegionalDA;
        }

        public async Task<bool> RegistrarUnidadRegional(UnidadRegional unidadRegional)
        {
            var validacion = ReglasUnidadRegional.EsUnidadRegionalValida(unidadRegional);

            if (!validacion.esValido)
            {
                return false; // Si no es válida, retorna false
            }

            try
            {
                return await _gestionarUnidadRegionalDA.RegistrarUnidadRegional(unidadRegional);
            }
            catch (ConflictException ex)
            {
                throw; // Relanza la excepción de conflicto para que el controlador la maneje
            }
        }

        public async Task<bool> ActualizarUnidadRegional(int id, UnidadRegional unidadRegional)
        {
            var validacion = ReglasUnidadRegional.EsUnidadRegionalValida(unidadRegional);
            var validacionID = ReglasUnidadRegional.EsIdValido(id);

            if (!validacion.esValido || !validacionID.esValido)
                return false;

            try
            {
                return await _gestionarUnidadRegionalDA.ActualizarUnidadRegional(id, unidadRegional);
            }
            catch (ConflictException ex)
            {
                throw; // Relanza la excepción de conflicto para que el controlador la maneje
            }
        }

        public async Task<bool> EliminarUnidadRegional(int id)
        {
            var validacionID = ReglasUnidadRegional.EsIdValido(id);

            if (!validacionID.esValido)
                return false;

            return await _gestionarUnidadRegionalDA.EliminarUnidadRegional(id);
        }

        public async Task<UnidadRegional> ObtenerUnidadRegional(int id)
        {
            var validacionID = ReglasUnidadRegional.EsIdValido(id);

            if (!validacionID.esValido)
                return null;

            return await _gestionarUnidadRegionalDA.ObtenerUnidadRegional(id);
        }

        public async Task<IEnumerable<UnidadRegional>> ObtenerTodasLasUnidadesRegionales()
        {
            return await _gestionarUnidadRegionalDA.ObtenerTodasLasUnidadesRegionales();
        }
    }
}

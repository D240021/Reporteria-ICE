using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Dominio.ReglasDeNegocio;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using static ICE.Capa_Negocios.CU.GestionarUsuarioCN;

namespace ICE.Capa_Negocios.CU
{
    public class GestionarSubestacionCN : IGestionarSubestacionCN
    {
        private readonly IGestionarSubestacionDA _gestionarSubestacionDA;

        public GestionarSubestacionCN(IGestionarSubestacionDA gestionarSubestacionDA)
        {
            _gestionarSubestacionDA = gestionarSubestacionDA;
        }

        public async Task<bool> ActualizarSubestacion(int id, Subestacion subestacion)
        {
            var validacion = ReglasSubestacion.EsSubestacionValida(subestacion);
            var validacionID = ReglasSubestacion.EsIdValido(id);

            if (!validacion.esValido || !validacionID.esValido)
                return false;

            try
            {
                return await _gestionarSubestacionDA.ActualizarSubestacion(id, subestacion);
            }
            catch (ConflictException ex)
            {
                throw; // Relanza la excepción de conflicto para que el controlador la maneje
            }
        }

        public async Task<bool> EliminarSubestacion(int id)
        {
            var validacionID = ReglasSubestacion.EsIdValido(id);

            if (!validacionID.esValido)
                return false;

            return await _gestionarSubestacionDA.EliminarSubestacion(id);
        }

        public async Task<Subestacion> ObtenerSubestacion(int id)
        {
            var validacionID = ReglasSubestacion.EsIdValido(id);

            if (!validacionID.esValido)
                return null;

            return await _gestionarSubestacionDA.ObtenerSubestacion(id);
        }

        public async Task<IEnumerable<Subestacion>> ObtenerTodasLasSubestaciones()
        {
            return await _gestionarSubestacionDA.ObtenerTodasLasSubestaciones();
        }

        public async Task<bool> RegistrarSubestacion(Subestacion subestacion)
        {
            var validacion = ReglasSubestacion.EsSubestacionValida(subestacion);

            if (!validacion.esValido)
                return false;

            try
            {
                return await _gestionarSubestacionDA.RegistrarSubestacion(subestacion);
            }
            catch (ConflictException ex)
            {
                throw; // Relanza la excepción de conflicto para que el controlador la maneje
            }
        }
    }
}

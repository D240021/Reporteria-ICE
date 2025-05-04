using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarTiemposDeDisparoDA : IGestionarTiemposDeDisparoDA
    {
        private readonly ICE_Context _context;

        public GestionarTiemposDeDisparoDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<int> RegistrarTiemposDeDisparo(TiemposDeDisparo tiemposDeDisparo)
        {
            var tiemposDeDisparoDA = new TiemposDeDisparoDA
            {
                R = tiemposDeDisparo.R,
                S = tiemposDeDisparo.S,
                T = tiemposDeDisparo.T,
                Reserva = tiemposDeDisparo.Reserva
            };

            _context.TiemposDeDisparo.Add(tiemposDeDisparoDA);            

            await _context.SaveChangesAsync();
            return tiemposDeDisparoDA.Id;

            //var resultado = await _context.SaveChangesAsync();
            //return resultado > 0;
        }

        public async Task<bool> ActualizarTiemposDeDisparo(int id, TiemposDeDisparo tiemposDeDisparo)
        {
            var tiemposDeDisparoBD = await _context.TiemposDeDisparo.FirstOrDefaultAsync(t => t.Id == id);
            if (tiemposDeDisparoBD != null)
            {
                tiemposDeDisparoBD.R = tiemposDeDisparo.R;
                tiemposDeDisparoBD.S = tiemposDeDisparo.S;
                tiemposDeDisparoBD.T = tiemposDeDisparo.T;
                tiemposDeDisparoBD.Reserva = tiemposDeDisparo.Reserva;

                //var resultado = await _context.SaveChangesAsync();
                //return resultado > 0;
                return true;
            }
            return false;
        }

        public async Task<bool> EliminarTiemposDeDisparo(int id)
        {
            var tiemposDeDisparoBD = await _context.TiemposDeDisparo.FirstOrDefaultAsync(t => t.Id == id);
            if (tiemposDeDisparoBD != null)
            {
                _context.TiemposDeDisparo.Remove(tiemposDeDisparoBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<TiemposDeDisparo> ObtenerTiemposDeDisparoPorId(int id)
        {
            var tiemposDeDisparoBD = await _context.TiemposDeDisparo.FirstOrDefaultAsync(t => t.Id == id);
            if (tiemposDeDisparoBD == null)
            {
                return null;
            }

            return new TiemposDeDisparo
            {
                Id = tiemposDeDisparoBD.Id,
                R = tiemposDeDisparoBD.R,
                S = tiemposDeDisparoBD.S,
                T = tiemposDeDisparoBD.T,
                Reserva = tiemposDeDisparoBD.Reserva
            };
        }
    }
}

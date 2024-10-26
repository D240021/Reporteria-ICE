using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarCorrientesDeFallaDA : IGestionarCorrientesDeFallaDA
    {
        private readonly ICE_Context _context;

        public GestionarCorrientesDeFallaDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<int> RegistrarCorrientesDeFalla(CorrientesDeFalla corrientesDeFalla)
        {
            var corrientesDeFallaDA = new CorrientesDeFallaDA
            {
                RealIR = corrientesDeFalla.RealIR,
                RealIS = corrientesDeFalla.RealIS,
                RealIT = corrientesDeFalla.RealIT,
                AcumuladaR = corrientesDeFalla.AcumuladaR,
                AcumuladaS = corrientesDeFalla.AcumuladaS,
                AcumuladaT = corrientesDeFalla.AcumuladaT
            };

            _context.CorrientesDeFalla.Add(corrientesDeFallaDA);

            await _context.SaveChangesAsync();
            return corrientesDeFallaDA.Id;


            //var resultado = await _context.SaveChangesAsync();
            //return resultado > 0;
        }

        public async Task<bool> ActualizarCorrientesDeFalla(int id, CorrientesDeFalla corrientesDeFalla)
        {
            var corrientesDeFallaBD = await _context.CorrientesDeFalla.FirstOrDefaultAsync(c => c.Id == id);
            if (corrientesDeFallaBD != null)
            {
                corrientesDeFallaBD.RealIR = corrientesDeFalla.RealIR;
                corrientesDeFallaBD.RealIS = corrientesDeFalla.RealIS;
                corrientesDeFallaBD.RealIT = corrientesDeFalla.RealIT;
                corrientesDeFallaBD.AcumuladaR = corrientesDeFalla.AcumuladaR;
                corrientesDeFallaBD.AcumuladaS = corrientesDeFalla.AcumuladaS;
                corrientesDeFallaBD.AcumuladaT = corrientesDeFalla.AcumuladaT;

                //var resultado = await _context.SaveChangesAsync();
                //return resultado > 0;
                return true;
            }
            return false;
        }

        public async Task<bool> EliminarCorrientesDeFalla(int id)
        {
            var corrientesDeFallaBD = await _context.CorrientesDeFalla.FirstOrDefaultAsync(c => c.Id == id);
            if (corrientesDeFallaBD != null)
            {
                _context.CorrientesDeFalla.Remove(corrientesDeFallaBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<CorrientesDeFalla> ObtenerCorrientesDeFallaPorId(int id)
        {
            var corrientesDeFallaBD = await _context.CorrientesDeFalla.FirstOrDefaultAsync(c => c.Id == id);
            if (corrientesDeFallaBD == null)
            {
                return null;
            }

            return new CorrientesDeFalla
            {
                Id = corrientesDeFallaBD.Id,
                RealIR = corrientesDeFallaBD.RealIR,
                RealIS = corrientesDeFallaBD.RealIS,
                RealIT = corrientesDeFallaBD.RealIT,
                AcumuladaR = corrientesDeFallaBD.AcumuladaR,
                AcumuladaS = corrientesDeFallaBD.AcumuladaS,
                AcumuladaT = corrientesDeFallaBD.AcumuladaT
            };
        }
    }
}

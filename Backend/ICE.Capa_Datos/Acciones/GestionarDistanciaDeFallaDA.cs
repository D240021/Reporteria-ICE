using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarDistanciaDeFallaDA : IGestionarDistanciaDeFallaDA
    {
        private readonly ICE_Context _context;

        public GestionarDistanciaDeFallaDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarDistanciaDeFalla(DistanciaDeFalla distanciaDeFalla)
        {
            var distanciaDeFallaDA = new DistanciaDeFallaDA
            {
                DistanciaKM = distanciaDeFalla.DistanciaKM,
                DistanciaPorcentaje = distanciaDeFalla.DistanciaPorcentaje,
                DistanciaReportada = distanciaDeFalla.DistanciaReportada,
                DistanciaDobleTemporal = distanciaDeFalla.DistanciaDobleTemporal,
                Error = distanciaDeFalla.Error,
                Error_Doble = distanciaDeFalla.Error_Doble
            };

            _context.DistanciasDeFalla.Add(distanciaDeFallaDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarDistanciaDeFalla(int id, DistanciaDeFalla distanciaDeFalla)
        {
            var distanciaDeFallaBD = await _context.DistanciasDeFalla.FirstOrDefaultAsync(d => d.Id == id);
            if (distanciaDeFallaBD != null)
            {
                distanciaDeFallaBD.DistanciaKM = distanciaDeFalla.DistanciaKM;
                distanciaDeFallaBD.DistanciaPorcentaje = distanciaDeFalla.DistanciaPorcentaje;
                distanciaDeFallaBD.DistanciaReportada = distanciaDeFalla.DistanciaReportada;
                distanciaDeFallaBD.DistanciaDobleTemporal = distanciaDeFalla.DistanciaDobleTemporal;
                distanciaDeFallaBD.Error = distanciaDeFalla.Error;
                distanciaDeFallaBD.Error_Doble = distanciaDeFalla.Error_Doble;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarDistanciaDeFalla(int id)
        {
            var distanciaDeFallaBD = await _context.DistanciasDeFalla.FirstOrDefaultAsync(d => d.Id == id);
            if (distanciaDeFallaBD != null)
            {
                _context.DistanciasDeFalla.Remove(distanciaDeFallaBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<DistanciaDeFalla> ObtenerDistanciaDeFallaPorId(int id)
        {
            var distanciaDeFallaBD = await _context.DistanciasDeFalla.FirstOrDefaultAsync(d => d.Id == id);
            if (distanciaDeFallaBD == null)
            {
                return null;
            }

            return new DistanciaDeFalla
            {
                Id = distanciaDeFallaBD.Id,
                DistanciaKM = distanciaDeFallaBD.DistanciaKM,
                DistanciaPorcentaje = distanciaDeFallaBD.DistanciaPorcentaje,
                DistanciaReportada = distanciaDeFallaBD.DistanciaReportada,
                DistanciaDobleTemporal = distanciaDeFallaBD.DistanciaDobleTemporal,
                Error = distanciaDeFallaBD.Error,
                Error_Doble = distanciaDeFallaBD.Error_Doble
            };
        }
    }
}

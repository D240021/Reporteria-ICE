using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarTeleproteccionDA : IGestionarTeleproteccionDA
    {
        private readonly ICE_Context _context;

        public GestionarTeleproteccionDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<int> RegistrarTeleproteccion(Teleproteccion teleproteccion)
        {
            var teleproteccionDA = new TeleproteccionDA
            {
                TX_TEL = teleproteccion.TX_TEL,
                RX_TEL = teleproteccion.RX_TEL,
                TiempoMPLS = teleproteccion.TiempoMPLS
            };

            _context.Teleprotecciones.Add(teleproteccionDA);            

            await _context.SaveChangesAsync();
            return teleproteccionDA.Id;
            //var resultado = await _context.SaveChangesAsync();
            //return resultado > 0;
        }

        public async Task<bool> ActualizarTeleproteccion(int id, Teleproteccion teleproteccion)
        {
            var teleproteccionBD = await _context.Teleprotecciones.FirstOrDefaultAsync(t => t.Id == id);
            if (teleproteccionBD != null)
            {
                teleproteccionBD.TX_TEL = teleproteccion.TX_TEL;
                teleproteccionBD.RX_TEL = teleproteccion.RX_TEL;
                teleproteccionBD.TiempoMPLS = teleproteccion.TiempoMPLS;

                //var resultado = await _context.SaveChangesAsync();
                //return resultado > 0;
                return true;
            }
            return false;
        }

        public async Task<bool> EliminarTeleproteccion(int id)
        {
            var teleproteccionBD = await _context.Teleprotecciones.FirstOrDefaultAsync(t => t.Id == id);
            if (teleproteccionBD != null)
            {
                _context.Teleprotecciones.Remove(teleproteccionBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Teleproteccion> ObtenerTeleproteccionPorId(int id)
        {
            var teleproteccionBD = await _context.Teleprotecciones.FirstOrDefaultAsync(t => t.Id == id);
            if (teleproteccionBD == null)
            {
                return null;
            }

            return new Teleproteccion
            {
                Id = teleproteccionBD.Id,
                TX_TEL = teleproteccionBD.TX_TEL,
                RX_TEL = teleproteccionBD.RX_TEL,
                TiempoMPLS = teleproteccionBD.TiempoMPLS
            };
        }
    }
}

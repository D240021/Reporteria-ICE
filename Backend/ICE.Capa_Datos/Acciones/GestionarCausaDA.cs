using ICE.Capa_Datos.Contexto;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarCausaDA : IGestionarCausaDA
    {
        private readonly ICE_Context _context;

        public GestionarCausaDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarCausa(Causa causa)
        {
            var causaDA = new CausaDA
            {
                Descripcion = causa.Descripcion
            };

            _context.Causas.Add(causaDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarCausa(int id, Causa causa)
        {
            var causaBD = await _context.Causas.FirstOrDefaultAsync(c => c.Id == id);
            if (causaBD != null)
            {
                causaBD.Descripcion = causa.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarCausa(int id)
        {
            var causaBD = await _context.Causas.FirstOrDefaultAsync(c => c.Id == id);
            if (causaBD != null)
            {
                _context.Causas.Remove(causaBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Causa> ObtenerCausaPorId(int id)
        {
            var causaBD = await _context.Causas.FirstOrDefaultAsync(c => c.Id == id);
            if (causaBD == null)
            {
                return null;
            }

            return new Causa
            {
                Id = causaBD.Id,
                Descripcion = causaBD.Descripcion
            };
        }
        
        public async Task<IEnumerable<Causa>> ObtenerTodasLasCausas()
        {
            var causasBD = await _context.Causas.ToListAsync();

            return causasBD.Select(causaBD => new Causa
            {
                Id = causaBD.Id,
                Descripcion = causaBD.Descripcion
            }).ToList();
        }
    }
}

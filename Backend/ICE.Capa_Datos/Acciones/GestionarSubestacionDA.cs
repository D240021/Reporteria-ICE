using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Capa_Datos.Entidades;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarSubestacionDA : IGestionarSubestacionDA
    {
        private readonly ICE_Context _context;

        public GestionarSubestacionDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarSubestacion(int id, Subestacion subestacion)
        {
            var subestacionBD = await _context.Subestaciones.FirstOrDefaultAsync(s => s.Id == id);

            if (subestacionBD != null)
            {
                subestacionBD.NombreUbicacion = subestacion.NombreUbicacion;
                subestacionBD.Identificador = subestacion.Identificador;
                subestacionBD.UnidadRegionalId = subestacion.UnidadRegionalId;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0 ? true : throw new Exception("Error al guardar los cambios en la base de datos.");
            }

            throw new Exception("Error al actualizar, la subestación no se encontró en la base de datos.");
        }

        public async Task<bool> EliminarSubestacion(int id)
        {
            var subestacionBD = await _context.Subestaciones.FirstOrDefaultAsync(s => s.Id == id);

            if (subestacionBD != null)
            {
                _context.Subestaciones.Remove(subestacionBD);
                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                    return true;
            }

            throw new Exception("Error al eliminar, la subestación no se encontró en la base de datos.");
        }

        public async Task<Subestacion> ObtenerSubestacion(int id)
        {
            var subestacionBD = await _context.Subestaciones.FirstOrDefaultAsync(s => s.Id == id);

            if (subestacionBD == null)
                throw new Exception("Error al obtener, la subestación no se encontró en la base de datos.");

            return new Subestacion
            {
                Id = subestacionBD.Id,
                NombreUbicacion = subestacionBD.NombreUbicacion,
                Identificador = subestacionBD.Identificador,
                UnidadRegionalId = subestacionBD.UnidadRegionalId
            };
        }

        public async Task<IEnumerable<Subestacion>> ObtenerTodasLasSubestaciones()
        {
            var subestaciones = await _context.Subestaciones
                .Select(s => new Subestacion
                {
                    Id = s.Id,
                    NombreUbicacion = s.NombreUbicacion,
                    Identificador = s.Identificador,
                    UnidadRegionalId = s.UnidadRegionalId
                })
                .ToListAsync();

            return subestaciones;
        }

        public async Task<bool> RegistrarSubestacion(Subestacion subestacion)
        {
            var subestacionBD = new SubestacionDA
            {
                NombreUbicacion = subestacion.NombreUbicacion,
                Identificador = subestacion.Identificador,
                UnidadRegionalId = subestacion.UnidadRegionalId
            };

            _context.Subestaciones.Add(subestacionBD);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? true : throw new Exception("Error al registrar la subestación en la base de datos.");
        }
    }
}

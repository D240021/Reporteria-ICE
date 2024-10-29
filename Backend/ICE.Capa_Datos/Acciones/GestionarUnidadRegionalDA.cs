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
    public class GestionarUnidadRegionalDA : IGestionarUnidadRegionalDA
    {
        private readonly ICE_Context _context;

        public GestionarUnidadRegionalDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarUnidadRegional(int id, UnidadRegional unidadRegional)
        {
            var unidadRegionalBD = await _context.UnidadesRegionales.FirstOrDefaultAsync(ur => ur.Id == id);

            if (unidadRegionalBD != null)
            {
                var existeIdentificador = await _context.UnidadesRegionales.AnyAsync(ur => ur.Identificador == unidadRegional.Identificador && ur.Id != id);
                if (existeIdentificador)
                {
                    throw new Exception("El identificador ya está en uso por otra unidad regional.");
                }

                unidadRegionalBD.NombreUbicacion = unidadRegional.NombreUbicacion;
                unidadRegionalBD.Identificador = unidadRegional.Identificador;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }

            throw new Exception("La unidad regional no se encontró en la base de datos.");
        }

        public async Task<bool> EliminarUnidadRegional(int id)
        {
            var unidadRegionalBD = await _context.UnidadesRegionales.FirstOrDefaultAsync(ur => ur.Id == id);

            if (unidadRegionalBD != null)
            {
                _context.UnidadesRegionales.Remove(unidadRegionalBD);
                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                    return true;
            }

            throw new Exception("Error al eliminar, la unidad regional no se encontró en la base de datos.");
        }

        public async Task<UnidadRegional> ObtenerUnidadRegional(int id)
        {
            var unidadRegionalBD = await _context.UnidadesRegionales.FirstOrDefaultAsync(ur => ur.Id == id);

            if (unidadRegionalBD == null)
                throw new Exception("Error al obtener, la unidad regional no se encontró en la base de datos.");

            return new UnidadRegional
            {
                Id = unidadRegionalBD.Id,
                NombreUbicacion = unidadRegionalBD.NombreUbicacion,
                Identificador = unidadRegionalBD.Identificador
            };
        }

        public async Task<IEnumerable<UnidadRegional>> ObtenerTodasLasUnidadesRegionales()
        {
            var unidades = await _context.UnidadesRegionales
                .Select(ur => new UnidadRegional
                {
                    Id = ur.Id,
                    NombreUbicacion = ur.NombreUbicacion,
                    Identificador = ur.Identificador
                })
                .ToListAsync();

            return unidades;
        }

        public async Task<bool> RegistrarUnidadRegional(UnidadRegional unidadRegional)
        {
            var existeIdentificador = await _context.UnidadesRegionales.AnyAsync(ur => ur.Identificador == unidadRegional.Identificador);
            if (existeIdentificador)
            {
                throw new Exception("El identificador ya está en uso.");
            }

            var unidadRegionalBD = new UnidadRegionalDA
            {
                NombreUbicacion = unidadRegional.NombreUbicacion,
                Identificador = unidadRegional.Identificador
            };

            _context.UnidadesRegionales.Add(unidadRegionalBD);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0;
        }
    }
}

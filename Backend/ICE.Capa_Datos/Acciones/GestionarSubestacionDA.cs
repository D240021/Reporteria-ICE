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
                var existeIdentificador = await _context.Subestaciones.AnyAsync(s => s.Identificador == subestacion.Identificador && s.Id != id);
                if (existeIdentificador)
                {
                    throw new Exception("El identificador ya está en uso por otra subestación.");
                }

                var existeNombre = await _context.Subestaciones.AnyAsync(s => s.NombreUbicacion == subestacion.NombreUbicacion && s.Id != id);
                if (existeNombre)
                {
                    throw new Exception("El nombre de la ubicación ya está en uso por otra subestación.");
                }

                subestacionBD.NombreUbicacion = subestacion.NombreUbicacion;
                subestacionBD.Identificador = subestacion.Identificador;
                subestacionBD.UnidadRegionalId = subestacion.UnidadRegionalId;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }

            throw new Exception("La subestación no se encontró en la base de datos.");
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
            // Primero obtenemos la subestación
            var subestacionBD = await _context.Subestaciones
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subestacionBD == null)
                throw new Exception("Error al obtener, la subestación no se encontró en la base de datos.");

            // Luego obtenemos la unidad regional asociada
            var unidadRegional = await _context.UnidadesRegionales
                .AsNoTracking()
                .FirstOrDefaultAsync(ur => ur.Id == subestacionBD.UnidadRegionalId);

            if (unidadRegional == null)
                throw new Exception("Error al obtener, la unidad regional no se encontró en la base de datos.");

            // Retornamos la subestación con el nombre de la unidad regional
            return new Subestacion
            {
                Id = subestacionBD.Id,
                NombreUbicacion = subestacionBD.NombreUbicacion,
                Identificador = subestacionBD.Identificador,
                UnidadRegionalId = subestacionBD.UnidadRegionalId,
                NombreUnidadRegional = unidadRegional.NombreUbicacion // Asigna el nombre de la unidad regional
            };
        }

        public async Task<IEnumerable<Subestacion>> ObtenerTodasLasSubestaciones()
        {
            var subestaciones = await _context.Subestaciones
                .Join(
                    _context.UnidadesRegionales,
                    subestacion => subestacion.UnidadRegionalId,
                    unidadRegional => unidadRegional.Id,
                    (subestacion, unidadRegional) => new Subestacion
                    {
                        Id = subestacion.Id,
                        NombreUbicacion = subestacion.NombreUbicacion,
                        Identificador = subestacion.Identificador,
                        UnidadRegionalId = subestacion.UnidadRegionalId,
                        NombreUnidadRegional = unidadRegional != null ? unidadRegional.NombreUbicacion : null
                    })
                .ToListAsync();

            return subestaciones;
        }



        public async Task<bool> RegistrarSubestacion(Subestacion subestacion)
        {
            var existeIdentificador = await _context.Subestaciones.AnyAsync(s => s.Identificador == subestacion.Identificador);
            if (existeIdentificador)
            {
                throw new Exception("El identificador ya está en uso.");
            }

            var existeNombre = await _context.Subestaciones.AnyAsync(s => s.NombreUbicacion == subestacion.NombreUbicacion);
            if (existeNombre)
            {
                throw new Exception("El nombre de la ubicación ya está en uso.");
            }

            var subestacionBD = new SubestacionDA
            {
                NombreUbicacion = subestacion.NombreUbicacion,
                Identificador = subestacion.Identificador,
                UnidadRegionalId = subestacion.UnidadRegionalId
            };

            _context.Subestaciones.Add(subestacionBD);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0;
        }

    }
}

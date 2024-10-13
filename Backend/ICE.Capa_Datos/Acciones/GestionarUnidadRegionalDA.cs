using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Capa_Datos.Entidades; // Asegúrate de incluir la referencia a la capa de datos

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarUnidadRegionalDA : IGestionarUnidadRegionalDA
    {
        private readonly ICE_Context _context;

        public GestionarUnidadRegionalDA(ICE_Context context)
        {
            _context = context;
        }

        // Método para actualizar una unidad regional
        public async Task<bool> ActualizarUnidadRegional(int id, UnidadRegional unidadRegional)
        {
            var unidadRegionalBD = await _context.UnidadesRegionales.FirstOrDefaultAsync(ur => ur.Id == id);

            if (unidadRegionalBD != null)
            {
                // Mapea los valores de la clase del dominio a la clase de acceso a datos
                unidadRegionalBD.NombreUbicacion = unidadRegional.NombreUbicacion;
                unidadRegionalBD.Identificador = unidadRegional.Identificador;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0 ? true : throw new Exception("Error al guardar los cambios en la base de datos.");
            }

            throw new Exception("Error al actualizar, la unidad regional no se encontró en la base de datos.");
        }

        // Método para eliminar una unidad regional
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

        // Método para obtener una unidad regional por su ID
        public async Task<UnidadRegional> ObtenerUnidadRegional(int id)
        {
            var unidadRegionalBD = await _context.UnidadesRegionales.FirstOrDefaultAsync(ur => ur.Id == id);

            if (unidadRegionalBD == null)
                throw new Exception("Error al obtener, la unidad regional no se encontró en la base de datos.");

            // Convertir la entidad de acceso a datos a la entidad del dominio
            return new UnidadRegional
            {
                Id = unidadRegionalBD.Id,
                NombreUbicacion = unidadRegionalBD.NombreUbicacion,
                Identificador = unidadRegionalBD.Identificador
            };
        }

        // Método para obtener todas las unidades regionales
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

        // Método para registrar una nueva unidad regional
        public async Task<bool> RegistrarUnidadRegional(UnidadRegional unidadRegional)
        {
            // Convertir la entidad de dominio a la entidad de acceso a datos
            var unidadRegionalBD = new UnidadRegionalDA
            {
                NombreUbicacion = unidadRegional.NombreUbicacion,
                Identificador = unidadRegional.Identificador
            };

            _context.UnidadesRegionales.Add(unidadRegionalBD);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? true : throw new Exception("Error al registrar la unidad regional en la base de datos.");
        }
    }
}

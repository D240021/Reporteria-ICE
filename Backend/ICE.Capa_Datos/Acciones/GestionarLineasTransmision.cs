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
    public class GestionarLineasTransmisionDA : IGestionarLineasTransmisionDA
    {
        private readonly ICE_Context _context;

        public GestionarLineasTransmisionDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarLineaTransmision(int id, LineaTransmision lineaTransmision)
        {
            var lineaTransmisionBD = await _context.LineasTransmision.FirstOrDefaultAsync(lt => lt.Id == id);

            if (lineaTransmisionBD != null)
            {
                lineaTransmisionBD.NombreUbicacion = lineaTransmision.NombreUbicacion;
                lineaTransmisionBD.Identificador = lineaTransmision.Identificador;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0 ? true : throw new Exception("Error al guardar los cambios en la base de datos.");
            }

            throw new Exception("Error al actualizar, la línea de transmisión no se encontró en la base de datos.");
        }

        public async Task<bool> EliminarLineaTransmision(int id)
        {
            var lineaTransmisionBD = await _context.LineasTransmision.FirstOrDefaultAsync(lt => lt.Id == id);

            if (lineaTransmisionBD != null)
            {
                _context.LineasTransmision.Remove(lineaTransmisionBD);
                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                    return true;
            }

            throw new Exception("Error al eliminar, la línea de transmisión no se encontró en la base de datos.");
        }

        public async Task<LineaTransmision> ObtenerLineaTransmision(int id)
        {
            var lineaTransmisionBD = await _context.LineasTransmision.FirstOrDefaultAsync(lt => lt.Id == id);

            if (lineaTransmisionBD == null)
                throw new Exception("Error al obtener, la línea de transmisión no se encontró en la base de datos.");

            return new LineaTransmision
            {
                Id = lineaTransmisionBD.Id,
                NombreUbicacion = lineaTransmisionBD.NombreUbicacion,
                Identificador = lineaTransmisionBD.Identificador
            };
        }

        public async Task<IEnumerable<LineaTransmision>> ObtenerTodasLasLineasTransmision()
        {
            var lineas = await _context.LineasTransmision
                .Select(lt => new LineaTransmision
                {
                    Id = lt.Id,
                    NombreUbicacion = lt.NombreUbicacion,
                    Identificador = lt.Identificador
                })
                .ToListAsync();

            return lineas;
        }

        public async Task<bool> RegistrarLineaTransmision(LineaTransmision lineaTransmision)
        {
            var lineaTransmisionBD = new LineaTransmisionDA
            {
                NombreUbicacion = lineaTransmision.NombreUbicacion,
                Identificador = lineaTransmision.Identificador
            };

            _context.LineasTransmision.Add(lineaTransmisionBD);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? true : throw new Exception("Error al registrar la línea de transmisión en la base de datos.");
        }
    }
}

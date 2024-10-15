using ICE.Capa_Datos.Contexto;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using Microsoft.EntityFrameworkCore;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarDatosGeneralesDA : IGestionarDatosGeneralesDA
    {
        private readonly ICE_Context _context;

        public GestionarDatosGeneralesDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarDatosGenerales(DatosGenerales datosGenerales)
        {
            var datosGeneralesDA = new DatosGeneralesDA
            {
                Evento = datosGenerales.Evento,
                Fecha = datosGenerales.Fecha,
                Hora = datosGenerales.Hora,
                Subestacion = datosGenerales.Subestacion,
                LT = datosGenerales.LT,
                Equipo = datosGenerales.Equipo
            };

            _context.DatosGenerales.Add(datosGeneralesDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarDatosGenerales(int id, DatosGenerales datosGenerales)
        {
            var datosGeneralesBD = await _context.DatosGenerales.FirstOrDefaultAsync(d => d.Id == id);
            if (datosGeneralesBD != null)
            {
                datosGeneralesBD.Evento = datosGenerales.Evento;
                datosGeneralesBD.Fecha = datosGenerales.Fecha;
                datosGeneralesBD.Hora = datosGenerales.Hora;
                datosGeneralesBD.Subestacion = datosGenerales.Subestacion;
                datosGeneralesBD.LT = datosGenerales.LT;
                datosGeneralesBD.Equipo = datosGenerales.Equipo;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarDatosGenerales(int id)
        {
            var datosGeneralesBD = await _context.DatosGenerales.FirstOrDefaultAsync(d => d.Id == id);
            if (datosGeneralesBD != null)
            {
                _context.DatosGenerales.Remove(datosGeneralesBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<DatosGenerales> ObtenerDatosGeneralesPorId(int id)
        {
            var datosGeneralesBD = await _context.DatosGenerales.FirstOrDefaultAsync(d => d.Id == id);
            if (datosGeneralesBD == null)
            {
                return null;
            }

            return new DatosGenerales
            {
                Id = datosGeneralesBD.Id,
                Evento = datosGeneralesBD.Evento,
                Fecha = datosGeneralesBD.Fecha,
                Hora = datosGeneralesBD.Hora,
                Subestacion = datosGeneralesBD.Subestacion,
                LT = datosGeneralesBD.LT,
                Equipo = datosGeneralesBD.Equipo
            };
        }
    }
}

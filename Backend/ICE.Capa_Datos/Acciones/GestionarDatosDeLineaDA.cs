using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarDatosDeLineaDA : IGestionarDatosDeLineaDA
    {
        private readonly ICE_Context _context;

        public GestionarDatosDeLineaDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<int> RegistrarDatosDeLinea(DatosDeLinea datosDeLinea)
        {
            var datosDeLineaDA = new DatosDeLineaDA
            {
                OT = datosDeLinea.OT,
                Aviso = datosDeLinea.Aviso,
                SAP = datosDeLinea.SAP,
                Distancia = datosDeLinea.Distancia,
                Funcion = datosDeLinea.Funcion,
                Zona = datosDeLinea.Zona
            };

            _context.DatosDeLinea.Add(datosDeLineaDA);

            await _context.SaveChangesAsync();
            return datosDeLineaDA.Id;

            
            //var resultado = await _context.SaveChangesAsync();
            //return resultado > 0;
        }

        public async Task<bool> ActualizarDatosDeLinea(int id, DatosDeLinea datosDeLinea)
        {
            var datosDeLineaBD = await _context.DatosDeLinea.FirstOrDefaultAsync(d => d.Id == id);
            if (datosDeLineaBD != null)
            {
                datosDeLineaBD.OT = datosDeLinea.OT;
                datosDeLineaBD.Aviso = datosDeLinea.Aviso;
                datosDeLineaBD.SAP = datosDeLinea.SAP;
                datosDeLineaBD.Distancia = datosDeLinea.Distancia;
                datosDeLineaBD.Funcion = datosDeLinea.Funcion;
                datosDeLineaBD.Zona = datosDeLinea.Zona;

                //var resultado = await _context.SaveChangesAsync();
                //return resultado > 0;
                return true;
            }
            return false;
        }

        public async Task<bool> EliminarDatosDeLinea(int id)
        {
            var datosDeLineaBD = await _context.DatosDeLinea.FirstOrDefaultAsync(d => d.Id == id);
            if (datosDeLineaBD != null)
            {
                _context.DatosDeLinea.Remove(datosDeLineaBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<DatosDeLinea> ObtenerDatosDeLineaPorId(int id)
        {
            var datosDeLineaBD = await _context.DatosDeLinea.FirstOrDefaultAsync(d => d.Id == id);
            if (datosDeLineaBD == null)
            {
                return null;
            }

            return new DatosDeLinea
            {
                Id = datosDeLineaBD.Id,
                OT = datosDeLineaBD.OT,
                Aviso = datosDeLineaBD.Aviso,
                SAP = datosDeLineaBD.SAP,
                Distancia = datosDeLineaBD.Distancia,
                Funcion = datosDeLineaBD.Funcion,
                Zona = datosDeLineaBD.Zona
            };
        }
    }
}

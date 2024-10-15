using ICE.Capa_Datos.Contexto;
using ICE.Capa_Dominio.Modelos;
using ICE.Capa_Datos.Entidades;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Acciones
{
    public class GestionarInformeDA : IGestionarInformeDA
    {
        private readonly ICE_Context _context;

        public GestionarInformeDA(ICE_Context context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarInforme(Informe informe)
        {
            var informeDA = new InformeDA
            {
                Tipo = informe.Tipo,
                SubestacionId = informe.SubestacionId,
                LineaTransmisionId = informe.LineaTransmisionId,
                DatosDeLineaId = informe.DatosDeLineaId,
                DatosGeneralesId = informe.DatosGeneralesId,
                TeleproteccionId = informe.TeleproteccionId,
                DistanciaDeFallaId = informe.DistanciaDeFallaId,
                TiemposDeDisparoId = informe.TiemposDeDisparoId,
                CorrientesDeFallaId = informe.CorrientesDeFallaId,
                Estado = informe.Estado
            };

            _context.Informes.Add(informeDA);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> ActualizarInforme(int id, Informe informe)
        {
            var informeBD = await _context.Informes.FirstOrDefaultAsync(i => i.Id == id);
            if (informeBD != null)
            {
                informeBD.Tipo = informe.Tipo;
                informeBD.SubestacionId = informe.SubestacionId;
                informeBD.LineaTransmisionId = informe.LineaTransmisionId;
                informeBD.DatosDeLineaId = informe.DatosDeLineaId;
                informeBD.DatosGeneralesId = informe.DatosGeneralesId;
                informeBD.TeleproteccionId = informe.TeleproteccionId;
                informeBD.DistanciaDeFallaId = informe.DistanciaDeFallaId;
                informeBD.TiemposDeDisparoId = informe.TiemposDeDisparoId;
                informeBD.CorrientesDeFallaId = informe.CorrientesDeFallaId;
                informeBD.Estado = informe.Estado;

                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<bool> EliminarInforme(int id)
        {
            var informeBD = await _context.Informes.FirstOrDefaultAsync(i => i.Id == id);
            if (informeBD != null)
            {
                _context.Informes.Remove(informeBD);
                var resultado = await _context.SaveChangesAsync();
                return resultado > 0;
            }
            return false;
        }

        public async Task<Informe> ObtenerInformePorId(int id)
        {
            var informeBD = await _context.Informes.FirstOrDefaultAsync(i => i.Id == id);
            if (informeBD == null)
            {
                return null;
            }

            return new Informe
            {
                Id = informeBD.Id,
                Tipo = informeBD.Tipo,
                SubestacionId = informeBD.SubestacionId,
                LineaTransmisionId = informeBD.LineaTransmisionId,
                DatosDeLineaId = informeBD.DatosDeLineaId,
                DatosGeneralesId = informeBD.DatosGeneralesId,
                TeleproteccionId = informeBD.TeleproteccionId,
                DistanciaDeFallaId = informeBD.DistanciaDeFallaId,
                TiemposDeDisparoId = informeBD.TiemposDeDisparoId,
                CorrientesDeFallaId = informeBD.CorrientesDeFallaId,
                Estado = informeBD.Estado
            };
        }
    }
}

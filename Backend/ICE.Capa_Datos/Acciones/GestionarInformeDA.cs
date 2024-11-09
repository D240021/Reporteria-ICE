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
        //Llamar a las interfaces de las instancias de Informe para actualizar
        private readonly IGestionarTeleproteccionDA _gestionarTeleproteccionDA;
        private readonly IGestionarDistanciaDeFallaDA _gestionarDistanciaDeFallaDA;
        private readonly IGestionarCorrientesDeFallaDA _gestionarCorrientesDeFallaDA;
        private readonly IGestionarTiemposDeDisparoDA _gestionarTiemposDeDisparoDA;
        private readonly IGestionarDatosDeLineaDA _gestionarDatosDeLineaDA;
        private readonly IGestionarDatosGeneralesDA _gestionarDatosGeneralesDA;

        public GestionarInformeDA(
            ICE_Context context,
            IGestionarTeleproteccionDA gestionarTeleproteccionDA,
            IGestionarDistanciaDeFallaDA gestionarDistanciaDeFallaDA,
            IGestionarCorrientesDeFallaDA gestionarCorrientesDeFallaDA,
            IGestionarTiemposDeDisparoDA gestionarTiemposDeDisparoDA,
            IGestionarDatosDeLineaDA gestionarDatosDeLineaDA,
            IGestionarDatosGeneralesDA gestionarDatosGeneralesDA)
        {
            _context = context;
            _gestionarTeleproteccionDA = gestionarTeleproteccionDA;
            _gestionarDistanciaDeFallaDA = gestionarDistanciaDeFallaDA;
            _gestionarCorrientesDeFallaDA = gestionarCorrientesDeFallaDA;
            _gestionarTiemposDeDisparoDA = gestionarTiemposDeDisparoDA;
            _gestionarDatosDeLineaDA = gestionarDatosDeLineaDA;
            _gestionarDatosGeneralesDA = gestionarDatosGeneralesDA;
        }

        public async Task<int> RegistrarInforme(Informe informe)
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
            await _context.SaveChangesAsync();
            return informeDA.Id;

        }

        public async Task<bool> ActualizarInforme(int id, Informe informe)
        {
            var existeInforme = await _context.Informes.FirstOrDefaultAsync(i => i.Id == id);
            if (existeInforme == null)
            {
                return false;
            }

            var validacionReferencia = await ValidarInformeReferencias(informe);
            if (!validacionReferencia)
            {
                return false;
            }
            //
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Cargar el informe con sus relaciones
                    var informeBD = await _context.Informes
                        .Include(i => i.DatosDeLinea)
                        .Include(i => i.DatosGenerales)
                        .Include(i => i.Teleproteccion)
                        .Include(i => i.DistanciaDeFalla)
                        .Include(i => i.TiemposDeDisparo)
                        .Include(i => i.CorrientesDeFalla)
                        .FirstOrDefaultAsync(i => i.Id == id);

                    //se actualizan los campos simples del informe
                    informeBD.Tipo = informe.Tipo;
                    informeBD.SubestacionId = informe.SubestacionId;
                    informeBD.LineaTransmisionId = informe.LineaTransmisionId;
                    informeBD.Estado = informe.Estado;

                    //se actualizan usando sus propios servicios las entidades relacionadas a informe
                    await _gestionarDistanciaDeFallaDA.ActualizarDistanciaDeFalla(informeBD.DistanciaDeFallaId, informe.DistanciaDeFalla);
                    await _gestionarTeleproteccionDA.ActualizarTeleproteccion(informeBD.TeleproteccionId, informe.Teleproteccion);
                    await _gestionarCorrientesDeFallaDA.ActualizarCorrientesDeFalla(informeBD.CorrientesDeFallaId, informe.CorrientesDeFalla);
                    await _gestionarTiemposDeDisparoDA.ActualizarTiemposDeDisparo(informeBD.TiemposDeDisparoId, informe.TiemposDeDisparo);
                    await _gestionarDatosDeLineaDA.ActualizarDatosDeLinea(informeBD.DatosDeLineaId, informe.DatosDeLinea);
                    await _gestionarDatosGeneralesDA.ActualizarDatosGenerales(informeBD.DatosGeneralesId, informe.DatosGenerales);

                    // Guardar los cambios en el contexto
                    await _context.SaveChangesAsync();

                    // Confirmar la transacción si todo sale bien
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
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


        private async Task<bool> ValidarInformeReferencias(Informe informe)
        {
            bool subestacionExiste = await _context.Subestaciones.AnyAsync(s => s.Id == informe.SubestacionId);
            bool lineaTransmisionExiste = await _context.LineasTransmision.AnyAsync(l => l.Id == informe.LineaTransmisionId);
            bool datosDeLineaExiste = await _context.DatosDeLinea.AnyAsync(d => d.Id == informe.DatosDeLineaId);
            bool datosGeneralesExiste = await _context.DatosGenerales.AnyAsync(d => d.Id == informe.DatosGeneralesId);
            bool teleproteccionExiste = await _context.Teleprotecciones.AnyAsync(t => t.Id == informe.TeleproteccionId);
            bool distanciaDeFallaExiste = await _context.DistanciasDeFalla.AnyAsync(d => d.Id == informe.DistanciaDeFallaId);
            bool tiemposDeDisparoExiste = await _context.TiemposDeDisparo.AnyAsync(t => t.Id == informe.TiemposDeDisparoId);
            bool corrientesDeFallaExiste = await _context.CorrientesDeFalla.AnyAsync(c => c.Id == informe.CorrientesDeFallaId);

            // Retornar true solo si todos los registros existen, de lo contrario false
            return subestacionExiste && lineaTransmisionExiste && datosDeLineaExiste &&
                   datosGeneralesExiste && teleproteccionExiste && distanciaDeFallaExiste &&
                   tiemposDeDisparoExiste && corrientesDeFallaExiste;
        }

        public async Task<Informe> ObtenerInformePorId(int id)
        {
            //var informeBD = await _context.Informes.FirstOrDefaultAsync(i => i.Id == id);

            //Incluir las relaciones de Informe (Corriente de Falla, Teleproteccion, etc)
            var informeBD = await _context.Informes
               .Include(i => i.DatosDeLinea)
               .Include(i => i.DatosGenerales)
               .Include(i => i.Teleproteccion)
               .Include(i => i.DistanciaDeFalla)
               .Include(i => i.TiemposDeDisparo)
               .Include(i => i.CorrientesDeFalla)
               .FirstOrDefaultAsync(i => i.Id == id);

            if (informeBD == null)
            {
                return null;
            }
            // Mapear los datos desde InformeDA a Informe
            return new Informe
            {
                Id = informeBD.Id,
                Tipo = informeBD.Tipo,
                SubestacionId = informeBD.SubestacionId,
                LineaTransmisionId = informeBD.LineaTransmisionId,

                DatosDeLineaId = informeBD.DatosDeLineaId,
                DatosDeLinea = informeBD.DatosDeLinea != null ? new DatosDeLinea
                {
                    Id = informeBD.DatosDeLinea.Id,
                    OT = informeBD.DatosDeLinea.OT,
                    Aviso = informeBD.DatosDeLinea.Aviso,
                    SAP = informeBD.DatosDeLinea.SAP,
                    Distancia = informeBD.DatosDeLinea.Distancia,
                    Funcion = informeBD.DatosDeLinea.Funcion,
                    Zona = informeBD.DatosDeLinea.Zona
                } : null,

                DatosGeneralesId = informeBD.DatosGeneralesId,
                DatosGenerales = informeBD.DatosGenerales != null ? new DatosGenerales
                {
                    Id = informeBD.DatosGenerales.Id,
                    Evento = informeBD.DatosGenerales.Evento,
                    Fecha = informeBD.DatosGenerales.Fecha,
                    Hora = informeBD.DatosGenerales.Hora,
                    Subestacion = informeBD.DatosGenerales.Subestacion,
                    LT = informeBD.DatosGenerales.LT,
                    Equipo = informeBD.DatosGenerales.Equipo
                } : null,

                TeleproteccionId = informeBD.TeleproteccionId,
                Teleproteccion = informeBD.Teleproteccion != null ? new Teleproteccion
                {
                    Id = informeBD.Teleproteccion.Id,
                    TX_TEL = informeBD.Teleproteccion.TX_TEL,
                    RX_TEL = informeBD.Teleproteccion.RX_TEL,
                    TiempoMPLS = informeBD.Teleproteccion.TiempoMPLS
                } : null,

                DistanciaDeFallaId = informeBD.DistanciaDeFallaId,
                DistanciaDeFalla = informeBD.DistanciaDeFalla != null ? new DistanciaDeFalla
                {
                    Id = informeBD.DistanciaDeFalla.Id,
                    DistanciaKM = informeBD.DistanciaDeFalla.DistanciaKM,
                    DistanciaPorcentaje = informeBD.DistanciaDeFalla.DistanciaPorcentaje,
                    DistanciaReportada = informeBD.DistanciaDeFalla.DistanciaReportada,
                    DistanciaDobleTemporal = informeBD.DistanciaDeFalla.DistanciaDobleTemporal,
                    Error = informeBD.DistanciaDeFalla.Error,
                    Error_Doble = informeBD.DistanciaDeFalla.Error_Doble
                } : null,

                TiemposDeDisparoId = informeBD.TiemposDeDisparoId,
                TiemposDeDisparo = informeBD.TiemposDeDisparo != null ? new TiemposDeDisparo
                {
                    Id = informeBD.TiemposDeDisparo.Id,
                    R = informeBD.TiemposDeDisparo.R,
                    S = informeBD.TiemposDeDisparo.S,
                    T = informeBD.TiemposDeDisparo.T,
                    Reserva = informeBD.TiemposDeDisparo.Reserva
                } : null,

                CorrientesDeFallaId = informeBD.CorrientesDeFallaId,
                CorrientesDeFalla = informeBD.CorrientesDeFalla != null ? new CorrientesDeFalla
                {
                    Id = informeBD.CorrientesDeFalla.Id,
                    RealIR = informeBD.CorrientesDeFalla.RealIR,
                    RealIS = informeBD.CorrientesDeFalla.RealIS,
                    RealIT = informeBD.CorrientesDeFalla.RealIT,
                    AcumuladaR = informeBD.CorrientesDeFalla.AcumuladaR,
                    AcumuladaS = informeBD.CorrientesDeFalla.AcumuladaS,
                    AcumuladaT = informeBD.CorrientesDeFalla.AcumuladaT
                } : null,

                Estado = informeBD.Estado
            };
        }
    }
}
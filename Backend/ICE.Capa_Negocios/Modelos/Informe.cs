using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class Informe
    {
        public int Id { get; set; }
        public int Tipo { get; set; }

        // Relación con Subestacion
        public int SubestacionId { get; set; }
        public Subestacion Subestacion { get; set; }

        // Relación con LineaTransmision
        public int LineaTransmisionId { get; set; }
        public LineaTransmision LineaTransmision { get; set; }

        // Relación con DatosDeLinea
        public int DatosDeLineaId { get; set; }
        public DatosDeLinea DatosDeLinea { get; set; }

        // Relación con DatosGenerales
        public int DatosGeneralesId { get; set; }
        public DatosGenerales DatosGenerales { get; set; }

        // Relación con Teleproteccion
        public int TeleproteccionId { get; set; }
        public Teleproteccion Teleproteccion { get; set; }

        // Relación con DistanciaDeFalla
        public int DistanciaDeFallaId { get; set; }
        public DistanciaDeFalla DistanciaDeFalla { get; set; }

        // Relación con TiemposDeDisparo
        public int TiemposDeDisparoId { get; set; }
        public TiemposDeDisparo TiemposDeDisparo { get; set; }

        // Relación con CorrientesDeFalla
        public int CorrientesDeFallaId { get; set; }
        public CorrientesDeFalla CorrientesDeFalla { get; set; }

        public int Estado { get; set; }
    }
}
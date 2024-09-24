using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("Informe")]
    public class InformeDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Tipo { get; set; }

        // Relación con Subestacion
        [ForeignKey("Subestacion")]
        public int SubestacionId { get; set; }
        public SubestacionDA Subestacion { get; set; }

        // Relación con LineaTransmision
        [ForeignKey("LineaTransmision")]
        public int LineaTransmisionId { get; set; }
        public LineaTransmisionDA LineaTransmision { get; set; }

        // Relación con DatosDeLinea
        [ForeignKey("DatosDeLinea")]
        public int DatosDeLineaId { get; set; }
        public DatosDeLineaDA DatosDeLinea { get; set; }

        // Relación con DatosGenerales
        [ForeignKey("DatosGenerales")]
        public int DatosGeneralesId { get; set; }
        public DatosGeneralesDA DatosGenerales { get; set; }

        // Relación con Teleproteccion
        [ForeignKey("Teleproteccion")]
        public int TeleproteccionId { get; set; }
        public TeleproteccionDA Teleproteccion { get; set; }

        // Relación con DistanciaDeFalla
        [ForeignKey("DistanciaDeFalla")]
        public int DistanciaDeFallaId { get; set; }
        public DistanciaDeFallaDA DistanciaDeFalla { get; set; }

        // Relación con TiemposDeDisparo
        [ForeignKey("TiemposDeDisparo")]
        public int TiemposDeDisparoId { get; set; }
        public TiemposDeDisparoDA TiemposDeDisparo { get; set; }

        // Relación con CorrientesDeFalla
        [ForeignKey("CorrientesDeFalla")]
        public int CorrientesDeFallaId { get; set; }
        public CorrientesDeFallaDA CorrientesDeFalla { get; set; }

        [Required]
        public int Estado { get; set; }
    }
}

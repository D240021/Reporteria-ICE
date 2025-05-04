using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("ReporteCausa")]
    public class ReporteCausaDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [ForeignKey("Reporte")]
        public int ReporteId { get; set; }
        public ReporteDA Reporte { get; set; }

        [ForeignKey("Causa")]
        public int CausaId { get; set; }
        public CausaDA Causa { get; set; }
    }
}
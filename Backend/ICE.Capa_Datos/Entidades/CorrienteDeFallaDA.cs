using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("CorrientesDeFalla")]
    public class CorrientesDeFallaDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string RealIR { get; set; }

        [StringLength(100)]
        public string RealIS { get; set; }

        [StringLength(100)]
        public string RealIT { get; set; }

        [StringLength(100)]
        public string AcumuladaR { get; set; }

        [StringLength(100)]
        public string AcumuladaS { get; set; }

        [StringLength(100)]
        public string AcumuladaT { get; set; }
    }
}

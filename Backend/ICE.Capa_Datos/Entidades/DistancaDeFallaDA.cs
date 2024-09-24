using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("DistanciaDeFalla")]
    public class DistanciaDeFallaDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DistanciaKM { get; set; }

        [Required]
        [StringLength(100)]
        public string DistanciaPorcentaje { get; set; }

        [Required]
        [StringLength(100)]
        public string DistanciaReportada { get; set; }

        [Required]
        [StringLength(100)]
        public string DistanciaDobleTemporal { get; set; }

        [Required]
        [StringLength(100)]
        public string Error { get; set; }

        [Required]
        [StringLength(100)]
        public string Error_Doble { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("DatosGenerales")]
    public class DatosGeneralesDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Evento { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        [StringLength(100)]
        public string Subestacion { get; set; }

        [Required]
        [StringLength(100)]
        public string LT { get; set; }

        [Required]
        [StringLength(100)]
        public string Equipo { get; set; }
    }
}
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
        
        [StringLength(100)]
        public string? Evento { get; set; }

        public DateTime? Fecha { get; set; }

        public TimeSpan? Hora { get; set; }

        [StringLength(100)]
        public string? Subestacion { get; set; }

        [StringLength(100)]
        public string? LT { get; set; }

        [StringLength(100)]
        public string? Equipo { get; set; }
    }
}
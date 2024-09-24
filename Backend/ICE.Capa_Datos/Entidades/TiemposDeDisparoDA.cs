using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("TiemposDeDisparo")]
    public class TiemposDeDisparoDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string R { get; set; }

        [Required]
        [StringLength(100)]
        public string S { get; set; }

        [Required]
        [StringLength(100)]
        public string T { get; set; }

        [Required]
        [StringLength(100)]
        public string Reserva { get; set; }
    }
}

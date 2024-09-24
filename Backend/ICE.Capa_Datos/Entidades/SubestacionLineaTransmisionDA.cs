using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("SubestacionLineaTransmision")]
    public class SubestacionLineaTransmisionDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  

        [ForeignKey("Subestacion")]
        public int SubestacionId { get; set; }
        public SubestacionDA Subestacion { get; set; }

        [ForeignKey("LineaTransmision")]
        public int LineaTransmisionId { get; set; }
        public LineaTransmisionDA LineaTransmision { get; set; }
    }
}
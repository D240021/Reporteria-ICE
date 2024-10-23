using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("Teleproteccion")]
    public class TeleproteccionDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string TX_TEL { get; set; }

        [StringLength(100)]
        public string RX_TEL { get; set; }

        [StringLength(100)]
        public string TiempoMPLS { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("DatosDeLinea")]
    public class DatosDeLineaDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string OT { get; set; }

        [Required]
        [StringLength(100)]
        public string Aviso { get; set; }

        [Required]
        [StringLength(100)]
        public string SAP { get; set; }

        [Required]
        [StringLength(100)]
        public string Distancia { get; set; }

        [Required]
        [StringLength(100)]
        public string Funcion { get; set; }

        [Required]
        [StringLength(100)]
        public string Zona { get; set; }
    }
}
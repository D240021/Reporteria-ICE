using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("Subestacion")]
    public class SubestacionDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreUbicacion { get; set; }

        [Required]
        public int Identificador { get; set; }

        // Relación con UnidadRegional
        [ForeignKey("UnidadRegional")]
        public int UnidadRegionalId { get; set; }
    }
}

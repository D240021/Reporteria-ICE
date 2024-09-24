using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("Notificacion")]
    public class NotificacionDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Destinatario { get; set; }

        [Required]
        [StringLength(500)]
        public string Cuerpo { get; set; }

        [Required]
        [StringLength(200)]
        public string Asunto { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}
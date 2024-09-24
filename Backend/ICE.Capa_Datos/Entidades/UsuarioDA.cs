using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("Usuario")]
    public class UsuarioDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasenia { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        public int Identificador { get; set; }

        // Relación con Rol
        [ForeignKey("Rol")]
        public int RollId { get; set; }
        public RolDA Rol { get; set; }

        // Relación con Subestacion
        [ForeignKey("Subestacion")]
        public int SubestacionId { get; set; }
        public SubestacionDA Subestacion { get; set; }
    }
}
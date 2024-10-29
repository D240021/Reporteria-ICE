using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Identificador { get; set; }

        [StringLength(100)]
        public string Rol { get; set; }

        // Relación opcional con Subestacion
        [ForeignKey("Subestacion")]
        public int? SubestacionId { get; set; }
        public SubestacionDA? Subestacion { get; set; }

        // Relación opcional con Unidad Regional
        [ForeignKey("UnidadRegional")]
        public int? UnidadRegionalId { get; set; }
        public UnidadRegionalDA? UnidadRegional { get; set; }
    }
}

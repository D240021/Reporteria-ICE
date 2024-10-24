using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Datos.Entidades
{
    [Table("Reporte")]
    public class ReporteDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] MapaDeDescargas { get; set; }

        [Required]
        [StringLength(500)]
        public string Observaciones { get; set; }

        // Relaciones con Informes
        [ForeignKey("InformeV1Id")]
        public int InformeV1Id { get; set; }
        [ForeignKey("InformeV2Id")]
        public int InformeV2Id { get; set; }
        [ForeignKey("InformeV3Id")]
        public int InformeV3Id { get; set; }
        [ForeignKey("InformeV4Id")]
        public int InformeV4Id { get; set; }        

        [Required]
        public int Estado { get; set; }

        // Relación con Usuario Supervisor
        [ForeignKey("UsuarioSupervisorId")]
        public int UsuarioSupervisorId { get; set; }

        // Relación con Técnico de Línea
        [ForeignKey("TecnicoLineaId")]
        public int TecnicoLineaId { get; set; }
    }
}

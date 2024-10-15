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
        public int InformeV1Id { get; set; }
        [ForeignKey("InformeV1Id")]
        public InformeDA InformeV1 { get; set; }

        public int InformeV2Id { get; set; }
        [ForeignKey("InformeV2Id")]
        public InformeDA InformeV2 { get; set; }

        public int InformeV3Id { get; set; }
        [ForeignKey("InformeV3Id")]
        public InformeDA InformeV3 { get; set; }

        public int InformeV4Id { get; set; }
        [ForeignKey("InformeV4Id")]
        public InformeDA InformeV4 { get; set; }

        [Required]
        public int Estado { get; set; }

        // Relación con Usuario Supervisor
        public int UsuarioSupervisorId { get; set; }
        [ForeignKey("UsuarioSupervisorId")]
        public UsuarioDA UsuarioSupervisor { get; set; }

        // Relación con Técnico de Línea
        public int TecnicoLineaId { get; set; }
        [ForeignKey("TecnicoLineaId")]
        public UsuarioDA TecnicoLinea { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class Reporte
    {
        public int Id { get; set; }
        public byte[] MapaDeDescargas { get; set; }
        public string Observaciones { get; set; }

        // Relaciones con Informes
        public int InformeV1Id { get; set; }
        public Informe InformeV1 { get; set; }

        public int InformeV2Id { get; set; }
        public Informe InformeV2 { get; set; }

        public int InformeV3Id { get; set; }
        public Informe InformeV3 { get; set; }

        public int InformeV4Id { get; set; }
        public Informe InformeV4 { get; set; }

        public int Estado { get; set; }

        // Relación con Usuario Supervisor
        public int UsuarioSupervisorId { get; set; }
        public Usuario UsuarioSupervisor { get; set; }

        // Relación con Técnico de Línea
        public int TecnicoLineaId { get; set; }
        public Usuario TecnicoLinea { get; set; }
    }
}


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
        //Datos que llena el supervisor
        public byte[]? MapaDeDescargas { get; set; }
        public string? Observaciones { get; set; }

        //Datos que llena el Tecnico de Linea
        public byte[]? Evidencia { get; set; }
        public string? ObservacionesTecnicoLinea { get; set; }
        //anidar las causas del frontend
        public string? Causas {get; set;}
        public DateTime? FechaHora { get; set; }
        
        // Relaciones con Informes
        public int InformeV1Id { get; set; }        

        public int InformeV2Id { get; set; }        

        public int InformeV3Id { get; set; }        

        public int InformeV4Id { get; set; }        

        public int Estado { get; set; }

        // Relación con Usuario Supervisor
        public int UsuarioSupervisorId { get; set; }        

        // Relación con Técnico de Línea
        public int TecnicoLineaId { get; set; }        
    }
}


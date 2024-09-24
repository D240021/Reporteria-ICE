using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class ReporteCausa
    {
        public int Id { get; set; }
        public int ReporteId { get; set; }
        public int CausaId { get; set; }
    }
}
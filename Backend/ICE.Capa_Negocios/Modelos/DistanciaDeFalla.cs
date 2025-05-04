using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class DistanciaDeFalla
    {
        public int Id { get; set; }
        public string? DistanciaKM { get; set; }
        public string? DistanciaPorcentaje { get; set; }
        public string? DistanciaReportada { get; set; }
        public string? DistanciaDobleTemporal { get; set; }
        public string? Error { get; set; }
        public string? Error_Doble { get; set; }
    }
}

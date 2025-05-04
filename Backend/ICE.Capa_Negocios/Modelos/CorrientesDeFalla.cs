using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class CorrientesDeFalla
    {
        public int Id { get; set; }
        public string? RealIR { get; set; }
        public string? RealIS { get; set; }
        public string? RealIT { get; set; }
        public string? AcumuladaR { get; set; }
        public string? AcumuladaS { get; set; }
        public string? AcumuladaT { get; set; }
    }
}
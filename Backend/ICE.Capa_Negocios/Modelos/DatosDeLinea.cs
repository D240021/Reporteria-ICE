using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class DatosDeLinea
    {
        public int Id { get; set; }
        public string? OT { get; set; }
        public string? Aviso { get; set; }
        public string? SAP { get; set; }
        public string? Distancia { get; set; }
        public string? Funcion { get; set; }
        public string? Zona { get; set; }
    }
}

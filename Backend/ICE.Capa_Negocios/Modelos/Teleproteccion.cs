using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class Teleproteccion
    {
        public int Id { get; set; }
        public string TX_TEL { get; set; }
        public string RX_TEL { get; set; }
        public string TiempoMPLS { get; set; }
    }
}
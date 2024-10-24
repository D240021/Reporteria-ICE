using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class DatosGenerales
    {
        public int Id { get; set; }
        public string? Evento { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public string? Subestacion { get; set; }
        public string? LT { get; set; }
        public string? Equipo { get; set; }
    }
}
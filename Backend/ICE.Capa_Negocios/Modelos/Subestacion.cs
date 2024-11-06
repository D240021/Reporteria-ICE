using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class Subestacion
    {
        public int Id { get; set; }
        public string NombreUbicacion { get; set; }
        public string Identificador { get; set; }
        public int UnidadRegionalId { get; set; }

        // Agrega esta propiedad
        public string? NombreUnidadRegional { get; set; } 
    }

}
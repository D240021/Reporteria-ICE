﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Contrasenia { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificador { get; set; }
        public string Rol { get; set; }
        public int? SubestacionId { get; set; }
        public int? UnidadRegionalId { get; set; }
        // Agrega esta propiedad
        public string? NombreUnidadRegional { get; set; } 
    }

}
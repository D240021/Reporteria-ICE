using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasSubestacion
    {
        // Validar los datos de la Subestacion
        public static (bool esValido, string mensaje) EsSubestacionValida(Subestacion subestacion)
        {
            // Validación del NombreUbicacion
            if (string.IsNullOrWhiteSpace(subestacion.NombreUbicacion))
            {
                return (false, "El nombre de la ubicación no puede estar vacío o solo contener espacios en blanco.");
            }

            if (subestacion.NombreUbicacion.Length > 100)
            {
                return (false, "El nombre de la ubicación no puede exceder los 100 caracteres.");
            }
            
            if (string.IsNullOrWhiteSpace(subestacion.Identificador))
            {
                return (false, "El identificador de la subestación no puede estar vacío o solo contener espacios en blanco.");
            }

            if (subestacion.Identificador.Length < 3 || subestacion.Identificador.Length > 20)
            {
                return (false, "El identificador de la subestación debe tener entre 3 y 20 caracteres.");
            }
            
            if (subestacion.UnidadRegionalId <= 0)
            {
                return (false, "El ID de la unidad regional debe ser mayor que cero.");
            }

            return (true, string.Empty);
        }

        // Validación específica del ID
        public static (bool esValido, string mensaje) EsIdValido(int id)
        {
            if (id <= 0)
            {
                return (false, "El ID proporcionado no es válido.");
            }

            return (true, string.Empty);
        }
    }
}

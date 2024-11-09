using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasLineaTransmision
    {
        // Validar los datos de la LineaTransmision
        public static (bool esValido, string mensaje) EsLineaTransmisionValida(LineaTransmision lineaTransmision)
        {
            // Validación del NombreUbicacion
            if (string.IsNullOrWhiteSpace(lineaTransmision.NombreUbicacion))
            {
                return (false, "El nombre de la ubicación no puede estar vacío o solo contener espacios en blanco.");
            }

            if (lineaTransmision.NombreUbicacion.Length > 100)
            {
                return (false, "El nombre de la ubicación no puede exceder los 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(lineaTransmision.Identificador))
            {
                return (false, "El identificador de la subestación no puede estar vacío o solo contener espacios en blanco.");
            }
            
            if (lineaTransmision.Identificador.Length < 3 || lineaTransmision.Identificador.Length > 20)
            {
                return (false, "El identificador de la subestación debe tener entre 3 y 20 caracteres.");
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

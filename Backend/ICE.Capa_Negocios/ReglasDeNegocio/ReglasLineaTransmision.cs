using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasLineaTransmision
    {
        // Validar los datos de la LineaTransmision
        public static (bool esValido, string mensaje) EsLineaTransmisionValida(LineaTransmision lineaTransmision)
        {
            // Validación del NombreUbicacion
            if (string.IsNullOrEmpty(lineaTransmision.NombreUbicacion))
            {
                return (false, "El nombre de la ubicación no puede estar vacío.");
            }

            if (lineaTransmision.NombreUbicacion.Length > 100)
            {
                return (false, "El nombre de la ubicación no puede exceder los 100 caracteres.");
            }

            // Validación del Identificador
            if (lineaTransmision.Identificador <= 0)
            {
                return (false, "El identificador de la línea de transmisión debe ser mayor que cero.");
            }

            return (true, string.Empty); // Retorna válido si todo es correcto
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

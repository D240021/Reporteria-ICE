using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasUnidadRegional
    {
        // Validar los datos de la UnidadRegional
        public static (bool esValido, string mensaje) EsUnidadRegionalValida(UnidadRegional unidadRegional)
        {

            // Validación del NombreUbicacion
            if (string.IsNullOrEmpty(unidadRegional.NombreUbicacion))
            {
                return (false, "El nombre de la ubicación no puede estar vacío.");
            }

            if (unidadRegional.NombreUbicacion.Length > 100)
            {
                return (false, "El nombre de la ubicación no puede exceder los 100 caracteres.");
            }

            // Validación del Identificador
            if (unidadRegional.Identificador.Length <= 0)
            {
                return (false, "El identificador de la unidad regional debe ser mayor que cero.");
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

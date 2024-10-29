using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasSubestacion
    {
        // Validar los datos de la Subestacion
        public static (bool esValido, string mensaje) EsSubestacionValida(Subestacion subestacion)
        {
            // Validación del NombreUbicacion
            if (string.IsNullOrEmpty(subestacion.NombreUbicacion))
            {
                return (false, "El nombre de la ubicación no puede estar vacío.");
            }

            if (subestacion.NombreUbicacion.Length > 100)
            {
                return (false, "El nombre de la ubicación no puede exceder los 100 caracteres.");
            }

            // Validación del Identificador
            if (subestacion.Identificador.Length <= 0)
            {
                return (false, "El identificador de la subestación debe ser mayor que cero.");
            }

            // Validación del UnidadRegionalId
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

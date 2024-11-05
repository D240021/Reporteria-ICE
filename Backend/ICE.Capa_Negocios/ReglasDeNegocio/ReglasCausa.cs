using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasCausa
    {

        public static (bool esValido, string mensaje) EsCausaValidaParaRegistro(Causa causa)
        {
            if (causa == null)
            {
                return (false, "La causa no debe ser nula.");
            }

            // Validación de la Descripción
            if (string.IsNullOrWhiteSpace(causa.Descripcion))
            {
                return (false, "La descripción de la causa no debe estar vacía.");
            }

            return (true, string.Empty);
        }


        // Método para validar que la instancia de Causa es válida
        public static (bool esValido, string mensaje) EsCausaValida(Causa causa)
        {
            if (causa == null)
            {
                return (false, "La causa no debe ser nula.");
            }

            // Validación del Id
            if (causa.Id <= 0)
            {
                return (false, "El ID de la causa debe ser mayor que cero.");
            }

            // Validación de la Descripción
            if (string.IsNullOrWhiteSpace(causa.Descripcion))
            {
                return (false, "La descripción de la causa no debe estar vacía.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        // Método adicional para verificar que el ID es válido (por separado)
        public static (bool esValido, string mensaje) EsIdValido(int id)
        {
            if (id <= 0)
            {
                return (false, "El ID debe ser mayor que cero.");
            }

            return (true, string.Empty);
        }
    }
}

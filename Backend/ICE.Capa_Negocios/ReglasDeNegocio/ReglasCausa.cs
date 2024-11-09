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

            // Validaci�n de la Descripci�n
            if (string.IsNullOrWhiteSpace(causa.Descripcion))
            {
                return (false, "La descripci�n de la causa no debe estar vac�a.");
            }

            return (true, string.Empty);
        }


        // M�todo para validar que la instancia de Causa es v�lida
        public static (bool esValido, string mensaje) EsCausaValida(Causa causa)
        {
            if (causa == null)
            {
                return (false, "La causa no debe ser nula.");
            }

            // Validaci�n del Id
            if (causa.Id <= 0)
            {
                return (false, "El ID de la causa debe ser mayor que cero.");
            }

            // Validaci�n de la Descripci�n
            if (string.IsNullOrWhiteSpace(causa.Descripcion))
            {
                return (false, "La descripci�n de la causa no debe estar vac�a.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        // M�todo adicional para verificar que el ID es v�lido (por separado)
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

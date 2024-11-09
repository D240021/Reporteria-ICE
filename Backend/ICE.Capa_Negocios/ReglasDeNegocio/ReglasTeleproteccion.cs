using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasTeleproteccion
    {
        public static (bool esValido, string mensaje) EsTeleproteccionValido(Teleproteccion teleproteccion)
        {
            if (teleproteccion == null)
            {
                return (false, "La teleprotección no debe ser nula.");
            }

            // Validación del Id
            if (teleproteccion.Id <= 0)
            {
                return (false, "El ID de teleprotección debe ser mayor que cero.");
            }
            
            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        public static (bool esValido, string mensaje) EsTeleproteccionCompleto(Teleproteccion teleproteccion)
        {
            // Validación del campo TX_TEL
            if (string.IsNullOrWhiteSpace(teleproteccion.TX_TEL))
            {
                return (false, "El campo TX_TEL no debe estar vacío.");
            }

            // Validación del campo RX_TEL
            if (string.IsNullOrWhiteSpace(teleproteccion.RX_TEL))
            {
                return (false, "El campo RX_TEL no debe estar vacío.");
            }

            // Validación del campo TiempoMPLS
            if (string.IsNullOrWhiteSpace(teleproteccion.TiempoMPLS))
            {
                return (false, "El campo TiempoMPLS no debe estar vacío.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }
    }
}

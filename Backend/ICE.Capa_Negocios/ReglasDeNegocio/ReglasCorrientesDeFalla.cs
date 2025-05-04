using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasCorrientesDeFalla
    {
        public static (bool esValido, string mensaje) EsCorrientesDeFallaValido(CorrientesDeFalla corrientesDeFalla)
        {
            if (corrientesDeFalla == null)
            {
                return (false, "Las corrientes de falla no deben ser nulas.");
            }

            // Validación del Id
            if (corrientesDeFalla.Id <= 0)
            {
                return (false, "El ID de corrientes de falla debe ser mayor que cero.");
            }
            

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }
        public static (bool esValido, string mensaje) EsCorrientesDeFallaCompleto(CorrientesDeFalla corrientesDeFalla)
        {
            // Validación de los campos RealIR, RealIS, RealIT
            if (string.IsNullOrWhiteSpace(corrientesDeFalla.RealIR))
            {
                return (false, "El valor de RealIR no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(corrientesDeFalla.RealIS))
            {
                return (false, "El valor de RealIS no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(corrientesDeFalla.RealIT))
            {
                return (false, "El valor de RealIT no debe estar vacío.");
            }

            // Validación de los campos AcumuladaR, AcumuladaS, AcumuladaT
            if (string.IsNullOrWhiteSpace(corrientesDeFalla.AcumuladaR))
            {
                return (false, "El valor de AcumuladaR no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(corrientesDeFalla.AcumuladaS))
            {
                return (false, "El valor de AcumuladaS no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(corrientesDeFalla.AcumuladaT))
            {
                return (false, "El valor de AcumuladaT no debe estar vacío.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }
    }
}

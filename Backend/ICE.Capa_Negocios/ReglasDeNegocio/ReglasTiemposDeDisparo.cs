using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasTiemposDeDisparo
    {
        public static (bool esValido, string mensaje) EsTiemposDeDisparoValido(TiemposDeDisparo tiemposDeDisparo)
        {
            if (tiemposDeDisparo == null)
            {
                return (false, "Los tiempos de disparo no deben ser nulos.");
            }

            // Validaci�n del Id
            if (tiemposDeDisparo.Id <= 0)
            {
                return (false, "El ID de tiempos de disparo debe ser mayor que cero.");
            }
            
            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        public static (bool esValido, string mensaje) EsTiemposDeDisparoCompleto(TiemposDeDisparo tiemposDeDisparo)
        {

            // Validaci�n del campo R
            if (string.IsNullOrWhiteSpace(tiemposDeDisparo.R))
            {
                return (false, "El valor de R no debe estar vac�o.");
            }

            // Validaci�n del campo S
            if (string.IsNullOrWhiteSpace(tiemposDeDisparo.S))
            {
                return (false, "El valor de S no debe estar vac�o.");
            }

            // Validaci�n del campo T
            if (string.IsNullOrWhiteSpace(tiemposDeDisparo.T))
            {
                return (false, "El valor de T no debe estar vac�o.");
            }

            // Validaci�n del campo Reserva
            if (string.IsNullOrWhiteSpace(tiemposDeDisparo.Reserva))
            {
                return (false, "El valor de Reserva no debe estar vac�o.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }
    }
}

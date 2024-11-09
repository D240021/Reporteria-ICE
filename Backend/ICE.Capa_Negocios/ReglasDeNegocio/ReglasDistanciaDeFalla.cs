using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasDistanciaDeFalla
    {
        public static (bool esValido, string mensaje) EsDistanciaDeFallaValido(DistanciaDeFalla distanciaDeFalla)
        {
            if (distanciaDeFalla == null)
            {
                return (false, "La distancia de falla no debe ser nula.");
            }

            // Validación del Id
            if (distanciaDeFalla.Id <= 0)
            {
                return (false, "El ID de distancia de falla debe ser mayor que cero.");
            }
            

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        public static (bool esValido, string mensaje) EsDistanciaDeFallaCompleto(DistanciaDeFalla distanciaDeFalla)
        {

            // Validación de los campos DistanciaKM, DistanciaPorcentaje, DistanciaReportada, DistanciaDobleTemporal, Error, y Error_Doble
            if (string.IsNullOrWhiteSpace(distanciaDeFalla.DistanciaKM))
            {
                return (false, "El campo DistanciaKM no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(distanciaDeFalla.DistanciaPorcentaje))
            {
                return (false, "El campo DistanciaPorcentaje no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(distanciaDeFalla.DistanciaReportada))
            {
                return (false, "El campo DistanciaReportada no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(distanciaDeFalla.DistanciaDobleTemporal))
            {
                return (false, "El campo DistanciaDobleTemporal no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(distanciaDeFalla.Error))
            {
                return (false, "El campo Error no debe estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(distanciaDeFalla.Error_Doble))
            {
                return (false, "El campo Error_Doble no debe estar vacío.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }
    }
}

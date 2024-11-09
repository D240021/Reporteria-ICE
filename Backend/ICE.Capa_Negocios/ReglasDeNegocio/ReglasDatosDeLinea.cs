using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasDatosDeLinea
    {
        public static (bool esValido, string mensaje) EsDatosDeLineaValido(DatosDeLinea datosDeLinea)
        {
            if (datosDeLinea == null)
            {
                return (false, "Los datos de l�nea no deben ser nulos.");
            }

            // Validaci�n del Id
            if (datosDeLinea.Id <= 0)
            {
                return (false, "El ID de datos de l�nea debe ser mayor que cero.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        public static (bool esValido, string mensaje) EsDatosDeLineaCompleto(DatosDeLinea datosDeLinea)
        {
            // Validaci�n de los campos OT, Aviso, SAP, Distancia, Funcion y Zona
            if (string.IsNullOrWhiteSpace(datosDeLinea.OT))
            {
                return (false, "El campo OT no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosDeLinea.Aviso))
            {
                return (false, "El campo Aviso no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosDeLinea.SAP))
            {
                return (false, "El campo SAP no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosDeLinea.Distancia))
            {
                return (false, "El campo Distancia no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosDeLinea.Funcion))
            {
                return (false, "El campo Funcion no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosDeLinea.Zona))
            {
                return (false, "El campo Zona no debe estar vac�o.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);

        }
    }
}

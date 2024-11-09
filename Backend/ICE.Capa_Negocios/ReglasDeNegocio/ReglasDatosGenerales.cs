using ICE.Capa_Dominio.Modelos;
using System;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasDatosGenerales
    {
        public static (bool esValido, string mensaje) EsDatosGeneralesValido(DatosGenerales datosGenerales)
        {
            if (datosGenerales == null)
            {
                return (false, "Los datos generales no deben ser nulos.");
            }

            // Validaci�n del Id
            if (datosGenerales.Id <= 0)
            {
                return (false, "El ID de datos generales debe ser mayor que cero.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);                        
        }
                
        public static (bool esValido, string mensaje) EsDatosGeneralesCompleto(DatosGenerales datosGenerales) 
        {

            // Validaci�n de campos de texto (Evento, Subestacion, LT y Equipo)
            if (string.IsNullOrWhiteSpace(datosGenerales.Evento))
            {
                return (false, "El campo Evento no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosGenerales.Subestacion))
            {
                return (false, "El campo Subestacion no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosGenerales.LT))
            {
                return (false, "El campo LT no debe estar vac�o.");
            }

            if (string.IsNullOrWhiteSpace(datosGenerales.Equipo))
            {
                return (false, "El campo Equipo no debe estar vac�o.");
            }

            // Validaci�n de Fecha y Hora
            if (!datosGenerales.Fecha.HasValue)
            {
                return (false, "La Fecha no debe ser nula.");
            }

            if (!datosGenerales.Hora.HasValue)
            {
                return (false, "La Hora no debe ser nula.");
            }

            // Si todas las validaciones pasan
            return (true, string.Empty);

        }
    }
}

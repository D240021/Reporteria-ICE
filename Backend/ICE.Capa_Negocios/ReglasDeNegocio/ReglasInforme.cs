using ICE.Capa_Dominio.Modelos;
using System.Threading.Tasks;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasInforme
    {
        // Validar los datos del Informe
        public static (bool esValido, string mensaje) EsInformeValido(Informe informe)
        {
            if (informe == null)
                throw new ArgumentNullException(nameof(informe), "El informe no puede ser nulo.");

            // Validación del Estado
            if (informe.Estado < 0 || informe.Estado > 1)
                return (false, "El estado del informe debe ser 0 o 1.");

            // Validación del Tipo
            if (informe.Tipo != 1 && informe.Tipo != 2)
                return (false, "El tipo de informe debe ser 1 o 2.");

            // Validación de las instancias de Informe utilizando las reglas específicas de cada instancia

            var validacionDatosDeLinea = ReglasDatosDeLinea.EsDatosDeLineaValido(informe.DatosDeLinea);
            if (!validacionDatosDeLinea.esValido)
                return validacionDatosDeLinea;

            var validacionDatosGenerales = ReglasDatosGenerales.EsDatosGeneralesValido(informe.DatosGenerales);
            if (!validacionDatosGenerales.esValido)
                return validacionDatosGenerales;

            var validacionTeleproteccion = ReglasTeleproteccion.EsTeleproteccionValido(informe.Teleproteccion);
            if (!validacionTeleproteccion.esValido)
                return validacionTeleproteccion;

            var validacionDistanciaDeFalla = ReglasDistanciaDeFalla.EsDistanciaDeFallaValido(informe.DistanciaDeFalla);
            if (!validacionDistanciaDeFalla.esValido)
                return validacionDistanciaDeFalla;

            var validacionTiemposDeDisparo = ReglasTiemposDeDisparo.EsTiemposDeDisparoValido(informe.TiemposDeDisparo);
            if (!validacionTiemposDeDisparo.esValido)
                return validacionTiemposDeDisparo;

            var validacionCorrientesDeFalla = ReglasCorrientesDeFalla.EsCorrientesDeFallaValido(informe.CorrientesDeFalla);
            if (!validacionCorrientesDeFalla.esValido)
                return validacionCorrientesDeFalla;

            // Si todas las validaciones pasan
            return (true, string.Empty);
        }

        //Si todos los atributos, incluso las instancias de Informe tienen todos sus atributos no nulos ni vacios
        public static (bool esValido, string mensaje) EsInformeCompleto(Informe informe)
        {

            // Validación de las instancias de Informe utilizando las reglas específicas de cada entidad

            var validacionDatosDeLinea = ReglasDatosDeLinea.EsDatosDeLineaCompleto(informe.DatosDeLinea);
            if (!validacionDatosDeLinea.esValido)
                return validacionDatosDeLinea;

            var validacionDatosGenerales = ReglasDatosGenerales.EsDatosGeneralesCompleto(informe.DatosGenerales);
            if (!validacionDatosGenerales.esValido)
                return validacionDatosGenerales;

            var validacionTeleproteccion = ReglasTeleproteccion.EsTeleproteccionCompleto(informe.Teleproteccion);
            if (!validacionTeleproteccion.esValido)
                return validacionTeleproteccion;

            var validacionDistanciaDeFalla = ReglasDistanciaDeFalla.EsDistanciaDeFallaCompleto(informe.DistanciaDeFalla);
            if (!validacionDistanciaDeFalla.esValido)
                return validacionDistanciaDeFalla;

            var validacionTiemposDeDisparo = ReglasTiemposDeDisparo.EsTiemposDeDisparoCompleto(informe.TiemposDeDisparo);
            if (!validacionTiemposDeDisparo.esValido)
                return validacionTiemposDeDisparo;

            var validacionCorrientesDeFalla = ReglasCorrientesDeFalla.EsCorrientesDeFallaCompleto(informe.CorrientesDeFalla);
            if (!validacionCorrientesDeFalla.esValido)
                return validacionCorrientesDeFalla;

            // Si todas las validaciones pasan
            return (true, string.Empty);

        }

        // Método para cambiar el estado del informe a "actualizado"
        public static void CambiarEstadoAConfirmado(Informe informe)
        {        
            if (informe.Estado == 0) informe.Estado = 1;            
        }

        public static void CambiarTodosLosInformesAPendientes(IEnumerable<Informe> informes)
        {
            foreach (var informe in informes)
            {
                informe.Estado = 0;
            }
        }

    }
}

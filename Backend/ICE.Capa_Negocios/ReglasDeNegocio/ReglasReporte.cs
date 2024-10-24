using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasReporte
    {

        // Validar los datos del Reporte
        public static (bool esValido, string mensaje) EsReporteValido(Reporte reporte)
        {

            // Validación del Estado
            if (reporte.Estado < 0)
            {
                return (false, "El estado del reporte debe ser mayor o igual que cero.");
            }

            // Validación del Usuario Supervisor
            if (reporte.UsuarioSupervisorId <= 0)
            {
                return (false, "El ID del supervisor del reporte no es válido.");
            }

            // Validación del Técnico de Línea
            if (reporte.TecnicoLineaId <= 0)
            {
                return (false, "El ID del técnico de línea no es válido.");
            }

            // Validación de los Informes relacionados
            if (!EsIdValido(reporte.InformeV1Id).esValido)
            {
                return (false, "El ID del Informe V1 no es válido.");
            }

            if (!EsIdValido(reporte.InformeV2Id).esValido)
            {
                return (false, "El ID del Informe V2 no es válido.");
            }

            if (!EsIdValido(reporte.InformeV3Id).esValido)
            {
                return (false, "El ID del Informe V3 no es válido.");
            }

            if (!EsIdValido(reporte.InformeV4Id).esValido)
            {
                return (false, "El ID del Informe V4 no es válido.");
            }

            // Si todas las validaciones pasan
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
using ICE.Capa_Dominio.Modelos;

namespace ICE.Capa_Dominio.ReglasDeNegocio
{
    public static class ReglasReporte
    {

        // Validar los datos del Reporte
        public static (bool esValido, string mensaje) EsReporteValido(Reporte reporte)
        {

            // Validación del Estado
            if (reporte.Estado <= 0 || reporte.Estado > 4)
            {
                return (false, "El estado del reporte debe estar entre 1 y 4");
                //El cero es cuando se crea el reporte nada mas y el backend lo cambia a 1 cuando se registra
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


        //El supervisor desea actualizar el reporte, debe revisarse que su estado sea 2 al querer actualizar, de ser asi, pasa a ser 3 (empieza el de campo a editar)
        public static (bool esValido, string mensaje) EsReporteSupervisorCompleto(Reporte reporte)
        {

            var validacionReporte = EsReporteValido(reporte);
            if (!validacionReporte.esValido)
            {
                return validacionReporte;
            }



            //Si es diferente de 2, es porque el supervisor no tiene permiso de actualizar
            if (reporte.Estado != 2)
            {
                return (false, "El reporte no está en el estado correcto para ser actualizado por el supervisor.");
            }

            // Validar que MapaDeDescargas no sea nulo o vacío
            //if (reporte.MapaDeDescargas == null || reporte.MapaDeDescargas.Length == 0)
            //{
            //return (false, "El Mapa de Descargas debe estar definido para continuar.");
            //}

            // Validar que Observaciones no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(reporte.Observaciones))
            {
            return (false, "Las Observaciones deben estar definidas para continuar.");
            }

            return (true, string.Empty);

        }

        //El supervisor desea actualizar el reporte, debe revisarse que su estado sea 3 al querer actualizar, de ser asi, pasa a ser 3 (empieza el de campo a editar)
        public static (bool esValido, string mensaje) EsReporteTecnicoLineaCompleto(Reporte reporte)
        {

            var validacionReporte = EsReporteValido(reporte);
            if (!validacionReporte.esValido)
            {
                return validacionReporte;

            }

            //Si es diferente de 3, es porque el tecnico de linea no tiene permiso de actualizar
            if (reporte.Estado != 3)
            {
                return (false, "El reporte no está en el estado correcto para ser actualizado por el técnico de linea.");
            }

            // Validar que Causas no sea nulo ni vacío
            if (string.IsNullOrWhiteSpace(reporte.Causas))
            {
                return (false, "El campo 'Causas' no puede estar vacío o nulo.");
            }

            // Validar que FechaHora tenga un valor asignado
            if (reporte.FechaHora == null)
            {
                return (false, "El campo 'FechaHora' debe tener una fecha y hora asignada.");
            }

            return (true, string.Empty);

        }

        public static (bool esValido, string mensaje) ActualizarEstadoReporte(Reporte reporte)
        {
            Console.WriteLine("Estamos en ActualizarEstadoReporte: " + reporte.Estado);
            if (reporte.Estado == 0)
            {
                // Pasar a estado de edicion de sus informes
                reporte.Estado = 1;
                return (true, "El estado del reporte ha sido actualizado a 'Técnicos de Protección editando'.");
            }

            if (reporte.Estado == 1)
            {
                // Pasar a estado de edición por supervisor
                reporte.Estado = 2;
                return (true, "El estado del reporte ha sido actualizado a 'Supervisor editando'.");
            }

            if (reporte.Estado == 2 && EsReporteSupervisorCompleto(reporte).esValido)
            {
                // Pasar a estado de edición por técnico de línea
                reporte.Estado = 3; 
                return (true, "El estado del reporte ha sido actualizado a 'Técnico de línea editando'.");
            }

            if (reporte.Estado == 3 && EsReporteTecnicoLineaCompleto(reporte).esValido)
            {
                // Reporte finalizado
                reporte.Estado = 4; 
                return (true, "El estado del reporte ha sido actualizado a 'Finalizado'.");
            }

            return (false, "No se cumplen las condiciones para actualizar el estado del reporte.");
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
using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class ReporteDTOMapper

    
    {

        public static Reporte ConvertirDTOAReporte(ReporteDTO reporteDTO)
        {
            return new Reporte
            {
                Id = reporteDTO.Id ?? 0,
                MapaDeDescargas = reporteDTO.MapaDeDescargas,
                Observaciones = reporteDTO.Observaciones,
                Evidencia = reporteDTO.Evidencia,
                ObservacionesTecnicoLinea = reporteDTO.ObservacionesTecnicoLinea,
                Causas = reporteDTO.Causas,
                FechaHora = reporteDTO.FechaHora,
                InformeV1Id = reporteDTO.InformeV1Id,
                InformeV2Id = reporteDTO.InformeV2Id,
                InformeV3Id = reporteDTO.InformeV3Id,
                InformeV4Id = reporteDTO.InformeV4Id,
                UsuarioSupervisorId = reporteDTO.UsuarioSupervisorId,
                TecnicoLineaId = reporteDTO.TecnicoLineaId,
                Estado = reporteDTO.Estado
            };
        }

        public static ReporteDTO ConvertirReporteADTO(Reporte reporte)
        {
            return new ReporteDTO
            {
                Id = reporte.Id,
                MapaDeDescargas = reporte.MapaDeDescargas,
                Observaciones = reporte.Observaciones,
                Evidencia = reporte.Evidencia,
                ObservacionesTecnicoLinea = reporte.ObservacionesTecnicoLinea,
                Causas = reporte.Causas,
                FechaHora = reporte.FechaHora,
                InformeV1Id = reporte.InformeV1Id,
                InformeV2Id = reporte.InformeV2Id,
                InformeV3Id = reporte.InformeV3Id,
                InformeV4Id = reporte.InformeV4Id,
                UsuarioSupervisorId = reporte.UsuarioSupervisorId,
                TecnicoLineaId = reporte.TecnicoLineaId,
                Estado = reporte.Estado
            };
        }

        public static IEnumerable<ReporteDTO> ConvertirListaDeReportesADTO(IEnumerable<Reporte> reportes)
        {
            return reportes.Select(reporte => ConvertirReporteADTO(reporte)).ToList();
        }
    }


}
namespace reporteria_ice_api.DTOs
{
    public class ReporteDTO
    {
        public int? Id { get; set; }
        public byte[]? MapaDeDescargas { get; set; }
        public string? Observaciones { get; set; }

        // Datos del Técnico de Línea
        public byte[]? Evidencia { get; set; }
        public string? ObservacionesTecnicoLinea { get; set; }
        public string? Causas { get; set; }
        public DateTime? FechaHora { get; set; }



        public int InformeV1Id { get; set; }
        public int InformeV2Id { get; set; }
        public int InformeV3Id { get; set; }
        public int InformeV4Id { get; set; }

        public int UsuarioSupervisorId { get; set; }
        public int TecnicoLineaId { get; set; }

        public int Estado { get; set; }
    }
}
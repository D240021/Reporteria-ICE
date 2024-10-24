namespace reporteria_ice_api.DTOs
{
    public class ReporteDTO
    {
        public int? Id { get; set; }
        public byte[]? MapaDeDescargas { get; set; }
        public string? Observaciones { get; set; }

        public int InformeV1Id { get; set; }
        public int InformeV2Id { get; set; }
        public int InformeV3Id { get; set; }
        public int InformeV4Id { get; set; }

        public int UsuarioSupervisorId { get; set; }
        public int TecnicoLineaId { get; set; }

        public int Estado { get; set; }
    }
}
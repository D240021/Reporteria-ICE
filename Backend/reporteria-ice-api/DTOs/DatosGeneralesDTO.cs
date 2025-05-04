namespace reporteria_ice_api.DTOs
{
    public class DatosGeneralesDTO
    {
        public int Id { get; set; }
        public string? Evento { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public string? Subestacion { get; set; }
        public string? LT { get; set; }
        public string? Equipo { get; set; }
    }
}

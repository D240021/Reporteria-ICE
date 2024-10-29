namespace reporteria_ice_api.DTOs
{
    public class SubestacionDTO
    {
        public int? Id { get; set; } 
        public string NombreUbicacion { get; set; }
        public string Identificador { get; set; }

        // Relación con UnidadRegional
        public int UnidadRegionalId { get; set; }
    }
}
namespace reporteria_ice_api.DTOs
{
    public class SubestacionDTO
    {
        public int? Id { get; set; }
        public string NombreUbicacion { get; set; }
        public string Identificador { get; set; }

        public int UnidadRegionalId { get; set; }
        public string? NombreUnidadRegional { get; set; } 
    }
}

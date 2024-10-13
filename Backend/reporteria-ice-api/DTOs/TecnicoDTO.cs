namespace reporteria_ice_api.DTOs
{
    public class TecnicoDTO
    {
        public int? Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int RolId { get; set; }
        public int SubestacionId { get; set; }
    }
}

namespace reporteria_ice_api.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Contrasenia { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificador { get; set; }
        public string Rol { get; set; }
        public int? SubestacionId { get; set; }
        public int? UnidadRegionalId { get; set; }
        public string? NombreUnidadRegional { get; set; }
    }
}

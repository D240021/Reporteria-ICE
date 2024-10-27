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
        public int Identificador { get; set; }
        public int RollId { get; set; }
        public int? SubestacionId { get; set; }
        public int? UnidadRegionalId { get; set; }
    }
}

using ICE.Capa_Datos.Entidades;
using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class UsuarioDTOMapper
    {
        public static Usuario ConvertirDTOAUsuario(UsuarioDTO usuarioDTO)
        {
            return new Usuario
            {
                Id = usuarioDTO.Id,
                Contrasenia = usuarioDTO.Contrasenia,
                NombreUsuario = usuarioDTO.NombreUsuario,
                Correo = usuarioDTO.Correo,
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Identificador = usuarioDTO.Identificador,
                RollId = usuarioDTO.RollId,
                SubestacionId = usuarioDTO.SubestacionId ?? default,
                UnidadRegionalId = usuarioDTO.UnidadRegionalId ?? default
            };
        }

        public static UsuarioDTO ConvertirUsuarioADTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Contrasenia = usuario.Contrasenia,
                NombreUsuario = usuario.NombreUsuario,
                Correo = usuario.Correo,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Identificador = usuario.Identificador,
                RollId = usuario.RollId,
                SubestacionId = usuario.SubestacionId,
                UnidadRegionalId = usuario.UnidadRegionalId
            };
        }

        public static IEnumerable<UsuarioDTO> ConvertirListaDeUsuariosADTO(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(usuario => ConvertirUsuarioADTO(usuario)).ToList();
        }
    }
}

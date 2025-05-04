using ICE.Capa_Datos.Entidades;
using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace reporteria_ice_api.Utilitarios
{
    public static class UsuarioDTOMapper
    {
        // Conversión de UsuarioDTO a Usuario (Creación)
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
                Rol = usuarioDTO.Rol,
                SubestacionId = usuarioDTO.SubestacionId ?? default,
                UnidadRegionalId = usuarioDTO.UnidadRegionalId ?? default
                // No incluimos NombreUnidadRegional para creación
            };
        }

        // Conversión de Usuario a UsuarioViewDTO (Visualización)
        public static UsuarioViewDTO ConvertirUsuarioAViewDTO(Usuario usuario)
        {
            return new UsuarioViewDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Correo = usuario.Correo,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Identificador = usuario.Identificador,
                Rol = usuario.Rol,
                SubestacionId = usuario.SubestacionId,
                UnidadRegionalId = usuario.UnidadRegionalId,
                NombreUnidadRegional = usuario.NombreUnidadRegional // Incluido solo para visualización
            };
        }

        // Conversión de Usuario a UsuarioDTO (Creación)
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
                Rol = usuario.Rol,
                SubestacionId = usuario.SubestacionId,
                UnidadRegionalId = usuario.UnidadRegionalId
                // No incluimos NombreUnidadRegional para creación

            };
        }

        // Conversión de lista de Usuario a UsuarioViewDTO
        public static IEnumerable<UsuarioViewDTO> ConvertirListaDeUsuariosAViewDTO(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(usuario => ConvertirUsuarioAViewDTO(usuario)).ToList();
        }

        // Conversión de lista de Usuario a UsuarioDTO
        public static IEnumerable<UsuarioDTO> ConvertirListaDeUsuariosADTO(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(usuario => ConvertirUsuarioADTO(usuario)).ToList();
        }
    }
}

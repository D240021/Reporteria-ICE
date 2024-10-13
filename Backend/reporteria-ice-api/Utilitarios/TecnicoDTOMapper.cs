using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class TecnicoDTOMapper
    {
        public static Usuario ConvertirDTOATecnico(TecnicoDTO tecnicoDTO)
        {
            return new Usuario
            {
                Id = tecnicoDTO.Id ?? 0,
                NombreUsuario = tecnicoDTO.NombreUsuario,
                Contrasenia = tecnicoDTO.Contrasenia,
                Correo = tecnicoDTO.Correo,
                Identificador = tecnicoDTO.Identificador,  
                RollId = tecnicoDTO.RolId,
                SubestacionId = tecnicoDTO.SubestacionId,
            };
        }

        public static TecnicoDTO ConvertirTecnicoADTO(Usuario usuario)
        {
            return new TecnicoDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Contrasenia = usuario.Contrasenia,
                Correo = usuario.Correo,
                Identificador = usuario.Identificador,  
                RolId = usuario.RollId,
                SubestacionId = usuario.SubestacionId,
            };
        }

        public static IEnumerable<TecnicoDTO> ConvertirListaDeTecnicosADTO(IEnumerable<Usuario> tecnicos)
        {
            return tecnicos.Select(tecnico => ConvertirTecnicoADTO(tecnico)).ToList();
        }
    }
}

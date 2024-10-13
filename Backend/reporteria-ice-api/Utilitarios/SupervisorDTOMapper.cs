using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class SupervisorDTOMapper
    {
        public static Usuario ConvertirDTOASupervisor(SupervisorDTO supervisorDTO)
        {
            return new Usuario
            {
                Id = supervisorDTO.Id ?? 0,
                NombreUsuario = supervisorDTO.NombreUsuario,
                Contrasenia = supervisorDTO.Contrasenia,
                Nombre = supervisorDTO.Nombre,
                Apellido = supervisorDTO.Apellido,
                Identificador = supervisorDTO.Identificador,
                RollId = supervisorDTO.RolId,
                SubestacionId = supervisorDTO.SubestacionId,
            };
        }

        public static SupervisorDTO ConvertirSupervisorADTO(Usuario usuario)
        {
            return new SupervisorDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Contrasenia = usuario.Contrasenia,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Identificador = usuario.Identificador,
                RolId = usuario.RollId,
                SubestacionId = usuario.SubestacionId,
            };
        }

        public static IEnumerable<SupervisorDTO> ConvertirListaDeSupervisoresADTO(IEnumerable<Usuario> supervisores)
        {
            return supervisores.Select(supervisor => ConvertirSupervisorADTO(supervisor)).ToList();
        }
    }
}

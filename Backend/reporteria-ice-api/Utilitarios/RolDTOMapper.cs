using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class RolDTOMapper
    {

        public static RolDTO ConvertirRolADTO(Rol rol)
        {
            return new RolDTO
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }


        public static Rol ConvertirDTOARol(RolDTO rolDTO)
        {
            return new Rol
            {
                Id = rolDTO.Id,
                Nombre = rolDTO.Nombre
            };
        }

        public static IEnumerable<RolDTO> ConvertirListaDeRolesADTO(IEnumerable<Rol> roles)
        {
            return roles.Select(rol => ConvertirRolADTO(rol)).ToList();
        }
    }
}

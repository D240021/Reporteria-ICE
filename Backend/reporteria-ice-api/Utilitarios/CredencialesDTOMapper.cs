using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class CredencialesDTOMapper
    {
        public static Credenciales ConvertirDTOACredenciales(CredencialesDTO credencialesDTO)
        {
            return new Credenciales
            {
                NombreUsuario = credencialesDTO.NombreUsuario,
                Contrasenia = credencialesDTO.Contrasenia
            };
        }

        public static CredencialesDTO ConvertirCredencialesADTO(Credenciales credenciales)
        {
            return new CredencialesDTO
            {
                NombreUsuario = credenciales.NombreUsuario,
                Contrasenia = credenciales.Contrasenia
            };
        }
    }
}

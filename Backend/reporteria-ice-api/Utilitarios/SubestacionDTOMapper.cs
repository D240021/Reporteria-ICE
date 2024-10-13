using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class SubestacionDTOMapper
    {
        public static SubestacionDTO ConvertirSubestacionADTO(Subestacion subestacion)
        {
            return new SubestacionDTO
            {
                Id = subestacion.Id,
                NombreUbicacion = subestacion.NombreUbicacion,
                Identificador = subestacion.Identificador,
                UnidadRegionalId = subestacion.UnidadRegionalId
            };
        }

        public static Subestacion ConvertirDTOASubestacion(SubestacionDTO subestacionDTO)
        {
            return new Subestacion
            {
                Id = subestacionDTO.Id ?? 0,
                NombreUbicacion = subestacionDTO.NombreUbicacion,
                Identificador = subestacionDTO.Identificador,
                UnidadRegionalId = subestacionDTO.UnidadRegionalId
            };
        }

        public static IEnumerable<SubestacionDTO> ConvertirListaDeSubestacionesADTO(IEnumerable<Subestacion> subestaciones)
        {
            return subestaciones.Select(subestacion => ConvertirSubestacionADTO(subestacion)).ToList();
        }
    }
}
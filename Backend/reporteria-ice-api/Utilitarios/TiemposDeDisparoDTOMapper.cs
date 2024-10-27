using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class TiemposDeDisparoDTOMapper
    {
        public static TiemposDeDisparo ConvertirDTOATiemposDeDisparo(TiemposDeDisparoDTO tiemposDeDisparoDTO)
        {
            return new TiemposDeDisparo
            {
                Id = tiemposDeDisparoDTO.Id,
                R = tiemposDeDisparoDTO.R,
                S = tiemposDeDisparoDTO.S,
                T = tiemposDeDisparoDTO.T,
                Reserva = tiemposDeDisparoDTO.Reserva
            };
        }

        public static TiemposDeDisparoDTO ConvertirTiemposDeDisparoADTO(TiemposDeDisparo tiemposDeDisparo)
        {
            return new TiemposDeDisparoDTO
            {
                Id = tiemposDeDisparo.Id,
                R = tiemposDeDisparo.R,
                S = tiemposDeDisparo.S,
                T = tiemposDeDisparo.T,
                Reserva = tiemposDeDisparo.Reserva
            };
        }

        public static IEnumerable<TiemposDeDisparoDTO> ConvertirListaDeTiemposDeDisparoADTO(IEnumerable<TiemposDeDisparo> tiemposDeDisparo)
        {
            return tiemposDeDisparo.Select(tiempos => ConvertirTiemposDeDisparoADTO(tiempos)).ToList();
        }
    }
}

using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class TeleproteccionDTOMapper
    {
        public static Teleproteccion ConvertirDTOATeleproteccion(TeleproteccionDTO teleproteccionDTO)
        {
            return new Teleproteccion
            {
                Id = teleproteccionDTO.Id,
                TX_TEL = teleproteccionDTO.TX_TEL,
                RX_TEL = teleproteccionDTO.RX_TEL,
                TiempoMPLS = teleproteccionDTO.TiempoMPLS
            };
        }

        public static TeleproteccionDTO ConvertirTeleproteccionADTO(Teleproteccion teleproteccion)
        {
            return new TeleproteccionDTO
            {
                Id = teleproteccion.Id,
                TX_TEL = teleproteccion.TX_TEL,
                RX_TEL = teleproteccion.RX_TEL,
                TiempoMPLS = teleproteccion.TiempoMPLS
            };
        }

        public static IEnumerable<TeleproteccionDTO> ConvertirListaDeTeleproteccionesADTO(IEnumerable<Teleproteccion> teleprotecciones)
        {
            return teleprotecciones.Select(teleproteccion => ConvertirTeleproteccionADTO(teleproteccion)).ToList();
        }
    }
}
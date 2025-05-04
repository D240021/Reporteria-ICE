using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class DistanciaDeFallaDTOMapper
    {
        public static DistanciaDeFalla ConvertirDTOADistanciaDeFalla(DistanciaDeFallaDTO distanciaDeFallaDTO)
        {
            return new DistanciaDeFalla
            {
                Id = distanciaDeFallaDTO.Id,
                DistanciaKM = distanciaDeFallaDTO.DistanciaKM,
                DistanciaPorcentaje = distanciaDeFallaDTO.DistanciaPorcentaje,
                DistanciaReportada = distanciaDeFallaDTO.DistanciaReportada,
                DistanciaDobleTemporal = distanciaDeFallaDTO.DistanciaDobleTemporal,
                Error = distanciaDeFallaDTO.Error,
                Error_Doble = distanciaDeFallaDTO.Error_Doble
            };
        }

        public static DistanciaDeFallaDTO ConvertirDistanciaDeFallaADTO(DistanciaDeFalla distanciaDeFalla)
        {
            return new DistanciaDeFallaDTO
            {
                Id = distanciaDeFalla.Id,
                DistanciaKM = distanciaDeFalla.DistanciaKM,
                DistanciaPorcentaje = distanciaDeFalla.DistanciaPorcentaje,
                DistanciaReportada = distanciaDeFalla.DistanciaReportada,
                DistanciaDobleTemporal = distanciaDeFalla.DistanciaDobleTemporal,
                Error = distanciaDeFalla.Error,
                Error_Doble = distanciaDeFalla.Error_Doble
            };
        }

        public static IEnumerable<DistanciaDeFallaDTO> ConvertirListaDeDistanciasDeFallaADTO(IEnumerable<DistanciaDeFalla> distanciasDeFalla)
        {
            return distanciasDeFalla.Select(distanciaDeFalla => ConvertirDistanciaDeFallaADTO(distanciaDeFalla)).ToList();
        }
    }
}

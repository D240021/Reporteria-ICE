using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class CorrientesDeFallaDTOMapper
    {
        public static CorrientesDeFalla ConvertirDTOACorrientesDeFalla(CorrientesDeFallaDTO corrientesDeFallaDTO)
        {
            return new CorrientesDeFalla
            {
                Id = corrientesDeFallaDTO.Id,
                RealIR = corrientesDeFallaDTO.RealIR,
                RealIS = corrientesDeFallaDTO.RealIS,
                RealIT = corrientesDeFallaDTO.RealIT,
                AcumuladaR = corrientesDeFallaDTO.AcumuladaR,
                AcumuladaS = corrientesDeFallaDTO.AcumuladaS,
                AcumuladaT = corrientesDeFallaDTO.AcumuladaT
            };
        }

        public static CorrientesDeFallaDTO ConvertirCorrientesDeFallaADTO(CorrientesDeFalla corrientesDeFalla)
        {
            return new CorrientesDeFallaDTO
            {
                Id = corrientesDeFalla.Id,
                RealIR = corrientesDeFalla.RealIR,
                RealIS = corrientesDeFalla.RealIS,
                RealIT = corrientesDeFalla.RealIT,
                AcumuladaR = corrientesDeFalla.AcumuladaR,
                AcumuladaS = corrientesDeFalla.AcumuladaS,
                AcumuladaT = corrientesDeFalla.AcumuladaT
            };
        }

        public static IEnumerable<CorrientesDeFallaDTO> ConvertirListaDeCorrientesDeFallaADTO(IEnumerable<CorrientesDeFalla> corrientesDeFalla)
        {
            return corrientesDeFalla.Select(corrientes => ConvertirCorrientesDeFallaADTO(corrientes)).ToList();
        }
    }
}
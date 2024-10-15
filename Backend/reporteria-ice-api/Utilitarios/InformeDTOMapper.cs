using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class InformeDTOMapper
    {
        public static Informe ConvertirDTOAInforme(InformeDTO informeDTO)
        {
            return new Informe
            {
                Id = informeDTO.Id,
                Tipo = informeDTO.Tipo,
                SubestacionId = informeDTO.SubestacionId,
                LineaTransmisionId = informeDTO.LineaTransmisionId,
                DatosDeLineaId = informeDTO.DatosDeLineaId,
                DatosGeneralesId = informeDTO.DatosGeneralesId,
                TeleproteccionId = informeDTO.TeleproteccionId,
                DistanciaDeFallaId = informeDTO.DistanciaDeFallaId,
                TiemposDeDisparoId = informeDTO.TiemposDeDisparoId,
                CorrientesDeFallaId = informeDTO.CorrientesDeFallaId,
                Estado = informeDTO.Estado
            };
        }

        public static InformeDTO ConvertirInformeADTO(Informe informe)
        {
            return new InformeDTO
            {
                Id = informe.Id,
                Tipo = informe.Tipo,
                SubestacionId = informe.SubestacionId,
                LineaTransmisionId = informe.LineaTransmisionId,
                DatosDeLineaId = informe.DatosDeLineaId,
                DatosGeneralesId = informe.DatosGeneralesId,
                TeleproteccionId = informe.TeleproteccionId,
                DistanciaDeFallaId = informe.DistanciaDeFallaId,
                TiemposDeDisparoId = informe.TiemposDeDisparoId,
                CorrientesDeFallaId = informe.CorrientesDeFallaId,
                Estado = informe.Estado
            };
        }

        public static IEnumerable<InformeDTO> ConvertirListaDeInformesADTO(IEnumerable<Informe> informes)
        {
            return informes.Select(informe => ConvertirInformeADTO(informe)).ToList();
        }
    }
}

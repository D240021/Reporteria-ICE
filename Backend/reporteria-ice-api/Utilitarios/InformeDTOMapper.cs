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
                DatosDeLinea = DatosDeLineaDTOMapper.ConvertirDTOADatosDeLinea(informeDTO.DatosDeLinea),
                DatosGeneralesId = informeDTO.DatosGeneralesId,
                DatosGenerales = DatosGeneralesDTOMapper.ConvertirDTOADatosGenerales(informeDTO.DatosGenerales),
                TeleproteccionId = informeDTO.TeleproteccionId,
                Teleproteccion = TeleproteccionDTOMapper.ConvertirDTOATeleproteccion(informeDTO.Teleproteccion),
                DistanciaDeFallaId = informeDTO.DistanciaDeFallaId,
                DistanciaDeFalla = DistanciaDeFallaDTOMapper.ConvertirDTOADistanciaDeFalla(informeDTO.DistanciaDeFalla),
                TiemposDeDisparoId = informeDTO.TiemposDeDisparoId,
                TiemposDeDisparo = TiemposDeDisparoDTOMapper.ConvertirDTOATiemposDeDisparo(informeDTO.TiemposDeDisparo),
                CorrientesDeFallaId = informeDTO.CorrientesDeFallaId,
                CorrientesDeFalla = CorrientesDeFallaDTOMapper.ConvertirDTOACorrientesDeFalla(informeDTO.CorrientesDeFalla),
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
                DatosDeLinea = DatosDeLineaDTOMapper.ConvertirDatosDeLineaADTO(informe.DatosDeLinea),
                DatosGeneralesId = informe.DatosGeneralesId,
                DatosGenerales = DatosGeneralesDTOMapper.ConvertirDatosGeneralesADTO(informe.DatosGenerales),
                TeleproteccionId = informe.TeleproteccionId,
                Teleproteccion = TeleproteccionDTOMapper.ConvertirTeleproteccionADTO(informe.Teleproteccion),
                DistanciaDeFallaId = informe.DistanciaDeFallaId,
                DistanciaDeFalla = DistanciaDeFallaDTOMapper.ConvertirDistanciaDeFallaADTO(informe.DistanciaDeFalla),
                TiemposDeDisparoId = informe.TiemposDeDisparoId,
                TiemposDeDisparo = TiemposDeDisparoDTOMapper.ConvertirTiemposDeDisparoADTO(informe.TiemposDeDisparo),
                CorrientesDeFallaId = informe.CorrientesDeFallaId,
                CorrientesDeFalla = CorrientesDeFallaDTOMapper.ConvertirCorrientesDeFallaADTO(informe.CorrientesDeFalla),
                Estado = informe.Estado
            };
        }

        public static IEnumerable<InformeDTO> ConvertirListaDeInformesADTO(IEnumerable<Informe> informes)
        {
            return informes.Select(informe => ConvertirInformeADTO(informe)).ToList();
        }
    }
}

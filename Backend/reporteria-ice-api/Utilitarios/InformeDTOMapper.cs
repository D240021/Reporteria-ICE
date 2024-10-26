using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class InformeDTOMapper
    {
        //lo que viene desde el cliente GUI
        //no pueden venir nulos, se mantiene asi
        public static Informe ConvertirDTOAInforme(InformeDTO informeDTO)
        {
            return new Informe
            {                
                Id = informeDTO.Id,
                Tipo = informeDTO.Tipo,
                SubestacionId = informeDTO.SubestacionId,
                LineaTransmisionId = informeDTO.LineaTransmisionId,
                DatosDeLineaId = informeDTO.DatosDeLineaId,
                DatosDeLinea = informeDTO.DatosDeLinea != null ? DatosDeLineaDTOMapper.ConvertirDTOADatosDeLinea(informeDTO.DatosDeLinea) : null,
                DatosGeneralesId = informeDTO.DatosGeneralesId,
                DatosGenerales = informeDTO.DatosGenerales != null ? DatosGeneralesDTOMapper.ConvertirDTOADatosGenerales(informeDTO.DatosGenerales) : null,
                TeleproteccionId = informeDTO.TeleproteccionId,
                Teleproteccion = informeDTO.Teleproteccion != null ? TeleproteccionDTOMapper.ConvertirDTOATeleproteccion(informeDTO.Teleproteccion) : null,
                DistanciaDeFallaId = informeDTO.DistanciaDeFallaId,
                DistanciaDeFalla = informeDTO.DistanciaDeFalla != null ? DistanciaDeFallaDTOMapper.ConvertirDTOADistanciaDeFalla(informeDTO.DistanciaDeFalla) : null,
                TiemposDeDisparoId = informeDTO.TiemposDeDisparoId,
                TiemposDeDisparo = informeDTO.TiemposDeDisparo != null ? TiemposDeDisparoDTOMapper.ConvertirDTOATiemposDeDisparo(informeDTO.TiemposDeDisparo) : null,
                CorrientesDeFallaId = informeDTO.CorrientesDeFallaId,
                CorrientesDeFalla = informeDTO.CorrientesDeFalla != null ? CorrientesDeFallaDTOMapper.ConvertirDTOACorrientesDeFalla(informeDTO.CorrientesDeFalla) : null,
                Estado = informeDTO.Estado
            };
        }

        //lo que se manda al GUI
        //si se pueden enviar nulos (cuando los informes se crean por primera vez)
        public static InformeDTO ConvertirInformeADTO(Informe informe)
        {
            return new InformeDTO
            {                
                Id = informe.Id,
                Tipo = informe.Tipo,
                SubestacionId = informe.SubestacionId,
                LineaTransmisionId = informe.LineaTransmisionId,
                DatosDeLineaId = informe.DatosDeLineaId,
                DatosDeLinea = informe.DatosDeLinea != null ? DatosDeLineaDTOMapper.ConvertirDatosDeLineaADTO(informe.DatosDeLinea) : null,
                DatosGeneralesId = informe.DatosGeneralesId,
                DatosGenerales = informe.DatosGenerales != null ? DatosGeneralesDTOMapper.ConvertirDatosGeneralesADTO(informe.DatosGenerales) : null,
                TeleproteccionId = informe.TeleproteccionId,
                Teleproteccion = informe.Teleproteccion != null ? TeleproteccionDTOMapper.ConvertirTeleproteccionADTO(informe.Teleproteccion) : null,
                DistanciaDeFallaId = informe.DistanciaDeFallaId,
                DistanciaDeFalla = informe.DistanciaDeFalla != null ? DistanciaDeFallaDTOMapper.ConvertirDistanciaDeFallaADTO(informe.DistanciaDeFalla) : null,
                TiemposDeDisparoId = informe.TiemposDeDisparoId,
                TiemposDeDisparo = informe.TiemposDeDisparo != null ? TiemposDeDisparoDTOMapper.ConvertirTiemposDeDisparoADTO(informe.TiemposDeDisparo) : null,
                CorrientesDeFallaId = informe.CorrientesDeFallaId,
                CorrientesDeFalla = informe.CorrientesDeFalla != null ? CorrientesDeFallaDTOMapper.ConvertirCorrientesDeFallaADTO(informe.CorrientesDeFalla) : null,
                Estado = informe.Estado
            };
        }

        public static IEnumerable<InformeDTO> ConvertirListaDeInformesADTO(IEnumerable<Informe> informes)
        {
            return informes.Select(informe => ConvertirInformeADTO(informe)).ToList();
        }
    }
}

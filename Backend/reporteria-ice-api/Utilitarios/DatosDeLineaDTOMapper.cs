using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class DatosDeLineaDTOMapper
    {
        public static DatosDeLinea ConvertirDTOADatosDeLinea(DatosDeLineaDTO datosDeLineaDTO)
        {
            return new DatosDeLinea
            {
                Id = datosDeLineaDTO.Id,
                OT = datosDeLineaDTO.OT,
                Aviso = datosDeLineaDTO.Aviso,
                SAP = datosDeLineaDTO.SAP,
                Distancia = datosDeLineaDTO.Distancia,
                Funcion = datosDeLineaDTO.Funcion,
                Zona = datosDeLineaDTO.Zona
            };
        }

        public static DatosDeLineaDTO ConvertirDatosDeLineaADTO(DatosDeLinea datosDeLinea)
        {
            return new DatosDeLineaDTO
            {
                Id = datosDeLinea.Id,
                OT = datosDeLinea.OT,
                Aviso = datosDeLinea.Aviso,
                SAP = datosDeLinea.SAP,
                Distancia = datosDeLinea.Distancia,
                Funcion = datosDeLinea.Funcion,
                Zona = datosDeLinea.Zona
            };
        }

        public static IEnumerable<DatosDeLineaDTO> ConvertirListaDeDatosDeLineaADTO(IEnumerable<DatosDeLinea> datosDeLinea)
        {
            return datosDeLinea.Select(datos => ConvertirDatosDeLineaADTO(datos)).ToList();
        }
    }
}

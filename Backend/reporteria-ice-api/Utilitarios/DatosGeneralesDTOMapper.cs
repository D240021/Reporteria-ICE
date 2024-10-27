using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public static class DatosGeneralesDTOMapper
    {
        public static DatosGenerales ConvertirDTOADatosGenerales(DatosGeneralesDTO datosGeneralesDTO)
        {
            return new DatosGenerales
            {
                Id = datosGeneralesDTO.Id,
                Evento = datosGeneralesDTO.Evento,
                Fecha = datosGeneralesDTO.Fecha,
                Hora = datosGeneralesDTO.Hora,
                Subestacion = datosGeneralesDTO.Subestacion,
                LT = datosGeneralesDTO.LT,
                Equipo = datosGeneralesDTO.Equipo
            };
        }

        public static DatosGeneralesDTO ConvertirDatosGeneralesADTO(DatosGenerales datosGenerales)
        {
            return new DatosGeneralesDTO
            {
                Id = datosGenerales.Id,
                Evento = datosGenerales.Evento,
                Fecha = datosGenerales.Fecha,
                Hora = datosGenerales.Hora,
                Subestacion = datosGenerales.Subestacion,
                LT = datosGenerales.LT,
                Equipo = datosGenerales.Equipo
            };
        }

        public static IEnumerable<DatosGeneralesDTO> ConvertirListaDeDatosGeneralesADTO(IEnumerable<DatosGenerales> datosGenerales)
        {
            return datosGenerales.Select(datos => ConvertirDatosGeneralesADTO(datos)).ToList();
        }
    }
}

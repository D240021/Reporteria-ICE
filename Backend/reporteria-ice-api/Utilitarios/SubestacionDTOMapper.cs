using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace reporteria_ice_api.Utilitarios
{
    public static class SubestacionDTOMapper
    {
        // Conversión de Subestacion a SubestacionDTO (Creación)
        public static SubestacionDTO ConvertirSubestacionADTO(Subestacion subestacion)
        {
            return new SubestacionDTO
            {
                Id = subestacion.Id,
                NombreUbicacion = subestacion.NombreUbicacion,
                Identificador = subestacion.Identificador,
                UnidadRegionalId = subestacion.UnidadRegionalId
                // No incluimos NombreUnidadRegional para creación
            };
        }

        // Conversión de Subestacion a SubestacionViewDTO (Visualización)
        public static SubestacionViewDTO ConvertirSubestacionAViewDTO(Subestacion subestacion)
        {
            return new SubestacionViewDTO
            {
                Id = subestacion.Id,
                NombreUbicacion = subestacion.NombreUbicacion,
                Identificador = subestacion.Identificador,
                UnidadRegionalId = subestacion.UnidadRegionalId,
                NombreUnidadRegional = subestacion.NombreUnidadRegional // Incluido solo para visualización
            };
        }

        // Conversión de SubestacionDTO a Subestacion (Creación)
        public static Subestacion ConvertirDTOASubestacion(SubestacionDTO subestacionDTO)
        {
            return new Subestacion
            {
                Id = subestacionDTO.Id ?? 0,
                NombreUbicacion = subestacionDTO.NombreUbicacion,
                Identificador = subestacionDTO.Identificador,
                UnidadRegionalId = subestacionDTO.UnidadRegionalId
                // No incluimos NombreUnidadRegional para creación
            };
        }

        // Conversión de lista de Subestacion a SubestacionViewDTO
        public static IEnumerable<SubestacionViewDTO> ConvertirListaDeSubestacionesAViewDTO(IEnumerable<Subestacion> subestaciones)
        {
            return subestaciones.Select(subestacion => ConvertirSubestacionAViewDTO(subestacion)).ToList();
        }

        // Conversión de lista de Subestacion a SubestacionDTO
        public static IEnumerable<SubestacionDTO> ConvertirListaDeSubestacionesADTO(IEnumerable<Subestacion> subestaciones)
        {
            return subestaciones.Select(subestacion => ConvertirSubestacionADTO(subestacion)).ToList();
        }
    }
}

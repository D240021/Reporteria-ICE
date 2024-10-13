using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

namespace reporteria_ice_api.Utilitarios
{
    public class LineaTransmisionDTOMapper
    {
        // Convierte de LineaTransmision a LineaTransmisionDTO
        public static LineaTransmisionDTO ConvertirLineaTransmisionADTO(LineaTransmision lineaTransmision)
        {
            return new LineaTransmisionDTO
            {
                Id = lineaTransmision.Id, 
                NombreUbicacion = lineaTransmision.NombreUbicacion,
                Identificador = lineaTransmision.Identificador
            };
        }

        // Convierte de LineaTransmisionDTO a LineaTransmision
        public static LineaTransmision ConvertirDTOALineaTransmision(LineaTransmisionDTO lineaTransmisionDTO)
        {
            return new LineaTransmision
            {
                Id = lineaTransmisionDTO.Id ?? 0,
                NombreUbicacion = lineaTransmisionDTO.NombreUbicacion,
                Identificador = lineaTransmisionDTO.Identificador
            };
        }

        // Convierte una lista de LineaTransmision a LineaTransmisionDTO
        public static IEnumerable<LineaTransmisionDTO> ConvertirListaDeLineasTransmisionADTO(IEnumerable<LineaTransmision> lineasTransmision)
        {
            return lineasTransmision.Select(linea => ConvertirLineaTransmisionADTO(linea)).ToList();
        }
    }
}
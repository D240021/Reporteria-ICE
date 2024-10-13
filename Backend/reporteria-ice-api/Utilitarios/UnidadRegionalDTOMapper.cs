using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;

public static class UnidadRegionalDTOMapper
{
    public static UnidadRegionalDTO ConvertirUnidadRegionalADTO(UnidadRegional unidadRegional)
    {
        return new UnidadRegionalDTO
        {
            Id = unidadRegional.Id,  
            NombreUbicacion = unidadRegional.NombreUbicacion,
            Identificador = unidadRegional.Identificador
        };
    }

    public static UnidadRegional ConvertirDTOAUnidadRegional(UnidadRegionalDTO unidadRegionalDTO)
    {
        return new UnidadRegional
        {
            Id = unidadRegionalDTO.Id ?? 0,
            NombreUbicacion = unidadRegionalDTO.NombreUbicacion,
            Identificador = unidadRegionalDTO.Identificador
        };
    }

    public static IEnumerable<UnidadRegionalDTO> ConvertirListaDeUnidadesRegionalesADTO(IEnumerable<UnidadRegional> unidadesRegionales)
    {
        return unidadesRegionales.Select(unidad => ConvertirUnidadRegionalADTO(unidad)).ToList();
    }
}

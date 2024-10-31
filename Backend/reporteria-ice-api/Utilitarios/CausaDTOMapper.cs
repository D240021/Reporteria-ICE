using ICE.Capa_Dominio.Modelos;
using reporteria_ice_api.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace reporteria_ice_api.Utilitarios
{
    public static class CausaDTOMapper
    {
        // Convierte de CausaDTO a Causa
        public static Causa ConvertirDTOACausa(CausaDTO causaDTO)
        {
            return new Causa
            {
                Id = causaDTO.Id,
                Descripcion = causaDTO.Descripcion
            };
        }

        // Convierte de Causa a CausaDTO
        public static CausaDTO ConvertirCausaADTO(Causa causa)
        {
            return new CausaDTO
            {
                Id = causa.Id,
                Descripcion = causa.Descripcion
            };
        }

        // Convierte una lista de Causa a una lista de CausaDTO
        public static IEnumerable<CausaDTO> ConvertirListaDeCausasADTO(IEnumerable<Causa> causas)
        {
            return causas.Select(causa => ConvertirCausaADTO(causa)).ToList();
        }
    }
}

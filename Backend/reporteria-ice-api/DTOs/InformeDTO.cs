namespace reporteria_ice_api.DTOs
{
    public class InformeDTO
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public int SubestacionId { get; set; }        

        public int LineaTransmisionId { get; set; }        

        public int DatosDeLineaId { get; set; }
        public DatosDeLineaDTO DatosDeLinea { get; set; } 

        public int DatosGeneralesId { get; set; }
        public DatosGeneralesDTO DatosGenerales { get; set; }

        public int TeleproteccionId { get; set; }
        public TeleproteccionDTO Teleproteccion { get; set; } 

        public int DistanciaDeFallaId { get; set; }
        public DistanciaDeFallaDTO DistanciaDeFalla { get; set; } 

        public int TiemposDeDisparoId { get; set; }
        public TiemposDeDisparoDTO TiemposDeDisparo { get; set; } 

        public int CorrientesDeFallaId { get; set; }
        public CorrientesDeFallaDTO CorrientesDeFalla { get; set; } 

        public int Estado { get; set; }
    }
}

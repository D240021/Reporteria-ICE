namespace reporteria_ice_api.DTOs
{
    public class DistanciaDeFallaDTO
    {
        public int Id { get; set; }
        public string DistanciaKM { get; set; }
        public string DistanciaPorcentaje { get; set; }
        public string DistanciaReportada { get; set; }
        public string DistanciaDobleTemporal { get; set; }
        public string Error { get; set; }
        public string Error_Doble { get; set; }
    }
}

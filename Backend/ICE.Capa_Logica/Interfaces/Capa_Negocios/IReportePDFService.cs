using System.Threading.Tasks;
using ICE.Capa_Dominio.Modelos;

public interface IPDFGeneratorService
{
    Task<byte[]> GenerarPDF(Reporte reporte);
}

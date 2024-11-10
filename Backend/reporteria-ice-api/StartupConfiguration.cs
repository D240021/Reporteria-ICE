using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ICE.Capa_Datos.Contexto;
using ICE.Capa_Datos.Acciones;
using Microsoft.EntityFrameworkCore;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;


public static class StartupConfiguration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, string environment)
    {
        Console.WriteLine($"Configurando servicios para el entorno: {environment}");

        // Configuración de servicios
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpClient();

        services.AddTransient<IGestionarUnidadRegionalCN, GestionarUnidadRegionalCN>();
        services.AddTransient<IGestionarUnidadRegionalDA, GestionarUnidadRegionalDA>();
        services.AddTransient<IGestionarUsuarioCN, GestionarUsuarioCN>();
        services.AddTransient<IGestionarUsuarioDA, GestionarUsuarioDA>();
        services.AddTransient<IGestionarSubestacionCN, GestionarSubestacionCN>();
        services.AddTransient<IGestionarSubestacionDA, GestionarSubestacionDA>();
        services.AddTransient<IGestionarLineasTransmisionCN, GestionarLineasTransmisionCN>();
        services.AddTransient<IGestionarLineasTransmisionDA, GestionarLineasTransmisionDA>();
        services.AddTransient<IGestionarInformeCN, GestionarInformeCN>();
        services.AddTransient<IGestionarInformeDA, GestionarInformeDA>();
        services.AddTransient<IGestionarTeleproteccionCN, GestionarTeleproteccionCN>();
        services.AddTransient<IGestionarTeleproteccionDA, GestionarTeleproteccionDA>();
        services.AddTransient<IGestionarDistanciaDeFallaCN, GestionarDistanciaDeFallaCN>();
        services.AddTransient<IGestionarDistanciaDeFallaDA, GestionarDistanciaDeFallaDA>();
        services.AddTransient<IGestionarCorrientesDeFallaCN, GestionarCorrientesDeFallaCN>();
        services.AddTransient<IGestionarCorrientesDeFallaDA, GestionarCorrientesDeFallaDA>();
        services.AddTransient<IGestionarTiemposDeDisparoCN, GestionarTiemposDeDisparoCN>();
        services.AddTransient<IGestionarTiemposDeDisparoDA, GestionarTiemposDeDisparoDA>();
        services.AddTransient<IGestionarDatosDeLineaCN, GestionarDatosDeLineaCN>();
        services.AddTransient<IGestionarDatosDeLineaDA, GestionarDatosDeLineaDA>();
        services.AddTransient<IGestionarDatosGeneralesCN, GestionarDatosGeneralesCN>();
        services.AddTransient<IGestionarDatosGeneralesDA, GestionarDatosGeneralesDA>();
        services.AddTransient<IGestionarReporteCN, GestionarReporteCN>();
        services.AddTransient<IGestionarReporteDA, GestionarReporteDA>();
        services.AddTransient<IGestionarReporteConInformesService, GestionarReporteConInformesService>();
        services.AddTransient<IPDFGeneratorService, PDFGeneratorService>();
        services.AddTransient<IGestionarCausaCN, GestionarCausaCN>();
        services.AddTransient<IGestionarCausaDA, GestionarCausaDA>();

        // Configurar conexión a la base de datos en función del entorno
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (environment == "Test")
        {
            // Si el entorno es de prueba, usa una conexión de prueba (opcionalmente puedes definir otra cadena de conexión en appsettings.Test.json)
            connectionString = configuration.GetConnectionString("TestConnection") ?? connectionString;
        }

        Console.WriteLine($"Cadena de conexión usada: {connectionString}");


        services.AddDbContext<ICE_Context>(options => options.UseSqlServer(connectionString));
    }
}

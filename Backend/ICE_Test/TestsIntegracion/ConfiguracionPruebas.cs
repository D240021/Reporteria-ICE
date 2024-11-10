using ICE.Capa_Datos.Contexto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ICE_Test.TestsIntegracion
{
    public class ConfiguracionPruebas
    {
        /*
        public IServiceProvider ProveedorServicios { get; private set; }

        public ConfiguracionPruebas()
        {
            // Cargar configuración explícitamente para confirmar el archivo de entorno "Test"
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Test.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine($"Entorno configurado: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
            Console.WriteLine($"Cadena de conexión: {configuration.GetConnectionString("DefaultConnection")}");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    StartupConfiguration.ConfigureServices(services, configuration, "Test");
                })
                .Build();

            ProveedorServicios = host.Services.CreateScope().ServiceProvider;

            using var scope = ProveedorServicios.CreateScope();
            var contexto = scope.ServiceProvider.GetRequiredService<ICE_Context>();

            // Inicializar la base de datos
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();
            EjecutarScriptSql(contexto, Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Tools", "SQLServer_TestIntegracion", "Database", "init.sql"));
        }
        */

        public IServiceProvider ProveedorServicios { get; private set; }

        public ConfiguracionPruebas()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Test.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    StartupConfiguration.ConfigureServices(services, configuration, "Test");
                })
                .Build();

            ProveedorServicios = host.Services.CreateScope().ServiceProvider;
        }

        private void EjecutarScriptSql(ICE_Context contexto, string rutaScript)
        {
            if (File.Exists(rutaScript))
            {
                var scriptSql = File.ReadAllText(rutaScript);
                contexto.Database.ExecuteSqlRaw(scriptSql);
            }
        }
    }
}

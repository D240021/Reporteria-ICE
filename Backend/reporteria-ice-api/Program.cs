using ICE.Capa_Datos.Acciones;
using ICE.Capa_Datos.Contexto;
using ICE.Capa_Negocios.CU;
using ICE.Capa_Negocios.Interfaces.Capa_Negocios;
using ICE.Capa_Negocios.Interfaces.Capa_Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// Inyección de dependencias para UnidadRegional
builder.Services.AddTransient<IGestionarUnidadRegionalCN, GestionarUnidadRegionalCN>();
builder.Services.AddTransient<IGestionarUnidadRegionalDA, GestionarUnidadRegionalDA>();

// Inyección de dependencias para Usuario
builder.Services.AddTransient<IGestionarUsuarioCN, GestionarUsuarioCN>();
builder.Services.AddTransient<IGestionarUsuarioDA, GestionarUsuarioDA>();

// Inyección de dependencias para Subestaciones
builder.Services.AddTransient<IGestionarSubestacionCN, GestionarSubestacionCN>();
builder.Services.AddTransient<IGestionarSubestacionDA, GestionarSubestacionDA>();

// Inyección de dependencias para Líneas de Transmisión
builder.Services.AddTransient<IGestionarLineasTransmisionCN, GestionarLineasTransmisionCN>();
builder.Services.AddTransient<IGestionarLineasTransmisionDA, GestionarLineasTransmisionDA>();

// Inyección de dependencias para Informes
builder.Services.AddTransient<IGestionarInformeCN, GestionarInformeCN>();
builder.Services.AddTransient<IGestionarInformeDA, GestionarInformeDA>();

// Inyección de dependencias para Teleprotección
builder.Services.AddTransient<IGestionarTeleproteccionCN, GestionarTeleproteccionCN>();
builder.Services.AddTransient<IGestionarTeleproteccionDA, GestionarTeleproteccionDA>();

// Inyección de dependencias para Distancia de Falla
builder.Services.AddTransient<IGestionarDistanciaDeFallaCN, GestionarDistanciaDeFallaCN>();
builder.Services.AddTransient<IGestionarDistanciaDeFallaDA, GestionarDistanciaDeFallaDA>();

// Inyección de dependencias para Corrientes de Falla
builder.Services.AddTransient<IGestionarCorrientesDeFallaCN, GestionarCorrientesDeFallaCN>();
builder.Services.AddTransient<IGestionarCorrientesDeFallaDA, GestionarCorrientesDeFallaDA>();

// Inyección de dependencias para Tiempos de Disparo
builder.Services.AddTransient<IGestionarTiemposDeDisparoCN, GestionarTiemposDeDisparoCN>();
builder.Services.AddTransient<IGestionarTiemposDeDisparoDA, GestionarTiemposDeDisparoDA>();

// Inyección de dependencias para Datos de Línea
builder.Services.AddTransient<IGestionarDatosDeLineaCN, GestionarDatosDeLineaCN>();
builder.Services.AddTransient<IGestionarDatosDeLineaDA, GestionarDatosDeLineaDA>();

// Inyección de dependencias para Datos Generales
builder.Services.AddTransient<IGestionarDatosGeneralesCN, GestionarDatosGeneralesCN>();
builder.Services.AddTransient<IGestionarDatosGeneralesDA, GestionarDatosGeneralesDA>();

// Inyección de dependencias para Reportes
builder.Services.AddTransient<IGestionarReporteCN, GestionarReporteCN>();
builder.Services.AddTransient<IGestionarReporteDA, GestionarReporteDA>();

// Inyección de dependencias para el servicio de dominio de Reporte con Informes
builder.Services.AddTransient<IGestionarReporteConInformesService, GestionarReporteConInformesService>();

// Inyección de dependencias para el servicio ieText (PDF)
builder.Services.AddTransient<IPDFGeneratorService, PDFGeneratorService>();

// Inyección de dependencias para Causas
builder.Services.AddTransient<IGestionarCausaCN, GestionarCausaCN>();
builder.Services.AddTransient<IGestionarCausaDA, GestionarCausaDA>();



// Conexión a BD según el entorno configurado
builder.Services.AddDbContext<ICE_Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});


// Conexión a BD original a secas
//builder.Services.AddDbContext<ICE_Context>(options =>
//{
  //  var connectionString = "Server=(localdb)\\LocalServerICE; Database=ICE_Reporteria; Trusted_Connection=True;TrustServerCertificate=True;";
    //options.UseSqlServer(connectionString);
//});

var app = builder.Build();
Console.WriteLine($"Entorno actual: {builder.Environment.EnvironmentName}");


// Habilitar CORS
app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});



Console.WriteLine($"Entorno ASPNETCORE_ENVIRONMENT detectado: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
// Ejecutar migraciones automáticas solo en entornos de Development o Test
if (app.Environment.IsDevelopment())
{
    // Solo en Development: aplica migraciones sin ejecutar init.sql
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ICE_Context>();
        context.Database.Migrate();
    }
}
else if (app.Environment.IsEnvironment("Test"))
{
    // Solo en Test: elimina y recrea la base de datos, y ejecuta init.sql
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ICE_Context>();

        // Elimina la base de datos existente y vuelve a crearla
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Ejecutar el init.sql para insertar datos de prueba en Test
        RunSqlScript(context, Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Tools", "SQLServer_TestIntegracion", "Database", "init.sql"));        
    }
}



// Ejecutar migraciones automáticas al iniciar la aplicación
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ICE_Context>();
//    context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Función para ejecutar el script SQL
void RunSqlScript(ICE_Context context, string scriptPath)
{
    if (File.Exists(scriptPath))
    {
        var sqlScript = File.ReadAllText(scriptPath);
        context.Database.ExecuteSqlRaw(sqlScript);
    }
}
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

// Inyecci�n de dependencias para UnidadRegional
builder.Services.AddTransient<IGestionarUnidadRegionalCN, GestionarUnidadRegionalCN>();
builder.Services.AddTransient<IGestionarUnidadRegionalDA, GestionarUnidadRegionalDA>();

// Inyecci�n de dependencias para Usuario
builder.Services.AddTransient<IGestionarUsuarioCN, GestionarUsuarioCN>();
builder.Services.AddTransient<IGestionarUsuarioDA, GestionarUsuarioDA>();

// Inyecci�n de dependencias para Subestaciones
builder.Services.AddTransient<IGestionarSubestacionCN, GestionarSubestacionCN>();
builder.Services.AddTransient<IGestionarSubestacionDA, GestionarSubestacionDA>();

// Inyecci�n de dependencias para L�neas de Transmisi�n
builder.Services.AddTransient<IGestionarLineasTransmisionCN, GestionarLineasTransmisionCN>();
builder.Services.AddTransient<IGestionarLineasTransmisionDA, GestionarLineasTransmisionDA>();

// Inyecci�n de dependencias para Informes
builder.Services.AddTransient<IGestionarInformeCN, GestionarInformeCN>();
builder.Services.AddTransient<IGestionarInformeDA, GestionarInformeDA>();

// Inyecci�n de dependencias para Teleprotecci�n
builder.Services.AddTransient<IGestionarTeleproteccionCN, GestionarTeleproteccionCN>();
builder.Services.AddTransient<IGestionarTeleproteccionDA, GestionarTeleproteccionDA>();

// Inyecci�n de dependencias para Distancia de Falla
builder.Services.AddTransient<IGestionarDistanciaDeFallaCN, GestionarDistanciaDeFallaCN>();
builder.Services.AddTransient<IGestionarDistanciaDeFallaDA, GestionarDistanciaDeFallaDA>();

// Inyecci�n de dependencias para Corrientes de Falla
builder.Services.AddTransient<IGestionarCorrientesDeFallaCN, GestionarCorrientesDeFallaCN>();
builder.Services.AddTransient<IGestionarCorrientesDeFallaDA, GestionarCorrientesDeFallaDA>();

// Inyecci�n de dependencias para Tiempos de Disparo
builder.Services.AddTransient<IGestionarTiemposDeDisparoCN, GestionarTiemposDeDisparoCN>();
builder.Services.AddTransient<IGestionarTiemposDeDisparoDA, GestionarTiemposDeDisparoDA>();

// Inyecci�n de dependencias para Datos de L�nea
builder.Services.AddTransient<IGestionarDatosDeLineaCN, GestionarDatosDeLineaCN>();
builder.Services.AddTransient<IGestionarDatosDeLineaDA, GestionarDatosDeLineaDA>();

// Inyecci�n de dependencias para Datos Generales
builder.Services.AddTransient<IGestionarDatosGeneralesCN, GestionarDatosGeneralesCN>();
builder.Services.AddTransient<IGestionarDatosGeneralesDA, GestionarDatosGeneralesDA>();

// Inyecci�n de dependencias para Reportes
builder.Services.AddTransient<IGestionarReporteCN, GestionarReporteCN>();
builder.Services.AddTransient<IGestionarReporteDA, GestionarReporteDA>();

// Inyecci�n de dependencias para el servicio de dominio de Reporte con Informes
builder.Services.AddTransient<IGestionarReporteConInformesService, GestionarReporteConInformesService>();

// Inyecci�n de dependencias para el servicio ieText (PDF)
builder.Services.AddTransient<IPDFGeneratorService, PDFGeneratorService>();

// Inyecci�n de dependencias para Causas
builder.Services.AddTransient<IGestionarCausaCN, GestionarCausaCN>();
builder.Services.AddTransient<IGestionarCausaDA, GestionarCausaDA>();



// Conexi�n a BD
builder.Services.AddDbContext<ICE_Context>(options =>
{
    var connectionString = "Server=reporteriaICE.mssql.somee.com;Database=reporteriaICE;User=DanielInfo24_SQLLogin_1;Password=ixm5yvjmrv;TrustServerCertificate=True;";
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

// Ejecutar migraciones autom�ticas al iniciar la aplicaci�n
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ICE_Context>();
    context.Database.Migrate();
}

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

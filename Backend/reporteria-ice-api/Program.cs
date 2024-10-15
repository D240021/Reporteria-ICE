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

// Inyecci�n de dependencias para Subestaciones
builder.Services.AddTransient<IGestionarSubestacionCN, GestionarSubestacionCN>();
builder.Services.AddTransient<IGestionarSubestacionDA, GestionarSubestacionDA>();

// Inyecci�n de dependencias para L�neas de Transmisi�n
builder.Services.AddTransient<IGestionarLineasTransmisionCN, GestionarLineasTransmisionCN>();
builder.Services.AddTransient<IGestionarLineasTransmisionDA, GestionarLineasTransmisionDA>();

// Inyecci�n de dependencias para T�cnicos
builder.Services.AddTransient<IGestionarTecnicoCN, GestionarTecnicoCN>();
builder.Services.AddTransient<IGestionarTecnicoDA, GestionarTecnicoDA>();

// Inyecci�n de dependencias para Supervisores
builder.Services.AddTransient<IGestionarSupervisorCN, GestionarSupervisorCN>();
builder.Services.AddTransient<IGestionarSupervisorDA, GestionarSupervisorDA>();

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

// Conexi�n a BD
builder.Services.AddDbContext<ICE_Context>(options =>
{
    var connectionString = "Server=(LocalDB)\\LocalServerJosue; Database=ICE_Reporteria; Trusted_Connection=True;TrustServerCertificate=True;";
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

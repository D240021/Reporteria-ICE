using ICE.Capa_Datos.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


//Conexión a BD
builder.Services.AddDbContext<ICE_Context>(options =>
{
    // Usar la cadena de conexión desde la configuración
    var connectionString = "Server = (LocalDB)\\LocalServerJosue; Database = ICE_Reporteria; Trusted_Connection =True;TrustServerCertificate=True;";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aquí, si es necesario
});

var app = builder.Build();

app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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

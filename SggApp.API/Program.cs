using Microsoft.EntityFrameworkCore;
using SggApp.BLL.Servicios;
using SggApp.BLL.Interfaces;
using SggApp.DAL.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurar DbContext con la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar los servicios y repositorios para la inyección de dependencias
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<IGastoService, GastoService>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<MonedaRepository>();
builder.Services.AddScoped<IMonedaService, MonedaService>();

builder.Services.AddScoped<PresupuestoRepository>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();

// Agregar OpenAPI para documentar la API
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Definir el WeatherForecast para pruebas (esto puede ser eliminado más tarde)
var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

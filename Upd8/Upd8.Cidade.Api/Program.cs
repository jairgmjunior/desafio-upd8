using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Upd8.Core.Enums;
using Upd8.Data.Context;
using Upd8.Data.Repository;
using Upd8.Manager.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICidadeRepository, CidadeRepository>();
builder.Services.AddDbContext<Upd8Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/GetCidadesPaginadas", 
    async ([FromQuery] int pageSize, 
    [FromQuery] int pageNum, 
    [FromQuery] string searchTerm, 
    [FromQuery] string estado,
    [FromServices] ICidadeRepository repository) =>
{
    var enumEstado = Enum.Parse<EEStado>(estado, true);

    var cidade = await repository.GetCidadesPaginadasPorEstado(pageSize, pageNum, searchTerm, enumEstado);

    return cidade;
})
.WithName("GetCidadesPaginadas");

app.MapGet("api/GetCidadePorCodigoIbge",
    async ([FromQuery] string codigoIbge,
    [FromServices] ICidadeRepository repository) =>
    {
        return await repository.GetCidadePorCodigoIbge(codigoIbge);
    })
.WithName("GetCidadePorCodigoIbge");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
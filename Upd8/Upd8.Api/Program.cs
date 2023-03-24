using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Serilog;
using System.Text.Json.Serialization;
using Upd8.Api.Configuration;

try
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json", optional: true);

    builder.Configuration.AddSerilog();
    builder.Host.UseSerilog(Log.Logger);

    builder.Services.AddControllers()
       .AddJsonOptions(x => 
       {
           x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
       });

    builder.Services.AddFluentValidationConfig();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddDataBaseConfiguration(builder.Configuration);

    builder.Services.AddDependencyInjectionConfig();

    builder.Services.AddAutoMapperConfig();

    builder.Services.AddSwaggerConfig();

    var app = builder.Build();

    app.UseExceptionHandler("/error");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseDataBaseConfiguration();

    app.UseSwaggerConfiguration();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    Log.Information("Iniciando a Api");

    app.Run();
}
catch (Exception e) when (
    // https://github.com/dotnet/runtime/issues/60600
    e.GetType().Name is not "StopTheHostException"
    // HostAbortedException was added in .NET 7, but since we target .NET 6 we
    // need to do it this way until we target .NET 8
    && e.GetType().Name is not "HostAbortedException")
{
    Log.Fatal(e, "Erro ao iniciar a webapi");
}
finally
{
    Log.CloseAndFlush();
}

using BH.Assessment.Api.Middlewares;
using BH.Assessment.Application;
using BH.Assessment.Persistence;
using Serilog;

namespace BH.Assessment.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        //Log.Logger = new LoggerConfiguration()
        //    .ReadFrom.Configuration(config)
        //    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        //    .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(config);
            configuration.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
        });

        // Add services to the container.

        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseHttpsRedirection();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomExceptionHandler();


        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
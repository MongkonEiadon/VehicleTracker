using System;
using System.IO;

using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EntityFramework;

using EventStore.Middleware;
using EventStore.Middleware.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EventStore.App;

internal static class Program {

    private static void Main(string[] args) {
        Console.WriteLine("Event store setting up for Event Sourcing");


        var config = new ConfigurationBuilder()
            .AddCommandLine(args)
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", true, true)
            .Build();


        // services
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
            Args = args,
            EnvironmentName = Environments.Production
        });
        
        builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
        builder.Configuration.AddConfiguration(config);
        builder.Services.AddEventFlow(e => e
            .AddAspNetCore()
            .RegisterModule<EventSourcingModule>());

        // application configure
        using var app = builder.Build();
        app.UseRouting();

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<IDbContextProvider<EventSourcingDbContext>>();
        dbContext?.CreateContext();

        app.Run();
    }

}
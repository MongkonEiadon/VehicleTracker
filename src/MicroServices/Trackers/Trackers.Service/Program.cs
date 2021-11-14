using System;

using Domain.Module;

using EventFlow;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EntityFramework;
using EventFlow.Extensions;
using EventFlow.RabbitMQ;
using EventFlow.RabbitMQ.Extensions;

using EventStore.Middleware.Module;

using Infrastructure.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Trackers.ReadStore;
using Trackers.ReadStore.Module;

namespace Trackers.Service; 

public static class Program {

    public static void Main(string[] args) {

        // services
        var env = EnvironmentConfiguration.Bind(new ConfigurationBuilder().AddEnvironmentVariables().Build());
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services
            .AddSingleton(env)
            .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trackers API", Version = "v1" }))
            .AddMvc(e => e.EnableEndpointRouting = false);
            
        EventFlowOptions.New
            .UseServiceCollection(builder.Services)
            .AddAspNetCore()
            .UseConsoleLog()
            .RegisterModule<DomainModule>()
            .RegisterModule<TrackingReadStoreModule>()
            .RegisterModule<EventSourcingModule>()
            .PublishToRabbitMq(RabbitMqConfiguration.With(new Uri(env.RabbitMqConnection)))
            .CreateServiceProvider();

        // application configure
        using var app = builder.Build();
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<IDbContextProvider<TrackingContext>>();
        dbContext?.CreateContext();

        if (app.Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trackers API V1"); });
            app.UseMvc();
        }
        else {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseMvc();
    }

}
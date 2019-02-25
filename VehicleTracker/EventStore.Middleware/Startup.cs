using System;
using System.Collections.Generic;
using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EntityFramework;
using EventStore.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VehicleTracker.Domain.Infrastructure;

namespace EventStore.Middleware
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return EventFlowOptions.New
                .UseServiceCollection(services)
                .RegisterModule<EventSourcingModule>()
                .CreateServiceProvider();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // initialize InfoDbContext
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<IDbContextProvider<EventSourcingDbContext>>();
                dbContext.CreateContext();
            }
        }
    }
}
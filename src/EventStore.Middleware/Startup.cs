using System;
using System.Collections.Generic;

using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EntityFramework;

using EventStore.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using VehicleTracker.Infrastructure;

namespace EventStore.Middleware {
    public class Startup {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment environment, IConfiguration configuration) {
            _environment = environment;
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services) {
            var middlewareConfig = new ServiceConfiguration().Create(new Dictionary<string, string> {
                {
                    nameof(ServiceConfiguration.EventDbConnection),
                    _configuration.GetValue<string>(Identifiers.EventDbConnection)
                }
            });

            return EventFlowOptions.New
                .UseServiceCollection(services.AddSingleton(middlewareConfig))
                .RegisterModule<EventSourcingModule>()
                .CreateServiceProvider();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {
            // initialize InfoDbContext
            using (var scope = app.ApplicationServices.CreateScope()) {
                var dbContext = scope.ServiceProvider.GetService<IDbContextProvider<EventSourcingDbContext>>();
                dbContext.CreateContext();
            }
        }
    }
}
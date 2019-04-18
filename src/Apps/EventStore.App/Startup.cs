using System;

using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EntityFramework;

using EventStore.Middleware;
using EventStore.Middleware.Module;

using Infrastructure.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventStore.App {
    public class Startup {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment environment, IConfiguration configuration) {
            _environment = environment;
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services) {
            var middlewareConfig = EnvironmentConfiguration.Bind(_configuration);

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
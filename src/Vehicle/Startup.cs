using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Extensions;
using EventStore.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vehicle.ReadStore;
using Vehicle.ReadStore.Module;
using Vehicle7Tracker.Domain.Infrastructure;

namespace Vehicle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return EventFlowOptions.New
                .UseServiceCollection(services)
                .AddAspNetCoreMetadataProviders()
                .UseConsoleLog()
                .AddDefaults(typeof(VehicleReadModel).Assembly)
                .RegisterModule<VehicleReadStoreModule>()
                .RegisterModule<EventSourcingModule>()
                .CreateServiceProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            // initialize InfoDbContext
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //var efentflow = scope.ServiceProvider.GetService<EventFlow.ReadStores.IReadModel>();
                var dbContext = scope.ServiceProvider.GetService<VehicleContext>();
                dbContext?.Database?.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

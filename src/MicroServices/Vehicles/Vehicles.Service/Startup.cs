using System;
using System.Collections.Generic;

using AutoMapper;

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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

using Vehicles.ReadStore;
using Vehicles.ReadStore.Module;

namespace Vehicles.Service {
    public class Startup {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services) {

            var env = EnvironmentConfiguration.Bind(_configuration);

            services.AddAutoMapper()
                .AddSingleton(env)
                .AddSwaggerGen(c => c.SwaggerDoc("v1", new Info {Title = "Vehicles API", Version = "v1"}))
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return EventFlowOptions.New
                .UseServiceCollection(services)
                .AddAspNetCoreMetadataProviders()
                .UseConsoleLog()
                .RegisterModule<DomainModule>()
                .RegisterModule<VehicleReadStoreModule>()
                .RegisterModule<EventSourcingModule>()
                .PublishToRabbitMq(RabbitMqConfiguration.With(new Uri(env.RabbitMqConnection)))
                .CreateServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            // initialize dbContext
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<IDbContextProvider<VehicleContext>>();
                dbContext.CreateContext();
            }
        

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicles API V1"); });
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
}
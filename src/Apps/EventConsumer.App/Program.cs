using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles;
using Domain.Business.Vehicles.Events;
using Domain.Module;

using EventFlow;
using EventFlow.Aggregates;
using EventFlow.AspNetCore.Extensions;
using EventFlow.Configuration;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Extensions;
using EventFlow.Logs.Internals.Logging;
using EventFlow.RabbitMQ;
using EventFlow.RabbitMQ.Extensions;
using EventFlow.Subscribers;

using Infrastructure.Configurations;
using Infrastructure.RabbitMq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EventConsumer.App {

    public class Program {

        public static async Task Main(string[] args) {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((host, config) => {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", true, true);
                    config.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", true, true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices(
                    (hostcontext, services) => {
                        var envconfig = EnvironmentConfiguration.Bind(hostcontext.Configuration);
                        services.AddSingleton(envconfig);

                        EventFlowOptions.New
                            .Configure(cfg => cfg.IsAsynchronousSubscribersEnabled = true)
                            .UseServiceCollection(services)
                            .AddAspNetCoreMetadataProviders()
                            .PublishToRabbitMq(RabbitMqConfiguration.With(new Uri($"{envconfig.RabbitMqConnection}"),
                                true, 5, envconfig.RabbitExchange))
                            .RegisterModule<DomainModule>()

                            //
                            // subscribe services changed
                            //
                            .AddAsynchronousSubscriber<VehicleAggregate, VehicleId, LocationUpdatedEvent, RabbitMqConsumePersistanceService>()
                            .RegisterServices(s => {
                                s.Register<IHostedService, RabbitConsumePersistenceService>(Lifetime.Singleton);
                                s.Register<IHostedService, RabbitMqConsumePersistanceService>(Lifetime.Singleton);
                            });
                    })
                .ConfigureLogging((hostingContext, logging) => { });

            await builder.RunConsoleAsync();
        }

    }

    public interface IRabbitMqConsumerPersistanceService {

    }

    public class RabbitMqConsumePersistanceService : IHostedService, IRabbitMqConsumerPersistanceService, ISubscribeAsynchronousTo<VehicleAggregate, VehicleId, LocationUpdatedEvent> {

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(IDomainEvent<VehicleAggregate, VehicleId, LocationUpdatedEvent> domainEvent, CancellationToken cancellationToken) {

            Console.WriteLine($"Location Updated for {domainEvent.AggregateIdentity} with Latitude => {domainEvent.AggregateEvent.Latitude}, Longitude => {domainEvent.AggregateEvent.Longitude}, z => {domainEvent.AggregateEvent.ZIndex}");


            return Task.CompletedTask;
        }

    }

}

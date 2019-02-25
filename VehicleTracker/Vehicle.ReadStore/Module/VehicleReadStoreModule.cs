using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;
using Vehicle.ReadStore.Services;
using Vehicle7Tracker.Domain.Application.QueryServices;

namespace Vehicle.ReadStore.Module
{
    public class VehicleReadStoreModule : IModule {

        public void Register(IEventFlowOptions options) {
            options.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(VehicleReadStoreModule).Assembly)
                .AddDbContextProvider<VehicleContext, VehicleContextProvider>()
                .UseEntityFrameworkEventStore<VehicleContext>()
                .UseEntityFrameworkReadModel<VehicleReadModel, VehicleContext>()
                .RegisterServices(s =>
                {
                    s.Register<IVehicleQueryService, VehicleQueryService>();
                });
        }
    }
}
using Domain.Application.CommandServices;
using Domain.Application.QueryServices;

using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;

using Infrastructure.ReadStores;

using Vehicles.ReadStore.Services;


namespace Vehicles.ReadStore.Module {
    public class VehicleReadStoreModule : IModule {
        public void Register(IEventFlowOptions options) {
            options.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(VehicleReadStoreModule).Assembly)
                .AddDbContextProvider<VehicleContext, VehicleContextProvider>()
                .UseEntityFrameworkEventStore<VehicleContext>()
                //update read models
                .UseEntityFrameworkReadModel<VehicleReadModel, VehicleContext>()

                .RegisterServices(s => {
                    s.Register<IVehicleQueryService, VehicleQueryService>();
                    s.Register<ISearchableReadModelStore<VehicleReadModel>, EfSearchableReadStore<VehicleReadModel, VehicleContext>>();
                });
        }
    }
}
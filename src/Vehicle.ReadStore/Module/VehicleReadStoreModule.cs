using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;

using Vehicle.ReadStore.Services;

using VehicleTracker.Application;
using VehicleTracker.Application.CommandServices;
using VehicleTracker.Application.QueryServices;

namespace Vehicle.ReadStore.Module {
    public class VehicleReadStoreModule : IModule {
        public void Register(IEventFlowOptions options) {
            options.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(VehicleReadStoreModule).Assembly)
                .AddDbContextProvider<VehicleContext, VehicleContextProvider>()
                .UseEntityFrameworkEventStore<VehicleContext>()
                .UseEntityFrameworkReadModel<VehicleReadModel, VehicleContext>()
                .RegisterServices(s => {
                    s.Register<IVehicleCommandService, VehicleCommandService>();
                    s.Register<IVehicleQueryService, VehicleQueryService>();
                    s.Register<ISearchableReadModelStore<VehicleReadModel>,
                        EfSearchableReadStore<VehicleReadModel, VehicleContext>>();
                });
        }
    }
}
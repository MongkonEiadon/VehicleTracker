using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;

using Tracking.ReadStore.ReadModels;
using Tracking.ReadStore.Services;

using VehicleTracker.Application;
using VehicleTracker.Application.CommandServices;
using VehicleTracker.Application.QueryServices;
using VehicleTracker.Infrastructure;

namespace Tracking.ReadStore.Module {
    public class TrackingReadStoreModule : IModule {


        public void Register(IEventFlowOptions options) {

            options.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(TrackingReadStoreModule).Assembly)
                .AddDbContextProvider<TrackingContext, TrackingContextProvider>()
                .UseEntityFrameworkEventStore<TrackingContext>()
                .UseEntityFrameworkReadModel<LocationReadModel, TrackingContext>()
                .RegisterServices(s => {

                    s.Register<ITrackingQueryService, TrackingQueryService>();
                    s.Register<ITrackingCommandService, TrackingCommandService>();
                    s.Register<ISearchableReadModelStore<LocationReadModel>, EfSearchableReadStore<LocationReadModel, TrackingContext>>();
                });
        }
    }
}
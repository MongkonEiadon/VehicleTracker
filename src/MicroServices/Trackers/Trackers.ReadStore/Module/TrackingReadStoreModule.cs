using Domain.Application.CommandServices;
using Domain.Application.QueryServices;

using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;

using Infrastructure.ReadStores;

using Trackers.ReadStore.ReadModels;
using Trackers.ReadStore.Services;

namespace Trackers.ReadStore.Module {
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
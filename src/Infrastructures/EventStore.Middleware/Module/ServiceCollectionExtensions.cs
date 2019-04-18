using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;

namespace EventStore.Middleware.Module {
    public class EventSourcingModule : IModule {
        public void Register(IEventFlowOptions options) {
            options
                .ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(EventSourcingModule).Assembly)
                .AddDbContextProvider<EventSourcingDbContext, EventSourcingDbContextProvider>()
                .UseEntityFrameworkEventStore<EventSourcingDbContext>()
                .UseEntityFrameworkSnapshotStore<EventSourcingDbContext>();
        }
    }
}
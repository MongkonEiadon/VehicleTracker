using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;

using VehicleTracker.Application;
using VehicleTracker.Application.CommandServices;
using VehicleTracker.Application.QueryServices;
using VehicleTracker.Infrastructure;

namespace Customer.ReadStore.Module {
    public class CustomerReadStoreModule : IModule {


        public void Register(IEventFlowOptions options) {

            options.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(CustomerReadStoreModule).Assembly)
                .AddDbContextProvider<CustomerContext, CustomerContextProvider>()
                .UseEntityFrameworkEventStore<CustomerContext>()
                .UseEntityFrameworkReadModel<CustomerReadModel, CustomerContext>()
                .RegisterServices(s => {

                    s.Register<ISearchableReadModelStore<CustomerReadModel>, EfSearchableReadStore<CustomerReadModel, CustomerContext>>();
                });
        }
    }
}
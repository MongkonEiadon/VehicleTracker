using System;
using System.Collections.Generic;
using System.Text;
using EventFlow;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;

namespace Vehicle.ReadStore.Extensions
{
    public static class EventFlowExtensions
    {
        public static IEventFlowOptions AddVehicleReadStore(this IEventFlowOptions options)
        {
            options
                .ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .UseEntityFrameworkEventStore<VehicleContext>()
                .UseEntityFrameworkReadModel<VehicleReadModel, VehicleContext>();

            return options;
        }
    }
}

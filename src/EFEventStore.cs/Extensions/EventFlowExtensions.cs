using System;
using System.Collections.Generic;
using System.Text;
using EventFlow;
using EventFlow.EntityFramework.Extensions;

namespace EFEventStore.Extensions
{
    public static class EventFlowExtensions
    {
        public static IEventFlowOptions AddEntityFrameworkEventSourcing(this IEventFlowOptions options)
        {
            return options
                .UseEntityFrameworkEventStore<EventSourcingDbContext>();
        }
    }
}

using System.Collections.Generic;

namespace VehicleTracker.Domain.Infrastructure
{
    public abstract class MiddlewareConfiguration
    {
        public abstract MiddlewareConfiguration Create(IDictionary<string, string> configurations);

        public string EventDbConnection { get; protected set; }
    }
}
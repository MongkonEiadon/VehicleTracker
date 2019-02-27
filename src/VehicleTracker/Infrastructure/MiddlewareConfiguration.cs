using System.Collections.Generic;

namespace VehicleTracker.Infrastructure
{
    public abstract class MiddlewareConfiguration
    {
        public abstract MiddlewareConfiguration Create(IDictionary<string, string> configurations);

        public string EventDbConnection { get; protected set; }
        public string DbConnection { get; protected set; }
    }
}
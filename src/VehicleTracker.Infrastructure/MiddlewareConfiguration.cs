using System.Collections.Generic;

namespace VehicleTracker.Infrastructure {
    public abstract class MiddlewareConfiguration {
        public string EventDbConnection { get; protected set; }
        public string DbConnection { get; protected set; }

        public string DistributedCache { get; private set; }

        public abstract MiddlewareConfiguration Create(IDictionary<string, string> configurations);
    }
}
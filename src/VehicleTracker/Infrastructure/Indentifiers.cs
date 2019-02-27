using System;
using System.Text;

namespace VehicleTracker.Infrastructure
{
    public sealed class Identifiers
    {
        public const string VehicleServiceName = "vehicle";
        public const string TrackingServiceName = "tracking";
        public const string CustomerServiceName = "customer";

        public const string EventDbConnection = "ES_CONNECTION";
        public const string DbConnection = "DB_CONNECTION";
    }
}

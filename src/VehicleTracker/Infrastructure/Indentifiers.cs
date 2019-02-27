using System;
using System.Text;

namespace VehicleTracker.Infrastructure
{
    public sealed class Identifiers
    {
        public const string VehicleServiceName = "vehicle";
        public const string TrackingServiceName = "tracking";
        public const string CustomerServiceName = "customer";

        public const string EventDbConnection = "es_connection";
        public const string DbConnection = "db_connection";
    }
}

using System;
using System.Text;

namespace VehicleTracker.Domain.Infrastructure
{
    public sealed class Identifiers
    {
        public const string VehicleServiceName = "vehicle";
        public const string TrackingServiceName = "tracking";
        public const string CustomerServiceName = "customer";

        public const string EventDbConnection = "event_db_connection";
    }
}

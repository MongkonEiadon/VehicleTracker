using EventFlow.Aggregates;

namespace VehicleTracker.Business.VehicleDomain.Events {

    public class LocationUpdatedEvent : AggregateEvent<VehicleAggregate, VehicleId> {

        public double Latitude { get; }
        public double Longitude { get; }
        public double ZIndex { get; }

        public LocationUpdatedEvent(double latitude, double longitude, double zindex) {
            Latitude = latitude;
            Longitude = longitude;
            ZIndex = zindex;
        }

    }

}
using System;

using EventFlow.Aggregates;

namespace Domain.Business.Vehicles.Events {

    public class LocationUpdatedEvent : AggregateEvent<VehicleAggregate, VehicleId> {

        public double Latitude { get; }
        public double Longitude { get; }
        public double ZIndex { get; }

        public DateTimeOffset TimeStamp { get; set; }

        public LocationUpdatedEvent(double latitude, double longitude, double zindex, DateTimeOffset timeStamp) {
            Latitude = latitude;
            Longitude = longitude;
            ZIndex = zindex;
            TimeStamp = timeStamp;
        }

    }

}
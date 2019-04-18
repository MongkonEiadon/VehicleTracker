using System;

using EventFlow.Entities;
using EventFlow.ValueObjects;

namespace Domain.Business.Vehicles {
    public class VehicleEntity : Entity<VehicleId> {
        public VehicleEntity(VehicleId id) : base(id) {
        }

        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
    }

    public class LocationEntity {

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Zindex { get; set; }
        public DateTimeOffset TimeStamp { get; set; }


    }

}
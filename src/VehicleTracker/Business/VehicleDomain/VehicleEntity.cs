using EventFlow.Entities;

namespace VehicleTracker.Business.VehicleDomain {
    public class VehicleEntity : Entity<VehicleId> {
        public VehicleEntity(VehicleId id) : base(id) {
        }

        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
    }

    public class LocationEntity  {

        public double Latitude { get; }
        public double Longitude { get; }
        public double Zindex { get; }


        public LocationEntity(double latitude, double longitude, double zindex) {
            Latitude = latitude;
            Longitude = longitude;
            Zindex = zindex;
        }

    }
}
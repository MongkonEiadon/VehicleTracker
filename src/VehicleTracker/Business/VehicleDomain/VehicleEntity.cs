using EventFlow.Entities;

namespace VehicleTracker.Business.VehicleDomain {
    public class VehicleEntity : Entity<VehicleId> {
        public VehicleEntity(VehicleId id) : base(id) {
        }

        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
    }
}
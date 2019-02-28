using EventFlow.Core;

namespace VehicleTracker.Business.VehicleDomain {
    public class VehicleId : Identity<VehicleId> {
        public VehicleId(string value) : base(value) {
        }
    }
}
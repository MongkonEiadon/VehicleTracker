using EventFlow.Core;

namespace Domain.Business.Vehicles {
    public class VehicleId : Identity<VehicleId> {
        public VehicleId(string value) : base(value) {
        }
    }
}
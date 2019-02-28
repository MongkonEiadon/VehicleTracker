using EventFlow.Aggregates;

namespace VehicleTracker.Business.VehicleDomain {
    public class VehicleAggregate : AggregateRoot<VehicleAggregate, VehicleId> {
        public VehicleAggregate(VehicleId id) : base(id) {
        }
    }
}
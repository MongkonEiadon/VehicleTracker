using EventFlow.Aggregates;

namespace VehicleTracker.Business.VehicleDomain.Events {
    public class CreateVehicleEvent : AggregateEvent<VehicleAggregate, VehicleId> {
        public VehicleEntity Vehicle { get; }

        public CreateVehicleEvent(VehicleEntity vehicle) {
            Vehicle = vehicle;
        }
    }
}
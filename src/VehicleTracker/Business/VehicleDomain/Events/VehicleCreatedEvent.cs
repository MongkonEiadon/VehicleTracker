using EventFlow.Aggregates;

namespace VehicleTracker.Business.VehicleDomain.Events {
    public class VehicleCreatedEvent : AggregateEvent<VehicleAggregate, VehicleId> {
        public VehicleEntity Vehicle { get; }

        public VehicleCreatedEvent(VehicleEntity vehicle) {
            Vehicle = vehicle;
        }
    }

}
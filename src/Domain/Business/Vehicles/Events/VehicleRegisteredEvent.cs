using EventFlow.Aggregates;

namespace Domain.Business.Vehicles.Events {
    public class VehicleRegisteredEvent : AggregateEvent<VehicleAggregate, VehicleId> {
        public VehicleEntity Vehicle { get; }

        public VehicleRegisteredEvent(VehicleEntity vehicle) {
            Vehicle = vehicle;
        }
    }

}
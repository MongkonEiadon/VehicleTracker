using EventFlow.Aggregates;

namespace Domain.Business.Vehicles.Events {
    public class VehicleCreatedEvent : AggregateEvent<VehicleAggregate, VehicleId> {
        public VehicleEntity Vehicle { get; }

        public VehicleCreatedEvent(VehicleEntity vehicle) {
            Vehicle = vehicle;
        }
    }

}
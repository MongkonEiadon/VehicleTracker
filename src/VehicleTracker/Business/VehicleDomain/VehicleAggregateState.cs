using EventFlow.Aggregates;

using VehicleTracker.Business.VehicleDomain.Events;

namespace VehicleTracker.Business.VehicleDomain {

    public class VehicleAggregateState : AggregateState<VehicleAggregate, VehicleId, VehicleAggregateState>,
        IApply<VehicleCreatedEvent> {

        public VehicleEntity Entity { get; private set; }


        public void Apply(VehicleCreatedEvent aggregateCreatedEvent) {
            Entity = aggregateCreatedEvent.Vehicle;
        }
    }
}
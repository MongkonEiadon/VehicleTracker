using EventFlow.Aggregates;

using VehicleTracker.Business.VehicleDomain.Events;

namespace VehicleTracker.Business.VehicleDomain {

    public class VehicleAggregateState : AggregateState<VehicleAggregate, VehicleId, VehicleAggregateState>,
        IApply<CreateVehicleEvent> {

        public VehicleEntity Entity { get; private set; }


        public void Apply(CreateVehicleEvent aggregateEvent) {
            Entity = aggregateEvent.Vehicle;
        }
    }
}
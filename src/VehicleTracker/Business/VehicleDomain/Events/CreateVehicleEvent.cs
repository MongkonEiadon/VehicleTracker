using EventFlow.Aggregates;

namespace VehicleTracker.Business.VehicleDomain.Events {
    public class CreateVehicleEvent : AggregateEvent<VehicleAggregate, VehicleId> {
    }
}
using EventFlow.Aggregates;

namespace Vehicle7Tracker.Domain.Business.VehicleDomain
{
    public class VehicleAggregate : AggregateRoot<VehicleAggregate, VehicleId>
    {
        public VehicleAggregate(VehicleId id) : base(id)
        {
        }
    }
}
using EventFlow.Aggregates;

using VehicleTracker.Business.CustomerDomain.Events;

namespace VehicleTracker.Business.CustomerDomain {

    public class CustomerAggregateState : AggregateState<CustomerAggregate, CustomerId, CustomerAggregateState>,
        IApply<CustomerCreatedEvent> {

        public void Apply(CustomerCreatedEvent aggregateEvent) {
        }

    }

}
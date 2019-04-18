using Domain.Business.Customers.Events;

using EventFlow.Aggregates;

namespace Domain.Business.Customers {

    public class CustomerAggregateState : AggregateState<CustomerAggregate, CustomerId, CustomerAggregateState>,
        IApply<CustomerCreatedEvent> {

        public void Apply(CustomerCreatedEvent aggregateEvent) {
        }

    }

}
using Domain.Business.Customers.Events;

using EventFlow.Aggregates;

namespace Domain.Business.Customers {

    public class CustomerAggregate : AggregateRoot<CustomerAggregate, CustomerId> {

        private readonly CustomerAggregateState _customerState = new CustomerAggregateState();

        public CustomerAggregate(CustomerId id) : base(id) {
            Register(_customerState);
        }

        #region [Emitter]

        public void CreateCustomer(CustomerEntity customer) {
            Emit(new CustomerCreatedEvent(customer));
        }

        #endregion
    }

}
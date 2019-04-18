using System;
using System.Collections.Generic;
using System.Text;

using EventFlow.Aggregates;

namespace Domain.Business.Customers.Events
{
    public class CustomerCreatedEvent : AggregateEvent<CustomerAggregate, CustomerId> {

        public CustomerEntity Customer { get; }

        public CustomerCreatedEvent(CustomerEntity customer) {
            Customer = customer;
        }

    }
}

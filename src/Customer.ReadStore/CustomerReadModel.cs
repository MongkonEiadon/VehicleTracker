using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EventFlow.Aggregates;
using EventFlow.ReadStores;
using VehicleTracker.Business.CustomerDomain;
using VehicleTracker.Business.CustomerDomain.Events;

namespace Customer.ReadStore {
    public class CustomerReadModel : IReadModel, 
        IAmReadModelFor<CustomerAggregate, CustomerId, CustomerCreatedEvent> {

        [Key] [Column("Id")] public virtual string AggregateId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTimeOffset? BirthDate { get; set; }
        public virtual string Country { get; set; }

        public CustomerEntity ToCustomer() {
            return new CustomerEntity(CustomerId.With(AggregateId)) {
                BirthDate = BirthDate,
                Country = Country,
                Email = Email,
                Mobile = Mobile,
                Name = Name
            };
        }

        public void Apply(IReadModelContext context,
            IDomainEvent<CustomerAggregate, CustomerId, CustomerCreatedEvent> domainEvent) {

            var customer = domainEvent.AggregateEvent.Customer;

            AggregateId = domainEvent.AggregateIdentity.ToString();
            Name = customer.Name;
            Country = customer.Country;
            BirthDate = customer.BirthDate;
            Email = customer.Email;
            Mobile = customer.Mobile;
        }

    }
}
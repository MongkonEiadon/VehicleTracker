using System;
using System.Collections.Generic;

using Domain.Business.Vehicles;

using EventFlow.Entities;

namespace Domain.Business.Customers {
    public class CustomerEntity : Entity<CustomerId> {
        public CustomerEntity(CustomerId id) : base(id) {
        }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public string Country { get; set; }
        public virtual HashSet<VehicleEntity> Vehicles { get; set; }
    }
}
using System;
using System.Collections.Generic;

using EventFlow.Entities;

using VehicleTracker.Business.VehicleDomain;

namespace VehicleTracker.Business.CustomerDomain {
    public class Customer : Entity<CustomerId> {
        public Customer(CustomerId id) : base(id) {
        }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public virtual HashSet<VehicleEntity> Vehicles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Entities;
using Vehicle7Tracker.Domain.Business.VehicleDomain;

namespace Vehicle7Tracker.Domain.Business.CustomerDomain
{
    public class Customer : Entity<CustomerId>
    {
        public Customer(CustomerId id) : base(id)
        {
        }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public virtual HashSet<Vehicle> Vehicles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Entities;
using VehicleTracker.Domain.Business.VehicleDomain;

namespace VehicleTracker.Domain.Business.CustomerDomain
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

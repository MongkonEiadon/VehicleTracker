using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Entities;

namespace VehicleTracker.Business.VehicleDomain
{
    public class VehicleModel : Entity<VehicleId>
    {
        public VehicleModel(VehicleId id) : base(id)
        {
        }

        public string LicensePlateNumber { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
    }
}

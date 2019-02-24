using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventFlow.ReadStores;
using Vehicle7Tracker.Domain.Business.VehicleDomain;

using VehicleDomain = Vehicle7Tracker.Domain.Business.VehicleDomain.Vehicle;

namespace Vehicle.ReadStore
{
    public class VehicleReadModel : IReadModel
    {
        [Key] [Column("VehicleId")]
        public virtual string AggregateId { get; set; }
        public virtual string LicensePlateNumber { get; set; }
        public virtual string Model { get; set; }
        public virtual string Country { get; set; }

        public VehicleDomain ToVehicle()
        {
            return new VehicleDomain(VehicleId.With(AggregateId))
            {
                Country = Country,
                LicensePlateNumber = LicensePlateNumber,
                Model = Model
            };
        }

    }
}

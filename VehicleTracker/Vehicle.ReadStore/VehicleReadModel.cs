using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Vehicle7Tracker.Domain.Business.VehicleDomain;
using Vehicle7Tracker.Domain.Business.VehicleDomain.Events;
using VehicleDomain = Vehicle7Tracker.Domain.Business.VehicleDomain.Vehicle;

namespace Vehicle.ReadStore
{
    public class VehicleReadModel : IReadModel,
        IAmReadModelFor<VehicleAggregate, VehicleId, CreateVehicleEvent>
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

        public void Apply(IReadModelContext context, 
            IDomainEvent<VehicleAggregate, VehicleId, CreateVehicleEvent> domainEvent)
        {

        }
    }
}

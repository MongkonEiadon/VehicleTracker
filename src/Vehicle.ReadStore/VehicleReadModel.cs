using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using VehicleTracker.Business.VehicleDomain;
using VehicleTracker.Business.VehicleDomain.Events;

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

        public VehicleModel ToVehicle()
        {
            return new VehicleModel(VehicleId.With(AggregateId))
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

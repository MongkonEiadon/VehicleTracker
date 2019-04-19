using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Domain.Business.Vehicles;
using Domain.Business.Vehicles.Events;

using EventFlow.Aggregates;
using EventFlow.ReadStores;


namespace Vehicles.ReadStore {
    public class VehicleReadModel : IReadModel,
        IAmReadModelFor<VehicleAggregate, VehicleId, VehicleRegisterCompleted> {
        [Key] [Column("Id")] public virtual string AggregateId { get; set; }

        public virtual string LicensePlateNumber { get; set; }
        public virtual string Model { get; set; }
        public virtual string Country { get; set; }

        public void Apply(IReadModelContext context,
            IDomainEvent<VehicleAggregate, VehicleId, VehicleRegisterCompleted> domainEvent) {

            var _vehicle = domainEvent.AggregateEvent.Enitity;

            AggregateId = domainEvent.AggregateIdentity.ToString();
            LicensePlateNumber = _vehicle.LicensePlateNumber;
            Model = _vehicle.Model;
            Country = _vehicle.Country;
        }

        public VehicleEntity ToVehicle() {
            return new VehicleEntity(VehicleId.With(AggregateId)) {
                Country = Country,
                LicensePlateNumber = LicensePlateNumber,
                Model = Model
            };
        }
    }

}
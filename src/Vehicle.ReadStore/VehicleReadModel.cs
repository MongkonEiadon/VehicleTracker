using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EventFlow.Aggregates;
using EventFlow.ReadStores;

using VehicleTracker.Business.VehicleDomain;
using VehicleTracker.Business.VehicleDomain.Events;

namespace Vehicle.ReadStore {
    public class VehicleReadModel : IReadModel,
        IAmReadModelFor<VehicleAggregate, VehicleId, CreateVehicleEvent> {
        [Key] [Column("VehicleId")] public virtual string AggregateId { get; set; }

        public virtual string LicensePlateNumber { get; set; }
        public virtual string Model { get; set; }
        public virtual string Country { get; set; }

        public void Apply(IReadModelContext context,
            IDomainEvent<VehicleAggregate, VehicleId, CreateVehicleEvent> domainEvent) {

            var _vehicle = domainEvent.AggregateEvent.Vehicle;

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
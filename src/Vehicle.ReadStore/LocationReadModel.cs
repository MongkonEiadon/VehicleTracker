using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EventFlow.Aggregates;
using EventFlow.ReadStores;

using VehicleTracker.Business.VehicleDomain;
using VehicleTracker.Business.VehicleDomain.Events;

namespace Vehicle.ReadStore {

    public class LocationReadModel : IReadModel ,
        IAmReadModelFor<VehicleAggregate, VehicleId, LocationUpdatedEvent>
    {


        [Key] [Column("AggregateId")] public virtual string AggregateId { get; set; }

        public virtual DateTimeOffset TimeStamp { get; set; }

        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual double ZIndex { get; set; }


        public void Apply(IReadModelContext context, IDomainEvent<VehicleAggregate, VehicleId, LocationUpdatedEvent> domainEvent) {

            AggregateId = domainEvent.AggregateIdentity.ToString();
            Latitude = domainEvent.AggregateEvent.Latitude;
            Longitude = domainEvent.AggregateEvent.Longitude;
            ZIndex = domainEvent.AggregateEvent.ZIndex;
            TimeStamp = domainEvent.Timestamp;
        }

    }

}
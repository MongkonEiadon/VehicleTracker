using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using EventFlow.Aggregates;

using VehicleTracker.Business.VehicleDomain.Events;

namespace VehicleTracker.Business.VehicleDomain {

    public class VehicleAggregateState : AggregateState<VehicleAggregate, VehicleId, VehicleAggregateState>,
        IApply<VehicleCreatedEvent>,
        IApply<LocationUpdatedEvent> {

        public VehicleEntity Entity { get; private set; }

        public ICollection<LocationEntity> Locations { get; set; } = new Collection<LocationEntity>();


        public void Apply(VehicleCreatedEvent aggregateCreatedEvent) {
            Entity = aggregateCreatedEvent.Vehicle;
        }

        public void Apply(LocationUpdatedEvent e) {
            Locations.Add(new LocationEntity(e.Latitude, e.Longitude, e.ZIndex));
        }

    }
}
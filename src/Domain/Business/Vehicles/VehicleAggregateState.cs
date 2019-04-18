using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Domain.Business.Vehicles.Events;

using EventFlow.Aggregates;

namespace Domain.Business.Vehicles {

    [Serializable]
    public class VehicleAggregateState : AggregateState<VehicleAggregate, VehicleId, VehicleAggregateState>,
        IApply<VehicleCreatedEvent>,
        IApply<LocationUpdatedEvent> {

        public VehicleEntity Entity { get; set; }

        public List<LocationEntity> Locations { get; set; } = new List<LocationEntity>();


        public void Apply(VehicleCreatedEvent aggregateCreatedEvent) {
            Entity = aggregateCreatedEvent.Vehicle;
        }

        public void Apply(LocationUpdatedEvent e) {
            Locations.Add(new LocationEntity() {
                Longitude = e.Longitude,
                Latitude = e.Latitude,
                Zindex = e.ZIndex,
                TimeStamp = e.TimeStamp
            });
        }


        public void LoadSnapshot(VehicleSnapshot snapshot) {
            Entity = snapshot.VehicleState.Entity;
            Locations.AddRange(snapshot.VehicleState.Locations);
        }
    }
}
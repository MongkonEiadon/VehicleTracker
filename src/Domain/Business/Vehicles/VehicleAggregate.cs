using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Domain.Business.Vehicles.Events;

using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Snapshots;
using EventFlow.Snapshots.Strategies;

namespace Domain.Business.Vehicles {

    public class VehicleAggregate : SnapshotAggregateRoot<VehicleAggregate, VehicleId, VehicleSnapshot>{

        private readonly VehicleAggregateState _vehicleAggregateState = new VehicleAggregateState();

        public VehicleAggregate(VehicleId id) : base(id, SnapshotEveryFewVersionsStrategy.With(10)) {
            Register(_vehicleAggregateState);
        }


        #region MyRegion

        public IExecutionResult RegisterVehicle(string licensePlate, string model, string country) {

            Emit(new VehicleRegisteredEvent(new VehicleEntity(this.Id) {
                Country = country,
                LicensePlateNumber = licensePlate,
                Model = model
            }));

            return ExecutionResult.Success();
        }

        public void RegisterComplete(VehicleEntity entity) {

            Emit(new VehicleRegisterCompleted(entity));
        }

        public IExecutionResult UpdateVehicleLocation(double latitude, double longitude, double zIndex) {
            Emit(new LocationUpdatedEvent(latitude, longitude, zIndex, DateTimeOffset.Now));
            return ExecutionResult.Success();
        }


        public IEnumerable<LocationEntity> GetLocationHistory() {

            return _vehicleAggregateState.Locations;
        }

        

        #endregion

        protected override Task<VehicleSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken) {
            return Task.FromResult(new VehicleSnapshot(_vehicleAggregateState));
        }

        protected override Task LoadSnapshotAsync(VehicleSnapshot snapshot, ISnapshotMetadata metadata, CancellationToken cancellationToken) {

            _vehicleAggregateState.LoadSnapshot(snapshot);
            return Task.CompletedTask;
        }

    }
}
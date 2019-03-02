using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

using VehicleTracker.Business.VehicleDomain.Events;

namespace VehicleTracker.Business.VehicleDomain {
    public class VehicleAggregate : AggregateRoot<VehicleAggregate, VehicleId>{

        private readonly VehicleAggregateState _vehicleAggregateState = new VehicleAggregateState();

        public VehicleAggregate(VehicleId id) : base(id) {
            Register(_vehicleAggregateState);
        }


        #region MyRegion

        public IExecutionResult CreateVehicle(VehicleEntity vehicle) {
            Emit(new VehicleCreatedEvent(vehicle));
            return ExecutionResult.Success();
        }

        public IExecutionResult UpdateVehicleLocation(double latitude, double longitude, double zIndex) {
            Emit(new LocationUpdatedEvent(latitude, longitude, zIndex));
            return ExecutionResult.Success();
        }

        

        #endregion
    }
}
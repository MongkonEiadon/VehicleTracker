using EventFlow.Aggregates;

using VehicleTracker.Business.VehicleDomain.Events;

namespace VehicleTracker.Business.VehicleDomain {
    public class VehicleAggregate : AggregateRoot<VehicleAggregate, VehicleId>{

        private readonly VehicleAggregateState _vehicleAggregateState = new VehicleAggregateState();

        public VehicleAggregate(VehicleId id) : base(id) {
            Register(_vehicleAggregateState);
        }


        #region MyRegion

        public void CreateVehicle(VehicleEntity vehicle) {
            Emit(new VehicleCreatedEvent(vehicle));
        }

        #endregion
    }
}
using EventFlow.Aggregates;

namespace Domain.Business.Vehicles.Events {

    public class VehicleRegisterCompleted : AggregateEvent<VehicleAggregate, VehicleId> {

        public VehicleEntity Enitity { get; }

        public VehicleRegisterCompleted(VehicleEntity enitity) {
            Enitity = enitity;
        }

    }

}
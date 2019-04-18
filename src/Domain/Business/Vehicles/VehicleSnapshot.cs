using System.Collections.Generic;
using System.Linq;

using EventFlow.Snapshots;

namespace Domain.Business.Vehicles {

    public class VehicleSnapshot :  ISnapshot {

        public VehicleAggregateState VehicleState { get; }

        public VehicleSnapshot(VehicleAggregateState vehicleState) {
            VehicleState = vehicleState;
        }

    }

}
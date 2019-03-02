using System.Collections.Generic;
using System.Linq;

using EventFlow.Snapshots;

namespace VehicleTracker.Business.VehicleDomain {

    public class VehicleSnapshot :  ISnapshot {

        public VehicleAggregateState VehicleState { get; }

        public VehicleSnapshot(VehicleAggregateState vehicleState) {
            VehicleState = vehicleState;
        }

    }

}
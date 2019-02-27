using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Aggregates;

namespace VehicleTracker.Business.VehicleDomain.Events
{
    public class CreateVehicleEvent : AggregateEvent<VehicleAggregate, VehicleId>
    {
    }
}

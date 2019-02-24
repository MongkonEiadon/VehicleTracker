using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Aggregates;

namespace Vehicle7Tracker.Domain.Business.VehicleDomain.Events
{
    public class CreateVehicleEvent : AggregateEvent<VehicleAggregate, VehicleId>
    {
    }
}

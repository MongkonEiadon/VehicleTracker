using System;
using System.Collections.Generic;
using System.Text;
using EventFlow.Core;

namespace VehicleTracker.Business.TrackingDomain
{
    public class TrackingId : Identity<TrackingId>
    {
        public TrackingId(string value) : base(value)
        {
        }
    }
}
